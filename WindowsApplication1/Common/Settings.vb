Namespace AppSettings
    Public Class Settings : Inherits BaseSettings : Implements ISettings

#Region "constructor"
        Public Sub New()
        End Sub
#End Region

#Region "fields"
        'Inherited from BaseSettings
#End Region

#Region "public properties"
        'on read takes the string and converts to specific type
        'on write takes a specific type and converts to a string
        '
        Public Overrides Property Width As Integer Implements ISettings.Width
            Get
                Return _width
            End Get
            Set(value As Integer)
                _width = CStr(value)
            End Set
        End Property
        Public Overrides Property Height As Integer Implements ISettings.Height
            Get
                Return _height
            End Get
            Set(value As Integer)
                _height = CStr(value)
            End Set
        End Property
        Public Overrides Property Scale As Short Implements ISettings.Scale
            Get
                Return _scale
            End Get
            Set(value As Short)
                _scale = CStr(value)
            End Set
        End Property
        Public Overrides Property Layers As Short Implements ISettings.Layers
            Get
                Return _layers
            End Get
            Set(value As Short)
                _layers = CStr(value)
            End Set
        End Property
        Public Overrides Property Cellheight As Short Implements ISettings.Cellheight
            Get
                Return _cellheight
            End Get
            Set(value As Short)
                _cellheight = CStr(value)
            End Set
        End Property
        Public Overrides Property Cellfactor As Double Implements ISettings.Cellfactor
            Get
                Return _cellfactor
            End Get
            Set(value As Double)
                _cellfactor = value
            End Set
        End Property
        Public Overrides Property Nodetrade As Short Implements ISettings.Nodetrade
            Get
                Return _nodetrade
            End Get
            Set(value As Short)
                _nodetrade = CStr(value)
            End Set
        End Property
        Public Overrides Property Expansionpower As Double Implements ISettings.Expansionpower
            Get
                Return _expansionpower
            End Get
            Set(value As Double)
                _expansionpower = value
            End Set
        End Property
        Public Overrides Property Offset As Short Implements ISettings.Offset
            Get
                Return _offset
            End Get
            Set(value As Short)
                If value < 2 Then
                    MessageBox.Show(Constants.MSGMINOFFSET)
                    value = 2
                End If
                _offset = value
            End Set
        End Property
        Public Overrides Property Smoothingcycles As Short Implements ISettings.Smoothingcycles
            Get
                Return _smoothingcycles
            End Get
            Set(value As Short)
                If value < 1 Then
                    MessageBox.Show(Constants.MSGSMOOTHINGCYCLES)
                    value = 1
                End If
                _smoothingcycles = value
            End Set
        End Property
        Public Overrides Property Airfoilnodes As Short Implements ISettings.Airfoilnodes
            Get
                Return _airfoilnodes
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
