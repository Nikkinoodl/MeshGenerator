Imports MeshGeneration.Data
Imports MeshGeneration.Factories

Namespace Services
    Public Class TriangleSplitter : Implements ITriangleSplitter
        Private numtriangles, vp, n As Integer
        Private n1, n2, n3, x1, x2, x3, y1, y2, y3, xp, yp As Double
        Private s1, s2, s3, b1, b2, b3 As Boolean

        Private ReadOnly data As IDataAccessService
        Private ReadOnly factory As IGridFactory

        Public Sub New(data As IDataAccessService, factory As IGridFactory)

            Me.data = data
            Me.factory = factory

        End Sub

        Public Sub SplitTriangles() Implements ITriangleSplitter.SplitTriangles
            'refines the mesh by creating new nodes and dividing up triangles

            numtriangles = data.Trianglelist.Count()
            n = data.Nodelist.Count

            'current max id in trianglelist and new id for triangle inserts
            Dim maxId = data.Trianglelist.Max(Function(p) p.Id)
            Dim newId = maxId + 1

            'cycle through all triangles
            't is the index of the triangle which is not the same as the id
            For t = 0 To numtriangles - 1

                'Get node ids for this triangle
                GetNodeId(t)

                'Get details for each node
                GetNodeDetails()

                'determine which is the longest side
                '
                'config = 1:  L1 is longest side

                '               n2
                '                |\
                '                | \ np
                '                |  \
                '                |___\
                '               n1     n3
                '
                'config = 2     L2 is longest side

                '               n1
                '                |\
                '                | \ np
                '                |  \
                '                |___\
                '               n2     n3
                '
                'config = 3     L3 is longest side (default)

                '               n1
                '                |\
                '                | \ np
                '                |  \
                '                |___\
                '               n3     n2

                Dim config As Integer = FindLongestSide(t)

                'Find the center point of longest side
                xp = FindMidPointX(config)
                yp = FindMidPointY(config)

                If data.Exists(xp, yp) > 0 Then          'if there is already a node there make sure we don't overwrite it

                    'point vp to the existing node
                    vp = data.FindNode(xp, yp)

                Else                                      'else create a new node (default and most common behavior)
                    vp = n

                    'Create a new node at the np point and return incremented n
                    n = CreateNewNode(t, config, n)

                End If

                'Split the existing triangle in two and return incremented newId
                newId = DivideTriangles(t, config, newId)

            Next

        End Sub

        Private Function FindLongestSide(t As Integer) As Integer
            'Returns an integer to indicate which is the longest side on the triangle

            If data.Trianglelist(t).L1 >= data.Trianglelist(t).L2 And data.Trianglelist(t).L1 > data.Trianglelist(t).L3 Then
                Return 1
            ElseIf data.Trianglelist(t).L2 > data.Trianglelist(t).L1 And data.Trianglelist(t).L2 > data.Trianglelist(t).L3 Then
                Return 2
            Else
                Return 3
            End If

        End Function

        Private Function FindMidPointX(config As Integer) As Double
            'Gets the location of xp depending on which is the longest side

            Select Case config
                Case 1
                    xp = MidPoint(x2, x3)
                Case 2
                    xp = MidPoint(x1, x3)
                Case 3
                    xp = MidPoint(x1, x2)
                Case Else
                    Throw New Exception
            End Select

            Return xp

        End Function

        Private Function FindMidPointY(config As Integer) As Double
            'Gets the location of y depending on which is the longest side

            Select Case config
                Case 1
                    yp = MidPoint(y2, y3)
                Case 2
                    yp = MidPoint(y1, y3)
                Case 3
                    yp = MidPoint(y1, y2)
                Case Else
                    Throw New Exception
            End Select

            Return yp

        End Function

        Private Function MidPoint(a As Double, b As Double) As Double
            'Finds the mid point of two cordinates

            Return ((a + b) / 2)

        End Function

        Private Sub GetNodeId(t As Integer)
            'Get the node ids of the triangle vertices

            n1 = data.Trianglelist(t).V1
            n2 = data.Trianglelist(t).V2
            n3 = data.Trianglelist(t).V3

        End Sub

        Private Sub GetNodeDetails()
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
        End Sub

        Private Function CreateNewNode(t As Integer, config As Integer, n As Integer) As Integer
            'Use node factory to create a new node of type determined by the factory.
            'If nodes to either side are both airfoil nodes, then np must be a airfoil node.
            'Boundary node identification must come from the existing triangle (not the nodes) as lines between nodes
            'can cut across corners of the calc domain

            Select Case config
                Case 1
                    factory.RequestNode(vp, xp, yp, (s2 And s3), IIf(data.Trianglelist(t).S1 = "boundary", True, False))
                Case 2
                    factory.RequestNode(vp, xp, yp, (s1 And s3), IIf(data.Trianglelist(t).S2 = "boundary", True, False))
                Case 3
                    factory.RequestNode(vp, xp, yp, (s2 And s1), IIf(data.Trianglelist(t).S3 = "boundary", True, False))
                Case Else
                    Throw New Exception
            End Select

            Return n + 1

        End Function

        Private Function DivideTriangles(t As Integer, config As Integer, newid As Integer) As Integer
            'Replace the existing triangle instance and create a new triangle instance

            Select Case config
                Case 1
                    'The new face cannot be either a boundary or surface node. All other faces inherit their existing state
                    factory.ReplaceTriangle(t, newid, n1, n2, vp, data.Trianglelist(t).S1, "", data.Trianglelist(t).S3)
                    factory.AddTriangle(newid + 1, n1, vp, n3, data.Trianglelist(t).S1, data.Trianglelist(t).S2, "")
                Case 2
                    factory.ReplaceTriangle(t, newid, n2, n3, vp, "", data.Trianglelist(t).S2, data.Trianglelist(t).S1)
                    factory.AddTriangle(newid + 1, n2, vp, n1, data.Trianglelist(t).S2, data.Trianglelist(t).S3, "")
                Case 3
                    factory.ReplaceTriangle(t, newid, n3, n1, vp, "", data.Trianglelist(t).S2, data.Trianglelist(t).S3)
                    factory.AddTriangle(newid + 1, n3, vp, n2, "", data.Trianglelist(t).S1, data.Trianglelist(t).S3)
                Case Else
                    Throw New Exception
            End Select

            Return newid + 1

        End Function
    End Class
End Namespace