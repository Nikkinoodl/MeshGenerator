Imports MeshGeneration.Models

Namespace Data
    Public Interface IDataAccessService
        Property Trianglelist As List(Of Triangle)
        Property Nodelist As List(Of Node)
        Function MaxTriangleId() As Integer
        Function Exists(xp As Double, yp As Double) As Integer
        Function FindNode(xp As Double, yp As Double) As Integer
        Function NodeV(n As Integer) As IEnumerable(Of Node)
        Function SmoothTriangle(thisnode As Integer) As IEnumerable(Of Triangle)
        Function SmoothNode() As IEnumerable(Of Node)
        Function BoundaryNode(farfield As Object) As IEnumerable(Of Node)
        Sub CheckBoundaryNode(farfield As Object)
        Sub SortTriangles()
        Function Trianglequery(configuration As Integer, n1 As Integer, n2 As Integer, n3 As Integer) As IEnumerable(Of Triangle)
        Function EdgeBoundary(edge As String, farfield As Object) As IOrderedEnumerable(Of Node)
    End Interface
End Namespace