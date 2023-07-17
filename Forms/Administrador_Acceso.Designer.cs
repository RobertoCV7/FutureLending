namespace FutureLending.Forms
{
    partial class Administrador_Acceso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administrador_Acceso));
            label1 = new Label();
            TextBoxUsuario = new Controles_personalizados.TextBoxPersonalizado();
            label2 = new Label();
            label3 = new Label();
            TextBoxContra = new Controles_personalizados.TextBoxPersonalizado();
            rjButton1 = new Controles_personalizados.RJButton();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Corbel", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 18);
            label1.Name = "label1";
            label1.Size = new Size(608, 33);
            label1.TabIndex = 0;
            label1.Text = "Porfavor Digite unas credenciales de administrador";
            // 
            // TextBoxUsuario
            // 
            TextBoxUsuario.BorderColor = Color.MediumSlateBlue;
            TextBoxUsuario.BorderFocusColor = Color.HotPink;
            TextBoxUsuario.BorderRadius = 0;
            TextBoxUsuario.BorderSize = 2;
            TextBoxUsuario.Font = new Font("Corbel", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            TextBoxUsuario.Location = new Point(102, 138);
            TextBoxUsuario.Multiline = false;
            TextBoxUsuario.Name = "TextBoxUsuario";
            TextBoxUsuario.Padding = new Padding(10, 7, 10, 7);
            TextBoxUsuario.PasswordChar = false;
            TextBoxUsuario.PlaceholderColor = Color.DarkGray;
            TextBoxUsuario.PlaceholderText = "";
            TextBoxUsuario.Size = new Size(358, 41);
            TextBoxUsuario.TabIndex = 1;
            TextBoxUsuario.Texts = "";
            TextBoxUsuario.UnderlinedStyle = true;
            TextBoxUsuario._TextChanged += TextBoxUsuario__TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Corbel", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(102, 85);
            label2.Name = "label2";
            label2.Size = new Size(99, 29);
            label2.TabIndex = 2;
            label2.Text = "Usuario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Corbel", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(102, 212);
            label3.Name = "label3";
            label3.Size = new Size(136, 29);
            label3.TabIndex = 3;
            label3.Text = "Contraseña:";
            // 
            // TextBoxContra
            // 
            TextBoxContra.BorderColor = Color.MediumSlateBlue;
            TextBoxContra.BorderFocusColor = Color.HotPink;
            TextBoxContra.BorderRadius = 0;
            TextBoxContra.BorderSize = 2;
            TextBoxContra.Font = new Font("Corbel", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            TextBoxContra.Location = new Point(102, 258);
            TextBoxContra.Multiline = false;
            TextBoxContra.Name = "TextBoxContra";
            TextBoxContra.Padding = new Padding(10, 7, 10, 7);
            TextBoxContra.PasswordChar = true;
            TextBoxContra.PlaceholderColor = Color.DarkGray;
            TextBoxContra.PlaceholderText = "";
            TextBoxContra.Size = new Size(358, 41);
            TextBoxContra.TabIndex = 4;
            TextBoxContra.Texts = "";
            TextBoxContra.UnderlinedStyle = true;
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.MediumSlateBlue;
            rjButton1.BackgroundColor = Color.MediumSlateBlue;
            rjButton1.BorderColor = Color.PaleVioletRed;
            rjButton1.BorderRadius = 20;
            rjButton1.BorderSize = 0;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.Font = new Font("Corbel", 18F, FontStyle.Bold, GraphicsUnit.Point);
            rjButton1.ForeColor = Color.White;
            rjButton1.Location = new Point(186, 328);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(171, 53);
            rjButton1.TabIndex = 5;
            rjButton1.Text = "Verificar";
            rjButton1.TextColor = Color.White;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Corbel", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(144, 399);
            label4.Name = "label4";
            label4.Size = new Size(278, 23);
            label4.TabIndex = 6;
            label4.Text = "Contraseña o Usuario incorectos";
            // 
            // Administrador_Acceso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(612, 440);
            Controls.Add(label4);
            Controls.Add(rjButton1);
            Controls.Add(TextBoxContra);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TextBoxUsuario);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Administrador_Acceso";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Revision_Permiso";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Controles_personalizados.TextBoxPersonalizado TextBoxUsuario;
        private Label label2;
        private Label label3;
        private Controles_personalizados.TextBoxPersonalizado TextBoxContra;
        private Controles_personalizados.RJButton rjButton1;
        private Label label4;
    }
}