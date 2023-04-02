Imports MeshGeneration.Data

Namespace Services
    Public Class Initializer
        Implements IInitializer

        Private ReadOnly data As IDataPreparer

        Public Sub New(dataPreparer As IDataPreparer)
            Me.data = dataPreparer
        End Sub

        Public Sub DataPreparer() Implements IInitializer.DataPreparer

            data.PrepareRepository()

        End Sub

    End Class
End Namespace