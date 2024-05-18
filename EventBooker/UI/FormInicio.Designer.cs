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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicio));
            this.LblSaludo = new Bunifu.UI.WinForms.BunifuLabel();
            this.SuspendLayout();
            // 
            // LblSaludo
            // 
            this.LblSaludo.AllowParentOverrides = false;
            this.LblSaludo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblSaludo.AutoEllipsis = false;
            this.LblSaludo.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblSaludo.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblSaludo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSaludo.Location = new System.Drawing.Point(357, 283);
            this.LblSaludo.Name = "LblSaludo";
            this.LblSaludo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblSaludo.Size = new System.Drawing.Size(187, 45);
            this.LblSaludo.TabIndex = 2;
            this.LblSaludo.Text = "Bienvenido ...";
            this.LblSaludo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblSaludo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(901, 611);
            this.Controls.Add(this.LblSaludo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInicio";
            this.Text = "FormInicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuLabel LblSaludo;
    }
}