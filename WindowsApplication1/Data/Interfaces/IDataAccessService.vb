Imports MeshGeneration.Models

Namespace Data
    Public Interface IDataAccessService
        Property Trianglelist As List(Of ITriangle)
        Property Nodelist As List(Of INode)
        Function MaxTriangleId() As Integer
        Function Exists(xp As Double, yp As Double) As Integer
        Function FindNode(xp As Double, yp As Double) As Integer
        Function NodeV(n As Integer) As IEnumerable(Of INode)
        Function SmoothTriangle(thisnode As Integer) As IEnumerable(Of ITriangle)
        Function SmoothNode() As IEnumerable(Of INode)
        Function BoundaryNode(farfield As Object) As IEnumerable(Of INode)
        Sub CheckBoundaryNode(farfield As Object)
        Sub SortTriangles()
        Function Trianglequery(configuration As Integer, n1 As Integer, n2 As Integer, n3 As Integer) As IEnumerable(Of ITriangle)
        Function EdgeBoundary(edge As String, farfield As Object) As IOrderedEnumerable(Of INode)
    End Interface
End Namespace