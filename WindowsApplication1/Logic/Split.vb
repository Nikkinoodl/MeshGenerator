﻿Imports System.Threading.Tasks
Imports MeshGeneration.Services

Namespace Logic
    Public Class Split

        Private checker As IBoundaryNodeChecker
        Private calculator As ITriangleCalculator
        Private sorter As ITriangleSorter
        Private cleaner As INodeCleaner
        Private splitter As ITriangleSplitter

        Public Sub New(ByVal checker As IBoundaryNodeChecker, ByVal calculator As ITriangleCalculator, ByVal sorter As ITriangleSorter, ByVal cleaner As INodeCleaner, ByVal splitter As ITriangleSplitter)

            Me.checker = checker
            Me.calculator = calculator
            Me.sorter = sorter
            Me.cleaner = cleaner
            Me.splitter = splitter

        End Sub

        Public Sub Logic(ByVal farfield As Object)

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