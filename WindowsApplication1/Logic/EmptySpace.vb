Imports MeshGeneration.Services

Namespace Logic
    Public Class EmptySpace

        Private ReadOnly builder As IEmptySpaceBuilder
        Private ReadOnly checker As IBoundaryNodeChecker
        Private ReadOnly calculator As ITriangleCalculator
        Private ReadOnly initializer As IInitializer

        Public Sub New(builder As IEmptySpaceBuilder, checker As IBoundaryNodeChecker, calculator As ITriangleCalculator, initializer As IInitializer)

            Me.builder = builder
            Me.checker = checker
            Me.calculator = calculator
            Me.initializer = initializer

        End Sub

        Public Sub Logic(farfield As Object)

            'Call service to prep data 
            initializer.DataPreparer()

            'Build grid
            builder.BuildEmptySpace(farfield)

            'Make sure all nodes on boundary have .boundary = True
            'and calculate lengths
            checker.CheckBoundaryNodes(farfield)
            calculator.CalculateLengths()

        End Sub

    End Class
End Namespace