Imports MeshGeneration.Services
Imports MeshGeneration.AppSettings
Imports MeshGeneration.AppSettings.Constants

Namespace Logic
    Public Class Build

        Private reader As IAirfoilNodeReader
        Private checker As IBoundaryNodeChecker
        Private calculator As ITriangleCalculator
        Private sorter As ITriangleSorter
        Private scaler As IScaler
        Private grid As IGridBuilder
        Private initializer As IInitializer

        Private filename As String

        Public Sub New(ByVal reader As IAirfoilNodeReader, ByVal checker As IBoundaryNodeChecker, ByVal calculator As ITriangleCalculator, ByVal sorter As ITriangleSorter, ByVal scaler As IScaler, ByVal grid As IGridBuilder, ByVal initializer As IInitializer)

            Me.reader = reader
            Me.checker = checker
            Me.calculator = calculator
            Me.sorter = sorter
            Me.scaler = scaler
            Me.grid = grid
            Me.initializer = initializer

        End Sub

        Public Sub Logic(ByVal farfield As Calcdomain)

            'Call service to prep data 
            initializer.DataPreparer()

            'Read the airfoil nodes (otherwise we default to nodes at 0,0)
            Try
                reader.ReadAirfoilNodes(farfield.Filename)
            Catch
                MsgBox(MSGFILEERROR)
                Exit Sub
            End Try

            'Apply scaling and offset to airfoil nodes
            'This must be run before preliminary grid is set
            scaler.AirfoilScaler(farfield)

            'Build grid
            grid.SetPrelimGrid(farfield)

            'Make sure all nodes on boundary have .boundary = True
            'and calculate lengths
            checker.CheckBoundaryNodes(farfield)
            calculator.CalculateLengths()

            'sort Repository.Trianglelist by x coord
            sorter.SortTriangles()
        End Sub

    End Class
End Namespace