Imports System.Threading.Tasks
Imports MeshGeneration.Services

Namespace Logic
    Public Class DelaunayLogic

        Private ReadOnly delaunay As IDelaunay
        Private ReadOnly setter As IStatusSetter
        Private ReadOnly sorter As ITriangleSorter
        Private ReadOnly calculator As ITriangleCalculator

        Public Sub New(delaunay As IDelaunay, setter As IStatusSetter, sorter As ITriangleSorter, calculator As ITriangleCalculator)

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