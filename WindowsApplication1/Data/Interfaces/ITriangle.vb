Public Interface ITriangle

    Property Id As Integer
    Property V1 As Integer
    Property V2 As Integer
    Property V3 As Integer

    Property AvgX As Double
    Property AvgY As Double
    Property L1 As Double
    Property L2 As Double
    Property L3 As Double
    Property S1 As String
    Property S2 As String
    Property S3 As String
    Property Complete As Boolean

    ReadOnly Property Area As Double

End Interface
