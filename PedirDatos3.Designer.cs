namespace FutureLending
{
    partial class PedirDatos3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PedirDatos3));
            TextImporte3 = new Controles_personalizados.TextBoxPersonalizado();
            label103 = new Label();
            label92 = new Label();
            ComboBoxResolucion3 = new ControlesPersonalizados.RJComboBox();
            label102 = new Label();
            rjButton1 = new Controles_personalizados.RJButton();
            ComboBoxResolucionD = new ControlesPersonalizados.RJComboBox();
            SuspendLayout();
            // 
            // TextImporte3
            // 
            TextImporte3.BorderColor = Color.DarkSlateGray;
            TextImporte3.BorderFocusColor = SystemColors.Info;
            TextImporte3.BorderRadius = 0;
            TextImporte3.BorderSize = 2;
            TextImporte3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            TextImporte3.Location = new Point(285, 179);
            TextImporte3.Margin = new Padding(3, 4, 3, 4);
            TextImporte3.Multiline = false;
            TextImporte3.Name = "TextImporte3";
            TextImporte3.Padding = new Padding(11, 9, 11, 9);
            TextImporte3.PasswordChar = false;
            TextImporte3.PlaceholderColor = Color.DimGray;
            TextImporte3.PlaceholderText = "";
            TextImporte3.Size = new Size(349, 48);
            TextImporte3.TabIndex = 136;
            TextImporte3.Texts = "";
            TextImporte3.UnderlinedStyle = true;
            // 
            // label103
            // 
            label103.AutoSize = true;
            label103.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label103.Location = new Point(25, 198);
            label103.Name = "label103";
            label103.Size = new Size(101, 29);
            label103.TabIndex = 135;
            label103.Text = "Importe:";
            // 
            // label92
            // 
            label92.AutoSize = true;
            label92.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label92.Location = new Point(25, 117);
            label92.Name = "label92";
            label92.Size = new Size(250, 29);
            label92.TabIndex = 133;
            label92.Text = "Resolucion Demanda:";
            // 
            // ComboBoxResolucion3
            // 
            ComboBoxResolucion3.AutoCompleteMode = AutoCompleteMode.Suggest;
            ComboBoxResolucion3.AutoCompleteSource = AutoCompleteSource.ListItems;
            ComboBoxResolucion3.BackColor = SystemColors.Info;
            ComboBoxResolucion3.BorderColor = Color.DarkSlateGray;
            ComboBoxResolucion3.BorderSize = 2;
            ComboBoxResolucion3.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxResolucion3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ComboBoxResolucion3.ForeColor = Color.Black;
            ComboBoxResolucion3.IconColor = Color.DarkSlateGray;
            ComboBoxResolucion3.Items.AddRange(new object[] { "Liquidacion", "Convenio" });
            ComboBoxResolucion3.ListBackColor = SystemColors.Info;
            ComboBoxResolucion3.ListTextColor = Color.DimGray;
            ComboBoxResolucion3.Location = new Point(273, 13);
            ComboBoxResolucion3.Margin = new Padding(3, 4, 3, 4);
            ComboBoxResolucion3.MinimumSize = new Size(229, 40);
            ComboBoxResolucion3.Name = "ComboBoxResolucion3";
            ComboBoxResolucion3.Padding = new Padding(2, 3, 2, 3);
            ComboBoxResolucion3.Size = new Size(361, 55);
            ComboBoxResolucion3.TabIndex = 129;
            ComboBoxResolucion3.Tag = "Selecciones un tipo de pago";
            ComboBoxResolucion3.Texts = "Seleccione un tipo de pago";
            ComboBoxResolucion3.OnSelectedIndexChanged += ComboBoxResolucion3_OnSelectedIndexChanged;
            // 
            // label102
            // 
            label102.AutoSize = true;
            label102.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label102.Location = new Point(25, 26);
            label102.Name = "label102";
            label102.Size = new Size(230, 29);
            label102.TabIndex = 131;
            label102.Text = "Tipo de Resolucion:";
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.Pink;
            rjButton1.BackgroundColor = Color.Pink;
            rjButton1.BorderColor = Color.PaleVioletRed;
            rjButton1.BorderRadius = 20;
            rjButton1.BorderSize = 0;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.Font = new Font("Roboto", 18F, FontStyle.Bold, GraphicsUnit.Point);
            rjButton1.ForeColor = Color.Black;
            rjButton1.Location = new Point(388, 307);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(213, 79);
            rjButton1.TabIndex = 137;
            rjButton1.Text = "Mover";
            rjButton1.TextColor = Color.Black;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // ComboBoxResolucionD
            // 
            ComboBoxResolucionD.AutoCompleteMode = AutoCompleteMode.Suggest;
            ComboBoxResolucionD.AutoCompleteSource = AutoCompleteSource.ListItems;
            ComboBoxResolucionD.BackColor = SystemColors.Info;
            ComboBoxResolucionD.BorderColor = Color.DarkSlateGray;
            ComboBoxResolucionD.BorderSize = 2;
            ComboBoxResolucionD.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxResolucionD.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ComboBoxResolucionD.ForeColor = Color.Black;
            ComboBoxResolucionD.IconColor = Color.DarkSlateGray;
            ComboBoxResolucionD.Items.AddRange(new object[] { "En Tramite", "Embargo" });
            ComboBoxResolucionD.ListBackColor = SystemColors.Info;
            ComboBoxResolucionD.ListTextColor = Color.DimGray;
            ComboBoxResolucionD.Location = new Point(273, 105);
            ComboBoxResolucionD.Margin = new Padding(3, 4, 3, 4);
            ComboBoxResolucionD.MinimumSize = new Size(229, 40);
            ComboBoxResolucionD.Name = "ComboBoxResolucionD";
            ComboBoxResolucionD.Padding = new Padding(2, 3, 2, 3);
            ComboBoxResolucionD.Size = new Size(361, 55);
            ComboBoxResolucionD.TabIndex = 138;
            ComboBoxResolucionD.Tag = "Selecciones un tipo de pago";
            ComboBoxResolucionD.Texts = "Seleccione un tipo de pago";
            // 
            // PedirDatos3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(700, 412);
            Controls.Add(ComboBoxResolucionD);
            Controls.Add(rjButton1);
            Controls.Add(TextImporte3);
            Controls.Add(label103);
            Controls.Add(label92);
            Controls.Add(ComboBoxResolucion3);
            Controls.Add(label102);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PedirDatos3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Informacion Lista3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Controles_personalizados.TextBoxPersonalizado TextImporte3;
        private Label label103;
        private Label label92;
        public ControlesPersonalizados.RJComboBox ComboBoxResolucion3;
        private Label label102;
        public Controles_personalizados.RJButton rjButton1;
        public ControlesPersonalizados.RJComboBox ComboBoxResolucionD;
    }
}