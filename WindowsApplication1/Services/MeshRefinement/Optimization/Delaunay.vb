Imports MeshGeneration.Models
Imports MeshGeneration.Data
Imports MeshGeneration.AppSettings.Constants

Namespace Services
    Public Class Delaunay : Implements IDelaunay

        Private n1, n2, n3, np, t, t2 As Integer
        Private x1, x2, x3, xp, y1, y2, y3, yp As Double
        Private s11, s12, s13, s21, s22, s23 As String

        Private data As IDataAccessService

        Public Sub New(ByVal data As IDataAccessService)

            Me.data = data

        End Sub

        Public Sub Delaunay() Implements IDelaunay.Delaunay
            'Laplace smoothing and SetCompleteStatus should be run before this

            'We are after every combination of vertex arrangements.
            '
            'Each possible configuration (numbered 1 through 6) is checked through iteration.
            'See JoiningSide function to see how this is coded.
            'The Triangle configurations are used by private methods in this class and in the Trianglequery class.
            '
            'In these diagrams 'this' refers to the current triangle and 'adj' is the adjacent triangle. 'np' is the
            'vertex on the 'adj' triangle that is being tested to see if it lies within the circumcircle of 'this' triangle.
            '
            ' 1. v2 is np
            '
            '                       v2---------v3      2
            '                        \         /     /    \
            '                         \       /    /        \
            '                          \     /   /            \
            '                             v1    1 -------------3
            '
            '                           adj         this
            ' 
            '
            ' 2. v3 is np
            '
            '                                 2       v2--------- v3
            '                              /     \      \       /
            '                             /       \      \     /
            '                            /         \      \   /
            '                           1 ----------3      v1
            '                               this            adj
            '
            '
            ' 3. v1 is np
            '
            '                                 2      
            '                              /     \ 
            '                             /       \  
            '                            /         \ 
            '                           1 ----------3
            '                               this        
            '
            '                           v2--------- v3
            '                             \       /
            '                              \     /
            '                               \   /
            '                                 v1
            '                                adj
            '
            ' 4.: v3 is np
            '
            '                       v3---------v1      2
            '                        \         /     /    \
            '                         \       /    /        \
            '                          \     /   /            \
            '                             v2    1 -------------3
            '
            '                           adj         this
            ' 
            '
            ' 5. v1 is np
            '
            '                                 2       v3--------- v1
            '                              /     \      \       /
            '                             /       \      \     /
            '                            /         \      \   /
            '                           1 ----------3      v2
            '                               this            adj
            '
            '
            ' 6. v2 is np
            '
            '                                 2      
            '                              /     \ 
            '                             /       \  
            '                            /         \ 
            '                           1 ----------3
            '                               this        
            '
            '                           v3--------- v1
            '                             \       /
            '                              \     /
            '                               \   /
            '                                 v2
            '                                adj
            '
            '
            Dim factory As New NodeFactory()
            Dim configurations = New Integer() {1, 2, 3, 4, 5, 6}

            Dim numtriangles = data.Trianglelist.Count

            For Each config In configurations

                'cycle through triangles
                For t = 0 To numtriangles - 1

                    'exclude if already processed
                    If Not (data.Trianglelist(t).Complete) Then

                        'find properties of joining side
                        Dim side = JoiningSide(config, t)

                        'exclude if joining side is boundary or surface
                        If Not (side = "boundary" Or side = "surface") Then

                            'get this triangle vertex nodes
                            GetNodeId(t)

                            'identify adjacent triangle
                            Dim triangleQuery = data.Trianglequery(config, n1, n2, n3)

                            'make sure we're only doing this if there is one adjacent triangle on this side
                            If triangleQuery.Count() = 1 Then

                                'identify which node will be np
                                ProcessAdjacent(config, triangleQuery)

                                'get the x and y coords of each node, including np
                                GetCoords()

                                'If nodep is in triangle circumcircle
                                If InCircle(xp, yp, x1, y1, x2, y2, x3, y3) And t <> t2 Then

                                    'Flip the triangles
                                    FlipTriangles(config, factory)

                                End If
                            End If
                        End If
                    End If
                Next
            Next
        End Sub

        Private Function InCircle(xp As Double, yp As Double, x1 As Double, y1 As Double, x2 As Double, y2 As Double, x3 As Double, y3 As Double) As Boolean
            'Credit to Paul Bourke (pbourke@swin.edu.au) for the original Fortran 77 Program :))
            'Conversion by EluZioN (EluZioN@casesladder.com)
            'You can use this code however you like providing the above credits remain intact

            'Return TRUE if the point (xp,yp) lies inside the circumcircle
            'made up by points (x1,y1) (x2,y2) (x3,y3)
            'The circumcircle centre is is (xc,yc) and the radius r
            'NOTE: A point on the edge is inside the circumcircle

            Dim eps As Double
            Dim m1 As Double
            Dim m2 As Double
            Dim mx1 As Double
            Dim mx2 As Double
            Dim my1 As Double
            Dim my2 As Double
            Dim dx As Double
            Dim dy As Double
            Dim rsqr As Double
            Dim drsqr As Double
            Dim xc As Double
            Dim yc As Double
            Dim r As Double

            eps = 0.000001

            InCircle = False

            'Pre-check for divide by zero condition
            If System.Math.Abs(y1 - y2) < eps And System.Math.Abs(y2 - y3) < eps Then
                MsgBox(MsgOverlap)
                Exit Function
            End If

            'We could wrap this If statement in a try..catch block but it is faster to check for non-zero divisors
            'beforehand
            If System.Math.Abs(y2 - y1) < eps Then
                m2 = -(x3 - x2) / (y3 - y2)
                mx2 = (x2 + x3) / 2
                my2 = (y2 + y3) / 2
                xc = (x2 + x1) / 2
                yc = m2 * (xc - mx2) + my2
            ElseIf System.Math.Abs(y3 - y2) < eps Then
                m1 = -(x2 - x1) / (y2 - y1)
                mx1 = (x1 + x2) / 2
                my1 = (y1 + y2) / 2
                xc = (x3 + x2) / 2
                yc = m1 * (xc - mx1) + my1
            Else
                m1 = -(x2 - x1) / (y2 - y1)
                m2 = -(x3 - x2) / (y3 - y2)
                mx1 = (x1 + x2) / 2
                mx2 = (x2 + x3) / 2
                my1 = (y1 + y2) / 2
                my2 = (y2 + y3) / 2
                xc = (m1 * mx1 - m2 * mx2 + my2 - my1) / (m1 - m2)
                yc = m1 * (xc - mx1) + my1
            End If

            dx = x2 - xc
            dy = y2 - yc
            rsqr = dx * dx + dy * dy
            r = System.Math.Sqrt(rsqr)
            dx = xp - xc
            dy = yp - yc
            drsqr = dx * dx + dy * dy

            If drsqr <= rsqr Then
                Return True
            Else
                Return False
            End If

        End Function

        Private Sub GetCoords()
            'assign x,y coords for each vertex node

            With data.NodeV(n1).Single
                x1 = .X
                y1 = .Y
            End With
            With data.NodeV(n2).Single
                x2 = .X
                y2 = .Y
            End With
            With data.NodeV(n3).Single
                x3 = .X
                y3 = .Y
            End With
            With data.NodeV(np).Single
                xp = .X
                yp = .Y
            End With

        End Sub

        Private Sub GetNodeId(ByVal t As Integer)
            'sets value of the node indexes and side values

            n1 = data.Trianglelist(t).V1
            n2 = data.Trianglelist(t).V2
            n3 = data.Trianglelist(t).V3
            s11 = data.Trianglelist(t).S1
            s12 = data.Trianglelist(t).S2
            s13 = data.Trianglelist(t).S3

        End Sub

        Private Function JoiningSide(ByVal configuration As Integer, ByVal t As Integer) As String
            'Identifies if joining side of this triangle is boundary or surface
            'This could all be moved to data, but it is basically the logic behind configuration

            Select Case configuration
                Case 1
                    Return data.Trianglelist(t).S3
                Case 2
                    Return data.Trianglelist(t).S1
                Case 3
                    Return data.Trianglelist(t).S2
                Case 4
                    Return data.Trianglelist(t).S3
                Case 5
                    Return data.Trianglelist(t).S1
                Case Else
                    Return data.Trianglelist(t).S2
            End Select

        End Function

        Private Sub ProcessAdjacent(ByVal configuration As Integer, ByVal trianglequery As IEnumerable(Of ITriangle))
            'Sets np for adjacent triangle
            'This could all be moved to factory, but it is basically the logic behind configuration

            For Each triangle In trianglequery
                t2 = data.Trianglelist.IndexOf(triangle)

                Select Case configuration
                    Case 1, 6
                        np = triangle.V2
                    Case 2, 4
                        np = triangle.V3
                    Case 3, 5
                        np = triangle.V1
                End Select

                s21 = triangle.S1
                s22 = triangle.S2
                s23 = triangle.S3
            Next

        End Sub

        Private Sub FlipTriangles(ByVal configuration As Integer, ByVal factory As NodeFactory)
            'Calls factory to flip triangles

            Select Case configuration
                Case 1
                    factory.UpdateTriangle(t, np, n2, n3, s12, Nothing, s23)
                    factory.UpdateTriangle(t2, np, n3, n1, s11, s21, Nothing)
                Case 2
                    factory.UpdateTriangle(t, np, n3, n1)
                    factory.UpdateTriangle(t2, np, n1, n2)
                Case 3
                    factory.UpdateTriangle(t, np, n1, n2)
                    factory.UpdateTriangle(t2, np, n2, n3)
                Case 4
                    factory.UpdateTriangle(t, np, n2, n3, s12, Nothing, s23)
                    factory.UpdateTriangle(t2, np, n3, n1, s11, s21, Nothing)
                Case 5
                    factory.UpdateTriangle(t, np, n3, n1)
                    factory.UpdateTriangle(t2, np, n1, n2)
                Case 6
                    factory.UpdateTriangle(t, np, n1, n2)
                    factory.UpdateTriangle(t2, np, n2, n3)
                Case Else
                    Throw New Exception
            End Select
        End Sub
    End Class
End Namespace

