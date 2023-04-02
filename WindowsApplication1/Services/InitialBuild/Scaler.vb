Imports MeshGeneration.Models
Imports MeshGeneration.Data

Namespace Services
    Public Class Scaler : Implements IScaler

        Private ReadOnly data As IDataAccessService

        Public Sub New(data As IDataAccessService)

            Me.data = data

        End Sub


        Public Sub AirfoilScaler(farfield As Object) Implements IScaler.AirfoilScaler
            'scales the airfoil nodes to fit the chosen farfield parameters
            'and centers the airfoil in the farfield

            Dim offsetx, offsety, scale As Short
            Dim orientation As SByte

            offsetx = (farfield.width - farfield.scale) / 2
            offsety = farfield.height / 2
            scale = farfield.scale
            orientation = 1         'flips the airfoil Y-axis depending on the coordinate system

            For Each node In data.Nodelist
                If node.X = 1.0 And node.Y = 0.0 Then
                    node.Te_posn = True
                Else
                    node.Te_posn = False
                End If
                node.X = node.X * scale + offsetx
                node.Y = node.Y * scale * orientation + offsety
            Next
        End Sub
    End Class
End Namespace