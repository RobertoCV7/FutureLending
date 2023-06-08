namespace FutureLending
{
    partial class Configuracion_Inicio_Sesion
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            rjButton1 = new Controles_personalizados.RJButton();
            rjButton3 = new Controles_personalizados.RJButton();
            LabelEstado = new Label();
            label51 = new Label();
            tabPage2 = new TabPage();
            rjButton2 = new Controles_personalizados.RJButton();
            checkBox3 = new CheckBox();
            TextContra = new TextBox();
            TextUsuario = new TextBox();
            TextBase = new TextBox();
            TextPuerto = new TextBox();
            TextServer = new TextBox();
            label48 = new Label();
            label47 = new Label();
            label46 = new Label();
            label45 = new Label();
            label44 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, -1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(798, 446);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(rjButton1);
            tabPage1.Controls.Add(rjButton3);
            tabPage1.Controls.Add(LabelEstado);
            tabPage1.Controls.Add(label51);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(790, 413);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Conexion";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.IndianRed;
            rjButton1.BackgroundColor = Color.IndianRed;
            rjButton1.BorderColor = Color.PaleVioletRed;
            rjButton1.BorderRadius = 20;
            rjButton1.BorderSize = 0;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            rjButton1.ForeColor = Color.White;
            rjButton1.Location = new Point(415, 245);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(227, 52);
            rjButton1.TabIndex = 21;
            rjButton1.Text = "Reparar";
            rjButton1.TextColor = Color.White;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // rjButton3
            // 
            rjButton3.BackColor = SystemColors.ActiveCaption;
            rjButton3.BackgroundColor = SystemColors.ActiveCaption;
            rjButton3.BorderColor = Color.PaleVioletRed;
            rjButton3.BorderRadius = 20;
            rjButton3.BorderSize = 0;
            rjButton3.FlatAppearance.BorderSize = 0;
            rjButton3.FlatStyle = FlatStyle.Flat;
            rjButton3.Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            rjButton3.ForeColor = Color.White;
            rjButton3.Location = new Point(115, 245);
            rjButton3.Name = "rjButton3";
            rjButton3.Size = new Size(227, 52);
            rjButton3.TabIndex = 20;
            rjButton3.Text = "Revisar";
            rjButton3.TextColor = Color.White;
            rjButton3.UseVisualStyleBackColor = false;
            rjButton3.Click += rjButton3_Click;
            // 
            // LabelEstado
            // 
            LabelEstado.Font = new Font("Segoe UI Semibold", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
            LabelEstado.ForeColor = Color.Red;
            LabelEstado.Location = new Point(275, 120);
            LabelEstado.Name = "LabelEstado";
            LabelEstado.Size = new Size(172, 55);
            LabelEstado.TabIndex = 19;
            LabelEstado.Text = "Inactivo";
            // 
            // label51
            // 
            label51.AutoSize = true;
            label51.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label51.ForeColor = Color.DarkSlateGray;
            label51.Location = new Point(173, 17);
            label51.Name = "label51";
            label51.Size = new Size(360, 54);
            label51.TabIndex = 18;
            label51.Text = "Estado del servidor";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(rjButton2);
            tabPage2.Controls.Add(checkBox3);
            tabPage2.Controls.Add(TextContra);
            tabPage2.Controls.Add(TextUsuario);
            tabPage2.Controls.Add(TextBase);
            tabPage2.Controls.Add(TextPuerto);
            tabPage2.Controls.Add(TextServer);
            tabPage2.Controls.Add(label48);
            tabPage2.Controls.Add(label47);
            tabPage2.Controls.Add(label46);
            tabPage2.Controls.Add(label45);
            tabPage2.Controls.Add(label44);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(790, 413);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Editar Conexion";
            tabPage2.UseVisualStyleBackColor = true;
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
            rjButton2.Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            rjButton2.ForeColor = Color.Azure;
            rjButton2.Location = new Point(210, 342);
            rjButton2.Name = "rjButton2";
            rjButton2.Size = new Size(194, 53);
            rjButton2.TabIndex = 39;
            rjButton2.Text = "Aplicar";
            rjButton2.TextColor = Color.Azure;
            rjButton2.UseVisualStyleBackColor = false;
            rjButton2.Click += rjButton2_Click;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox3.ForeColor = Color.LightSlateGray;
            checkBox3.Location = new Point(566, 262);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(175, 32);
            checkBox3.TabIndex = 38;
            checkBox3.Text = "Ver contraseña";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // TextContra
            // 
            TextContra.BackColor = SystemColors.ButtonHighlight;
            TextContra.Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            TextContra.Location = new Point(267, 258);
            TextContra.Name = "TextContra";
            TextContra.Size = new Size(255, 36);
            TextContra.TabIndex = 37;
            TextContra.UseSystemPasswordChar = true;
            // 
            // TextUsuario
            // 
            TextUsuario.BackColor = SystemColors.ButtonHighlight;
            TextUsuario.Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            TextUsuario.Location = new Point(267, 196);
            TextUsuario.Name = "TextUsuario";
            TextUsuario.Size = new Size(255, 36);
            TextUsuario.TabIndex = 36;
            // 
            // TextBase
            // 
            TextBase.BackColor = SystemColors.ButtonHighlight;
            TextBase.Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            TextBase.Location = new Point(267, 142);
            TextBase.Name = "TextBase";
            TextBase.Size = new Size(251, 36);
            TextBase.TabIndex = 35;
            // 
            // TextPuerto
            // 
            TextPuerto.BackColor = SystemColors.ButtonHighlight;
            TextPuerto.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            TextPuerto.Location = new Point(267, 75);
            TextPuerto.Name = "TextPuerto";
            TextPuerto.Size = new Size(249, 38);
            TextPuerto.TabIndex = 34;
            // 
            // TextServer
            // 
            TextServer.BackColor = SystemColors.ButtonHighlight;
            TextServer.Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            TextServer.Location = new Point(267, 21);
            TextServer.Name = "TextServer";
            TextServer.Size = new Size(249, 36);
            TextServer.TabIndex = 33;
            // 
            // label48
            // 
            label48.AutoSize = true;
            label48.Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label48.ForeColor = Color.LightSlateGray;
            label48.Location = new Point(45, 142);
            label48.Name = "label48";
            label48.Size = new Size(148, 28);
            label48.TabIndex = 32;
            label48.Text = "Base de datos:";
            // 
            // label47
            // 
            label47.AutoSize = true;
            label47.Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label47.ForeColor = Color.LightSlateGray;
            label47.Location = new Point(45, 75);
            label47.Name = "label47";
            label47.Size = new Size(82, 28);
            label47.TabIndex = 31;
            label47.Text = "Puerto:";
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label46.ForeColor = Color.LightSlateGray;
            label46.Location = new Point(45, 261);
            label46.Name = "label46";
            label46.Size = new Size(126, 28);
            label46.TabIndex = 30;
            label46.Text = "Contraseña:";
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label45.ForeColor = Color.LightSlateGray;
            label45.Location = new Point(45, 196);
            label45.Name = "label45";
            label45.Size = new Size(90, 28);
            label45.TabIndex = 29;
            label45.Text = "Usuario:";
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Font = new Font("Corbel", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label44.ForeColor = Color.LightSlateGray;
            label44.Location = new Point(45, 24);
            label44.Name = "label44";
            label44.Size = new Size(98, 28);
            label44.TabIndex = 28;
            label44.Text = "Servidor:";
            // 
            // Configuracion_Inicio_Sesion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Configuracion_Inicio_Sesion";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuracion";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Controles_personalizados.RJButton rjButton2;
        private CheckBox checkBox3;
        private TextBox TextContra;
        private TextBox TextUsuario;
        private TextBox TextBase;
        private TextBox TextPuerto;
        private TextBox TextServer;
        private Label label48;
        private Label label47;
        private Label label46;
        private Label label45;
        private Label label44;
        private Controles_personalizados.RJButton rjButton1;
        private Controles_personalizados.RJButton rjButton3;
        private Label LabelEstado;
        private Label label51;
    }
}