Imports MeshGeneration.Data
Imports System.Threading.Tasks

Namespace Services
    Public Class TriangleCalculator : Implements ITriangleCalculator

        Private ReadOnly data As IDataAccessService

        Public Sub New(ByVal data As IDataAccessService)

            Me.data = data

        End Sub

        Public Sub CalculateLengths() Implements ITriangleCalculator.CalculateLengths
            'gather information required to calculate the area of each triangle in the mesh
            'the actual area calculation is done in the triangle class
            'This executes in parallel so most fields are declared locally instead of as class-wide private properties

            Parallel.ForEach(data.Trianglelist, Sub(triangle)

                                                    Dim n1 = triangle.V1
                                                    Dim n2 = triangle.V2
                                                    Dim n3 = triangle.V3
                                                    Dim x1 As Double
                                                    Dim x2 As Double
                                                    Dim x3 As Double
                                                    Dim y1 As Double
                                                    Dim y2 As Double
                                                    Dim y3 As Double

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

                                                    'calculate length metrics
                                                    triangle.L1 = System.Math.Sqrt(System.Math.Pow((x3 - x2), 2) + System.Math.Pow((y3 - y2), 2))
                                                    triangle.L2 = System.Math.Sqrt(System.Math.Pow((x3 - x1), 2) + System.Math.Pow((y3 - y1), 2))
                                                    triangle.L3 = System.Math.Sqrt(System.Math.Pow((x1 - x2), 2) + System.Math.Pow((y1 - y2), 2))
                                                    triangle.AvgX = (x1 + x2 + x3) / 3
                                                    triangle.AvgY = (y1 + y2 + y3) / 3

                                                End Sub)
        End Sub
    End Class
End Namespace