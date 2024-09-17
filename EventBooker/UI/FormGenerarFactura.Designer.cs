namespace UI
{
    partial class FormGenerarFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGenerarFactura));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.BtnGenerar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.LblSeleccionarFactura = new Bunifu.UI.WinForms.BunifuLabel();
            this.CmbFacturas = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BtnGenerar
            // 
            this.BtnGenerar.AllowAnimations = true;
            this.BtnGenerar.AllowMouseEffects = true;
            this.BtnGenerar.AllowToggling = false;
            this.BtnGenerar.AnimationSpeed = 200;
            this.BtnGenerar.AutoGenerateColors = false;
            this.BtnGenerar.AutoRoundBorders = false;
            this.BtnGenerar.AutoSizeLeftIcon = true;
            this.BtnGenerar.AutoSizeRightIcon = true;
            this.BtnGenerar.BackColor = System.Drawing.Color.Transparent;
            this.BtnGenerar.BackColor1 = System.Drawing.Color.DimGray;
            this.BtnGenerar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnGenerar.BackgroundImage")));
            this.BtnGenerar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnGenerar.ButtonText = "Generar";
            this.BtnGenerar.ButtonTextMarginLeft = 0;
            this.BtnGenerar.ColorContrastOnClick = 45;
            this.BtnGenerar.ColorContrastOnHover = 45;
            this.BtnGenerar.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.BtnGenerar.CustomizableEdges = borderEdges1;
            this.BtnGenerar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BtnGenerar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnGenerar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnGenerar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnGenerar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.BtnGenerar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnGenerar.ForeColor = System.Drawing.Color.White;
            this.BtnGenerar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGenerar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.BtnGenerar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.BtnGenerar.IconMarginLeft = 11;
            this.BtnGenerar.IconPadding = 10;
            this.BtnGenerar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGenerar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.BtnGenerar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.BtnGenerar.IconSize = 25;
            this.BtnGenerar.IdleBorderColor = System.Drawing.Color.Gray;
            this.BtnGenerar.IdleBorderRadius = 1;
            this.BtnGenerar.IdleBorderThickness = 1;
            this.BtnGenerar.IdleFillColor = System.Drawing.Color.DimGray;
            this.BtnGenerar.IdleIconLeftImage = null;
            this.BtnGenerar.IdleIconRightImage = null;
            this.BtnGenerar.IndicateFocus = false;
            this.BtnGenerar.Location = new System.Drawing.Point(220, 123);
            this.BtnGenerar.Name = "BtnGenerar";
            this.BtnGenerar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnGenerar.OnDisabledState.BorderRadius = 1;
            this.BtnGenerar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnGenerar.OnDisabledState.BorderThickness = 1;
            this.BtnGenerar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnGenerar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnGenerar.OnDisabledState.IconLeftImage = null;
            this.BtnGenerar.OnDisabledState.IconRightImage = null;
            this.BtnGenerar.onHoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnGenerar.onHoverState.BorderRadius = 1;
            this.BtnGenerar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnGenerar.onHoverState.BorderThickness = 1;
            this.BtnGenerar.onHoverState.FillColor = System.Drawing.Color.DarkGray;
            this.BtnGenerar.onHoverState.ForeColor = System.Drawing.Color.White;
            this.BtnGenerar.onHoverState.IconLeftImage = null;
            this.BtnGenerar.onHoverState.IconRightImage = null;
            this.BtnGenerar.OnIdleState.BorderColor = System.Drawing.Color.Gray;
            this.BtnGenerar.OnIdleState.BorderRadius = 1;
            this.BtnGenerar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnGenerar.OnIdleState.BorderThickness = 1;
            this.BtnGenerar.OnIdleState.FillColor = System.Drawing.Color.DimGray;
            this.BtnGenerar.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.BtnGenerar.OnIdleState.IconLeftImage = null;
            this.BtnGenerar.OnIdleState.IconRightImage = null;
            this.BtnGenerar.OnPressedState.BorderColor = System.Drawing.Color.Gray;
            this.BtnGenerar.OnPressedState.BorderRadius = 1;
            this.BtnGenerar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnGenerar.OnPressedState.BorderThickness = 1;
            this.BtnGenerar.OnPressedState.FillColor = System.Drawing.Color.DimGray;
            this.BtnGenerar.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.BtnGenerar.OnPressedState.IconLeftImage = null;
            this.BtnGenerar.OnPressedState.IconRightImage = null;
            this.BtnGenerar.Size = new System.Drawing.Size(130, 37);
            this.BtnGenerar.TabIndex = 46;
            this.BtnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnGenerar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnGenerar.TextMarginLeft = 0;
            this.BtnGenerar.TextPadding = new System.Windows.Forms.Padding(0);
            this.BtnGenerar.UseDefaultRadiusAndThickness = true;
            this.BtnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);
            // 
            // LblSeleccionarFactura
            // 
            this.LblSeleccionarFactura.AllowParentOverrides = false;
            this.LblSeleccionarFactura.AutoEllipsis = false;
            this.LblSeleccionarFactura.AutoSize = false;
            this.LblSeleccionarFactura.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblSeleccionarFactura.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblSeleccionarFactura.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.LblSeleccionarFactura.Location = new System.Drawing.Point(117, 34);
            this.LblSeleccionarFactura.Name = "LblSeleccionarFactura";
            this.LblSeleccionarFactura.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblSeleccionarFactura.Size = new System.Drawing.Size(349, 36);
            this.LblSeleccionarFactura.TabIndex = 45;
            this.LblSeleccionarFactura.Text = "Seleccionar Factura";
            this.LblSeleccionarFactura.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.LblSeleccionarFactura.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // CmbFacturas
            // 
            this.CmbFacturas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFacturas.FormattingEnabled = true;
            this.CmbFacturas.Location = new System.Drawing.Point(171, 76);
            this.CmbFacturas.Name = "CmbFacturas";
            this.CmbFacturas.Size = new System.Drawing.Size(228, 21);
            this.CmbFacturas.TabIndex = 47;
            // 
            // FormGenerarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(572, 220);
            this.Controls.Add(this.CmbFacturas);
            this.Controls.Add(this.BtnGenerar);
            this.Controls.Add(this.LblSeleccionarFactura);
            this.Name = "FormGenerarFactura";
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton BtnGenerar;
        private Bunifu.UI.WinForms.BunifuLabel LblSeleccionarFactura;
        private System.Windows.Forms.ComboBox CmbFacturas;
    }
}