Imports MeshGeneration.Data

Namespace Models
    Public Class UpdateTriangle : Inherits Triangle
        'when triangle t in the trianglelist must be replaced

        Private _t As Integer

        Public Sub New()

        End Sub

        Public Sub New(ByVal this_t As Integer, ByVal this_v1 As Integer, ByVal this_v2 As Integer, ByVal this_v3 As Integer,
                       ByVal this_s1 As String, ByVal this_s2 As String, ByVal this_s3 As String)

            Dim this As ITriangle

            this = Repository.Trianglelist(this_t)

            this.Id = this_t
            this.V1 = this_v1
            this.V2 = this_v2
            this.V3 = this_v3
            this.Complete = True
            this.S1 = this_s1
            this.S2 = this_s2
            this.S3 = this_s3

            '_t = this_t
            'Id = this_t
            'V1 = this_v1
            'V2 = this_v2
            'V3 = this_v3
            'Me.Complete = True
            'S1 = this_s1
            'S2 = this_s2
            'S3 = this_s3

            'Repository.Trianglelist.Remove(Repository.Trianglelist(_t))
            'Repository.Trianglelist.Insert(_t, Me)

        End Sub

    End Class
End Namespace
