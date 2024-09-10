namespace UI
{
    partial class FormCambiosServicios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCambiosServicios));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.DataGridViewServicios = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.LblCambiosServicios = new Bunifu.UI.WinForms.BunifuLabel();
            this.BtnActivar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.BtnAplicar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.BtnLimpiar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.DateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.DateTimePickerIni = new System.Windows.Forms.DateTimePicker();
            this.LblFechaFin = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblFechaIni = new Bunifu.UI.WinForms.BunifuLabel();
            this.CmbDescripcion = new System.Windows.Forms.ComboBox();
            this.LblDescripcion = new Bunifu.UI.WinForms.BunifuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewServicios
            // 
            this.DataGridViewServicios.AllowCustomTheming = false;
            this.DataGridViewServicios.AllowUserToAddRows = false;
            this.DataGridViewServicios.AllowUserToDeleteRows = false;
            this.DataGridViewServicios.AllowUserToResizeColumns = false;
            this.DataGridViewServicios.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.DataGridViewServicios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewServicios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewServicios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridViewServicios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridViewServicios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewServicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewServicios.ColumnHeadersHeight = 40;
            this.DataGridViewServicios.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.DataGridViewServicios.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DataGridViewServicios.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DataGridViewServicios.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.DataGridViewServicios.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DataGridViewServicios.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.DataGridViewServicios.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.DataGridViewServicios.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.DataGridViewServicios.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.DataGridViewServicios.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridViewServicios.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.DataGridViewServicios.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DataGridViewServicios.CurrentTheme.Name = null;
            this.DataGridViewServicios.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridViewServicios.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DataGridViewServicios.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DataGridViewServicios.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.DataGridViewServicios.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewServicios.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridViewServicios.EnableHeadersVisualStyles = false;
            this.DataGridViewServicios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.DataGridViewServicios.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.DataGridViewServicios.HeaderBgColor = System.Drawing.Color.Empty;
            this.DataGridViewServicios.HeaderForeColor = System.Drawing.Color.White;
            this.DataGridViewServicios.Location = new System.Drawing.Point(12, 63);
            this.DataGridViewServicios.MultiSelect = false;
            this.DataGridViewServicios.Name = "DataGridViewServicios";
            this.DataGridViewServicios.ReadOnly = true;
            this.DataGridViewServicios.RowHeadersVisible = false;
            this.DataGridViewServicios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataGridViewServicios.RowTemplate.Height = 40;
            this.DataGridViewServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewServicios.ShowCellErrors = false;
            this.DataGridViewServicios.ShowCellToolTips = false;
            this.DataGridViewServicios.ShowEditingIcon = false;
            this.DataGridViewServicios.ShowRowErrors = false;
            this.DataGridViewServicios.Size = new System.Drawing.Size(877, 358);
            this.DataGridViewServicios.TabIndex = 40;
            this.DataGridViewServicios.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            this.DataGridViewServicios.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridViewServicios_DataBindingComplete);
            // 
            // LblCambiosServicios
            // 
            this.LblCambiosServicios.AllowParentOverrides = false;
            this.LblCambiosServicios.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblCambiosServicios.AutoEllipsis = false;
            this.LblCambiosServicios.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblCambiosServicios.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblCambiosServicios.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.LblCambiosServicios.Location = new System.Drawing.Point(12, 12);
            this.LblCambiosServicios.Name = "LblCambiosServicios";
            this.LblCambiosServicios.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblCambiosServicios.Size = new System.Drawing.Size(256, 45);
            this.LblCambiosServicios.TabIndex = 39;
            this.LblCambiosServicios.Text = "Cambios servicios";
            this.LblCambiosServicios.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblCambiosServicios.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // BtnActivar
            // 
            this.BtnActivar.AllowAnimations = true;
            this.BtnActivar.AllowMouseEffects = true;
            this.BtnActivar.AllowToggling = false;
            this.BtnActivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnActivar.AnimationSpeed = 200;
            this.BtnActivar.AutoGenerateColors = false;
            this.BtnActivar.AutoRoundBorders = false;
            this.BtnActivar.AutoSizeLeftIcon = true;
            this.BtnActivar.AutoSizeRightIcon = true;
            this.BtnActivar.BackColor = System.Drawing.Color.Transparent;
            this.BtnActivar.BackColor1 = System.Drawing.Color.DimGray;
            this.BtnActivar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnActivar.BackgroundImage")));
            this.BtnActivar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnActivar.ButtonText = "Activar";
            this.BtnActivar.ButtonTextMarginLeft = 0;
            this.BtnActivar.ColorContrastOnClick = 45;
            this.BtnActivar.ColorContrastOnHover = 45;
            this.BtnActivar.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.BtnActivar.CustomizableEdges = borderEdges1;
            this.BtnActivar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BtnActivar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnActivar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnActivar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnActivar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.BtnActivar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnActivar.ForeColor = System.Drawing.Color.White;
            this.BtnActivar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnActivar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.BtnActivar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.BtnActivar.IconMarginLeft = 11;
            this.BtnActivar.IconPadding = 10;
            this.BtnActivar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnActivar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.BtnActivar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.BtnActivar.IconSize = 25;
            this.BtnActivar.IdleBorderColor = System.Drawing.Color.DimGray;
            this.BtnActivar.IdleBorderRadius = 1;
            this.BtnActivar.IdleBorderThickness = 1;
            this.BtnActivar.IdleFillColor = System.Drawing.Color.DimGray;
            this.BtnActivar.IdleIconLeftImage = null;
            this.BtnActivar.IdleIconRightImage = null;
            this.BtnActivar.IndicateFocus = false;
            this.BtnActivar.Location = new System.Drawing.Point(739, 543);
            this.BtnActivar.Name = "BtnActivar";
            this.BtnActivar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnActivar.OnDisabledState.BorderRadius = 1;
            this.BtnActivar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnActivar.OnDisabledState.BorderThickness = 1;
            this.BtnActivar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnActivar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnActivar.OnDisabledState.IconLeftImage = null;
            this.BtnActivar.OnDisabledState.IconRightImage = null;
            this.BtnActivar.onHoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnActivar.onHoverState.BorderRadius = 1;
            this.BtnActivar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnActivar.onHoverState.BorderThickness = 1;
            this.BtnActivar.onHoverState.FillColor = System.Drawing.Color.DarkGray;
            this.BtnActivar.onHoverState.ForeColor = System.Drawing.Color.White;
            this.BtnActivar.onHoverState.IconLeftImage = null;
            this.BtnActivar.onHoverState.IconRightImage = null;
            this.BtnActivar.OnIdleState.BorderColor = System.Drawing.Color.DimGray;
            this.BtnActivar.OnIdleState.BorderRadius = 1;
            this.BtnActivar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnActivar.OnIdleState.BorderThickness = 1;
            this.BtnActivar.OnIdleState.FillColor = System.Drawing.Color.DimGray;
            this.BtnActivar.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.BtnActivar.OnIdleState.IconLeftImage = null;
            this.BtnActivar.OnIdleState.IconRightImage = null;
            this.BtnActivar.OnPressedState.BorderColor = System.Drawing.Color.Gray;
            this.BtnActivar.OnPressedState.BorderRadius = 1;
            this.BtnActivar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnActivar.OnPressedState.BorderThickness = 1;
            this.BtnActivar.OnPressedState.FillColor = System.Drawing.Color.DimGray;
            this.BtnActivar.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.BtnActivar.OnPressedState.IconLeftImage = null;
            this.BtnActivar.OnPressedState.IconRightImage = null;
            this.BtnActivar.Size = new System.Drawing.Size(150, 39);
            this.BtnActivar.TabIndex = 52;
            this.BtnActivar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnActivar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnActivar.TextMarginLeft = 0;
            this.BtnActivar.TextPadding = new System.Windows.Forms.Padding(0);
            this.BtnActivar.UseDefaultRadiusAndThickness = true;
            this.BtnActivar.Click += new System.EventHandler(this.BtnActivar_Click);
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
            this.BtnAplicar.Location = new System.Drawing.Point(12, 543);
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
            this.BtnAplicar.TabIndex = 51;
            this.BtnAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnAplicar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnAplicar.TextMarginLeft = 0;
            this.BtnAplicar.TextPadding = new System.Windows.Forms.Padding(0);
            this.BtnAplicar.UseDefaultRadiusAndThickness = true;
            this.BtnAplicar.Click += new System.EventHandler(this.BtnAplicar_Click);
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
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.BtnLimpiar.CustomizableEdges = borderEdges3;
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
            this.BtnLimpiar.Location = new System.Drawing.Point(385, 543);
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
            this.BtnLimpiar.TabIndex = 50;
            this.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnLimpiar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnLimpiar.TextMarginLeft = 0;
            this.BtnLimpiar.TextPadding = new System.Windows.Forms.Padding(0);
            this.BtnLimpiar.UseDefaultRadiusAndThickness = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // DateTimePickerFin
            // 
            this.DateTimePickerFin.Location = new System.Drawing.Point(616, 489);
            this.DateTimePickerFin.Name = "DateTimePickerFin";
            this.DateTimePickerFin.Size = new System.Drawing.Size(200, 20);
            this.DateTimePickerFin.TabIndex = 59;
            // 
            // DateTimePickerIni
            // 
            this.DateTimePickerIni.Location = new System.Drawing.Point(202, 489);
            this.DateTimePickerIni.Name = "DateTimePickerIni";
            this.DateTimePickerIni.Size = new System.Drawing.Size(200, 20);
            this.DateTimePickerIni.TabIndex = 58;
            // 
            // LblFechaFin
            // 
            this.LblFechaFin.AllowParentOverrides = false;
            this.LblFechaFin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblFechaFin.AutoEllipsis = false;
            this.LblFechaFin.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblFechaFin.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblFechaFin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LblFechaFin.Location = new System.Drawing.Point(507, 488);
            this.LblFechaFin.Name = "LblFechaFin";
            this.LblFechaFin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblFechaFin.Size = new System.Drawing.Size(68, 21);
            this.LblFechaFin.TabIndex = 57;
            this.LblFechaFin.Text = "Fecha Fin:";
            this.LblFechaFin.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblFechaFin.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblFechaIni
            // 
            this.LblFechaIni.AllowParentOverrides = false;
            this.LblFechaIni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblFechaIni.AutoEllipsis = false;
            this.LblFechaIni.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblFechaIni.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblFechaIni.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LblFechaIni.Location = new System.Drawing.Point(93, 488);
            this.LblFechaIni.Name = "LblFechaIni";
            this.LblFechaIni.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblFechaIni.Size = new System.Drawing.Size(87, 21);
            this.LblFechaIni.TabIndex = 56;
            this.LblFechaIni.Text = "Fecha Inicial:";
            this.LblFechaIni.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblFechaIni.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // CmbDescripcion
            // 
            this.CmbDescripcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDescripcion.FormattingEnabled = true;
            this.CmbDescripcion.Location = new System.Drawing.Point(386, 440);
            this.CmbDescripcion.Name = "CmbDescripcion";
            this.CmbDescripcion.Size = new System.Drawing.Size(190, 21);
            this.CmbDescripcion.TabIndex = 61;
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.AllowParentOverrides = false;
            this.LblDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblDescripcion.AutoEllipsis = false;
            this.LblDescripcion.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblDescripcion.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblDescripcion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LblDescripcion.Location = new System.Drawing.Point(281, 440);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblDescripcion.Size = new System.Drawing.Size(84, 21);
            this.LblDescripcion.TabIndex = 60;
            this.LblDescripcion.Text = "Descripcion:";
            this.LblDescripcion.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblDescripcion.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // FormCambiosServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(901, 611);
            this.Controls.Add(this.CmbDescripcion);
            this.Controls.Add(this.LblDescripcion);
            this.Controls.Add(this.DateTimePickerFin);
            this.Controls.Add(this.DateTimePickerIni);
            this.Controls.Add(this.LblFechaFin);
            this.Controls.Add(this.LblFechaIni);
            this.Controls.Add(this.BtnActivar);
            this.Controls.Add(this.BtnAplicar);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.DataGridViewServicios);
            this.Controls.Add(this.LblCambiosServicios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCambiosServicios";
            this.Text = "FormCambiosServicios";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewServicios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuDataGridView DataGridViewServicios;
        private Bunifu.UI.WinForms.BunifuLabel LblCambiosServicios;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton BtnActivar;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton BtnAplicar;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton BtnLimpiar;
        private System.Windows.Forms.DateTimePicker DateTimePickerFin;
        private System.Windows.Forms.DateTimePicker DateTimePickerIni;
        private Bunifu.UI.WinForms.BunifuLabel LblFechaFin;
        private Bunifu.UI.WinForms.BunifuLabel LblFechaIni;
        private System.Windows.Forms.ComboBox CmbDescripcion;
        private Bunifu.UI.WinForms.BunifuLabel LblDescripcion;
    }
}