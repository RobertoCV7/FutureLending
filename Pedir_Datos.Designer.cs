﻿namespace FutureLending
{
    partial class Pedir_Datos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pedir_Datos));
            rjComboBox2 = new ControlesPersonalizados.RJComboBox();
            label30 = new Label();
            TextLiquidacionPedir = new Controles_personalizados.TextBoxPersonalizado();
            label33 = new Label();
            BotonDeingresarPedir = new Controles_personalizados.RJButton();
            SuspendLayout();
            // 
            // rjComboBox2
            // 
            rjComboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            rjComboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            rjComboBox2.BackColor = SystemColors.Info;
            rjComboBox2.BorderColor = Color.DarkSlateGray;
            rjComboBox2.BorderSize = 2;
            rjComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            rjComboBox2.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            rjComboBox2.ForeColor = Color.Black;
            rjComboBox2.IconColor = Color.DarkSlateGray;
            rjComboBox2.Items.AddRange(new object[] { "Liquidacion", "Convenio" });
            rjComboBox2.ListBackColor = SystemColors.Info;
            rjComboBox2.ListTextColor = Color.DimGray;
            rjComboBox2.Location = new Point(217, 36);
            rjComboBox2.Margin = new Padding(3, 2, 3, 2);
            rjComboBox2.MinimumSize = new Size(175, 22);
            rjComboBox2.Name = "rjComboBox2";
            rjComboBox2.Padding = new Padding(2);
            rjComboBox2.Size = new Size(389, 48);
            rjComboBox2.TabIndex = 56;
            rjComboBox2.Tag = "Selecciones un tipo de pago";
            rjComboBox2.Texts = "Seleccione un tipo de pago";
            rjComboBox2.OnSelectedIndexChanged += rjComboBox2_OnSelectedIndexChanged;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label30.Location = new Point(10, 47);
            label30.Name = "label30";
            label30.Size = new Size(166, 24);
            label30.TabIndex = 57;
            label30.Text = "Tipo de pago:";
            // 
            // TextLiquidacionPedir
            // 
            TextLiquidacionPedir.BorderColor = Color.DarkSlateGray;
            TextLiquidacionPedir.BorderFocusColor = SystemColors.Info;
            TextLiquidacionPedir.BorderRadius = 0;
            TextLiquidacionPedir.BorderSize = 2;
            TextLiquidacionPedir.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            TextLiquidacionPedir.Location = new Point(290, 130);
            TextLiquidacionPedir.Multiline = false;
            TextLiquidacionPedir.Name = "TextLiquidacionPedir";
            TextLiquidacionPedir.Padding = new Padding(10, 7, 10, 7);
            TextLiquidacionPedir.PasswordChar = false;
            TextLiquidacionPedir.PlaceholderColor = Color.DimGray;
            TextLiquidacionPedir.PlaceholderText = "";
            TextLiquidacionPedir.Size = new Size(316, 39);
            TextLiquidacionPedir.TabIndex = 59;
            TextLiquidacionPedir.Texts = "";
            TextLiquidacionPedir.UnderlinedStyle = true;
            TextLiquidacionPedir._TextChanged += TextLiquidacionPedir__TextChanged;
            TextLiquidacionPedir.KeyPress += TextLiquidacionPedir_KeyPress;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label33.Location = new Point(10, 145);
            label33.Name = "label33";
            label33.Size = new Size(274, 24);
            label33.TabIndex = 58;
            label33.Text = "Liquidacion/Intencion:";
            // 
            // BotonDeingresarPedir
            // 
            BotonDeingresarPedir.BackColor = Color.Crimson;
            BotonDeingresarPedir.BackgroundColor = Color.Crimson;
            BotonDeingresarPedir.BorderColor = Color.PaleVioletRed;
            BotonDeingresarPedir.BorderRadius = 20;
            BotonDeingresarPedir.BorderSize = 0;
            BotonDeingresarPedir.FlatAppearance.BorderSize = 0;
            BotonDeingresarPedir.FlatStyle = FlatStyle.Flat;
            BotonDeingresarPedir.Font = new Font("Cooper Black", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            BotonDeingresarPedir.ForeColor = Color.White;
            BotonDeingresarPedir.Location = new Point(304, 215);
            BotonDeingresarPedir.Margin = new Padding(3, 2, 3, 2);
            BotonDeingresarPedir.Name = "BotonDeingresarPedir";
            BotonDeingresarPedir.Size = new Size(218, 70);
            BotonDeingresarPedir.TabIndex = 62;
            BotonDeingresarPedir.Text = "Ingresar";
            BotonDeingresarPedir.TextColor = Color.White;
            BotonDeingresarPedir.UseVisualStyleBackColor = false;
            BotonDeingresarPedir.Click += BotonDeingresarPedir_Click;
            // 
            // Pedir_Datos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(626, 295);
            Controls.Add(BotonDeingresarPedir);
            Controls.Add(TextLiquidacionPedir);
            Controls.Add(label33);
            Controls.Add(rjComboBox2);
            Controls.Add(label30);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Pedir_Datos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pedir_Datos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ControlesPersonalizados.RJComboBox rjComboBox2;
        private Label label30;
        public Controles_personalizados.TextBoxPersonalizado TextLiquidacionPedir;
        private Label label33;
        public Controles_personalizados.RJButton BotonDeingresarPedir;
    }
}