namespace UI
{
    partial class FormInicio
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicio));
            this.PictureInicio = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.PanelReporte = new System.Windows.Forms.Panel();
            this.PanelProximosEventos = new Bunifu.UI.WinForms.BunifuPanel();
            this.BtnEventos = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblDatoMedioPago = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblDatoCliente = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblDatoUbicacion = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblDatoFecha = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblDatoEvento = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuPictureBox1 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.LblMedioDePago = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblCliente = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblUbicacion = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblFecha = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblEvento = new Bunifu.UI.WinForms.BunifuLabel();
            this.TimerReporte = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PictureInicio)).BeginInit();
            this.PanelReporte.SuspendLayout();
            this.PanelProximosEventos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureInicio
            // 
            this.PictureInicio.AllowFocused = false;
            this.PictureInicio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PictureInicio.AutoSizeHeight = true;
            this.PictureInicio.BorderRadius = 181;
            this.PictureInicio.Image = ((System.Drawing.Image)(resources.GetObject("PictureInicio.Image")));
            this.PictureInicio.IsCircle = true;
            this.PictureInicio.Location = new System.Drawing.Point(200, 76);
            this.PictureInicio.Name = "PictureInicio";
            this.PictureInicio.Size = new System.Drawing.Size(363, 363);
            this.PictureInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureInicio.TabIndex = 2;
            this.PictureInicio.TabStop = false;
            this.PictureInicio.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // PanelReporte
            // 
            this.PanelReporte.Controls.Add(this.PanelProximosEventos);
            this.PanelReporte.Controls.Add(this.PictureInicio);
            this.PanelReporte.Location = new System.Drawing.Point(79, 51);
            this.PanelReporte.Name = "PanelReporte";
            this.PanelReporte.Size = new System.Drawing.Size(749, 509);
            this.PanelReporte.TabIndex = 3;
            // 
            // PanelProximosEventos
            // 
            this.PanelProximosEventos.BackgroundColor = System.Drawing.Color.Transparent;
            this.PanelProximosEventos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelProximosEventos.BackgroundImage")));
            this.PanelProximosEventos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelProximosEventos.BorderColor = System.Drawing.Color.LightSlateGray;
            this.PanelProximosEventos.BorderRadius = 20;
            this.PanelProximosEventos.BorderThickness = 1;
            this.PanelProximosEventos.Controls.Add(this.BtnEventos);
            this.PanelProximosEventos.Controls.Add(this.LblDatoMedioPago);
            this.PanelProximosEventos.Controls.Add(this.LblDatoCliente);
            this.PanelProximosEventos.Controls.Add(this.LblDatoUbicacion);
            this.PanelProximosEventos.Controls.Add(this.LblDatoFecha);
            this.PanelProximosEventos.Controls.Add(this.LblDatoEvento);
            this.PanelProximosEventos.Controls.Add(this.bunifuPictureBox1);
            this.PanelProximosEventos.Controls.Add(this.LblMedioDePago);
            this.PanelProximosEventos.Controls.Add(this.LblCliente);
            this.PanelProximosEventos.Controls.Add(this.LblUbicacion);
            this.PanelProximosEventos.Controls.Add(this.LblFecha);
            this.PanelProximosEventos.Controls.Add(this.LblEvento);
            this.PanelProximosEventos.Location = new System.Drawing.Point(3, 3);
            this.PanelProximosEventos.Name = "PanelProximosEventos";
            this.PanelProximosEventos.ShowBorders = true;
            this.PanelProximosEventos.Size = new System.Drawing.Size(743, 503);
            this.PanelProximosEventos.TabIndex = 3;
            // 
            // BtnEventos
            // 
            this.BtnEventos.AllowParentOverrides = false;
            this.BtnEventos.AutoEllipsis = false;
            this.BtnEventos.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnEventos.CursorType = System.Windows.Forms.Cursors.Default;
            this.BtnEventos.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Italic);
            this.BtnEventos.Location = new System.Drawing.Point(301, 39);
            this.BtnEventos.Name = "BtnEventos";
            this.BtnEventos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnEventos.Size = new System.Drawing.Size(158, 65);
            this.BtnEventos.TabIndex = 11;
            this.BtnEventos.Text = "Eventos";
            this.BtnEventos.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.BtnEventos.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblDatoMedioPago
            // 
            this.LblDatoMedioPago.AllowParentOverrides = false;
            this.LblDatoMedioPago.AutoEllipsis = false;
            this.LblDatoMedioPago.CursorType = null;
            this.LblDatoMedioPago.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Italic);
            this.LblDatoMedioPago.Location = new System.Drawing.Point(245, 423);
            this.LblDatoMedioPago.Name = "LblDatoMedioPago";
            this.LblDatoMedioPago.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblDatoMedioPago.Size = new System.Drawing.Size(79, 32);
            this.LblDatoMedioPago.TabIndex = 10;
            this.LblDatoMedioPago.Text = "Efectivo";
            this.LblDatoMedioPago.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblDatoMedioPago.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblDatoCliente
            // 
            this.LblDatoCliente.AllowParentOverrides = false;
            this.LblDatoCliente.AutoEllipsis = false;
            this.LblDatoCliente.CursorType = null;
            this.LblDatoCliente.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Italic);
            this.LblDatoCliente.Location = new System.Drawing.Point(134, 351);
            this.LblDatoCliente.Name = "LblDatoCliente";
            this.LblDatoCliente.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblDatoCliente.Size = new System.Drawing.Size(142, 32);
            this.LblDatoCliente.TabIndex = 9;
            this.LblDatoCliente.Text = "Tomas Juarez";
            this.LblDatoCliente.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblDatoCliente.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblDatoUbicacion
            // 
            this.LblDatoUbicacion.AllowParentOverrides = false;
            this.LblDatoUbicacion.AutoEllipsis = false;
            this.LblDatoUbicacion.CursorType = null;
            this.LblDatoUbicacion.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Italic);
            this.LblDatoUbicacion.Location = new System.Drawing.Point(175, 282);
            this.LblDatoUbicacion.Name = "LblDatoUbicacion";
            this.LblDatoUbicacion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblDatoUbicacion.Size = new System.Drawing.Size(62, 32);
            this.LblDatoUbicacion.TabIndex = 8;
            this.LblDatoUbicacion.Text = "Alsina ";
            this.LblDatoUbicacion.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblDatoUbicacion.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblDatoFecha
            // 
            this.LblDatoFecha.AllowParentOverrides = false;
            this.LblDatoFecha.AutoEllipsis = false;
            this.LblDatoFecha.CursorType = null;
            this.LblDatoFecha.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Italic);
            this.LblDatoFecha.Location = new System.Drawing.Point(115, 211);
            this.LblDatoFecha.Name = "LblDatoFecha";
            this.LblDatoFecha.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblDatoFecha.Size = new System.Drawing.Size(124, 32);
            this.LblDatoFecha.TabIndex = 7;
            this.LblDatoFecha.Text = "04/11/2024";
            this.LblDatoFecha.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblDatoFecha.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblDatoEvento
            // 
            this.LblDatoEvento.AllowParentOverrides = false;
            this.LblDatoEvento.AutoEllipsis = false;
            this.LblDatoEvento.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblDatoEvento.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblDatoEvento.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Italic);
            this.LblDatoEvento.Location = new System.Drawing.Point(129, 141);
            this.LblDatoEvento.Name = "LblDatoEvento";
            this.LblDatoEvento.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblDatoEvento.Size = new System.Drawing.Size(111, 32);
            this.LblDatoEvento.TabIndex = 6;
            this.LblDatoEvento.Text = "Evento pro";
            this.LblDatoEvento.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblDatoEvento.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuPictureBox1
            // 
            this.bunifuPictureBox1.AllowFocused = false;
            this.bunifuPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPictureBox1.AutoSizeHeight = true;
            this.bunifuPictureBox1.BorderRadius = 73;
            this.bunifuPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuPictureBox1.Image")));
            this.bunifuPictureBox1.IsCircle = true;
            this.bunifuPictureBox1.Location = new System.Drawing.Point(594, 3);
            this.bunifuPictureBox1.Name = "bunifuPictureBox1";
            this.bunifuPictureBox1.Size = new System.Drawing.Size(146, 146);
            this.bunifuPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox1.TabIndex = 5;
            this.bunifuPictureBox1.TabStop = false;
            this.bunifuPictureBox1.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // LblMedioDePago
            // 
            this.LblMedioDePago.AllowParentOverrides = false;
            this.LblMedioDePago.AutoEllipsis = false;
            this.LblMedioDePago.CursorType = null;
            this.LblMedioDePago.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Italic);
            this.LblMedioDePago.Location = new System.Drawing.Point(20, 414);
            this.LblMedioDePago.Name = "LblMedioDePago";
            this.LblMedioDePago.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblMedioDePago.Size = new System.Drawing.Size(219, 45);
            this.LblMedioDePago.TabIndex = 4;
            this.LblMedioDePago.Text = "Medio de pago:";
            this.LblMedioDePago.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblMedioDePago.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblCliente
            // 
            this.LblCliente.AllowParentOverrides = false;
            this.LblCliente.AutoEllipsis = false;
            this.LblCliente.CursorType = null;
            this.LblCliente.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Italic);
            this.LblCliente.Location = new System.Drawing.Point(20, 342);
            this.LblCliente.Name = "LblCliente";
            this.LblCliente.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblCliente.Size = new System.Drawing.Size(108, 45);
            this.LblCliente.TabIndex = 3;
            this.LblCliente.Text = "Cliente:";
            this.LblCliente.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblCliente.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblUbicacion
            // 
            this.LblUbicacion.AllowParentOverrides = false;
            this.LblUbicacion.AutoEllipsis = false;
            this.LblUbicacion.CursorType = null;
            this.LblUbicacion.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Italic);
            this.LblUbicacion.Location = new System.Drawing.Point(20, 273);
            this.LblUbicacion.Name = "LblUbicacion";
            this.LblUbicacion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblUbicacion.Size = new System.Drawing.Size(149, 45);
            this.LblUbicacion.TabIndex = 2;
            this.LblUbicacion.Text = "Ubicación:";
            this.LblUbicacion.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblUbicacion.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblFecha
            // 
            this.LblFecha.AllowParentOverrides = false;
            this.LblFecha.AutoEllipsis = false;
            this.LblFecha.CursorType = null;
            this.LblFecha.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Italic);
            this.LblFecha.Location = new System.Drawing.Point(20, 202);
            this.LblFecha.Name = "LblFecha";
            this.LblFecha.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblFecha.Size = new System.Drawing.Size(89, 45);
            this.LblFecha.TabIndex = 1;
            this.LblFecha.Text = "Fecha:";
            this.LblFecha.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblFecha.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblEvento
            // 
            this.LblEvento.AllowParentOverrides = false;
            this.LblEvento.AutoEllipsis = false;
            this.LblEvento.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblEvento.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblEvento.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Italic);
            this.LblEvento.Location = new System.Drawing.Point(20, 132);
            this.LblEvento.Name = "LblEvento";
            this.LblEvento.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblEvento.Size = new System.Drawing.Size(103, 45);
            this.LblEvento.TabIndex = 0;
            this.LblEvento.Text = "Evento:";
            this.LblEvento.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblEvento.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // TimerReporte
            // 
            this.TimerReporte.Interval = 5000;
            this.TimerReporte.Tick += new System.EventHandler(this.TimerReporte_Tick);
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(901, 611);
            this.Controls.Add(this.PanelReporte);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInicio";
            this.Text = "FormInicio";
            ((System.ComponentModel.ISupportInitialize)(this.PictureInicio)).EndInit();
            this.PanelReporte.ResumeLayout(false);
            this.PanelProximosEventos.ResumeLayout(false);
            this.PanelProximosEventos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPictureBox PictureInicio;
        private System.Windows.Forms.Panel PanelReporte;
        private Bunifu.UI.WinForms.BunifuPanel PanelProximosEventos;
        private Bunifu.UI.WinForms.BunifuLabel LblMedioDePago;
        private Bunifu.UI.WinForms.BunifuLabel LblCliente;
        private Bunifu.UI.WinForms.BunifuLabel LblUbicacion;
        private Bunifu.UI.WinForms.BunifuLabel LblFecha;
        private Bunifu.UI.WinForms.BunifuLabel LblEvento;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        private System.Windows.Forms.Timer TimerReporte;
        private Bunifu.UI.WinForms.BunifuLabel LblDatoEvento;
        private Bunifu.UI.WinForms.BunifuLabel LblDatoFecha;
        private Bunifu.UI.WinForms.BunifuLabel LblDatoUbicacion;
        private Bunifu.UI.WinForms.BunifuLabel LblDatoCliente;
        private Bunifu.UI.WinForms.BunifuLabel LblDatoMedioPago;
        private Bunifu.UI.WinForms.BunifuLabel BtnEventos;
    }
}