<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTextaCaixatextoVB
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
        Me.btnValorInteiro = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.lblTextBoxNormal = New System.Windows.Forms.Label()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnValorInteiro
        '
        Me.btnValorInteiro.Location = New System.Drawing.Point(129, 9)
        Me.btnValorInteiro.Name = "btnValorInteiro"
        Me.btnValorInteiro.Size = New System.Drawing.Size(169, 54)
        Me.btnValorInteiro.TabIndex = 13
        Me.btnValorInteiro.Text = "Put the value ""integer"" in Normal TextBox - Coloca o valor ""Inteiro"" na TextBox N" &
    "ormal"
        Me.btnValorInteiro.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(6, 66)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(289, 54)
        Me.label1.TabIndex = 12
        Me.label1.Text = "Put some clsCaixatexto inherited from here (pick of the list of the ToolBox):  - " &
    " Coloque algumas clsCaixaTexto Herdadas aqui (pegue da na lista da ToolBox):"
        '
        'lblTextBoxNormal
        '
        Me.lblTextBoxNormal.Location = New System.Drawing.Point(9, 9)
        Me.lblTextBoxNormal.Name = "lblTextBoxNormal"
        Me.lblTextBoxNormal.Size = New System.Drawing.Size(114, 31)
        Me.lblTextBoxNormal.TabIndex = 11
        Me.lblTextBoxNormal.Text = "Normal TextBox - TextBox Normal:"
        '
        'textBox1
        '
        Me.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textBox1.Location = New System.Drawing.Point(12, 43)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(111, 20)
        Me.textBox1.TabIndex = 10
        Me.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmTextaCaixatextoVB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(306, 313)
        Me.Controls.Add(Me.btnValorInteiro)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.lblTextBoxNormal)
        Me.Controls.Add(Me.textBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTextaCaixatextoVB"
        Me.ShowIcon = False
        Me.Text = "Test VB Text Box - Testa Caixa Texto VB"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnValorInteiro As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents lblTextBoxNormal As System.Windows.Forms.Label
    Private WithEvents textBox1 As System.Windows.Forms.TextBox
End Class
