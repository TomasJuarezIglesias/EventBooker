namespace UI
{
    partial class FormSistemaNoDisponible
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
            this.LblErrorSistema = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblErrorSistema
            // 
            this.LblErrorSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblErrorSistema.Location = new System.Drawing.Point(46, 59);
            this.LblErrorSistema.Name = "LblErrorSistema";
            this.LblErrorSistema.Size = new System.Drawing.Size(467, 98);
            this.LblErrorSistema.TabIndex = 0;
            this.LblErrorSistema.Text = "El sistema no se encuentra disponible en estos momentos. Contacte al Administrado" +
    "r.";
            this.LblErrorSistema.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormSistemaNoDisponible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(572, 220);
            this.Controls.Add(this.LblErrorSistema);
            this.Name = "FormSistemaNoDisponible";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblErrorSistema;
    }
}