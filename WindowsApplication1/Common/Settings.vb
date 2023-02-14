Namespace AppSettings
    Public Class Settings : Inherits BaseSettings : Implements ISettings

#Region "constructor"
        Public Sub New()
        End Sub
#End Region

#Region "fields"
        'Inherits protected variables from basesettings.vb
#End Region

#Region "public properties"
        'on read takes the string and converts to specific type
        'on write takes a specific type and converts to a string
        'public property filename is inherited from basesetting.vb and is not overridden
        Public Overrides Property Width As Integer Implements ISettings.Width
            Get
                Return CInt(_width)
            End Get
            Set(value As Integer)
                _width = CStr(value)
            End Set
        End Property
        Public Overrides Property Height As Integer Implements ISettings.Height
            Get
                Return CInt(_height)
            End Get
            Set(value As Integer)
                _height = CStr(value)
            End Set
        End Property
        Public Overrides Property Scale As Short Implements ISettings.Scale
            Get
                Return CShort(_scale)
            End Get
            Set(value As Short)
                _scale = CStr(value)
            End Set
        End Property
        Public Overrides Property Layers As Short Implements ISettings.Layers
            Get
                Return CShort(_layers)
            End Get
            Set(value As Short)
                _layers = CStr(value)
            End Set
        End Property
        Public Overrides Property Cellheight As Short Implements ISettings.Cellheight
            Get
                Return CShort(_cellheight)
            End Get
            Set(value As Short)
                _cellheight = CStr(value)
            End Set
        End Property
        Public Overrides Property Cellfactor As Double Implements ISettings.Cellfactor
            Get
                Return CDbl(_cellfactor)
            End Get
            Set(value As Double)
                _cellfactor = CDbl(value)
            End Set
        End Property
        Public Overrides Property Nodetrade As Short Implements ISettings.Nodetrade
            Get
                Return CShort(_nodetrade)
            End Get
            Set(value As Short)
                _nodetrade = CStr(value)
            End Set
        End Property
        Public Overrides Property Expansionpower As Double Implements ISettings.Expansionpower
            Get
                Return CDbl(_expansionpower)
            End Get
            Set(value As Double)
                _expansionpower = CDbl(value)
            End Set
        End Property
        Public Overrides Property Offset As Short Implements ISettings.Offset
            Get
                Return CShort(_offset)
            End Get
            Set(value As Short)
                _offset = CStr(value)
            End Set
        End Property
        Public Overrides Property Smoothingcycles As Short Implements ISettings.Smoothingcycles
            Get
                Return CShort(_smoothingcycles)
            End Get
            Set(value As Short)
                _smoothingcycles = CStr(value)
            End Set
        End Property
        Public Overrides Property Airfoilnodes As Short Implements ISettings.Airfoilnodes
            Get
                Return CShort(_airfoilnodes)
            End Get
            Set(value As Short)
                _airfoilnodes = CStr(value)
            End Set
        End Property
        Public Overrides Property Filename As String Implements ISettings.Filename
            Get
                Return _filename
            End Get
            Set(value As String)
                _filename = value
            End Set
        End Property

#End Region

    End Class
End Namespace
