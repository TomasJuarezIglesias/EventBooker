namespace UI
{
    partial class FormBitacoraEventos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBitacoraEventos));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.BtnLimpiar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.DataGridViewEventos = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.LblBitacoraEventos = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblUsuario = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblModulo = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblFechaIni = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblFechaFin = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblCriticidad = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblEvento = new Bunifu.UI.WinForms.BunifuLabel();
            this.BtnAplicar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.BtnImprimir = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.CmbUsuario = new System.Windows.Forms.ComboBox();
            this.CmbModulo = new System.Windows.Forms.ComboBox();
            this.CmbEvento = new System.Windows.Forms.ComboBox();
            this.CmbCriticidad = new System.Windows.Forms.ComboBox();
            this.DateTimePickerIni = new System.Windows.Forms.DateTimePicker();
            this.DateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.LblNombre = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblApellido = new Bunifu.UI.WinForms.BunifuLabel();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.TxtApellido = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewEventos)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.AllowAnimations = true;
            this.BtnLimpiar.AllowMouseEffects = true;
            this.BtnLimpiar.AllowToggling = false;
            this.BtnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLimpiar.AnimationSpeed = 200;
            this.BtnLimpiar.AutoGenerateColors = false;
            this.BtnLimpiar.AutoRoundBorders = false;
            this.BtnLimpiar.AutoSizeLeftIcon = true;
            this.BtnLimpiar.AutoSizeRightIcon = true;
            this.BtnLimpiar.BackColor = System.Drawing.Color.Transparent;
            this.BtnLimpiar.BackColor1 = System.Drawing.Color.DimGray;
            this.BtnLimpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnLimpiar.BackgroundImage")));
            this.BtnLimpiar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnLimpiar.ButtonText = "Limpiar";
            this.BtnLimpiar.ButtonTextMarginLeft = 0;
            this.BtnLimpiar.ColorContrastOnClick = 45;
            this.BtnLimpiar.ColorContrastOnHover = 45;
            this.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.BtnLimpiar.CustomizableEdges = borderEdges1;
            this.BtnLimpiar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BtnLimpiar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnLimpiar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnLimpiar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnLimpiar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.BtnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnLimpiar.ForeColor = System.Drawing.Color.White;
            this.BtnLimpiar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLimpiar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.BtnLimpiar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.BtnLimpiar.IconMarginLeft = 11;
            this.BtnLimpiar.IconPadding = 10;
            this.BtnLimpiar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLimpiar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.BtnLimpiar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.BtnLimpiar.IconSize = 25;
            this.BtnLimpiar.IdleBorderColor = System.Drawing.Color.DimGray;
            this.BtnLimpiar.IdleBorderRadius = 1;
            this.BtnLimpiar.IdleBorderThickness = 1;
            this.BtnLimpiar.IdleFillColor = System.Drawing.Color.DimGray;
            this.BtnLimpiar.IdleIconLeftImage = null;
            this.BtnLimpiar.IdleIconRightImage = null;
            this.BtnLimpiar.IndicateFocus = false;
            this.BtnLimpiar.Location = new System.Drawing.Point(739, 480);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnLimpiar.OnDisabledState.BorderRadius = 1;
            this.BtnLimpiar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnLimpiar.OnDisabledState.BorderThickness = 1;
            this.BtnLimpiar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnLimpiar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnLimpiar.OnDisabledState.IconLeftImage = null;
            this.BtnLimpiar.OnDisabledState.IconRightImage = null;
            this.BtnLimpiar.onHoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnLimpiar.onHoverState.BorderRadius = 1;
            this.BtnLimpiar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnLimpiar.onHoverState.BorderThickness = 1;
            this.BtnLimpiar.onHoverState.FillColor = System.Drawing.Color.DarkGray;
            this.BtnLimpiar.onHoverState.ForeColor = System.Drawing.Color.White;
            this.BtnLimpiar.onHoverState.IconLeftImage = null;
            this.BtnLimpiar.onHoverState.IconRightImage = null;
            this.BtnLimpiar.OnIdleState.BorderColor = System.Drawing.Color.DimGray;
            this.BtnLimpiar.OnIdleState.BorderRadius = 1;
            this.BtnLimpiar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnLimpiar.OnIdleState.BorderThickness = 1;
            this.BtnLimpiar.OnIdleState.FillColor = System.Drawing.Color.DimGray;
            this.BtnLimpiar.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.BtnLimpiar.OnIdleState.IconLeftImage = null;
            this.BtnLimpiar.OnIdleState.IconRightImage = null;
            this.BtnLimpiar.OnPressedState.BorderColor = System.Drawing.Color.Gray;
            this.BtnLimpiar.OnPressedState.BorderRadius = 1;
            this.BtnLimpiar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnLimpiar.OnPressedState.BorderThickness = 1;
            this.BtnLimpiar.OnPressedState.FillColor = System.Drawing.Color.DimGray;
            this.BtnLimpiar.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.BtnLimpiar.OnPressedState.IconLeftImage = null;
            this.BtnLimpiar.OnPressedState.IconRightImage = null;
            this.BtnLimpiar.Size = new System.Drawing.Size(150, 39);
            this.BtnLimpiar.TabIndex = 41;
            this.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnLimpiar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnLimpiar.TextMarginLeft = 0;
            this.BtnLimpiar.TextPadding = new System.Windows.Forms.Padding(0);
            this.BtnLimpiar.UseDefaultRadiusAndThickness = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // DataGridViewEventos
            // 
            this.DataGridViewEventos.AllowCustomTheming = false;
            this.DataGridViewEventos.AllowUserToAddRows = false;
            this.DataGridViewEventos.AllowUserToDeleteRows = false;
            this.DataGridViewEventos.AllowUserToResizeColumns = false;
            this.DataGridViewEventos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.DataGridViewEventos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewEventos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewEventos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewEventos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridViewEventos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridViewEventos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewEventos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewEventos.ColumnHeadersHeight = 40;
            this.DataGridViewEventos.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.DataGridViewEventos.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DataGridViewEventos.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DataGridViewEventos.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.DataGridViewEventos.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DataGridViewEventos.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.DataGridViewEventos.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.DataGridViewEventos.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.DataGridViewEventos.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.DataGridViewEventos.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridViewEventos.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.DataGridViewEventos.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DataGridViewEventos.CurrentTheme.Name = null;
            this.DataGridViewEventos.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridViewEventos.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DataGridViewEventos.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DataGridViewEventos.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.DataGridViewEventos.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewEventos.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridViewEventos.EnableHeadersVisualStyles = false;
            this.DataGridViewEventos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.DataGridViewEventos.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.DataGridViewEventos.HeaderBgColor = System.Drawing.Color.Empty;
            this.DataGridViewEventos.HeaderForeColor = System.Drawing.Color.White;
            this.DataGridViewEventos.Location = new System.Drawing.Point(12, 63);
            this.DataGridViewEventos.MultiSelect = false;
            this.DataGridViewEventos.Name = "DataGridViewEventos";
            this.DataGridViewEventos.ReadOnly = true;
            this.DataGridViewEventos.RowHeadersVisible = false;
            this.DataGridViewEventos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataGridViewEventos.RowTemplate.Height = 40;
            this.DataGridViewEventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewEventos.ShowCellErrors = false;
            this.DataGridViewEventos.ShowCellToolTips = false;
            this.DataGridViewEventos.ShowEditingIcon = false;
            this.DataGridViewEventos.ShowRowErrors = false;
            this.DataGridViewEventos.Size = new System.Drawing.Size(877, 318);
            this.DataGridViewEventos.TabIndex = 38;
            this.DataGridViewEventos.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // LblBitacoraEventos
            // 
            this.LblBitacoraEventos.AllowParentOverrides = false;
            this.LblBitacoraEventos.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblBitacoraEventos.AutoEllipsis = false;
            this.LblBitacoraEventos.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblBitacoraEventos.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblBitacoraEventos.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.LblBitacoraEventos.Location = new System.Drawing.Point(12, 12);
            this.LblBitacoraEventos.Name = "LblBitacoraEventos";
            this.LblBitacoraEventos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblBitacoraEventos.Size = new System.Drawing.Size(239, 45);
            this.LblBitacoraEventos.TabIndex = 37;
            this.LblBitacoraEventos.Text = "Bitácora Eventos";
            this.LblBitacoraEventos.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblBitacoraEventos.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblUsuario
            // 
            this.LblUsuario.AllowParentOverrides = false;
            this.LblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblUsuario.AutoEllipsis = false;
            this.LblUsuario.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblUsuario.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LblUsuario.Location = new System.Drawing.Point(35, 455);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblUsuario.Size = new System.Drawing.Size(57, 21);
            this.LblUsuario.TabIndex = 42;
            this.LblUsuario.Text = "Usuario:";
            this.LblUsuario.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblUsuario.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblModulo
            // 
            this.LblModulo.AllowParentOverrides = false;
            this.LblModulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblModulo.AutoEllipsis = false;
            this.LblModulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblModulo.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblModulo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LblModulo.Location = new System.Drawing.Point(35, 507);
            this.LblModulo.Name = "LblModulo";
            this.LblModulo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblModulo.Size = new System.Drawing.Size(57, 21);
            this.LblModulo.TabIndex = 43;
            this.LblModulo.Text = "Modulo:";
            this.LblModulo.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblModulo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblFechaIni
            // 
            this.LblFechaIni.AllowParentOverrides = false;
            this.LblFechaIni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblFechaIni.AutoEllipsis = false;
            this.LblFechaIni.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblFechaIni.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblFechaIni.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LblFechaIni.Location = new System.Drawing.Point(360, 454);
            this.LblFechaIni.Name = "LblFechaIni";
            this.LblFechaIni.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblFechaIni.Size = new System.Drawing.Size(87, 21);
            this.LblFechaIni.TabIndex = 44;
            this.LblFechaIni.Text = "Fecha Inicial:";
            this.LblFechaIni.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblFechaIni.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblFechaFin
            // 
            this.LblFechaFin.AllowParentOverrides = false;
            this.LblFechaFin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblFechaFin.AutoEllipsis = false;
            this.LblFechaFin.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblFechaFin.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblFechaFin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LblFechaFin.Location = new System.Drawing.Point(360, 507);
            this.LblFechaFin.Name = "LblFechaFin";
            this.LblFechaFin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblFechaFin.Size = new System.Drawing.Size(68, 21);
            this.LblFechaFin.TabIndex = 45;
            this.LblFechaFin.Text = "Fecha Fin:";
            this.LblFechaFin.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblFechaFin.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblCriticidad
            // 
            this.LblCriticidad.AllowParentOverrides = false;
            this.LblCriticidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCriticidad.AutoEllipsis = false;
            this.LblCriticidad.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblCriticidad.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblCriticidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LblCriticidad.Location = new System.Drawing.Point(360, 563);
            this.LblCriticidad.Name = "LblCriticidad";
            this.LblCriticidad.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblCriticidad.Size = new System.Drawing.Size(69, 21);
            this.LblCriticidad.TabIndex = 46;
            this.LblCriticidad.Text = "Criticidad:";
            this.LblCriticidad.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblCriticidad.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblEvento
            // 
            this.LblEvento.AllowParentOverrides = false;
            this.LblEvento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblEvento.AutoEllipsis = false;
            this.LblEvento.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblEvento.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblEvento.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LblEvento.Location = new System.Drawing.Point(35, 563);
            this.LblEvento.Name = "LblEvento";
            this.LblEvento.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblEvento.Size = new System.Drawing.Size(50, 21);
            this.LblEvento.TabIndex = 47;
            this.LblEvento.Text = "Evento:";
            this.LblEvento.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblEvento.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // BtnAplicar
            // 
            this.BtnAplicar.AllowAnimations = true;
            this.BtnAplicar.AllowMouseEffects = true;
            this.BtnAplicar.AllowToggling = false;
            this.BtnAplicar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAplicar.AnimationSpeed = 200;
            this.BtnAplicar.AutoGenerateColors = false;
            this.BtnAplicar.AutoRoundBorders = false;
            this.BtnAplicar.AutoSizeLeftIcon = true;
            this.BtnAplicar.AutoSizeRightIcon = true;
            this.BtnAplicar.BackColor = System.Drawing.Color.Transparent;
            this.BtnAplicar.BackColor1 = System.Drawing.Color.DimGray;
            this.BtnAplicar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnAplicar.BackgroundImage")));
            this.BtnAplicar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnAplicar.ButtonText = "Aplicar";
            this.BtnAplicar.ButtonTextMarginLeft = 0;
            this.BtnAplicar.ColorContrastOnClick = 45;
            this.BtnAplicar.ColorContrastOnHover = 45;
            this.BtnAplicar.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.BtnAplicar.CustomizableEdges = borderEdges2;
            this.BtnAplicar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BtnAplicar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnAplicar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnAplicar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnAplicar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.BtnAplicar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnAplicar.ForeColor = System.Drawing.Color.White;
            this.BtnAplicar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAplicar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.BtnAplicar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.BtnAplicar.IconMarginLeft = 11;
            this.BtnAplicar.IconPadding = 10;
            this.BtnAplicar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAplicar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.BtnAplicar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.BtnAplicar.IconSize = 25;
            this.BtnAplicar.IdleBorderColor = System.Drawing.Color.DimGray;
            this.BtnAplicar.IdleBorderRadius = 1;
            this.BtnAplicar.IdleBorderThickness = 1;
            this.BtnAplicar.IdleFillColor = System.Drawing.Color.DimGray;
            this.BtnAplicar.IdleIconLeftImage = null;
            this.BtnAplicar.IdleIconRightImage = null;
            this.BtnAplicar.IndicateFocus = false;
            this.BtnAplicar.Location = new System.Drawing.Point(739, 411);
            this.BtnAplicar.Name = "BtnAplicar";
            this.BtnAplicar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnAplicar.OnDisabledState.BorderRadius = 1;
            this.BtnAplicar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnAplicar.OnDisabledState.BorderThickness = 1;
            this.BtnAplicar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnAplicar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnAplicar.OnDisabledState.IconLeftImage = null;
            this.BtnAplicar.OnDisabledState.IconRightImage = null;
            this.BtnAplicar.onHoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnAplicar.onHoverState.BorderRadius = 1;
            this.BtnAplicar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnAplicar.onHoverState.BorderThickness = 1;
            this.BtnAplicar.onHoverState.FillColor = System.Drawing.Color.DarkGray;
            this.BtnAplicar.onHoverState.ForeColor = System.Drawing.Color.White;
            this.BtnAplicar.onHoverState.IconLeftImage = null;
            this.BtnAplicar.onHoverState.IconRightImage = null;
            this.BtnAplicar.OnIdleState.BorderColor = System.Drawing.Color.DimGray;
            this.BtnAplicar.OnIdleState.BorderRadius = 1;
            this.BtnAplicar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnAplicar.OnIdleState.BorderThickness = 1;
            this.BtnAplicar.OnIdleState.FillColor = System.Drawing.Color.DimGray;
            this.BtnAplicar.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.BtnAplicar.OnIdleState.IconLeftImage = null;
            this.BtnAplicar.OnIdleState.IconRightImage = null;
            this.BtnAplicar.OnPressedState.BorderColor = System.Drawing.Color.Gray;
            this.BtnAplicar.OnPressedState.BorderRadius = 1;
            this.BtnAplicar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnAplicar.OnPressedState.BorderThickness = 1;
            this.BtnAplicar.OnPressedState.FillColor = System.Drawing.Color.DimGray;
            this.BtnAplicar.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.BtnAplicar.OnPressedState.IconLeftImage = null;
            this.BtnAplicar.OnPressedState.IconRightImage = null;
            this.BtnAplicar.Size = new System.Drawing.Size(150, 39);
            this.BtnAplicar.TabIndex = 48;
            this.BtnAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnAplicar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnAplicar.TextMarginLeft = 0;
            this.BtnAplicar.TextPadding = new System.Windows.Forms.Padding(0);
            this.BtnAplicar.UseDefaultRadiusAndThickness = true;
            this.BtnAplicar.Click += new System.EventHandler(this.BtnAplicar_Click);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.AllowAnimations = true;
            this.BtnImprimir.AllowMouseEffects = true;
            this.BtnImprimir.AllowToggling = false;
            this.BtnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnImprimir.AnimationSpeed = 200;
            this.BtnImprimir.AutoGenerateColors = false;
            this.BtnImprimir.AutoRoundBorders = false;
            this.BtnImprimir.AutoSizeLeftIcon = true;
            this.BtnImprimir.AutoSizeRightIcon = true;
            this.BtnImprimir.BackColor = System.Drawing.Color.Transparent;
            this.BtnImprimir.BackColor1 = System.Drawing.Color.DimGray;
            this.BtnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnImprimir.BackgroundImage")));
            this.BtnImprimir.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnImprimir.ButtonText = "Imprimir";
            this.BtnImprimir.ButtonTextMarginLeft = 0;
            this.BtnImprimir.ColorContrastOnClick = 45;
            this.BtnImprimir.ColorContrastOnHover = 45;
            this.BtnImprimir.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.BtnImprimir.CustomizableEdges = borderEdges3;
            this.BtnImprimir.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BtnImprimir.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnImprimir.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnImprimir.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnImprimir.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.BtnImprimir.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnImprimir.ForeColor = System.Drawing.Color.White;
            this.BtnImprimir.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImprimir.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.BtnImprimir.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.BtnImprimir.IconMarginLeft = 11;
            this.BtnImprimir.IconPadding = 10;
            this.BtnImprimir.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnImprimir.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.BtnImprimir.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.BtnImprimir.IconSize = 25;
            this.BtnImprimir.IdleBorderColor = System.Drawing.Color.DimGray;
            this.BtnImprimir.IdleBorderRadius = 1;
            this.BtnImprimir.IdleBorderThickness = 1;
            this.BtnImprimir.IdleFillColor = System.Drawing.Color.DimGray;
            this.BtnImprimir.IdleIconLeftImage = null;
            this.BtnImprimir.IdleIconRightImage = null;
            this.BtnImprimir.IndicateFocus = false;
            this.BtnImprimir.Location = new System.Drawing.Point(739, 545);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnImprimir.OnDisabledState.BorderRadius = 1;
            this.BtnImprimir.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnImprimir.OnDisabledState.BorderThickness = 1;
            this.BtnImprimir.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnImprimir.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnImprimir.OnDisabledState.IconLeftImage = null;
            this.BtnImprimir.OnDisabledState.IconRightImage = null;
            this.BtnImprimir.onHoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnImprimir.onHoverState.BorderRadius = 1;
            this.BtnImprimir.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnImprimir.onHoverState.BorderThickness = 1;
            this.BtnImprimir.onHoverState.FillColor = System.Drawing.Color.DarkGray;
            this.BtnImprimir.onHoverState.ForeColor = System.Drawing.Color.White;
            this.BtnImprimir.onHoverState.IconLeftImage = null;
            this.BtnImprimir.onHoverState.IconRightImage = null;
            this.BtnImprimir.OnIdleState.BorderColor = System.Drawing.Color.DimGray;
            this.BtnImprimir.OnIdleState.BorderRadius = 1;
            this.BtnImprimir.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnImprimir.OnIdleState.BorderThickness = 1;
            this.BtnImprimir.OnIdleState.FillColor = System.Drawing.Color.DimGray;
            this.BtnImprimir.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.BtnImprimir.OnIdleState.IconLeftImage = null;
            this.BtnImprimir.OnIdleState.IconRightImage = null;
            this.BtnImprimir.OnPressedState.BorderColor = System.Drawing.Color.Gray;
            this.BtnImprimir.OnPressedState.BorderRadius = 1;
            this.BtnImprimir.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnImprimir.OnPressedState.BorderThickness = 1;
            this.BtnImprimir.OnPressedState.FillColor = System.Drawing.Color.DimGray;
            this.BtnImprimir.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.BtnImprimir.OnPressedState.IconLeftImage = null;
            this.BtnImprimir.OnPressedState.IconRightImage = null;
            this.BtnImprimir.Size = new System.Drawing.Size(150, 39);
            this.BtnImprimir.TabIndex = 49;
            this.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnImprimir.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnImprimir.TextMarginLeft = 0;
            this.BtnImprimir.TextPadding = new System.Windows.Forms.Padding(0);
            this.BtnImprimir.UseDefaultRadiusAndThickness = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // CmbUsuario
            // 
            this.CmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUsuario.FormattingEnabled = true;
            this.CmbUsuario.Location = new System.Drawing.Point(132, 454);
            this.CmbUsuario.Name = "CmbUsuario";
            this.CmbUsuario.Size = new System.Drawing.Size(158, 21);
            this.CmbUsuario.TabIndex = 50;
            // 
            // CmbModulo
            // 
            this.CmbModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbModulo.FormattingEnabled = true;
            this.CmbModulo.Location = new System.Drawing.Point(132, 507);
            this.CmbModulo.Name = "CmbModulo";
            this.CmbModulo.Size = new System.Drawing.Size(158, 21);
            this.CmbModulo.TabIndex = 51;
            // 
            // CmbEvento
            // 
            this.CmbEvento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEvento.FormattingEnabled = true;
            this.CmbEvento.Location = new System.Drawing.Point(132, 563);
            this.CmbEvento.Name = "CmbEvento";
            this.CmbEvento.Size = new System.Drawing.Size(158, 21);
            this.CmbEvento.TabIndex = 52;
            // 
            // CmbCriticidad
            // 
            this.CmbCriticidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCriticidad.FormattingEnabled = true;
            this.CmbCriticidad.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.CmbCriticidad.Location = new System.Drawing.Point(469, 563);
            this.CmbCriticidad.Name = "CmbCriticidad";
            this.CmbCriticidad.Size = new System.Drawing.Size(57, 21);
            this.CmbCriticidad.TabIndex = 53;
            // 
            // DateTimePickerIni
            // 
            this.DateTimePickerIni.Location = new System.Drawing.Point(469, 455);
            this.DateTimePickerIni.Name = "DateTimePickerIni";
            this.DateTimePickerIni.Size = new System.Drawing.Size(200, 20);
            this.DateTimePickerIni.TabIndex = 54;
            // 
            // DateTimePickerFin
            // 
            this.DateTimePickerFin.Location = new System.Drawing.Point(469, 508);
            this.DateTimePickerFin.Name = "DateTimePickerFin";
            this.DateTimePickerFin.Size = new System.Drawing.Size(200, 20);
            this.DateTimePickerFin.TabIndex = 55;
            // 
            // LblNombre
            // 
            this.LblNombre.AllowParentOverrides = false;
            this.LblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblNombre.AutoEllipsis = false;
            this.LblNombre.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblNombre.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblNombre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LblNombre.Location = new System.Drawing.Point(35, 410);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblNombre.Size = new System.Drawing.Size(61, 21);
            this.LblNombre.TabIndex = 56;
            this.LblNombre.Text = "Nombre:";
            this.LblNombre.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblNombre.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblApellido
            // 
            this.LblApellido.AllowParentOverrides = false;
            this.LblApellido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblApellido.AutoEllipsis = false;
            this.LblApellido.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblApellido.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblApellido.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LblApellido.Location = new System.Drawing.Point(360, 410);
            this.LblApellido.Name = "LblApellido";
            this.LblApellido.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblApellido.Size = new System.Drawing.Size(60, 21);
            this.LblApellido.TabIndex = 57;
            this.LblApellido.Text = "Apellido:";
            this.LblApellido.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblApellido.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Enabled = false;
            this.TxtNombre.Location = new System.Drawing.Point(132, 411);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(158, 20);
            this.TxtNombre.TabIndex = 58;
            // 
            // TxtApellido
            // 
            this.TxtApellido.Enabled = false;
            this.TxtApellido.Location = new System.Drawing.Point(469, 411);
            this.TxtApellido.Name = "TxtApellido";
            this.TxtApellido.Size = new System.Drawing.Size(158, 20);
            this.TxtApellido.TabIndex = 59;
            // 
            // FormBitacoraEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(901, 611);
            this.Controls.Add(this.TxtApellido);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.LblApellido);
            this.Controls.Add(this.LblNombre);
            this.Controls.Add(this.DateTimePickerFin);
            this.Controls.Add(this.DateTimePickerIni);
            this.Controls.Add(this.CmbCriticidad);
            this.Controls.Add(this.CmbEvento);
            this.Controls.Add(this.CmbModulo);
            this.Controls.Add(this.CmbUsuario);
            this.Controls.Add(this.BtnImprimir);
            this.Controls.Add(this.BtnAplicar);
            this.Controls.Add(this.LblEvento);
            this.Controls.Add(this.LblCriticidad);
            this.Controls.Add(this.LblFechaFin);
            this.Controls.Add(this.LblFechaIni);
            this.Controls.Add(this.LblModulo);
            this.Controls.Add(this.LblUsuario);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.DataGridViewEventos);
            this.Controls.Add(this.LblBitacoraEventos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBitacoraEventos";
            this.Text = "FormBitacoraEventos";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewEventos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton BtnLimpiar;
        private Bunifu.UI.WinForms.BunifuDataGridView DataGridViewEventos;
        private Bunifu.UI.WinForms.BunifuLabel LblBitacoraEventos;
        private Bunifu.UI.WinForms.BunifuLabel LblUsuario;
        private Bunifu.UI.WinForms.BunifuLabel LblModulo;
        private Bunifu.UI.WinForms.BunifuLabel LblFechaIni;
        private Bunifu.UI.WinForms.BunifuLabel LblFechaFin;
        private Bunifu.UI.WinForms.BunifuLabel LblCriticidad;
        private Bunifu.UI.WinForms.BunifuLabel LblEvento;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton BtnAplicar;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton BtnImprimir;
        private System.Windows.Forms.ComboBox CmbUsuario;
        private System.Windows.Forms.ComboBox CmbModulo;
        private System.Windows.Forms.ComboBox CmbEvento;
        private System.Windows.Forms.ComboBox CmbCriticidad;
        private System.Windows.Forms.DateTimePicker DateTimePickerIni;
        private System.Windows.Forms.DateTimePicker DateTimePickerFin;
        private Bunifu.UI.WinForms.BunifuLabel LblNombre;
        private Bunifu.UI.WinForms.BunifuLabel LblApellido;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtApellido;
    }
}