Imports MeshGeneration.Services

Namespace Logic
    Public Class Redistribute

        Private ReadOnly calculator As ITriangleCalculator
        Private ReadOnly redistributor As IRedistributor
        Private ReadOnly setter As IStatusSetter

        Public Sub New(calculator As ITriangleCalculator, redistributor As IRedistributor, setter As IStatusSetter)

            Me.calculator = calculator
            Me.redistributor = redistributor
            Me.setter = setter

        End Sub

        Public Sub Logic(farfield As Object)

            'Redistribute boundary nodes
            redistributor.Redistribute(farfield)

            'Recalculate triangle sides
            calculator.CalculateLengths()

        End Sub

    End Class
End Namespace