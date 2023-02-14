Imports MeshGeneration.Models

Public MustInherit Class BaseNodeFactory
    'The base class of the grid element factory

    'The node and triangle production line. Should these be defined as INode/ITriangle and use interfaces??
    MustOverride Sub RequestNode(ByVal this_id As Integer, ByVal this_x As Double, ByVal this_y As Double, ByVal this_surface As Boolean, ByVal this_boundary As Boolean)
    MustOverride Sub AddNode(ByVal this_id As Integer, ByVal this_x As Double, ByVal this_y As Double)
    MustOverride Sub AddBoundaryNode(ByVal this_id As Integer, ByVal this_x As Double, ByVal this_y As Double)
    MustOverride Sub AddCornerNodes(ByVal farfield As Object)
    MustOverride Sub AddMidBoundaryNodes(ByVal farfield As Object)
    MustOverride Sub SetupEmptySpaceBoundary(ByVal farfield As Object)
    MustOverride Sub AddAirfoilNode(ByVal this_id As Integer, ByVal this_x As Double, ByVal this_y As Double)
    MustOverride Sub AddTriangle(ByVal this_id As Integer, ByVal this_n1 As Integer, ByVal this_n2 As Integer, ByVal this_n3 As Integer, ByVal Optional this_s1 As String = Nothing, ByVal Optional this_s2 As String = Nothing, ByVal Optional this_s3 As String = Nothing)
    MustOverride Sub SetupEmptySpaceTriangles()

    'If this class is a factory, then this is the returns department.  Replacement goods only.
    MustOverride Sub ReplaceTriangle(ByVal t As Integer, ByVal newId As Integer, ByVal this_n1 As Integer, ByVal this_n2 As Integer, ByVal this_n3 As Integer, ByVal Optional this_s1 As String = Nothing, ByVal Optional this_s2 As String = Nothing, ByVal Optional this_s3 As String = Nothing)

    'Updating of triangles and nodes moved to factory
    MustOverride Sub UpdateTriangle(ByVal t As Integer, ByVal this_n1 As Integer, ByVal this_n2 As Integer, ByVal this_n3 As Integer, ByVal Optional this_s1 As String = Nothing, ByVal Optional this_s2 As String = Nothing, ByVal Optional this_s3 As String = Nothing)

End Class
