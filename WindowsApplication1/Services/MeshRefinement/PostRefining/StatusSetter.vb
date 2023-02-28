Imports MeshGeneration.Models
Imports MeshGeneration.Data

Namespace Services
    Public Class StatusSetter : Implements IStatusSetter

        Private ReadOnly data As IDataAccessService

        Public Sub New(ByVal data As IDataAccessService)

            Me.data = data

        End Sub

        Public Sub SetCompleteStatus() Implements IStatusSetter.SetCompleteStatus
            'resets the status of each element of the mesh

            For Each triangle In data.Trianglelist

                triangle.Complete = False

            Next
        End Sub

    End Class
End Namespace