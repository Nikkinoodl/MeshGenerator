Imports MeshGeneration.Models

Namespace Services
    Public Class AirfoilNodeReader : Inherits Base : Implements IAirfoilNodeReader
        Public Sub New()

        End Sub

        Public Sub ReadAirfoilNodes(ByVal filename As String) Implements IAirfoilNodeReader.ReadAirfoilNodes

            'reads a list of nodes from a flat file that will be used to model an object
            'no error checking is performed during the read

            Dim factory As New NodeFactory()
            Dim n As Integer
            Dim objReader As New IO.StreamReader(filename)
            Dim thisstr As String
            'Dim unused(0 To 2) As String

            n = 0   'start loop at zero so that list index will match .id

            'read airfoil data and assign coordinates to nodes
            '
            While objReader.Peek <> -1

                thisstr = objReader.ReadLine()
                Dim coord As String() = Split(thisstr, ",")

                'create the node
                factory.AddAirfoilNode(n, coord(0), coord(1))

                n += 1

            End While

        End Sub
    End Class
End Namespace