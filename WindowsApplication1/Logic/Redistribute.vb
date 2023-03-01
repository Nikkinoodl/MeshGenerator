Imports System.Threading.Tasks
Imports MeshGeneration.Services

Namespace Logic
    Public Class Redistribute

        Private ReadOnly calculator As ITriangleCalculator
        Private ReadOnly redistributor As IRedistributor
        Private ReadOnly setter As IStatusSetter

        Public Sub New(ByVal calculator As ITriangleCalculator, ByVal redistributor As IRedistributor, ByVal setter As IStatusSetter)

            Me.calculator = calculator
            Me.redistributor = redistributor
            Me.setter = setter

        End Sub

        Public Sub Logic(ByVal farfield As Object)

            'Redistribute boundary nodes
            redistributor.Redistribute(farfield)

            'Recalculate triangle sides
            calculator.CalculateLengths()

        End Sub

    End Class
End Namespace