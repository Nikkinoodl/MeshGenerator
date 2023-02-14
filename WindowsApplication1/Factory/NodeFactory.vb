Imports MeshGeneration.Data
Imports MeshGeneration.Models

Public Class NodeFactory
    Inherits BaseNodeFactory
    'This factory is used to create the basic grid elements (nodes and triangles)

#Region "Fields"

    '    Private data As IDataAccessService

#End Region

#Region "Constructor"

    '    Public Sub New(ByVal data As IDataAccessService)

    '   Me.data = data

    '   End Sub

#End Region

#Region "Simple Create/Update/Replace Methods"

    Public Overrides Sub RequestNode(ByVal this_id As Integer, ByVal this_x As Double, ByVal this_y As Double, ByVal this_surface As Boolean, ByVal this_boundary As Boolean)
        'When specific type not requested. Constructor overload in the model takes care of it.
        Dim newNode As INode = New Node(this_id, this_x, this_y, this_surface, this_boundary)
    End Sub

    Public Overrides Sub AddNode(ByVal this_id As Integer, ByVal this_x As Double, ByVal this_y As Double)
        Dim newNode As INode = New Node(this_id, this_x, this_y, False, False)
    End Sub

    Public Overrides Sub AddBoundaryNode(ByVal this_id As Integer, ByVal this_x As Double, ByVal this_y As Double)
        Dim newNode As INode = New Node(this_id, this_x, this_y, False, True)
    End Sub

    Public Overrides Sub AddAirfoilNode(ByVal this_id As Integer, ByVal this_x As Double, ByVal this_y As Double)
        Dim newNode As INode = New Node(this_id, this_x, this_y, True, False)
    End Sub

    Public Overrides Sub AddTriangle(ByVal this_id As Integer, ByVal this_n1 As Integer, ByVal this_n2 As Integer, ByVal this_n3 As Integer, ByVal Optional this_s1 As String = Nothing, ByVal Optional this_s2 As String = Nothing, ByVal Optional this_s3 As String = Nothing)
        Dim newTriangle As ITriangle = New Triangle(this_id, this_n1, this_n2, this_n3, this_s1, this_s2, this_s3)
    End Sub

    'Triangles are replaced with other triangles
    Public Overrides Sub ReplaceTriangle(ByVal t As Integer, ByVal newId As Integer, ByVal this_n1 As Integer, ByVal this_n2 As Integer, ByVal this_n3 As Integer, ByVal Optional this_s1 As String = Nothing, ByVal Optional this_s2 As String = Nothing, ByVal Optional this_s3 As String = Nothing)
        Dim replacetriangle As ITriangle = New ReplacementTriangle(t, newId, this_n1, this_n2, this_n3, this_s1, this_s2, this_s3)
    End Sub

    Public Overrides Sub UpdateTriangle(ByVal this_t As Integer, ByVal this_n1 As Integer, ByVal this_n2 As Integer, ByVal this_n3 As Integer, ByVal Optional this_s1 As String = Nothing, ByVal Optional this_s2 As String = Nothing, ByVal Optional this_s3 As String = Nothing)
        'The UpdateTriangle model is used for easier updating of triangle properties
        Dim updateTriangle As ITriangle = New UpdateTriangle(this_t, this_n1, this_n2, this_n3, this_s1, this_s2, this_s3)

    End Sub

#End Region

#Region "Empty Space Build Methods"

    Public Overrides Sub SetupEmptySpaceBoundary(farfield As Object)
        'Used for empty space setup

        AddCornerNodes(farfield)
        AddMidBoundaryNodes(farfield)

    End Sub

    Public Overrides Sub AddCornerNodes(ByVal farfield As Object)

        AddBoundaryNode(0, 0, 0)
        AddBoundaryNode(1, 0, farfield.height)
        AddBoundaryNode(2, farfield.width, farfield.height)
        AddBoundaryNode(3, farfield.width, 0)

    End Sub

    Public Overrides Sub AddMidBoundaryNodes(farfield As Object)

        AddBoundaryNode(4, 0, farfield.height / 2)
        AddBoundaryNode(5, farfield.width, farfield.height / 2)

    End Sub

    Public Overrides Sub SetupEmptySpaceTriangles()
        'Setup triangles for empty space
        'the vertex ids must correspond to specific node ids

        AddTriangle(0, 0, 4, 3, Nothing, "boundary", "boundary")
        AddTriangle(1, 4, 1, 3, Nothing, Nothing, "boundary")
        AddTriangle(2, 1, 5, 3, "boundary", Nothing, Nothing)
        AddTriangle(3, 1, 2, 5, "boundary", Nothing, "boundary")

    End Sub
#End Region

#Region "Spline Fitting Methods"

    Public Sub SplineFitting(ByVal n2 As Integer, ByVal n3 As Integer)
        'Placeholder - not implemented
        'Create a new node on the airfoil surface between n2 and n3 using a spline fitting method

        'Dim this_n As Integer
        'Dim this_x, this_y As Double

        'What makes this tricky (and slow!) is finding nodes at either side of n2 and n3
        'we must follow airfoil surface in a given rotational direction
        '(pseudo code)
        '   n1 = data.GetNodeBefore(n2)
        '   n4 = data.GetNodeAfter(n3)
        '
        '   Do some  curve fitting from n1, n2, n3, n4
        '
        '   Interpolate a point between n2 and n3

        'AddBoundaryNode(this_n, this_x, this_y)

    End Sub

#End Region

End Class
