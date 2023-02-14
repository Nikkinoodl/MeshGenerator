Namespace AppSettings
    Public Class Constants
        'Hard coded constants used throughout the application are defined here

        Public Const DialogTitle As String = "Select a File"
        Public Const FileLocation As String = "C:\Users\Simon\OneDrive\Documents\Apps"
        Public Const MsgComplete As String = "Complete"
        Public Const MsgInitialize As String = "Initializing"
        Public Const MsgDelaunay As String = "Starting Delaunay Trianguation"
        Public Const MsgDivide As String = "Refining Grid"
        Public Const MsgLoaded As String = "Data Loaded From File"
        Public Const MsgConstruct As String = "Building Grid"
        Public Const MsgRedistribute As String = "Redistributing Boundary Edge Nodes"
        Public Const MsgSmooth As String = "Performing Laplace Smoothing"
        Public Const MsgNumNodes As String = "The value of nodetrade exceeds the number of nodes on the boundary side. Setting to maximum allowed value."
        Public Const MsgOffset As String = "The value of offset exceeds the number of nodes in a layer. Reducing to maximum allowed value."
        Public Const MsgMinOffset As String = "The value of offset must be at least 2"
        Public Const MsgSmoothingCycles As String = "There must be at least 1 smoothing cycle if used. Recommend a minimum of 8"
        Public Const MsgFileError As String = "There was an error reading the file"
        Public Const MsgOverlap As String = "There are overlapping nodes"
    End Class
End Namespace