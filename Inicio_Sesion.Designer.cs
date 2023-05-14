namespace FutureLending
{
    partial class Inicio_Sesion
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio_Sesion));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            TextUsuario = new TextBox();
            TextContra = new TextBox();
            button1 = new Button();
            Mensaje = new Label();
            bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(636, 539);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(43, 37);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            pictureBox2.Click += PictureBox2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto Black", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(721, 35);
            label1.Name = "label1";
            label1.Size = new Size(226, 41);
            label1.TabIndex = 2;
            label1.Text = "Iniciar Sesión";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(657, 140);
            label2.Name = "label2";
            label2.Size = new Size(91, 28);
            label2.TabIndex = 3;
            label2.Text = "Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Roboto", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(657, 260);
            label3.Name = "label3";
            label3.Size = new Size(130, 28);
            label3.TabIndex = 4;
            label3.Text = "Contraseña";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(657, 171);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(312, 65);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(657, 291);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(312, 65);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            // 
            // TextUsuario
            // 
            TextUsuario.BackColor = Color.FromArgb(28, 41, 86);
            TextUsuario.BorderStyle = BorderStyle.None;
            TextUsuario.Font = new Font("Consolas", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            TextUsuario.ForeColor = Color.White;
            TextUsuario.Location = new Point(663, 190);
            TextUsuario.Name = "TextUsuario";
            TextUsuario.Size = new Size(281, 32);
            TextUsuario.TabIndex = 7;
            // 
            // TextContra
            // 
            TextContra.BackColor = Color.FromArgb(28, 41, 86);
            TextContra.BorderStyle = BorderStyle.None;
            TextContra.Font = new Font("Consolas", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            TextContra.Location = new Point(663, 308);
            TextContra.Name = "TextContra";
            TextContra.Size = new Size(281, 32);
            TextContra.TabIndex = 8;
            TextContra.UseSystemPasswordChar = true;
            TextContra.TextChanged += TextContra_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(155, 145, 221);
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Roboto", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(657, 407);
            button1.Name = "button1";
            button1.Size = new Size(312, 65);
            button1.TabIndex = 9;
            button1.Text = "Iniciar Sesión";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Button1_Click;
            // 
            // Mensaje
            // 
            Mensaje.AutoSize = true;
            Mensaje.Font = new Font("Roboto Medium", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            Mensaje.ForeColor = Color.Red;
            Mensaje.Location = new Point(657, 430);
            Mensaje.Name = "Mensaje";
            Mensaje.Size = new Size(0, 22);
            Mensaje.TabIndex = 10;
            // 
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 5;
            bunifuElipse1.TargetControl = this;
            // 
            // Inicio_Sesion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 25, 74);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1035, 563);
            ControlBox = false;
            Controls.Add(Mensaje);
            Controls.Add(button1);
            Controls.Add(TextContra);
            Controls.Add(TextUsuario);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Inicio_Sesion";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio_Sesion";
            Load += Inicio_Sesion_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private TextBox TextUsuario;
        private TextBox TextContra;
        private Button button1;
        private Label Mensaje;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}