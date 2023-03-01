Imports System.Threading.Tasks
Imports MeshGeneration.Services

Namespace Logic
    Public Class Smooth

        Private ReadOnly calculator As ITriangleCalculator
        Private ReadOnly smoother As IGridSmoother
        Private ReadOnly sorter As ITriangleSorter
        Private ReadOnly setter As IStatusSetter

        Public Sub New(ByVal calculator As ITriangleCalculator, ByVal smoother As IGridSmoother, ByVal sorter As ITriangleSorter, ByVal setter As IStatusSetter)

            Me.calculator = calculator
            Me.smoother = smoother
            Me.sorter = sorter
            Me.setter = setter

        End Sub

        Public Sub Logic(ByVal farfield As Object)

            'Calculate lengths, sort Repository.Trianglelist by x coord can be done in parallel
            Dim calcTask As Task = Task.Factory.StartNew(Sub() calculator.CalculateLengths())
            sorter.SortTriangles()

            calcTask.Wait()

            'run cycles of laplace smoothing
            If farfield.Smoothingcycles > 0 Then
                For n As Integer = 1 To farfield.Smoothingcycles
                    smoother.SmoothGrid()
                Next
            End If

            'Recalculate triangle areas and set triangle complete status to false
            calculator.CalculateLengths()

            'Calculate lengths and set each traingle's status to complete in parallel
            Dim secondCalcTask As Task = Task.Factory.StartNew(Sub() calculator.CalculateLengths())
            setter.SetCompleteStatus()

            secondCalcTask.Wait()

        End Sub

    End Class
End Namespace