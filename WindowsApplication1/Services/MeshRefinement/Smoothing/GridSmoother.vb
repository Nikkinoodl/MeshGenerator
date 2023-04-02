Imports MeshGeneration.Models
Imports MeshGeneration.Data
Imports System.Threading.Tasks

Namespace Services
    Public Class GridSmoother : Implements IGridSmoother

        Private ReadOnly data As IDataAccessService

        Public Sub New(data As IDataAccessService)

            Me.data = data

        End Sub

        Public Sub SmoothGrid() Implements IGridSmoother.SmoothGrid
            'takes each node in turn, finds the triangles that contain this node
            'and re-centers the node in relation to the nodes of these triangles
            'using Laplace smoothing
            '
            ' new (x, y) coordinates of np become the average (x, y) of A, B, C, D and np
            '
            '                                   A
            '                                  /|\ 
            '                                 / | \ 
            '                                /  |  \
            '                               /   |   \
            '                              /    |    \
            '                             /     |     \
            '                            /      |      \
            '                           /       |       \
            '                          /        |        \
            '                         /         |         \
            '                      B  --------- np -------- C
            '                         \         |          /
            '                          \        |         /
            '                           \       |        /
            '                            \      |       /
            '                             \     |      /
            '                              \    |     /
            '                               \   |    /
            '                                \  |   /
            '                                 \ |  /  
            '                                  \| / 
            '                                   D            
            '

            'Loop through each node in parallel
            'fields are declared locally instead of as class-wide private properties
            Parallel.ForEach(data.SmoothNode(), Sub(node)
                                                    'reset variables and counters
                                                    Dim n = 0
                                                    Dim thisx As Double = 0
                                                    Dim thisy As Double = 0

                                                    'Find the triangles that contain this node
                                                    For Each triangle In data.SmoothTriangle(node.Id)
                                                        n = n + 1
                                                        Dim n1 = triangle.V1
                                                        Dim n2 = triangle.V2
                                                        Dim n3 = triangle.V3

                                                        'aggregate the x and y of all nodes
                                                        thisx = data.Nodelist(n1).X + data.Nodelist(n2).X + data.Nodelist(n3).X + thisx
                                                        thisy = data.Nodelist(n1).Y + data.Nodelist(n2).Y + data.Nodelist(n3).Y + thisy

                                                    Next

                                                    'update the x and y for this node with the mean of thisx and thisy
                                                    data.Nodelist(node.Id).X = thisx / (3 * n)
                                                    data.Nodelist(node.Id).Y = thisy / (3 * n)

                                                End Sub)
            'Next
        End Sub
    End Class
End Namespace