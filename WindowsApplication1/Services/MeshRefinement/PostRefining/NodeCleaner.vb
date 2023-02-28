Imports MeshGeneration.Data
Imports MeshGeneration.Models

Namespace Services
    Public Class NodeCleaner : Implements INodeCleaner

        Private ReadOnly data As IDataAccessService

        Public Sub New(ByVal data As IDataAccessService)

            Me.data = data

        End Sub

        Public Sub CleanOrpanNodes() Implements INodeCleaner.CleanOrphanNodes
            'finds triangles that have an orphan node in the middle of one side and splits them at the orphan node

            Dim n1, n2, n3, np As Integer
            Dim x1, x2, x3, y1, y2, y3, xp, yp As Double
            Dim s1, s2, s3, b1, b2, b3 As Boolean

            Dim factory As New NodeFactory()

            Dim numtriangles As Integer = data.Trianglelist.Count
            Dim n As Integer = data.Nodelist.Count

            'cycle through 1 less than the count
            For t = 0 To numtriangles - 1

                'current max id in trianglelist and new id for new triangles
                Dim maxId = data.Trianglelist.Max(Function(p) p.Id)
                Dim newId = maxId + 1

                'Get node ids for this triangle
                n1 = data.Trianglelist(t).V1
                n2 = data.Trianglelist(t).V2
                n3 = data.Trianglelist(t).V3

                'Get details for each node
                With data.NodeV(n1).Single
                    x1 = .X
                    y1 = .Y
                    s1 = .Surface   'is it an airfoil node?
                    b1 = .Boundary ' is it a boundary node?
                End With

                With data.NodeV(n2).Single
                    x2 = .X
                    y2 = .Y
                    s2 = .Surface   'is it an airfoil node?
                    b2 = .Boundary ' is it a boundary node?
                End With

                With data.NodeV(n3).Single
                    x3 = .X
                    y3 = .Y
                    s3 = .Surface   'is it an airfoil node?
                    b3 = .Boundary ' is it a boundary node?
                End With

                'check for orphan nodes on l1
                xp = MidPoint(x2, x3)
                yp = MidPoint(y2, y3)

                If data.Exists(xp, yp) > 0 Then           'if there is an orphan node

                    'point vp to the existing node
                    n = data.FindNode(xp, yp)

                    factory.ReplaceTriangle(t, newId, n1, n2, n, "", "", data.Trianglelist(t).S3)       'new triangles
                    factory.AddTriangle(newId + 1, n1, n, n3, "", data.Trianglelist(t).S2, "")

                Else

                    'check for orphan nodes on l2
                    xp = MidPoint(x3, x1)
                    yp = MidPoint(y3, y1)

                    If data.Exists(xp, yp) > 0 Then           'if there is an orphan node

                        'point vp to the existing node
                        n = data.FindNode(xp, yp)

                        factory.ReplaceTriangle(t, newId, n2, n3, n, "", "", data.Trianglelist(t).S1)
                        factory.AddTriangle(newId + 1, n2, n, n1, "", data.Trianglelist(t).S3, "")

                    Else

                        ''check for orphan nodes on l3
                        xp = MidPoint(x2, x1)
                        yp = MidPoint(y2, y1)

                        If data.Exists(xp, yp) > 0 Then           'if there is an orphan node

                            'point vp to the existing node
                            n = data.FindNode(xp, yp)

                            factory.ReplaceTriangle(t, newId, n3, n1, n, "", "", data.Trianglelist(t).S2)
                            factory.AddTriangle(newId + 1, n3, n, n2, "", data.Trianglelist(t).S1, "")

                        End If
                    End If
                End If
            Next
        End Sub

        Private Function MidPoint(ByVal a As Double, ByVal b As Double) As Double
            'Finds the mid point of two cordinates
            Return ((a + b) / 2)
        End Function

    End Class
End Namespace