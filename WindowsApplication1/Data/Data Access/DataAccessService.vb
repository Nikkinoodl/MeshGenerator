Imports MeshGeneration.Models

Namespace Data
    Public Class DataAccessService : Implements IDataAccessService
        'A collection of functions that supply information about data in the repository

        Public Sub New()

        End Sub

        'Use this property for sort, count, etc.
        Public Property Trianglelist As List(Of ITriangle) = Repository.Trianglelist Implements IDataAccessService.Trianglelist

        'Use this property for sort, count, etc.
        Public Property Nodelist As List(Of INode) = Repository.Nodelist Implements IDataAccessService.Nodelist

        Public Function MaxTriangleId() As Integer Implements IDataAccessService.MaxTriangleId
            'Returns the maximum triangle Id

            Dim thisId = (From triangle As ITriangle In Repository.Trianglelist
                          Select triangle.Id).Max()
            Return thisId

        End Function

        Public Function Exists(xp As Double, yp As Double) As Integer Implements IDataAccessService.Exists
            'Checks for an existing node at the given coordinates

            Dim countNode = Aggregate node As INode In Repository.Nodelist
                            Where node.X = xp And node.Y = yp
                            Into Count()
            Return countNode

        End Function

        Function FindNode(xp As Double, yp As Double) As Integer Implements IDataAccessService.FindNode
            'Returns the id of an existing node

            Dim n = (From node As INode In Repository.Nodelist
                     Where node.X = xp And node.Y = yp
                     Select node.Id).FirstOrDefault
            Return n

        End Function

        Function NodeV(n As Integer) As IEnumerable(Of INode) Implements IDataAccessService.NodeV
            'Returns a specific node (as IEnumerable)

            Dim thisNode = From node As INode In Repository.Nodelist
                           Where node.Id = n
                           Select node
            Return thisNode

        End Function

        Public Function SmoothTriangle(thisnode As Integer) As IEnumerable(Of ITriangle) Implements IDataAccessService.SmoothTriangle
            'Returns a list of the triangles that contains a specific node

            Dim thislist = From triangle As ITriangle In Repository.Trianglelist
                           Where triangle.V1 = thisnode Or triangle.V2 = thisnode Or triangle.V3 = thisnode
                           Select triangle
                           Order By triangle.AvgX
            Return thislist

        End Function

        Public Function SmoothNode() As IEnumerable(Of INode) Implements IDataAccessService.SmoothNode
            'Returns a list of nodes that are candidates for smoothing. Surface and boundary nodes are excluded

            Dim thislist = From node As INode In Repository.Nodelist
                           Where node.Boundary = False And node.Surface = False  'nodes on the surface or boundary aren't moved
                           Select node
            Return thislist

        End Function

        Public Function BoundaryNode(farfield As Object) As IEnumerable(Of INode) Implements IDataAccessService.BoundaryNode
            'Returns a list of all nodes that are on the boundary of the farfield

            Dim boundarynodes = From node As INode In Repository.Nodelist
                                Where node.X = 0 Or node.X = farfield.width Or node.Y = 0 Or node.Y = farfield.height And node.Boundary = False
                                Select node
            Return boundarynodes

        End Function

        Public Sub CheckBoundaryNode(farfield As Object) Implements IDataAccessService.CheckBoundaryNode
            'Ensures that all nodes on the boundary have the correct attribute
            'It was easier to implement this here rather than in NodeFactory

            For Each node In BoundaryNode(farfield)
                node.Boundary = True
            Next

        End Sub

        Public Sub SortTriangles() Implements IDataAccessService.SortTriangles
            'Sorts triangles in the repository  
            'helps to set a calc order for the mesh, working from left to right

            Repository.Trianglelist.Sort(Function(t1, t2) t1.AvgX.CompareTo(t2.AvgX))

        End Sub

        Public Function Trianglequery(configuration As Integer, n1 As Integer, n2 As Integer, n3 As Integer) As IEnumerable(Of ITriangle) Implements IDataAccessService.Trianglequery
            'Returns a list of triangles for use in Delaunay triangulation

            Dim basequery = Repository.Trianglelist

            Dim filterquery = basequery.Where(Function(t)
                                                  Select Case configuration
                                                      Case 1
                                                          Return t.V1 = n1 And t.V3 = n2 And Not t.Complete
                                                      Case 2
                                                          Return t.V2 = n2 And t.V1 = n3 And Not t.Complete
                                                      Case 3
                                                          Return t.V2 = n1 And t.V3 = n3 And Not t.Complete
                                                      Case 4
                                                          Return t.V2 = n1 And t.V1 = n2 And Not t.Complete
                                                      Case 5
                                                          Return t.V3 = n2 And t.V2 = n3 And Not t.Complete
                                                      Case 6
                                                          Return t.V3 = n1 And t.V1 = n3 And Not t.Complete
                                                      Case Else
                                                          Throw New Exception
                                                  End Select
                                              End Function)
            Return filterquery

        End Function

        Function EdgeBoundary(edge As String, farfield As Object) As IOrderedEnumerable(Of INode) Implements IDataAccessService.EdgeBoundary
            'Returns an ordered list of nodes on the top edge of the farfield boundary
            'Excludes the corner nodes

            Dim basequery = Repository.Nodelist

            Dim filterquery = basequery.Where(Function(n)
                                                  Select Case edge
                                                      Case "top"
                                                          Return n.Y = farfield.height And n.X <> 0 And n.X <> farfield.width
                                                      Case "bottom"
                                                          Return n.Y = 0 And n.X <> 0 And n.X <> farfield.width
                                                      Case "right"
                                                          Return n.X = farfield.width And n.Y <> 0 And n.Y <> farfield.height
                                                      Case "left"
                                                          Return n.X = 0 And n.Y <> 0 And n.Y <> farfield.height
                                                      Case Else
                                                          Throw New Exception
                                                  End Select
                                              End Function)

            Dim orderquery = filterquery.OrderBy(Function(n)
                                                     Select Case edge
                                                         Case "top", "bottom"
                                                             Return n.X
                                                         Case "left", "right"
                                                             Return n.Y
                                                         Case Else
                                                             Throw New Exception
                                                     End Select
                                                 End Function)
            Return orderquery

        End Function
    End Class
End Namespace