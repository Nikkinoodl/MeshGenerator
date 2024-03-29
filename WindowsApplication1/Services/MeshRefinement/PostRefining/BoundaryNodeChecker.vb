﻿Imports MeshGeneration.Data

Namespace Services
    Public Class BoundaryNodeChecker : Implements IBoundaryNodeChecker

        Private ReadOnly data As IDataAccessService

        Public Sub New(data As IDataAccessService)

            Me.data = data

        End Sub

        Public Sub CheckBoundaryNodes(farfield As Object) Implements IBoundaryNodeChecker.CheckBoundaryNodes
            'fixes occasional blips where boundary nodes can be misclassified, leading to problems
            'with the smoothing cycle. this is a legacy from the early stages of development

            data.CheckBoundaryNode(farfield)

        End Sub

    End Class
End Namespace