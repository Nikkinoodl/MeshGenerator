Namespace Models
    Public Interface INode
        Property Id As Integer
        Property X As Double
        Property Y As Double
        Property Surface As Boolean    'True if this node sits on the airfoil surface
        Property Boundary As Boolean   'True if this node sits on the calc domain boundary
        Property Te_posn As Boolean
    End Interface
End Namespace