Imports MeshGeneration.Models
Imports MeshGeneration.AppSettings
Imports MeshGeneration.Logic
Imports MeshGeneration.Data
Imports OpenTK.Graphics.OpenGL

Public Class MainForm

#Region "fields"

    Private ReadOnly settings As ISettings
    Private ReadOnly data As IDataAccessService

    Private ReadOnly farfield As New Farfield

#End Region

#Region "Constructor"

    Public Sub New(settings As ISettings, data As IDataAccessService)

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

        Dim ToolTip1 = New System.Windows.Forms.ToolTip()
        Dim ToolTip2 = New System.Windows.Forms.ToolTip()
        Dim ToolTip3 = New System.Windows.Forms.ToolTip()
        Dim ToolTip4 = New System.Windows.Forms.ToolTip()
        Dim ToolTip5 = New System.Windows.Forms.ToolTip()
        Dim ToolTip6 = New System.Windows.Forms.ToolTip()
        Dim ToolTip7 = New System.Windows.Forms.ToolTip()
        Dim ToolTip8 = New System.Windows.Forms.ToolTip()
        Dim ToolTip9 = New System.Windows.Forms.ToolTip()
        Dim ToolTip10 = New System.Windows.Forms.ToolTip()

        ToolTip1.SetToolTip(Me.TextBoxWidth, "The width of the farfield in pixels")
        ToolTip2.SetToolTip(Me.TextBoxHeight, "The height of the farfield in pixels")
        ToolTip3.SetToolTip(Me.TextBoxScale, "The amount by which to scale the airfoil size")
        ToolTip4.SetToolTip(Me.TextBoxLayers, "The number of layers of triangles to create around the airfoil in the first pass")
        ToolTip5.SetToolTip(Me.TextBoxCellHeight, "The initial triangle layer height")
        ToolTip6.SetToolTip(Me.TextBoxCellFactor, "A factor used to fine-tune the layer height")
        ToolTip7.SetToolTip(Me.TextBoxExpansionPower, "The amount by which to increase the height of subsequent layers: height = cellheight*cellfactor*layernumber^expansionpower")
        ToolTip8.SetToolTip(Me.TextBoxNodeTrade, "Number of boundary nodes to reallocate between vertical/horizontal edges")
        ToolTip9.SetToolTip(Me.TextBoxOffset, "Number of nodes to offsetp between layers - reduces the initial grid distortion")
        ToolTip10.SetToolTip(Me.TextBoxSmoothingCycles, "Number of iterations of the smoothing routine")

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

#Region "utilities"

    Private Sub EventCompletion()
        'initiates refresh of the form and repaint of the GL drawing control
        Me.Refresh()
        GlControl1.Invalidate()
        StatusMessage(Constants.MSGCOMPLETE)
    End Sub

    Private Sub UpdateFarfield()
        'Obtain form data and perform a simple validation. Default to saved settings in 
        'case of error
        farfield.Height = ValidateEntry(Of Integer)(TextBoxHeight, settings.Height)
        farfield.Width = ValidateEntry(Of Integer)(TextBoxWidth, settings.Width)
        farfield.Scale = ValidateEntry(Of Short)(TextBoxScale, settings.Scale)
        farfield.Layers = ValidateEntry(Of Short)(TextBoxLayers, settings.Layers)
        farfield.Cellheight = ValidateEntry(Of Short)(TextBoxCellHeight, settings.Cellheight)
        farfield.Cellfactor = ValidateEntry(Of Double)(TextBoxCellFactor, settings.Cellfactor)
        farfield.Nodetrade = ValidateEntry(Of Short)(TextBoxNodeTrade, settings.Nodetrade)
        farfield.Expansionpower = ValidateEntry(Of Double)(TextBoxExpansionPower, settings.Expansionpower)
        farfield.Offset = ValidateEntry(Of Short)(TextBoxOffset, settings.Offset)
        farfield.Smoothingcycles = ValidateEntry(Of Short)(TextBoxSmoothingCycles, settings.Smoothingcycles)
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

        StatusMessage(Constants.MSGINITIALIZE)

        'pull in any changed farfield values
        UpdateFarfield()

        'set window drawing size
        UpdateGLSize()

        StatusMessage(Constants.MSGCONSTRUCT)

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

        StatusMessage(Constants.MSGDELAUNAY)

        'call the logic layer - here we initiate the grid optimization
        'the first line gets the object by type from the container
        Dim delaunayLogic As DelaunayLogic = Main.container.GetInstance(Of DelaunayLogic)()
        delaunayLogic.Logic()

        'Repaint
        EventCompletion()

    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'Refines existing grid

        StatusMessage(Constants.MSGDIVIDE)

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

        StatusMessage(Constants.MSGSMOOTH)

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
            MessageBox.Show(Constants.MSGLOADED)
        End If

    End Sub
    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        'Runs the open file dialog

        OpenFileDialog1.Title = Constants.DIALOGTITLE
        OpenFileDialog1.InitialDirectory = Constants.FILELOCATION
        OpenFileDialog1.ShowDialog()

    End Sub
    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        'Builds grid for an empty space with no airfoil present

        StatusMessage(Constants.MSGINITIALIZE)

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

        StatusMessage(Constants.MSGREDISTRIBUTE)

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

#Region "functions"

    Private Function StatusMessage(s) As Integer
        'displays a status message in the form
        TextBoxStatus.Text = s
        TextBoxStatus.Refresh()
        Return 0
    End Function

    Private Function ValidateEntry(Of T)(ByRef value As Object, ByRef fallback As Object) As T
        'On success return the value converted to specified type. On failure return the fallback value and highlight
        'the box in yellow.
        Try
            value.BackColor = Color.White
            Return CType(value.Text, T)
        Catch ex As Exception
            value.BackColor = Color.Yellow
            Return fallback
        End Try
    End Function

#End Region
End Class