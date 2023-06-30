namespace FutureLending.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuracion_Inicio_Sesion));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            PingLabel = new Label();
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
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.Controls.Add(PingLabel);
            tabPage1.Controls.Add(rjButton1);
            tabPage1.Controls.Add(rjButton3);
            tabPage1.Controls.Add(LabelEstado);
            tabPage1.Controls.Add(label51);
            tabPage1.Name = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // PingLabel
            // 
            resources.ApplyResources(PingLabel, "PingLabel");
            PingLabel.ForeColor = Color.Red;
            PingLabel.Name = "PingLabel";
            // 
            // rjButton1
            // 
            resources.ApplyResources(rjButton1, "rjButton1");
            rjButton1.BackColor = Color.IndianRed;
            rjButton1.BackgroundColor = Color.IndianRed;
            rjButton1.BorderColor = Color.PaleVioletRed;
            rjButton1.BorderRadius = 20;
            rjButton1.BorderSize = 0;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.ForeColor = Color.White;
            rjButton1.Name = "rjButton1";
            rjButton1.TextColor = Color.White;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // rjButton3
            // 
            resources.ApplyResources(rjButton3, "rjButton3");
            rjButton3.BackColor = SystemColors.ActiveCaption;
            rjButton3.BackgroundColor = SystemColors.ActiveCaption;
            rjButton3.BorderColor = Color.PaleVioletRed;
            rjButton3.BorderRadius = 20;
            rjButton3.BorderSize = 0;
            rjButton3.FlatAppearance.BorderSize = 0;
            rjButton3.ForeColor = Color.White;
            rjButton3.Name = "rjButton3";
            rjButton3.TextColor = Color.White;
            rjButton3.UseVisualStyleBackColor = false;
            rjButton3.Click += rjButton3_Click;
            // 
            // LabelEstado
            // 
            resources.ApplyResources(LabelEstado, "LabelEstado");
            LabelEstado.ForeColor = Color.Red;
            LabelEstado.Name = "LabelEstado";
            // 
            // label51
            // 
            resources.ApplyResources(label51, "label51");
            label51.ForeColor = Color.DarkSlateGray;
            label51.Name = "label51";
            // 
            // tabPage2
            // 
            resources.ApplyResources(tabPage2, "tabPage2");
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
            tabPage2.Name = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // rjButton2
            // 
            resources.ApplyResources(rjButton2, "rjButton2");
            rjButton2.BackColor = Color.IndianRed;
            rjButton2.BackgroundColor = Color.IndianRed;
            rjButton2.BorderColor = Color.PaleVioletRed;
            rjButton2.BorderRadius = 20;
            rjButton2.BorderSize = 0;
            rjButton2.FlatAppearance.BorderSize = 0;
            rjButton2.ForeColor = Color.Azure;
            rjButton2.Name = "rjButton2";
            rjButton2.TextColor = Color.Azure;
            rjButton2.UseVisualStyleBackColor = false;
            rjButton2.Click += rjButton2_Click;
            // 
            // checkBox3
            // 
            resources.ApplyResources(checkBox3, "checkBox3");
            checkBox3.ForeColor = Color.LightSlateGray;
            checkBox3.Name = "checkBox3";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // TextContra
            // 
            resources.ApplyResources(TextContra, "TextContra");
            TextContra.BackColor = SystemColors.Info;
            TextContra.Name = "TextContra";
            TextContra.UseSystemPasswordChar = true;
            // 
            // TextUsuario
            // 
            resources.ApplyResources(TextUsuario, "TextUsuario");
            TextUsuario.BackColor = SystemColors.Info;
            TextUsuario.Name = "TextUsuario";
            // 
            // TextBase
            // 
            resources.ApplyResources(TextBase, "TextBase");
            TextBase.BackColor = SystemColors.Info;
            TextBase.Name = "TextBase";
            // 
            // TextPuerto
            // 
            resources.ApplyResources(TextPuerto, "TextPuerto");
            TextPuerto.BackColor = SystemColors.Info;
            TextPuerto.Name = "TextPuerto";
            // 
            // TextServer
            // 
            resources.ApplyResources(TextServer, "TextServer");
            TextServer.BackColor = SystemColors.Info;
            TextServer.Name = "TextServer";
            // 
            // label48
            // 
            resources.ApplyResources(label48, "label48");
            label48.ForeColor = Color.LightSlateGray;
            label48.Name = "label48";
            // 
            // label47
            // 
            resources.ApplyResources(label47, "label47");
            label47.ForeColor = Color.LightSlateGray;
            label47.Name = "label47";
            // 
            // label46
            // 
            resources.ApplyResources(label46, "label46");
            label46.ForeColor = Color.LightSlateGray;
            label46.Name = "label46";
            // 
            // label45
            // 
            resources.ApplyResources(label45, "label45");
            label45.ForeColor = Color.LightSlateGray;
            label45.Name = "label45";
            // 
            // label44
            // 
            resources.ApplyResources(label44, "label44");
            label44.ForeColor = Color.LightSlateGray;
            label44.Name = "label44";
            // 
            // Configuracion_Inicio_Sesion
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Configuracion_Inicio_Sesion";
            ShowInTaskbar = false;
            Load += Configuracion_Inicio_Sesion_Load;
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
        private Label PingLabel;
    }
}