﻿namespace FutureLending
{
    partial class Exportar_Excel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Exportar_Excel));
            rjButton1 = new Controles_personalizados.RJButton();
            comboBox1 = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.Crimson;
            rjButton1.BackgroundColor = Color.Crimson;
            rjButton1.BorderColor = Color.PaleVioletRed;
            rjButton1.BorderRadius = 20;
            rjButton1.BorderSize = 0;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.Font = new Font("Cooper Black", 24F, FontStyle.Regular, GraphicsUnit.Point);
            rjButton1.ForeColor = Color.White;
            rjButton1.Location = new Point(52, 269);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(243, 96);
            rjButton1.TabIndex = 0;
            rjButton1.Text = "Exportar";
            rjButton1.TextColor = Color.White;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.Info;
            comboBox1.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(37, 126);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(275, 39);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cooper Black", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(27, 40);
            label1.Name = "label1";
            label1.Size = new Size(302, 39);
            label1.TabIndex = 2;
            label1.Text = "Exportar a Excel";
            // 
            // Exportar_Excel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(355, 400);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(rjButton1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Exportar_Excel";
            Text = "Exportar_Excel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controles_personalizados.RJButton rjButton1;
        private ComboBox comboBox1;
        private Label label1;
    }
}