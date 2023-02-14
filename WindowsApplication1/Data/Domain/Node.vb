Imports MeshGeneration.Data

Namespace Models
    Public Class Node : Inherits BaseNode

#Region "constructor"
        Public Sub New()
            Repository.Nodelist.Add(Me)
        End Sub
#End Region

#Region "constructor overloads"
        Public Sub New(ByVal this_id As Integer, ByVal this_x As Double, ByVal this_y As Double)
            Id = this_id
            X = this_x
            Y = this_y
            Surface = False
            Boundary = False
            Repository.Nodelist.Add(Me)
        End Sub

        Public Sub New(ByVal this_id As Integer, ByVal this_x As Double, ByVal this_y As Double, ByVal this_surface As Boolean, ByVal this_boundary As Boolean)
            Id = this_id
            X = this_x
            Y = this_y
            Surface = this_surface
            Boundary = this_boundary
            Repository.Nodelist.Add(Me)
        End Sub
#End Region

    End Class
End Namespace