namespace FutureLending.Forms
{
    partial class Revision_Mover_Liquidados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Revision_Mover_Liquidados));
            label1 = new Label();
            rjButton1 = new Controles_personalizados.RJButton();
            rjButton2 = new Controles_personalizados.RJButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Corbel", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(98, 19);
            label1.Name = "label1";
            label1.Size = new Size(451, 39);
            label1.TabIndex = 0;
            label1.Text = "¿Seguro de mover a liquidados?";
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.Gray;
            rjButton1.BackgroundColor = Color.Gray;
            rjButton1.BorderColor = Color.PaleVioletRed;
            rjButton1.BorderRadius = 20;
            rjButton1.BorderSize = 0;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.Font = new Font("Corbel", 24F, FontStyle.Bold, GraphicsUnit.Point);
            rjButton1.ForeColor = Color.White;
            rjButton1.Location = new Point(53, 207);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(187, 65);
            rjButton1.TabIndex = 1;
            rjButton1.Text = "Cancelar";
            rjButton1.TextColor = Color.White;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // rjButton2
            // 
            rjButton2.BackColor = Color.IndianRed;
            rjButton2.BackgroundColor = Color.IndianRed;
            rjButton2.BorderColor = Color.PaleVioletRed;
            rjButton2.BorderRadius = 20;
            rjButton2.BorderSize = 0;
            rjButton2.FlatAppearance.BorderSize = 0;
            rjButton2.FlatStyle = FlatStyle.Flat;
            rjButton2.Font = new Font("Corbel", 24F, FontStyle.Bold, GraphicsUnit.Point);
            rjButton2.ForeColor = Color.White;
            rjButton2.Location = new Point(448, 207);
            rjButton2.Name = "rjButton2";
            rjButton2.Size = new Size(187, 65);
            rjButton2.TabIndex = 2;
            rjButton2.Text = "Mover";
            rjButton2.TextColor = Color.White;
            rjButton2.UseVisualStyleBackColor = false;
            rjButton2.Click += rjButton2_Click;
            // 
            // Revision_Mover_Liquidados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            ClientSize = new Size(687, 302);
            Controls.Add(rjButton2);
            Controls.Add(rjButton1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Revision_Mover_Liquidados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Revision Mover Liquidados";
            FormClosing += Revision_Mover_Liquidados_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Controles_personalizados.RJButton rjButton1;
        private Controles_personalizados.RJButton rjButton2;
    }
}