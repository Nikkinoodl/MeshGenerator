Imports System.Xml
Imports MeshGeneration.AppSettings.Constants

Namespace AppSettings
    Public MustInherit Class BaseSettings : Implements ISettings
        Protected _width As String
        Protected _height As String
        Protected _scale As String
        Protected _layers As String
        Protected _cellheight As String
        Protected _cellfactor As String
        Protected _nodetrade As String
        Protected _expansionpower As String
        Protected _offset As String
        Protected _smoothingcycles As String
        Protected _airfoilnodes As String
        Protected _filename As String

        Public Overridable Property Width As Integer Implements ISettings.Width
            Get
                Return _width
            End Get
            Set(value As Integer)
                _width = value
            End Set
        End Property
        Public Overridable Property Height As Integer Implements ISettings.Height
            Get
                Return _height
            End Get
            Set(value As Integer)
                _height = value
            End Set
        End Property
        Public Overridable Property Scale As Short Implements ISettings.Scale
            Get
                Return _scale
            End Get
            Set(value As Short)
                _scale = value
            End Set
        End Property
        Public Overridable Property Layers As Short Implements ISettings.Layers
            Get
                Return _layers
            End Get
            Set(value As Short)
                _layers = value
            End Set
        End Property
        Public Overridable Property Cellheight As Short Implements ISettings.Cellheight
            Get
                Return _cellheight
            End Get
            Set(value As Short)
                _cellheight = value
            End Set
        End Property
        Public Overridable Property Cellfactor As Double Implements ISettings.Cellfactor
            Get
                Return _cellfactor
            End Get
            Set(value As Double)
                _cellfactor = value
            End Set
        End Property
        Public Overridable Property Nodetrade As Short Implements ISettings.Nodetrade
            Get
                Return _nodetrade
            End Get
            Set(value As Short)
                _nodetrade = value
            End Set
        End Property
        Public Overridable Property Expansionpower As Double Implements ISettings.Expansionpower
            Get
                Return _expansionpower
            End Get
            Set(value As Double)
                _expansionpower = value
            End Set
        End Property
        Public Overridable Property Offset As Short Implements ISettings.Offset
            Get
                Return _offset
            End Get
            Set(value As Short)
                If value < 2 Then
                    MessageBox.Show(Constants.MsgMinOffset)
                    value = 2
                End If
                _offset = value
            End Set
        End Property
        Public Overridable Property Smoothingcycles As Short Implements ISettings.Smoothingcycles
            Get
                Return _smoothingcycles
            End Get
            Set(value As Short)
                If value < 1 Then
                    MessageBox.Show(Constants.MsgSmoothingCycles)
                    value = 1
                End If
                _smoothingcycles = value
            End Set
        End Property
        Public Overridable Property Airfoilnodes As Short Implements ISettings.Airfoilnodes
            Get
                Return _airfoilnodes
            End Get
            Set(value As Short)
                _airfoilnodes = value
            End Set
        End Property
        Public Overridable Property Filename As String Implements ISettings.Filename
            Get
                Return _filename
            End Get
            Set(value As String)
                _filename = value
            End Set
        End Property

#Region "methods"
        Public Sub CreateSettings() Implements ISettings.CreateSettings

            'creates a settings.xml file if one doesn't already exist
            If IO.File.Exists("Settings.xml") = False Then

                Dim doc As New XmlDocument()
                Dim writer As XmlWriter

                writer = doc.CreateNavigator().AppendChild()

                With writer
                    .WriteStartDocument()
                    .WriteStartElement("settings")
                    .WriteElementString("width", "1000")
                    .WriteElementString("height", "600")
                    .WriteElementString("scale", "500")
                    .WriteElementString("layers", "4")
                    .WriteElementString("cellheight", "40")
                    .WriteElementString("cellfactor", "0.95")
                    .WriteElementString("nodetrade", "4")
                    .WriteElementString("expansionpower", "0.3")
                    .WriteElementString("offset", "2")
                    .WriteElementString("smoothingcycles", "8")
                    .WriteElementString("filename", "C:\users\simon\OneDrive\documents\Apps\Airfoil.csv")
                    .WriteEndElement()
                    .WriteEndDocument()
                    .Close()
                End With
                doc.Save("Settings.xml")
            End If

            'read settings from settings.xml
            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load("Settings.xml")

            Dim nodelist As XmlNodeList = xmlDoc.SelectNodes("settings")

            For Each childnode As XmlNode In nodelist
                _width = childnode.SelectSingleNode("width").InnerText
                _height = childnode.SelectSingleNode("height").InnerText
                _scale = childnode.SelectSingleNode("scale").InnerText
                _layers = childnode.SelectSingleNode("layers").InnerText
                _cellheight = childnode.SelectSingleNode("cellheight").InnerText
                _cellfactor = childnode.SelectSingleNode("cellfactor").InnerText
                _nodetrade = childnode.SelectSingleNode("nodetrade").InnerText
                _expansionpower = childnode.SelectSingleNode("expansionpower").InnerText
                _offset = childnode.SelectSingleNode("offset").InnerText
                _smoothingcycles = childnode.SelectSingleNode("smoothingcycles").InnerText
                _filename = childnode.SelectSingleNode("filename").InnerText
            Next
        End Sub

        'Write settings to the settings.xml file
        Public Sub WriteSettings(ByVal farfield As Object) Implements ISettings.WriteSettings
            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load("Settings.xml")

            Dim nodelist As XmlNodeList = xmlDoc.SelectNodes("settings")

            For Each childnode As XmlNode In nodelist
                childnode.SelectSingleNode("width").InnerText = farfield.width
                childnode.SelectSingleNode("height").InnerText = farfield.height
                childnode.SelectSingleNode("scale").InnerText = farfield.scale
                childnode.SelectSingleNode("layers").InnerText = farfield.layers
                childnode.SelectSingleNode("cellheight").InnerText = farfield.cellheight
                childnode.SelectSingleNode("cellfactor").InnerText = farfield.cellfactor
                childnode.SelectSingleNode("nodetrade").InnerText = farfield.nodetrade
                childnode.SelectSingleNode("expansionpower").InnerText = farfield.expansionpower
                childnode.SelectSingleNode("offset").InnerText = farfield.offset
                childnode.SelectSingleNode("smoothingcycles").InnerText = farfield.smoothingcycles
                childnode.SelectSingleNode("filename").InnerText = farfield.filename
            Next

            xmlDoc.Save("Settings.xml")

        End Sub
#End Region

    End Class
End Namespace