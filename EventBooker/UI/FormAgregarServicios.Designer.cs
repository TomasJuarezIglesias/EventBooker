namespace UI
{
    partial class FormAgregarServicios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgregarServicios));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.BtnVolver = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.LblValoresTitulo = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblValores = new Bunifu.UI.WinForms.BunifuLabel();
            this.PanelServicios = new System.Windows.Forms.Panel();
            this.LblLista = new Bunifu.UI.WinForms.BunifuLabel();
            this.BtnAñadirServiciosAdicionales = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.LblSeleccionarServicios = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 3;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.BtnVolver);
            this.bunifuPanel1.Controls.Add(this.LblValoresTitulo);
            this.bunifuPanel1.Controls.Add(this.LblValores);
            this.bunifuPanel1.Controls.Add(this.PanelServicios);
            this.bunifuPanel1.Controls.Add(this.LblLista);
            this.bunifuPanel1.Controls.Add(this.BtnAñadirServiciosAdicionales);
            this.bunifuPanel1.Controls.Add(this.LblSeleccionarServicios);
            this.bunifuPanel1.Location = new System.Drawing.Point(68, 63);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(765, 485);
            this.bunifuPanel1.TabIndex = 7;
            // 
            // BtnVolver
            // 
            this.BtnVolver.AllowAnimations = true;
            this.BtnVolver.AllowMouseEffects = true;
            this.BtnVolver.AllowToggling = false;
            this.BtnVolver.AnimationSpeed = 200;
            this.BtnVolver.AutoGenerateColors = false;
            this.BtnVolver.AutoRoundBorders = false;
            this.BtnVolver.AutoSizeLeftIcon = true;
            this.BtnVolver.AutoSizeRightIcon = true;
            this.BtnVolver.BackColor = System.Drawing.Color.Transparent;
            this.BtnVolver.BackColor1 = System.Drawing.Color.DimGray;
            this.BtnVolver.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnVolver.BackgroundImage")));
            this.BtnVolver.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnVolver.ButtonText = "Volver";
            this.BtnVolver.ButtonTextMarginLeft = 0;
            this.BtnVolver.ColorContrastOnClick = 45;
            this.BtnVolver.ColorContrastOnHover = 45;
            this.BtnVolver.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.BtnVolver.CustomizableEdges = borderEdges1;
            this.BtnVolver.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BtnVolver.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnVolver.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnVolver.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnVolver.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.BtnVolver.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnVolver.ForeColor = System.Drawing.Color.White;
            this.BtnVolver.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnVolver.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.BtnVolver.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.BtnVolver.IconMarginLeft = 11;
            this.BtnVolver.IconPadding = 10;
            this.BtnVolver.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnVolver.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.BtnVolver.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.BtnVolver.IconSize = 25;
            this.BtnVolver.IdleBorderColor = System.Drawing.Color.Gray;
            this.BtnVolver.IdleBorderRadius = 1;
            this.BtnVolver.IdleBorderThickness = 1;
            this.BtnVolver.IdleFillColor = System.Drawing.Color.DimGray;
            this.BtnVolver.IdleIconLeftImage = null;
            this.BtnVolver.IdleIconRightImage = null;
            this.BtnVolver.IndicateFocus = false;
            this.BtnVolver.Location = new System.Drawing.Point(373, 427);
            this.BtnVolver.Name = "BtnVolver";
            this.BtnVolver.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnVolver.OnDisabledState.BorderRadius = 1;
            this.BtnVolver.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnVolver.OnDisabledState.BorderThickness = 1;
            this.BtnVolver.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnVolver.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnVolver.OnDisabledState.IconLeftImage = null;
            this.BtnVolver.OnDisabledState.IconRightImage = null;
            this.BtnVolver.onHoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnVolver.onHoverState.BorderRadius = 1;
            this.BtnVolver.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnVolver.onHoverState.BorderThickness = 1;
            this.BtnVolver.onHoverState.FillColor = System.Drawing.Color.DarkGray;
            this.BtnVolver.onHoverState.ForeColor = System.Drawing.Color.White;
            this.BtnVolver.onHoverState.IconLeftImage = null;
            this.BtnVolver.onHoverState.IconRightImage = null;
            this.BtnVolver.OnIdleState.BorderColor = System.Drawing.Color.Gray;
            this.BtnVolver.OnIdleState.BorderRadius = 1;
            this.BtnVolver.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnVolver.OnIdleState.BorderThickness = 1;
            this.BtnVolver.OnIdleState.FillColor = System.Drawing.Color.DimGray;
            this.BtnVolver.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.BtnVolver.OnIdleState.IconLeftImage = null;
            this.BtnVolver.OnIdleState.IconRightImage = null;
            this.BtnVolver.OnPressedState.BorderColor = System.Drawing.Color.Gray;
            this.BtnVolver.OnPressedState.BorderRadius = 1;
            this.BtnVolver.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnVolver.OnPressedState.BorderThickness = 1;
            this.BtnVolver.OnPressedState.FillColor = System.Drawing.Color.DimGray;
            this.BtnVolver.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.BtnVolver.OnPressedState.IconLeftImage = null;
            this.BtnVolver.OnPressedState.IconRightImage = null;
            this.BtnVolver.Size = new System.Drawing.Size(176, 39);
            this.BtnVolver.TabIndex = 34;
            this.BtnVolver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnVolver.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnVolver.TextMarginLeft = 0;
            this.BtnVolver.TextPadding = new System.Windows.Forms.Padding(0);
            this.BtnVolver.UseDefaultRadiusAndThickness = true;
            this.BtnVolver.Click += new System.EventHandler(this.BtnVolver_Click);
            // 
            // LblValoresTitulo
            // 
            this.LblValoresTitulo.AllowParentOverrides = false;
            this.LblValoresTitulo.AutoEllipsis = false;
            this.LblValoresTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblValoresTitulo.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblValoresTitulo.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.LblValoresTitulo.Location = new System.Drawing.Point(411, 93);
            this.LblValoresTitulo.Name = "LblValoresTitulo";
            this.LblValoresTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblValoresTitulo.Size = new System.Drawing.Size(83, 32);
            this.LblValoresTitulo.TabIndex = 30;
            this.LblValoresTitulo.Text = "Valores:";
            this.LblValoresTitulo.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblValoresTitulo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblValores
            // 
            this.LblValores.AllowParentOverrides = false;
            this.LblValores.AutoEllipsis = false;
            this.LblValores.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblValores.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblValores.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LblValores.Location = new System.Drawing.Point(411, 141);
            this.LblValores.Name = "LblValores";
            this.LblValores.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblValores.Size = new System.Drawing.Size(55, 21);
            this.LblValores.TabIndex = 29;
            this.LblValores.Text = "Valores:";
            this.LblValores.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblValores.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // PanelServicios
            // 
            this.PanelServicios.BackColor = System.Drawing.Color.Transparent;
            this.PanelServicios.Location = new System.Drawing.Point(30, 141);
            this.PanelServicios.Margin = new System.Windows.Forms.Padding(2);
            this.PanelServicios.Name = "PanelServicios";
            this.PanelServicios.Size = new System.Drawing.Size(324, 271);
            this.PanelServicios.TabIndex = 27;
            // 
            // LblLista
            // 
            this.LblLista.AllowParentOverrides = false;
            this.LblLista.AutoEllipsis = false;
            this.LblLista.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblLista.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblLista.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.LblLista.Location = new System.Drawing.Point(30, 93);
            this.LblLista.Name = "LblLista";
            this.LblLista.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblLista.Size = new System.Drawing.Size(52, 32);
            this.LblLista.TabIndex = 26;
            this.LblLista.Text = "Lista:";
            this.LblLista.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblLista.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // BtnAñadirServiciosAdicionales
            // 
            this.BtnAñadirServiciosAdicionales.AllowAnimations = true;
            this.BtnAñadirServiciosAdicionales.AllowMouseEffects = true;
            this.BtnAñadirServiciosAdicionales.AllowToggling = false;
            this.BtnAñadirServiciosAdicionales.AnimationSpeed = 200;
            this.BtnAñadirServiciosAdicionales.AutoGenerateColors = false;
            this.BtnAñadirServiciosAdicionales.AutoRoundBorders = false;
            this.BtnAñadirServiciosAdicionales.AutoSizeLeftIcon = true;
            this.BtnAñadirServiciosAdicionales.AutoSizeRightIcon = true;
            this.BtnAñadirServiciosAdicionales.BackColor = System.Drawing.Color.Transparent;
            this.BtnAñadirServiciosAdicionales.BackColor1 = System.Drawing.Color.DimGray;
            this.BtnAñadirServiciosAdicionales.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnAñadirServiciosAdicionales.BackgroundImage")));
            this.BtnAñadirServiciosAdicionales.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnAñadirServiciosAdicionales.ButtonText = "Añadir servicios";
            this.BtnAñadirServiciosAdicionales.ButtonTextMarginLeft = 0;
            this.BtnAñadirServiciosAdicionales.ColorContrastOnClick = 45;
            this.BtnAñadirServiciosAdicionales.ColorContrastOnHover = 45;
            this.BtnAñadirServiciosAdicionales.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.BtnAñadirServiciosAdicionales.CustomizableEdges = borderEdges2;
            this.BtnAñadirServiciosAdicionales.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BtnAñadirServiciosAdicionales.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnAñadirServiciosAdicionales.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnAñadirServiciosAdicionales.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnAñadirServiciosAdicionales.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.BtnAñadirServiciosAdicionales.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnAñadirServiciosAdicionales.ForeColor = System.Drawing.Color.White;
            this.BtnAñadirServiciosAdicionales.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAñadirServiciosAdicionales.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.BtnAñadirServiciosAdicionales.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.BtnAñadirServiciosAdicionales.IconMarginLeft = 11;
            this.BtnAñadirServiciosAdicionales.IconPadding = 10;
            this.BtnAñadirServiciosAdicionales.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAñadirServiciosAdicionales.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.BtnAñadirServiciosAdicionales.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.BtnAñadirServiciosAdicionales.IconSize = 25;
            this.BtnAñadirServiciosAdicionales.IdleBorderColor = System.Drawing.Color.Gray;
            this.BtnAñadirServiciosAdicionales.IdleBorderRadius = 1;
            this.BtnAñadirServiciosAdicionales.IdleBorderThickness = 1;
            this.BtnAñadirServiciosAdicionales.IdleFillColor = System.Drawing.Color.DimGray;
            this.BtnAñadirServiciosAdicionales.IdleIconLeftImage = null;
            this.BtnAñadirServiciosAdicionales.IdleIconRightImage = null;
            this.BtnAñadirServiciosAdicionales.IndicateFocus = false;
            this.BtnAñadirServiciosAdicionales.Location = new System.Drawing.Point(567, 427);
            this.BtnAñadirServiciosAdicionales.Name = "BtnAñadirServiciosAdicionales";
            this.BtnAñadirServiciosAdicionales.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnAñadirServiciosAdicionales.OnDisabledState.BorderRadius = 1;
            this.BtnAñadirServiciosAdicionales.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnAñadirServiciosAdicionales.OnDisabledState.BorderThickness = 1;
            this.BtnAñadirServiciosAdicionales.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnAñadirServiciosAdicionales.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnAñadirServiciosAdicionales.OnDisabledState.IconLeftImage = null;
            this.BtnAñadirServiciosAdicionales.OnDisabledState.IconRightImage = null;
            this.BtnAñadirServiciosAdicionales.onHoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnAñadirServiciosAdicionales.onHoverState.BorderRadius = 1;
            this.BtnAñadirServiciosAdicionales.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnAñadirServiciosAdicionales.onHoverState.BorderThickness = 1;
            this.BtnAñadirServiciosAdicionales.onHoverState.FillColor = System.Drawing.Color.DarkGray;
            this.BtnAñadirServiciosAdicionales.onHoverState.ForeColor = System.Drawing.Color.White;
            this.BtnAñadirServiciosAdicionales.onHoverState.IconLeftImage = null;
            this.BtnAñadirServiciosAdicionales.onHoverState.IconRightImage = null;
            this.BtnAñadirServiciosAdicionales.OnIdleState.BorderColor = System.Drawing.Color.Gray;
            this.BtnAñadirServiciosAdicionales.OnIdleState.BorderRadius = 1;
            this.BtnAñadirServiciosAdicionales.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnAñadirServiciosAdicionales.OnIdleState.BorderThickness = 1;
            this.BtnAñadirServiciosAdicionales.OnIdleState.FillColor = System.Drawing.Color.DimGray;
            this.BtnAñadirServiciosAdicionales.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.BtnAñadirServiciosAdicionales.OnIdleState.IconLeftImage = null;
            this.BtnAñadirServiciosAdicionales.OnIdleState.IconRightImage = null;
            this.BtnAñadirServiciosAdicionales.OnPressedState.BorderColor = System.Drawing.Color.Gray;
            this.BtnAñadirServiciosAdicionales.OnPressedState.BorderRadius = 1;
            this.BtnAñadirServiciosAdicionales.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnAñadirServiciosAdicionales.OnPressedState.BorderThickness = 1;
            this.BtnAñadirServiciosAdicionales.OnPressedState.FillColor = System.Drawing.Color.DimGray;
            this.BtnAñadirServiciosAdicionales.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.BtnAñadirServiciosAdicionales.OnPressedState.IconLeftImage = null;
            this.BtnAñadirServiciosAdicionales.OnPressedState.IconRightImage = null;
            this.BtnAñadirServiciosAdicionales.Size = new System.Drawing.Size(176, 39);
            this.BtnAñadirServiciosAdicionales.TabIndex = 16;
            this.BtnAñadirServiciosAdicionales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnAñadirServiciosAdicionales.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnAñadirServiciosAdicionales.TextMarginLeft = 0;
            this.BtnAñadirServiciosAdicionales.TextPadding = new System.Windows.Forms.Padding(0);
            this.BtnAñadirServiciosAdicionales.UseDefaultRadiusAndThickness = true;
            this.BtnAñadirServiciosAdicionales.Click += new System.EventHandler(this.BtnAñadirServiciosAdicionales_Click);
            // 
            // LblSeleccionarServicios
            // 
            this.LblSeleccionarServicios.AllowParentOverrides = false;
            this.LblSeleccionarServicios.AutoEllipsis = false;
            this.LblSeleccionarServicios.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblSeleccionarServicios.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblSeleccionarServicios.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.LblSeleccionarServicios.Location = new System.Drawing.Point(30, 29);
            this.LblSeleccionarServicios.Name = "LblSeleccionarServicios";
            this.LblSeleccionarServicios.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblSeleccionarServicios.Size = new System.Drawing.Size(299, 45);
            this.LblSeleccionarServicios.TabIndex = 0;
            this.LblSeleccionarServicios.Text = "Seleccionar Servicios";
            this.LblSeleccionarServicios.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblSeleccionarServicios.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // FormAgregarServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(901, 611);
            this.Controls.Add(this.bunifuPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAgregarServicios";
            this.Text = "FormAgregarServicios";
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton BtnVolver;
        private Bunifu.UI.WinForms.BunifuLabel LblValoresTitulo;
        private Bunifu.UI.WinForms.BunifuLabel LblValores;
        private System.Windows.Forms.Panel PanelServicios;
        private Bunifu.UI.WinForms.BunifuLabel LblLista;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton BtnAñadirServiciosAdicionales;
        private Bunifu.UI.WinForms.BunifuLabel LblSeleccionarServicios;
    }
}