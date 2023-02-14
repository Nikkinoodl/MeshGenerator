Imports MeshGeneration.Data

Namespace Services
    Public Class Initializer
        Implements IInitializer

        Private data As IDataPreparer

        Public Sub New(ByVal dataPreparer As IDataPreparer)
            Me.data = dataPreparer
        End Sub

        Public Sub DataPreparer() Implements IInitializer.DataPreparer

            data.PrepareRepository()

        End Sub

    End Class
End Namespace