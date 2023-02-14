<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TextBoxFileName = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBoxSmoothingCycles = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBoxStatus = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxOffset = New System.Windows.Forms.TextBox()
        Me.TextBoxExpansionPower = New System.Windows.Forms.TextBox()
        Me.TextBoxNodeTrade = New System.Windows.Forms.TextBox()
        Me.TextBoxCellFactor = New System.Windows.Forms.TextBox()
        Me.TextBoxCellHeight = New System.Windows.Forms.TextBox()
        Me.TextBoxScale = New System.Windows.Forms.TextBox()
        Me.TextBoxHeight = New System.Windows.Forms.TextBox()
        Me.TextBoxWidth = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxLayers = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GlControl1 = New OpenTK.GLControl()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.TextBoxFileName)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.TextBoxSmoothingCycles)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.TextBoxStatus)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TextBoxOffset)
        Me.Panel1.Controls.Add(Me.TextBoxExpansionPower)
        Me.Panel1.Controls.Add(Me.TextBoxNodeTrade)
        Me.Panel1.Controls.Add(Me.TextBoxCellFactor)
        Me.Panel1.Controls.Add(Me.TextBoxCellHeight)
        Me.Panel1.Controls.Add(Me.TextBoxScale)
        Me.Panel1.Controls.Add(Me.TextBoxHeight)
        Me.Panel1.Controls.Add(Me.TextBoxWidth)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TextBoxLayers)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(1196, 13)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(310, 622)
        Me.Panel1.TabIndex = 0
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(208, 496)
        Me.Button7.Margin = New System.Windows.Forms.Padding(4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(96, 28)
        Me.Button7.TabIndex = 31
        Me.Button7.Text = "Redistribute"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(7, 405)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(116, 28)
        Me.Button6.TabIndex = 30
        Me.Button6.Text = "Empty Space"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(25, 324)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(113, 28)
        Me.Button5.TabIndex = 29
        Me.Button5.Text = "Open File"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TextBoxFileName
        '
        Me.TextBoxFileName.Location = New System.Drawing.Point(160, 327)
        Me.TextBoxFileName.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxFileName.Name = "TextBoxFileName"
        Me.TextBoxFileName.Size = New System.Drawing.Size(143, 22)
        Me.TextBoxFileName.TabIndex = 28
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(112, 496)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(87, 28)
        Me.Button4.TabIndex = 27
        Me.Button4.Text = "Smooth"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(7, 532)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(97, 28)
        Me.Button3.TabIndex = 26
        Me.Button3.Text = "Refine"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(112, 532)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 28)
        Me.Button2.TabIndex = 25
        Me.Button2.Text = "Delaunay"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(19, 294)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 17)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Smoothing Cycles"
        '
        'TextBoxSmoothingCycles
        '
        Me.TextBoxSmoothingCycles.Location = New System.Drawing.Point(160, 294)
        Me.TextBoxSmoothingCycles.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxSmoothingCycles.Name = "TextBoxSmoothingCycles"
        Me.TextBoxSmoothingCycles.Size = New System.Drawing.Size(68, 22)
        Me.TextBoxSmoothingCycles.TabIndex = 23
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(21, 569)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 17)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Status"
        '
        'TextBoxStatus
        '
        Me.TextBoxStatus.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxStatus.CausesValidation = False
        Me.TextBoxStatus.Location = New System.Drawing.Point(7, 588)
        Me.TextBoxStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxStatus.Name = "TextBoxStatus"
        Me.TextBoxStatus.ReadOnly = True
        Me.TextBoxStatus.Size = New System.Drawing.Size(240, 15)
        Me.TextBoxStatus.TabIndex = 21
        Me.TextBoxStatus.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(93, 262)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 17)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Offset"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 230)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 17)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Expansion Power"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(59, 198)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 17)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Node trade"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(63, 166)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 17)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Cell Factor"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(63, 134)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 17)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Cell Height"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(95, 70)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 17)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Scale"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(89, 38)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Height"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(93, 5)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Width"
        '
        'TextBoxOffset
        '
        Me.TextBoxOffset.Location = New System.Drawing.Point(160, 262)
        Me.TextBoxOffset.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxOffset.Name = "TextBoxOffset"
        Me.TextBoxOffset.Size = New System.Drawing.Size(68, 22)
        Me.TextBoxOffset.TabIndex = 9
        '
        'TextBoxExpansionPower
        '
        Me.TextBoxExpansionPower.Location = New System.Drawing.Point(163, 230)
        Me.TextBoxExpansionPower.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxExpansionPower.Name = "TextBoxExpansionPower"
        Me.TextBoxExpansionPower.Size = New System.Drawing.Size(65, 22)
        Me.TextBoxExpansionPower.TabIndex = 8
        '
        'TextBoxNodeTrade
        '
        Me.TextBoxNodeTrade.Location = New System.Drawing.Point(160, 198)
        Me.TextBoxNodeTrade.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxNodeTrade.Name = "TextBoxNodeTrade"
        Me.TextBoxNodeTrade.Size = New System.Drawing.Size(68, 22)
        Me.TextBoxNodeTrade.TabIndex = 7
        '
        'TextBoxCellFactor
        '
        Me.TextBoxCellFactor.Location = New System.Drawing.Point(160, 166)
        Me.TextBoxCellFactor.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxCellFactor.Name = "TextBoxCellFactor"
        Me.TextBoxCellFactor.Size = New System.Drawing.Size(68, 22)
        Me.TextBoxCellFactor.TabIndex = 6
        '
        'TextBoxCellHeight
        '
        Me.TextBoxCellHeight.Location = New System.Drawing.Point(160, 134)
        Me.TextBoxCellHeight.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxCellHeight.Name = "TextBoxCellHeight"
        Me.TextBoxCellHeight.Size = New System.Drawing.Size(68, 22)
        Me.TextBoxCellHeight.TabIndex = 5
        '
        'TextBoxScale
        '
        Me.TextBoxScale.Location = New System.Drawing.Point(160, 70)
        Me.TextBoxScale.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxScale.Name = "TextBoxScale"
        Me.TextBoxScale.Size = New System.Drawing.Size(68, 22)
        Me.TextBoxScale.TabIndex = 3
        '
        'TextBoxHeight
        '
        Me.TextBoxHeight.Location = New System.Drawing.Point(160, 38)
        Me.TextBoxHeight.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxHeight.Name = "TextBoxHeight"
        Me.TextBoxHeight.Size = New System.Drawing.Size(68, 22)
        Me.TextBoxHeight.TabIndex = 2
        '
        'TextBoxWidth
        '
        Me.TextBoxWidth.Location = New System.Drawing.Point(160, 5)
        Me.TextBoxWidth.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxWidth.Name = "TextBoxWidth"
        Me.TextBoxWidth.Size = New System.Drawing.Size(68, 22)
        Me.TextBoxWidth.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(89, 102)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Layers"
        '
        'TextBoxLayers
        '
        Me.TextBoxLayers.Location = New System.Drawing.Point(160, 102)
        Me.TextBoxLayers.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxLayers.Name = "TextBoxLayers"
        Me.TextBoxLayers.Size = New System.Drawing.Size(68, 22)
        Me.TextBoxLayers.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(7, 496)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(97, 28)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Build"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GlControl1
        '
        Me.GlControl1.BackColor = System.Drawing.Color.White
        Me.GlControl1.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.GlControl1.Location = New System.Drawing.Point(13, 13)
        Me.GlControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GlControl1.Name = "GlControl1"
        Me.GlControl1.Size = New System.Drawing.Size(387, 223)
        Me.GlControl1.TabIndex = 1
        Me.GlControl1.VSync = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1651, 641)
        Me.Controls.Add(Me.GlControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MainForm"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBoxLayers As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxScale As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxHeight As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxWidth As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCellFactor As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCellHeight As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxOffset As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxExpansionPower As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNodeTrade As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBoxStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSmoothingCycles As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TextBoxFileName As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents GlControl1 As OpenTK.GLControl
End Class
