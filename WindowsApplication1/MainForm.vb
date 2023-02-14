Imports MeshGeneration.Models
Imports MeshGeneration.AppSettings
Imports MeshGeneration.Logic
Imports MeshGeneration.Data
Imports OpenTK.Graphics.OpenGL

Public Class MainForm

#Region "fields"

    Private settings As ISettings
    Private data As IDataAccessService
    Private farfield As New Calcdomain

#End Region

#Region "Constructor"

    Public Sub New(ByVal settings As ISettings, ByVal data As IDataAccessService)

        Me.settings = settings
        Me.data = data

        InitializeComponent()

    End Sub
#End Region

#Region "form events"

    Private Sub MainForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'initialize settings and read from settings.xml file
        settings.CreateSettings()

        'Initial settings copied to public properties that will persist through the class
        farfield.Height = settings.Height
        farfield.Width = settings.Width
        farfield.Scale = settings.Scale
        farfield.Layers = settings.Layers
        farfield.Cellheight = settings.Cellheight
        farfield.Cellfactor = settings.Cellfactor
        farfield.Nodetrade = settings.Nodetrade
        farfield.Expansionpower = settings.Expansionpower
        farfield.Offset = settings.Offset
        farfield.Smoothingcycles = settings.Smoothingcycles
        farfield.Filename = settings.Filename

        'populate text boxes with farfield settings
        TextBoxHeight.Text = farfield.Height
        TextBoxWidth.Text = farfield.Width
        TextBoxScale.Text = farfield.Scale
        TextBoxLayers.Text = farfield.Layers
        TextBoxCellHeight.Text = farfield.Cellheight
        TextBoxCellFactor.Text = farfield.Cellfactor
        TextBoxNodeTrade.Text = farfield.Nodetrade
        TextBoxExpansionPower.Text = farfield.Expansionpower
        TextBoxOffset.Text = farfield.Offset
        TextBoxSmoothingCycles.Text = farfield.Smoothingcycles
        TextBoxFileName.Text = farfield.Filename

        Me.WindowState = FormWindowState.Maximized

        GL.ClearColor(Color.White)

        GL.MatrixMode(MatrixMode.Modelview)
        GL.LoadIdentity()

        GL.Ortho(0, farfield.Width, 0, farfield.Height, -1, 1)
        GL.Viewport(0, 0, farfield.Width, farfield.Height)

    End Sub

    Private Sub MainForm_Paint(sender As System.Object, e As PaintEventArgs) Handles MyBase.Paint

        'Clear GPU buffers
        GL.Clear(ClearBufferMask.ColorBufferBit)
        GL.Clear(ClearBufferMask.DepthBufferBit)

        'Set size of Gl Control (used to display grid)
        GL.Viewport(0, 0, farfield.Width, farfield.Height)

        'Draw the Grid based on triangles
        Dim n1, n2, n3 As Integer
        Dim point(0 To 3) As Point 'instantiates a drawing object

        'UI layer dealing directly with the repository layer
        For Each triangle In Repository.Trianglelist

            n1 = triangle.V1
            n2 = triangle.V2
            n3 = triangle.V3

            With data.NodeV(n1).Single
                point(1) = New Point(.X, .Y)
            End With

            With data.NodeV(n2).Single
                point(2) = New Point(.X, .Y)
            End With

            With data.NodeV(n3).Single
                point(3) = New Point(.X, .Y)
            End With

            'This is old school OpenGl 1.0
            'Filled shapes
            'GL.Begin(PrimitiveType.Triangles)
            'GL.Color3(Color.Blue)
            'GL.Vertex2(point(1).X, point(1).Y)
            'GL.Color3(Color.White)
            'GL.Vertex2(point(2).X, point(2).Y)
            'GL.Color3(Color.Red)
            'GL.Vertex2(point(3).X, point(3).Y)
            'GL.End()

            'This is old school OpenGl 1.0
            'Wire frame
            GL.Begin(PrimitiveType.LineLoop)
            GL.Color3(Color.Black)
            GL.Vertex2(point(1).X, point(1).Y)
            GL.Vertex2(point(2).X, point(2).Y)
            GL.Vertex2(point(3).X, point(3).Y)
            GL.End()

        Next

        GlControl1.SwapBuffers()

    End Sub

    Private Sub MainForm_Closing(sender As System.Object, e As System.EventArgs) Handles MyBase.Closing
        'on closing the form update settings.xml

        settings.WriteSettings(farfield)

    End Sub

#End Region

#Region "functions"
    Private Function StatusMessage(s) As Integer
        'displays a status message in the form
        TextBoxStatus.Text = s
        TextBoxStatus.Refresh()
        Return 0
    End Function

    Private Sub EventCompletion()
        'initiates refresh of the form and repaint of the GL drawing control
        Me.Refresh()
        GlControl1.Invalidate()
        StatusMessage(Constants.MsgComplete)
    End Sub

    Private Sub UpdateFarfield()
        'pull in any changed farfield values from the form
        farfield.Height = TextBoxHeight.Text
        farfield.Width = TextBoxWidth.Text
        farfield.Scale = TextBoxScale.Text
        farfield.Layers = TextBoxLayers.Text
        farfield.Cellheight = TextBoxCellHeight.Text
        farfield.Cellfactor = TextBoxCellFactor.Text
        farfield.Nodetrade = TextBoxNodeTrade.Text
        farfield.Expansionpower = TextBoxExpansionPower.Text
        farfield.Offset = TextBoxOffset.Text
        farfield.Smoothingcycles = TextBoxSmoothingCycles.Text
        farfield.Filename = TextBoxFileName.Text
    End Sub

    Private Sub UpdateGLSize()
        'set the GL control size
        GlControl1.Width = farfield.Width
        GlControl1.Height = farfield.Height
    End Sub

#End Region

#Region "button events"
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Builds grid around an airfoil

        StatusMessage(Constants.MsgInitialize)

        'pull in any changed farfield values
        UpdateFarfield()

        'set window drawing size
        UpdateGLSize()

        StatusMessage(Constants.MsgConstruct)

        'call the logic layer - here we initiate the actual work of building the grid
        'the first line gets the object by type from the container
        Dim build As Build = Main.container.GetInstance(Of Build)()
        build.Logic(farfield)

        'disable the empty grid build button
        Button6.Enabled = False

        'Repaint
        EventCompletion()

    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Runs delaunay triangulation on grid

        StatusMessage(Constants.MsgDelaunay)

        'call the logic layer - here we initiate the grid optimization
        'the first line gets the object by type from the container
        Dim delaunayLogic As DelaunayLogic = Main.container.GetInstance(Of DelaunayLogic)()
        delaunayLogic.Logic()

        'Repaint
        EventCompletion()

    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'Refines existing grid

        StatusMessage(Constants.MsgDivide)

        'pull in any changed farfield values
        UpdateFarfield()

        'call the logic layer - here we initiate grid refining
        'the first line gets the object by type from the container
        Dim split As Split = Main.container.GetInstance(Of Split)()
        split.Logic(farfield)

        'Repaint
        EventCompletion()

    End Sub
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        'perform Laplace smoothing

        StatusMessage(Constants.MsgSmooth)

        'pull in any changed farfield values
        UpdateFarfield()

        'call the logic layer - here we initiate grid smoothing
        'the first line gets the object by type from the container
        Dim smooth As Smooth = Main.container.GetInstance(Of Smooth)()
        smooth.Logic(farfield)

        'Repaint
        EventCompletion()

    End Sub
    Private Sub OpenFileDialog1_FileOk(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        'Initiates load of airfoil data from selected file when OK button is clicked

        Dim strm As System.IO.Stream
        strm = OpenFileDialog1.OpenFile()
        TextBoxFileName.Text = OpenFileDialog1.FileName.ToString()
        If Not (strm Is Nothing) Then
            'insert additionalcode to process the file data here
            strm.Close()
            MessageBox.Show(Constants.MsgLoaded)
        End If

    End Sub
    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        'Runs the open file dialog

        OpenFileDialog1.Title = Constants.DialogTitle
        OpenFileDialog1.InitialDirectory = Constants.FileLocation
        OpenFileDialog1.ShowDialog()

    End Sub
    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        'Builds grid for an empty space with no airfoil present

        StatusMessage(Constants.MsgInitialize)

        'pull in any changed farfield values
        UpdateFarfield()

        'set window drawing size
        UpdateGLSize()

        'call the logic layer - here we do the actual work of building the empty grid
        'the first line gets the object by type from the container
        Dim emptySpace As EmptySpace = Main.container.GetInstance(Of EmptySpace)()
        emptySpace.Logic(farfield)

        'disable the airfoil build button
        Button1.Enabled = False

        'Repaint
        EventCompletion()

    End Sub
    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        'Redistributes nodes on edges of farfield

        StatusMessage(Constants.MsgRedistribute)

        'pull in any changed farfield values
        'UpdateFarfield()

        'call the logic layer - here we initiate redistru=ibution of the edge nodes
        'the first line gets the object by type from the container
        Dim redistribute As Redistribute = Main.container.GetInstance(Of Redistribute)()
        redistribute.Logic(farfield)

        'Repaint
        EventCompletion()

    End Sub
#End Region
End Class