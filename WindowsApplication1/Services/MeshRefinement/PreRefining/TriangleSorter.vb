Imports MeshGeneration.Data

Namespace Services
    Public Class TriangleSorter : Implements ITriangleSorter

        Private ReadOnly data As IDataAccessService

        Public Sub New(data As IDataAccessService)

            Me.data = data

        End Sub

        Public Sub SortTriangles() Implements ITriangleSorter.SortTriangles
            'helps to set a calc order for the mesh, working from left to right

            data.SortTriangles()

        End Sub

    End Class
End Namespace