<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmWHO
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
        Me.grdDisplay = New UJGrid.UJGrid()
        Me.btnCountry = New System.Windows.Forms.Button()
        Me.btnCalcInfected = New System.Windows.Forms.Button()
        Me.btnCalLethality = New System.Windows.Forms.Button()
        Me.btnFileSave = New System.Windows.Forms.Button()
        Me.btnGuidelines = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'grdDisplay
        '
        Me.grdDisplay.AutoSize = True
        Me.grdDisplay.FixedCols = 1
        Me.grdDisplay.FixedRows = 1
        Me.grdDisplay.Location = New System.Drawing.Point(194, 12)
        Me.grdDisplay.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grdDisplay.Name = "grdDisplay"
        Me.grdDisplay.Scrollbars = System.Windows.Forms.ScrollBars.Both
        Me.grdDisplay.Size = New System.Drawing.Size(578, 414)
        Me.grdDisplay.TabIndex = 0
        '
        'btnCountry
        '
        Me.btnCountry.Location = New System.Drawing.Point(12, 39)
        Me.btnCountry.Name = "btnCountry"
        Me.btnCountry.Size = New System.Drawing.Size(156, 23)
        Me.btnCountry.TabIndex = 1
        Me.btnCountry.Text = "Country Information"
        Me.btnCountry.UseVisualStyleBackColor = True
        '
        'btnCalcInfected
        '
        Me.btnCalcInfected.Location = New System.Drawing.Point(12, 85)
        Me.btnCalcInfected.Name = "btnCalcInfected"
        Me.btnCalcInfected.Size = New System.Drawing.Size(156, 23)
        Me.btnCalcInfected.TabIndex = 2
        Me.btnCalcInfected.Text = "Calculate Population Infected"
        Me.btnCalcInfected.UseVisualStyleBackColor = True
        '
        'btnCalLethality
        '
        Me.btnCalLethality.Location = New System.Drawing.Point(12, 129)
        Me.btnCalLethality.Name = "btnCalLethality"
        Me.btnCalLethality.Size = New System.Drawing.Size(156, 23)
        Me.btnCalLethality.TabIndex = 3
        Me.btnCalLethality.Text = "Calculate Lethality"
        Me.btnCalLethality.UseVisualStyleBackColor = True
        '
        'btnFileSave
        '
        Me.btnFileSave.Location = New System.Drawing.Point(12, 218)
        Me.btnFileSave.Name = "btnFileSave"
        Me.btnFileSave.Size = New System.Drawing.Size(156, 23)
        Me.btnFileSave.TabIndex = 4
        Me.btnFileSave.Text = "Save File"
        Me.btnFileSave.UseVisualStyleBackColor = True
        '
        'btnGuidelines
        '
        Me.btnGuidelines.Location = New System.Drawing.Point(12, 170)
        Me.btnGuidelines.Name = "btnGuidelines"
        Me.btnGuidelines.Size = New System.Drawing.Size(156, 23)
        Me.btnGuidelines.TabIndex = 5
        Me.btnGuidelines.Text = "Guidelines"
        Me.btnGuidelines.UseVisualStyleBackColor = True
        '
        'frmWHO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnGuidelines)
        Me.Controls.Add(Me.btnFileSave)
        Me.Controls.Add(Me.btnCalLethality)
        Me.Controls.Add(Me.btnCalcInfected)
        Me.Controls.Add(Me.btnCountry)
        Me.Controls.Add(Me.grdDisplay)
        Me.Name = "frmWHO"
        Me.Text = "World Health Organization Country Disease Records"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grdDisplay As UJGrid.UJGrid
    Friend WithEvents btnCountry As Button
    Friend WithEvents btnCalcInfected As Button
    Friend WithEvents btnCalLethality As Button
    Friend WithEvents btnFileSave As Button
    Friend WithEvents btnGuidelines As Button
End Class
