Imports MeshGeneration.Data

Namespace Models
    Public Class BoundaryNode : Inherits BaseNode
        'Class for all nodes that are on the boundary of the farfield

        'constructor
        Public Sub New()
            Repository.Nodelist.Add(Me)
        End Sub

        'constructor overloads
        Public Sub New(ByVal this_id As Integer, ByVal this_x As Double, ByVal this_y As Double)
            Id = this_id
            X = this_x
            Y = this_y
            Surface = False
            Boundary = True
            Repository.Nodelist.Add(Me)
        End Sub

    End Class
End Namespace
