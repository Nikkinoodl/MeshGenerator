Namespace AppSettings
    Public Interface ISettings
        Property Width As Integer
        Property Height As Integer
        Property Scale As Short
        Property Layers As Short
        Property Cellheight As Short
        Property Cellfactor As Double
        Property Nodetrade As Short
        Property Expansionpower As Double
        Property Offset As Short
        Property Smoothingcycles As Short
        Property Airfoilnodes As Short
        Property Filename As String

        Sub CreateSettings()
        Sub WriteSettings(ByVal farfield As Object)

    End Interface
End Namespace