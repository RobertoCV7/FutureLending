namespace FutureLending
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            Texto = new Label();
            rjButton1 = new Controles_personalizados.RJButton();
            SuspendLayout();
            // 
            // Texto
            // 
            Texto.AutoSize = true;
            Texto.Font = new Font("Cooper Black", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            Texto.ForeColor = SystemColors.Highlight;
            Texto.Location = new Point(43, 23);
            Texto.Margin = new Padding(3, 3, 3, 0);
            Texto.Name = "Texto";
            Texto.Size = new Size(517, 31);
            Texto.TabIndex = 0;
            Texto.Text = "El programa funciona correctamente";
            Texto.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.LightCoral;
            rjButton1.BackgroundColor = Color.LightCoral;
            rjButton1.BorderColor = Color.PaleVioletRed;
            rjButton1.BorderRadius = 20;
            rjButton1.BorderSize = 0;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.Font = new Font("Cooper Black", 24F, FontStyle.Regular, GraphicsUnit.Point);
            rjButton1.ForeColor = Color.White;
            rjButton1.Location = new Point(183, 125);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(254, 83);
            rjButton1.TabIndex = 1;
            rjButton1.Text = "Aceptar";
            rjButton1.TextColor = Color.White;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += RjButton1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(617, 220);
            Controls.Add(rjButton1);
            Controls.Add(Texto);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form2";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Controles_personalizados.RJButton rjButton1;
        private Label Texto;
    }
}