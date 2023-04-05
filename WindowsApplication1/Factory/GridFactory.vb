Imports MeshGeneration.Models

Namespace Factories

    ''' <summary>
    ''' This factory is used to create the basic grid elements (nodes and triangles)
    ''' </summary>
    Public Class GridFactory : Implements IGridFactory

#Region "Constructor"

        Public Sub New()

        End Sub
#End Region

#Region "Simple Create/Update/Replace Methods"
        ''' <summary>
        ''' Add a new node which optionally lies on the boundary or airfoil surface
        ''' </summary>
        ''' <param name="this_id"></param>
        ''' <param name="this_x"></param>
        ''' <param name="this_y"></param>
        ''' <param name="this_surface"></param>
        ''' <param name="this_boundary"></param>
        Public Sub RequestNode(this_id As Integer, this_x As Double, this_y As Double, this_surface As Boolean, this_boundary As Boolean) Implements IGridFactory.RequestNode
            Dim newNode As Node = New Node(this_id, this_x, this_y, this_surface, this_boundary)
        End Sub

        ''' <summary>
        ''' Add a generic node which does not lie on the boundary or airfoil surface
        ''' </summary>
        ''' <param name="this_id"></param>
        ''' <param name="this_x"></param>
        ''' <param name="this_y"></param>
        Public Sub AddNode(this_id As Integer, this_x As Double, this_y As Double) Implements IGridFactory.AddNode
            Dim newNode As Node = New Node(this_id, this_x, this_y, False, False)
        End Sub

        ''' <summary>
        ''' Add a node on the boundary of the farfield
        ''' </summary>
        ''' <param name="this_id"></param>
        ''' <param name="this_x"></param>
        ''' <param name="this_y"></param>
        Public Sub AddBoundaryNode(this_id As Integer, this_x As Double, this_y As Double) Implements IGridFactory.AddBoundaryNode
            Dim newNode As Node = New Node(this_id, this_x, this_y, False, True)
        End Sub

        ''' <summary>
        ''' Add a node on the surface of the airfoil
        ''' </summary>
        ''' <param name="this_id"></param>
        ''' <param name="this_x"></param>
        ''' <param name="this_y"></param>
        Public Sub AddAirfoilNode(this_id As Integer, this_x As Double, this_y As Double) Implements IGridFactory.AddAirfoilNode
            Dim newNode As Node = New Node(this_id, this_x, this_y, True, False)
        End Sub

        ''' <summary>
        ''' Add a new triangle
        ''' </summary>
        ''' <param name="this_id"></param>
        ''' <param name="this_n1"></param>
        ''' <param name="this_n2"></param>
        ''' <param name="this_n3"></param>
        ''' <param name="this_s1"></param>
        ''' <param name="this_s2"></param>
        ''' <param name="this_s3"></param>
        Public Sub AddTriangle(this_id As Integer, this_n1 As Integer, this_n2 As Integer, this_n3 As Integer, Optional this_s1 As String = Nothing, Optional this_s2 As String = Nothing, Optional this_s3 As String = Nothing) Implements IGridFactory.AddTriangle
            Dim newTriangle As Triangle = New Triangle(this_id, this_n1, this_n2, this_n3, this_s1, this_s2, this_s3)
        End Sub

        ''' <summary>
        ''' Replace an existing grid triangle with a new one
        ''' To avoid confusion, note that t is the index, not the Id
        ''' </summary>
        ''' <param name="t">Index</param>
        ''' <param name="newId"></param>
        ''' <param name="this_n1"></param>
        ''' <param name="this_n2"></param>
        ''' <param name="this_n3"></param>
        ''' <param name="this_s1"></param>
        ''' <param name="this_s2"></param>
        ''' <param name="this_s3"></param>
        Public Sub ReplaceTriangle(t As Integer, newId As Integer, this_n1 As Integer, this_n2 As Integer, this_n3 As Integer, Optional this_s1 As String = Nothing, Optional this_s2 As String = Nothing, Optional this_s3 As String = Nothing) Implements IGridFactory.ReplaceTriangle
            Dim replacetriangle As Triangle = New ReplacementTriangle(t, newId, this_n1, this_n2, this_n3, this_s1, this_s2, this_s3)
        End Sub

        ''' <summary>
        ''' Update the properties of an existing grid triangle
        ''' To avoid confusion, note that t is the index, not the Id
        ''' </summary>
        ''' <param name="t">Index</param>
        ''' <param name="this_n1"></param>
        ''' <param name="this_n2"></param>
        ''' <param name="this_n3"></param>
        ''' <param name="this_s1"></param>
        ''' <param name="this_s2"></param>
        ''' <param name="this_s3"></param>
        Public Sub UpdateTriangle(t As Integer, this_n1 As Integer, this_n2 As Integer, this_n3 As Integer, Optional this_s1 As String = Nothing, Optional this_s2 As String = Nothing, Optional this_s3 As String = Nothing) Implements IGridFactory.UpdateTriangle
            Dim updateTriangle As Triangle = New UpdateTriangle(t, this_n1, this_n2, this_n3, this_s1, this_s2, this_s3)
        End Sub
#End Region

#Region "Empty Space Build Methods"

        ''' <summary>
        ''' Adds first set of nodes to an empty farfield when no airfoil is present
        ''' </summary>
        ''' <param name="farfield"></param>
        Public Sub SetupEmptySpaceBoundary(farfield As Object) Implements IGridFactory.SetupEmptySpaceBoundary
            'Used for empty space setup

            AddCornerNodes(farfield)
            AddMidBoundaryNodes(farfield)

        End Sub

        ''' <summary>
        ''' Adds corner nodes to an empty farfield when no airfoil is present
        ''' </summary>
        ''' <param name="farfield"></param>
        Public Sub AddCornerNodes(farfield As Object) Implements IGridFactory.AddCornerNodes

            AddBoundaryNode(0, 0, 0)
            AddBoundaryNode(1, 0, farfield.height)
            AddBoundaryNode(2, farfield.width, farfield.height)
            AddBoundaryNode(3, farfield.width, 0)

        End Sub

        ''' <summary>
        ''' Add mid boundary nodes to an empty farfield when no airfoil is present
        ''' </summary>
        ''' <param name="farfield"></param>
        Public Sub AddMidBoundaryNodes(farfield As Object) Implements IGridFactory.AddMidBoundaryNodes

            AddBoundaryNode(4, 0, farfield.height / 2)
            AddBoundaryNode(5, farfield.width, farfield.height / 2)

        End Sub

        ''' <summary>
        ''' Creates the first set of grid triangles in a mesh when no airfoil is present
        ''' </summary>
        Public Sub SetupEmptySpaceTriangles() Implements IGridFactory.SetupEmptySpaceTriangles
            'Setup triangles for empty space
            'the vertex ids must correspond to specific node ids

            AddTriangle(0, 0, 4, 3, Nothing, "boundary", "boundary")
            AddTriangle(1, 4, 1, 3, Nothing, Nothing, "boundary")
            AddTriangle(2, 1, 5, 3, "boundary", Nothing, Nothing)
            AddTriangle(3, 1, 2, 5, "boundary", Nothing, "boundary")

        End Sub
#End Region
    End Class
End Namespace