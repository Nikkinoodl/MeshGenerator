Imports MeshGeneration.Models

Namespace Data
    Public Interface IDataAccessService
        Property Trianglelist As List(Of ITriangle)
        Property Nodelist As List(Of INode)
        Function MaxTriangleId() As Integer
        Function Exists(ByVal xp As Double, ByVal yp As Double) As Integer
        Function FindNode(ByVal xp As Double, ByVal yp As Double) As Integer
        Function NodeV(ByVal n As Integer) As IEnumerable(Of INode)
        Function SmoothTriangle(ByVal thisnode As Integer) As IEnumerable(Of ITriangle)
        Function SmoothNode() As IEnumerable(Of INode)
        Function BoundaryNode(ByVal farfield As Object) As IEnumerable(Of INode)
        Sub CheckBoundaryNode(ByVal farfield As Object)
        Sub SortTriangles()
        Function Trianglequery(ByVal configuration As Integer, ByVal n1 As Integer, ByVal n2 As Integer, ByVal n3 As Integer) As IEnumerable(Of ITriangle)
        Function EdgeBoundary(ByVal edge As String, ByVal farfield As Object) As IOrderedEnumerable(Of INode)
    End Interface
End Namespace