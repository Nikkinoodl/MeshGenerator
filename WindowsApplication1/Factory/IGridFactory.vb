Namespace Factories
    Public Interface IGridFactory
        'Interface for the grid element factory

        'The node and triangle production line. Should these be defined as INode/ITriangle and use interfaces??
        Sub RequestNode(this_id As Integer, this_x As Double, this_y As Double, this_surface As Boolean, this_boundary As Boolean)
        Sub AddNode(this_id As Integer, this_x As Double, this_y As Double)
        Sub AddBoundaryNode(this_id As Integer, this_x As Double, this_y As Double)
        Sub AddCornerNodes(farfield As Object)
        Sub AddMidBoundaryNodes(farfield As Object)
        Sub SetupEmptySpaceBoundary(farfield As Object)
        Sub AddAirfoilNode(this_id As Integer, this_x As Double, this_y As Double)
        Sub AddTriangle(this_id As Integer, this_n1 As Integer, this_n2 As Integer, this_n3 As Integer, Optional this_s1 As String = Nothing, Optional this_s2 As String = Nothing, Optional this_s3 As String = Nothing)
        Sub SetupEmptySpaceTriangles()

        'If this class is a factory, then this is the returns department.  Replacement goods only.
        Sub ReplaceTriangle(t As Integer, newId As Integer, this_n1 As Integer, this_n2 As Integer, this_n3 As Integer, Optional this_s1 As String = Nothing, Optional this_s2 As String = Nothing, Optional this_s3 As String = Nothing)

        'Updating of triangles and nodes moved to factory
        Sub UpdateTriangle(t As Integer, this_n1 As Integer, this_n2 As Integer, this_n3 As Integer, Optional this_s1 As String = Nothing, Optional this_s2 As String = Nothing, Optional this_s3 As String = Nothing)

    End Interface
End Namespace