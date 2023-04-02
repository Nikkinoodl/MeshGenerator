Imports System.Threading.Tasks
Imports MeshGeneration.Services

Namespace Logic
    Public Class Split

        Private ReadOnly checker As IBoundaryNodeChecker
        Private ReadOnly calculator As ITriangleCalculator
        Private ReadOnly sorter As ITriangleSorter
        Private ReadOnly cleaner As INodeCleaner
        Private ReadOnly splitter As ITriangleSplitter

        Public Sub New(checker As IBoundaryNodeChecker, calculator As ITriangleCalculator, sorter As ITriangleSorter, cleaner As INodeCleaner, splitter As ITriangleSplitter)

            Me.checker = checker
            Me.calculator = calculator
            Me.sorter = sorter
            Me.cleaner = cleaner
            Me.splitter = splitter

        End Sub

        Public Sub Logic(farfield As Object)

            'calculate lengths, average x's and sort Repository.Trianglelist by avg x coord
            'these can be done in parallel
            Dim calcTask As Task = Task.Factory.StartNew(Sub() calculator.CalculateLengths())
            sorter.SortTriangles()

            calcTask.Wait()

            'Split triangles
            splitter.SplitTriangles()

            'Post triangle splitting cleanup
            cleaner.CleanOrphanNodes()
            calculator.CalculateLengths()

            'Some post cleanup tasks can be done in parallel, but only these
            Dim checkTask As Task = Task.Factory.StartNew(Sub() checker.CheckBoundaryNodes(farfield))
            sorter.SortTriangles()
            checkTask.Wait()

        End Sub

    End Class
End Namespace