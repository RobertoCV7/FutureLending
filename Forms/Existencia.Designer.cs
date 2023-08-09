namespace FutureLending.Forms
{
    partial class Existencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Existencia));
            label1 = new Label();
            label2 = new Label();
            LabelLista = new Label();
            label3 = new Label();
            LabelNombre = new Label();
            label4 = new Label();
            LabelLiquidacion = new Label();
            rjButton1 = new Controles_personalizados.RjButton();
            rjButton2 = new Controles_personalizados.RjButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Corbel", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(156, 9);
            label1.Name = "label1";
            label1.Size = new Size(301, 39);
            label1.TabIndex = 0;
            label1.Text = "Registro Encontrado";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Corbel", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 82);
            label2.Name = "label2";
            label2.Size = new Size(240, 29);
            label2.TabIndex = 1;
            label2.Text = "Se encontro en la lista:";
            // 
            // LabelLista
            // 
            LabelLista.AutoSize = true;
            LabelLista.Font = new Font("Corbel", 18F, FontStyle.Regular, GraphicsUnit.Point);
            LabelLista.Location = new Point(280, 82);
            LabelLista.Name = "LabelLista";
            LabelLista.Size = new Size(73, 29);
            LabelLista.TabIndex = 2;
            LabelLista.Text = "label3";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Corbel", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 150);
            label3.Name = "label3";
            label3.Size = new Size(102, 29);
            label3.TabIndex = 3;
            label3.Text = "Nombre:";
            // 
            // LabelNombre
            // 
            LabelNombre.AutoSize = true;
            LabelNombre.Font = new Font("Corbel", 18F, FontStyle.Regular, GraphicsUnit.Point);
            LabelNombre.Location = new Point(143, 150);
            LabelNombre.Name = "LabelNombre";
            LabelNombre.Size = new Size(74, 29);
            LabelNombre.TabIndex = 4;
            LabelNombre.Text = "label4";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Corbel", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 222);
            label4.Name = "label4";
            label4.Size = new Size(214, 29);
            label4.TabIndex = 5;
            label4.Text = "Manera de Liquidar:";
            // 
            // LabelLiquidacion
            // 
            LabelLiquidacion.AutoSize = true;
            LabelLiquidacion.Font = new Font("Corbel", 18F, FontStyle.Regular, GraphicsUnit.Point);
            LabelLiquidacion.Location = new Point(261, 222);
            LabelLiquidacion.Name = "LabelLiquidacion";
            LabelLiquidacion.Size = new Size(74, 29);
            LabelLiquidacion.TabIndex = 6;
            LabelLiquidacion.Text = "label5";
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
            rjButton1.Location = new Point(485, 309);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(185, 53);
            rjButton1.TabIndex = 7;
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
            rjButton2.Font = new Font("Corbel", 18F, FontStyle.Bold, GraphicsUnit.Point);
            rjButton2.ForeColor = Color.White;
            rjButton2.Location = new Point(261, 309);
            rjButton2.Name = "rjButton2";
            rjButton2.Size = new Size(169, 53);
            rjButton2.TabIndex = 8;
            rjButton2.Text = "Renovar";
            rjButton2.TextColor = Color.White;
            rjButton2.UseVisualStyleBackColor = false;
            rjButton2.Click += rjButton2_Click;
            // 
            // Existencia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            ClientSize = new Size(682, 374);
            Controls.Add(rjButton2);
            Controls.Add(rjButton1);
            Controls.Add(LabelLiquidacion);
            Controls.Add(label4);
            Controls.Add(LabelNombre);
            Controls.Add(label3);
            Controls.Add(LabelLista);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Existencia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Existencia";
            FormClosing += Existencia_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label LabelLista;
        private Label label3;
        private Label LabelNombre;
        private Label label4;
        private Label LabelLiquidacion;
        private Controles_personalizados.RjButton rjButton1;
        private Controles_personalizados.RjButton rjButton2;
    }
}