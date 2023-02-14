Namespace Models
    Public MustInherit Class BaseTriangle : Inherits Base : Implements ITriangle

#Region "public properties"
        Public Property Id As Integer Implements ITriangle.Id
        Public Property V1 As Integer Implements ITriangle.V1    'each vertex is a node
        Public Property V2 As Integer Implements ITriangle.V2
        Public Property V3 As Integer Implements ITriangle.V3
        Public Property AvgX As Double Implements ITriangle.AvgX  'avgx and avgy are x and y coords of triangle center
        Public Property AvgY As Double Implements ITriangle.AvgY
        Public Property L1 As Double Implements ITriangle.L1      'length of side opposite v1
        Public Property L2 As Double Implements ITriangle.L2
        Public Property L3 As Double Implements ITriangle.L3
        Public Property S1 As String Implements ITriangle.S1       'used to flag if surface, boundary or interior side
        Public Property S2 As String Implements ITriangle.S2
        Public Property S3 As String Implements ITriangle.S3
        Public Property Complete As Boolean Implements ITriangle.Complete
        Public ReadOnly Property Area As Double Implements ITriangle.Area
#End Region

    End Class
End Namespace
