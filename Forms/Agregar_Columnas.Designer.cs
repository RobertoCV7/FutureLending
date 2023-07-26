using FutureLending.ControlesPersonalizados;

namespace FutureLending.Forms
{
    partial class Agregar_Columnas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Agregar_Columnas));
            textBoxPersonalizado1 = new TextBoxPersonalizado();
            label1 = new Label();
            rjButton1 = new Controles_personalizados.RjButton();
            rjButton2 = new Controles_personalizados.RjButton();
            SuspendLayout();
            // 
            // textBoxPersonalizado1
            // 
            textBoxPersonalizado1.BorderColor = Color.MediumSlateBlue;
            textBoxPersonalizado1.BorderFocusColor = Color.HotPink;
            textBoxPersonalizado1.BorderRadius = 0;
            textBoxPersonalizado1.BorderSize = 2;
            textBoxPersonalizado1.Font = new Font("Corbel", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxPersonalizado1.Location = new Point(286, 42);
            textBoxPersonalizado1.Multiline = false;
            textBoxPersonalizado1.Name = "textBoxPersonalizado1";
            textBoxPersonalizado1.Padding = new Padding(10, 7, 10, 7);
            textBoxPersonalizado1.PasswordChar = false;
            textBoxPersonalizado1.PlaceholderColor = Color.DarkGray;
            textBoxPersonalizado1.PlaceholderText = "";
            textBoxPersonalizado1.Size = new Size(125, 57);
            textBoxPersonalizado1.TabIndex = 0;
            textBoxPersonalizado1.Texts = "";
            textBoxPersonalizado1.UnderlinedStyle = false;
            textBoxPersonalizado1.KeyPress += textBoxPersonalizado1_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Corbel", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 70);
            label1.Name = "label1";
            label1.Size = new Size(244, 29);
            label1.TabIndex = 1;
            label1.Text = "Cantidad de Columnas:";
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
            rjButton1.Font = new Font("Corbel", 18F, FontStyle.Bold, GraphicsUnit.Point);
            rjButton1.ForeColor = Color.White;
            rjButton1.Location = new Point(33, 201);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(180, 57);
            rjButton1.TabIndex = 2;
            rjButton1.Text = "Agregar";
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
            rjButton2.Font = new Font("Corbel", 18F, FontStyle.Bold, GraphicsUnit.Point);
            rjButton2.ForeColor = Color.White;
            rjButton2.Location = new Point(325, 201);
            rjButton2.Name = "rjButton2";
            rjButton2.Size = new Size(180, 57);
            rjButton2.TabIndex = 3;
            rjButton2.Text = "Cancelar";
            rjButton2.TextColor = Color.White;
            rjButton2.UseVisualStyleBackColor = false;
            rjButton2.Click += rjButton2_Click;
            // 
            // Agregar_Columnas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(558, 290);
            Controls.Add(rjButton2);
            Controls.Add(rjButton1);
            Controls.Add(label1);
            Controls.Add(textBoxPersonalizado1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Agregar_Columnas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar_Columnas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBoxPersonalizado textBoxPersonalizado1;
        private Label label1;
        private Controles_personalizados.RjButton rjButton1;
        private Controles_personalizados.RjButton rjButton2;
    }
}