﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Padron_Clientes
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Padron_Clientes))
        Me.cboExcel = New System.Windows.Forms.ComboBox()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.cboSector = New System.Windows.Forms.ComboBox()
        Me.btnMostrarPadron = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.btnCargarExcel = New System.Windows.Forms.Button()
        Me.dgvmedidor = New System.Windows.Forms.DataGridView()
        CType(Me.dgvmedidor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboExcel
        '
        Me.cboExcel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExcel.FormattingEnabled = True
        Me.cboExcel.Location = New System.Drawing.Point(412, 12)
        Me.cboExcel.Name = "cboExcel"
        Me.cboExcel.Size = New System.Drawing.Size(121, 21)
        Me.cboExcel.TabIndex = 29
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(704, 6)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(75, 31)
        Me.btnExportar.TabIndex = 28
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'cboSector
        '
        Me.cboSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSector.FormattingEnabled = True
        Me.cboSector.Location = New System.Drawing.Point(159, 12)
        Me.cboSector.Name = "cboSector"
        Me.cboSector.Size = New System.Drawing.Size(121, 21)
        Me.cboSector.TabIndex = 27
        '
        'btnMostrarPadron
        '
        Me.btnMostrarPadron.Location = New System.Drawing.Point(12, 6)
        Me.btnMostrarPadron.Name = "btnMostrarPadron"
        Me.btnMostrarPadron.Size = New System.Drawing.Size(141, 31)
        Me.btnMostrarPadron.TabIndex = 26
        Me.btnMostrarPadron.Text = "Mostrar Padrón Actual"
        Me.btnMostrarPadron.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(9, 421)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(783, 23)
        Me.ProgressBar1.TabIndex = 25
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(539, 6)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(114, 31)
        Me.btnProcesar.TabIndex = 24
        Me.btnProcesar.Text = "Procesar y Guardar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'btnCargarExcel
        '
        Me.btnCargarExcel.Location = New System.Drawing.Point(331, 6)
        Me.btnCargarExcel.Name = "btnCargarExcel"
        Me.btnCargarExcel.Size = New System.Drawing.Size(75, 31)
        Me.btnCargarExcel.TabIndex = 23
        Me.btnCargarExcel.Text = "Cargar Excel"
        Me.btnCargarExcel.UseVisualStyleBackColor = True
        '
        'dgvmedidor
        '
        Me.dgvmedidor.AllowUserToAddRows = False
        Me.dgvmedidor.AllowUserToDeleteRows = False
        Me.dgvmedidor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvmedidor.Location = New System.Drawing.Point(9, 46)
        Me.dgvmedidor.Name = "dgvmedidor"
        Me.dgvmedidor.ReadOnly = True
        Me.dgvmedidor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvmedidor.Size = New System.Drawing.Size(783, 369)
        Me.dgvmedidor.TabIndex = 22
        '
        'Padron_Clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.cboExcel)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.cboSector)
        Me.Controls.Add(Me.btnMostrarPadron)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.btnCargarExcel)
        Me.Controls.Add(Me.dgvmedidor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Padron_Clientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Padron de Clientes"
        CType(Me.dgvmedidor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cboExcel As ComboBox
    Friend WithEvents btnExportar As Button
    Friend WithEvents cboSector As ComboBox
    Friend WithEvents btnMostrarPadron As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents btnProcesar As Button
    Friend WithEvents btnCargarExcel As Button
    Friend WithEvents dgvmedidor As DataGridView
End Class
