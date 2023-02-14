Imports System.Threading.Tasks
Imports MeshGeneration.Services

Namespace Logic
    Public Class DelaunayLogic

        Private delaunay As IDelaunay
        Private setter As IStatusSetter
        Private sorter As ITriangleSorter
        Private calculator As ITriangleCalculator

        Public Sub New(ByVal delaunay As IDelaunay, ByVal setter As IStatusSetter, ByVal sorter As ITriangleSorter, ByVal calculator As ITriangleCalculator)

            Me.delaunay = delaunay
            Me.setter = setter
            Me.sorter = sorter
            Me.calculator = calculator

        End Sub

        Public Sub Logic()

            'sort triangle list
            sorter.SortTriangles()

            'do Delaunay triangulation
            delaunay.Delaunay()

            'calc lengths, reset complete status in parallel
            Dim calcTask As Task = Task.Factory.StartNew(Sub() calculator.CalculateLengths())
            setter.SetCompleteStatus()
            calcTask.Wait()

        End Sub

    End Class
End Namespace