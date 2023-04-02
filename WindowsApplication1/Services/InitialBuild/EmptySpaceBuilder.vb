Imports MeshGeneration.Factories

Namespace Services
    Public Class EmptySpaceBuilder : Implements IEmptySpaceBuilder

        Private ReadOnly factory As INodeFactory

        Public Sub New(factory As INodeFactory)

            Me.factory = factory

        End Sub

        Public Sub BuildEmptySpace(farfield As Object) Implements IEmptySpaceBuilder.BuildEmptySpace
            'creates a template for a mesh in an empty space that does not contain an airfoil
            'for best results use an asymmetrical grid

            With factory

                .SetupEmptySpaceBoundary(farfield)
                .SetupEmptySpaceTriangles()

                'use this for testing with nodes 0,1,2
                '.AddTriangle(0, 0, 1, 2, "boundary", "boundary", "boundary")

            End With
        End Sub

    End Class
End Namespace