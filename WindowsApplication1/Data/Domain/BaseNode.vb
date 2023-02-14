Namespace Models
    Public MustInherit Class BaseNode : Inherits Base : Implements INode

#Region "public properties"
        Public Property Id As Integer Implements INode.Id
        Public Property X As Double Implements INode.X
        Public Property Y As Double Implements INode.Y
        Public Property Surface As Boolean Implements INode.Surface
        Public Property Boundary As Boolean Implements INode.Boundary
        Public Property Te_posn As Boolean Implements INode.Te_posn
#End Region

    End Class
End Namespace