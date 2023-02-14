Imports MeshGeneration.AppSettings
Imports MeshGeneration.Services
Imports MeshGeneration.Data
Imports MeshGeneration.Logic
Imports SimpleInjector

Module Main

    Public container As Container = New Container()

    Public Sub Main()

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Bootstrapper()
        Application.Run(container.GetInstance(Of MainForm)())

    End Sub

    Private Sub Bootstrapper()

        'the Of keyword is used for a list of types in place of the <> brackets in C#

        'UI Layer
        container.Register(Of MainForm)()
        container.Register(Of ISettings, Settings)()

        'logic layer
        container.Register(Of EmptySpace)()
        container.Register(Of DelaunayLogic)()
        container.Register(Of Redistribute)()
        container.Register(Of Smooth)()
        container.Register(Of Split)()
        container.Register(Of Build)()

        'services layer
        container.Register(Of IInitializer, Initializer)()
        container.Register(Of IAirfoilNodeReader, AirfoilNodeReader)()
        container.Register(Of ITriangleSorter, TriangleSorter)()
        container.Register(Of IStatusSetter, StatusSetter)()
        container.Register(Of ITriangleCalculator, TriangleCalculator)()
        container.Register(Of IBoundaryNodeChecker, BoundaryNodeChecker)()
        container.Register(Of ITriangleSplitter, TriangleSplitter)()
        container.Register(Of INodeCleaner, NodeCleaner)()
        container.Register(Of IGridSmoother, GridSmoother)()
        container.Register(Of IEmptySpaceBuilder, EmptySpaceBuilder)()
        container.Register(Of IDelaunay, Delaunay)()
        container.Register(Of IScaler, Scaler)()
        container.Register(Of IRedistributor, Redistributor)()
        container.Register(Of IGridBuilder, GridBuilder)()
        container.Register(Of BaseNodeFactory, NodeFactory)()

        'data layer
        container.Register(Of IDataPreparer, DataPreparer)()
        container.Register(Of IDataAccessService, DataAccessService)()

        'optional verification
        'container.Verify()

    End Sub

End Module