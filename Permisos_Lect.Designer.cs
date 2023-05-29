namespace FutureLending
{
    partial class Permisos_Lect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Permisos_Lect));
            checkedListBox1 = new CheckedListBox();
            label1 = new Label();
            Label_User = new Label();
            rjButton1 = new Controles_personalizados.RJButton();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.BackColor = SystemColors.Info;
            checkedListBox1.Font = new Font("Roboto Black", 18F, FontStyle.Bold, GraphicsUnit.Point);
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "lista1", "lista2", "lista3", "liquidados" });
            checkedListBox1.Location = new Point(63, 92);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(256, 160);
            checkedListBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 26);
            label1.Name = "label1";
            label1.Size = new Size(129, 37);
            label1.TabIndex = 1;
            label1.Text = "Usuario:";
            // 
            // Label_User
            // 
            Label_User.AutoSize = true;
            Label_User.Font = new Font("Roboto", 18F, FontStyle.Bold, GraphicsUnit.Point);
            Label_User.Location = new Point(147, 26);
            Label_User.Name = "Label_User";
            Label_User.Size = new Size(0, 37);
            Label_User.TabIndex = 2;
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
            rjButton1.Font = new Font("Roboto Black", 18F, FontStyle.Bold, GraphicsUnit.Point);
            rjButton1.ForeColor = Color.White;
            rjButton1.Location = new Point(74, 313);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(225, 76);
            rjButton1.TabIndex = 3;
            rjButton1.Text = "Guardar";
            rjButton1.TextColor = Color.White;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // Permisos_Lect
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(388, 416);
            Controls.Add(rjButton1);
            Controls.Add(Label_User);
            Controls.Add(label1);
            Controls.Add(checkedListBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Permisos_Lect";
            Text = "Permisos de Lectura";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBox1;
        private Label label1;
        private Label Label_User;
        private Controles_personalizados.RJButton rjButton1;
    }
}