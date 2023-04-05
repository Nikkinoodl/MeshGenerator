Namespace Models
    Public MustInherit Class BaseTriangle

#Region "public properties"
        Public Property Id As Integer
        Public Property V1 As Integer  'each vertex is a node
        Public Property V2 As Integer
        Public Property V3 As Integer
        Public Property AvgX As Double  'avgx and avgy are x and y coords of triangle center
        Public Property AvgY As Double
        Public Property L1 As Double     'length of side opposite v1
        Public Property L2 As Double
        Public Property L3 As Double
        Public Property S1 As String    'used to flag if surface, boundary or interior side
        Public Property S2 As String
        Public Property S3 As String
        Public Property Complete As Boolean
#End Region

    End Class
End Namespace
