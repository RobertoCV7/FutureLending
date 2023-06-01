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
            bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(components);
            bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(components);
            bunifuElipse4 = new Bunifu.Framework.UI.BunifuElipse(components);
            bunifuElipse5 = new Bunifu.Framework.UI.BunifuElipse(components);
            bunifuElipse6 = new Bunifu.Framework.UI.BunifuElipse(components);
            btnTodosSistemas = new FontAwesome.Sharp.IconButton();
            bunifuElipse7 = new Bunifu.Framework.UI.BunifuElipse(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(53, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(554, 573);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(47, 45);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            pictureBox2.Click += PictureBox2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cooper Black", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(685, 24);
            label1.Name = "label1";
            label1.Size = new Size(298, 46);
            label1.TabIndex = 2;
            label1.Text = "Iniciar Sesión";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cooper Black", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(657, 97);
            label2.Name = "label2";
            label2.Size = new Size(136, 35);
            label2.TabIndex = 3;
            label2.Text = "Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cooper Black", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(657, 245);
            label3.Name = "label3";
            label3.Size = new Size(189, 35);
            label3.TabIndex = 4;
            label3.Text = "Contraseña";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(650, 149);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(327, 75);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(650, 307);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(327, 75);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            // 
            // TextUsuario
            // 
            TextUsuario.BackColor = Color.FromArgb(28, 41, 86);
            TextUsuario.BorderStyle = BorderStyle.None;
            TextUsuario.Font = new Font("Consolas", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            TextUsuario.ForeColor = Color.White;
            TextUsuario.Location = new Point(657, 169);
            TextUsuario.Name = "TextUsuario";
            TextUsuario.Size = new Size(281, 40);
            TextUsuario.TabIndex = 7;
            // 
            // TextContra
            // 
            TextContra.BackColor = Color.FromArgb(28, 41, 86);
            TextContra.BorderStyle = BorderStyle.None;
            TextContra.Font = new Font("Consolas", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            TextContra.Location = new Point(657, 325);
            TextContra.Name = "TextContra";
            TextContra.Size = new Size(296, 40);
            TextContra.TabIndex = 8;
            TextContra.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(155, 145, 221);
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(650, 407);
            button1.Name = "button1";
            button1.Size = new Size(319, 87);
            button1.TabIndex = 9;
            button1.Text = "Iniciar Sesión";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Button1_Click;
            // 
            // Mensaje
            // 
            Mensaje.AutoSize = true;
            Mensaje.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Mensaje.ForeColor = Color.Red;
            Mensaje.Location = new Point(650, 515);
            Mensaje.Name = "Mensaje";
            Mensaje.Size = new Size(0, 32);
            Mensaje.TabIndex = 10;
            // 
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 35;
            bunifuElipse1.TargetControl = this;
            // 
            // bunifuElipse2
            // 
            bunifuElipse2.ElipseRadius = 30;
            bunifuElipse2.TargetControl = pictureBox1;
            // 
            // bunifuElipse3
            // 
            bunifuElipse3.ElipseRadius = 12;
            bunifuElipse3.TargetControl = pictureBox2;
            // 
            // bunifuElipse4
            // 
            bunifuElipse4.ElipseRadius = 30;
            bunifuElipse4.TargetControl = button1;
            // 
            // bunifuElipse5
            // 
            bunifuElipse5.ElipseRadius = 30;
            bunifuElipse5.TargetControl = pictureBox3;
            // 
            // bunifuElipse6
            // 
            bunifuElipse6.ElipseRadius = 30;
            bunifuElipse6.TargetControl = pictureBox4;
            // 
            // btnTodosSistemas
            // 
            btnTodosSistemas.FlatAppearance.BorderSize = 0;
            btnTodosSistemas.FlatStyle = FlatStyle.Flat;
            btnTodosSistemas.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnTodosSistemas.ForeColor = Color.White;
            btnTodosSistemas.IconChar = FontAwesome.Sharp.IconChar.Wrench;
            btnTodosSistemas.IconColor = Color.White;
            btnTodosSistemas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTodosSistemas.ImageAlign = ContentAlignment.MiddleLeft;
            btnTodosSistemas.Location = new Point(958, 515);
            btnTodosSistemas.Margin = new Padding(3, 4, 3, 4);
            btnTodosSistemas.Name = "btnTodosSistemas";
            btnTodosSistemas.Padding = new Padding(11, 0, 0, 0);
            btnTodosSistemas.Size = new Size(78, 81);
            btnTodosSistemas.TabIndex = 11;
            btnTodosSistemas.Tag = "Reparar";
            btnTodosSistemas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTodosSistemas.UseVisualStyleBackColor = true;
            btnTodosSistemas.Click += BtnTodosSistemas_Click;
            // 
            // bunifuElipse7
            // 
            bunifuElipse7.ElipseRadius = 100;
            bunifuElipse7.TargetControl = btnTodosSistemas;
            // 
            // Inicio_Sesion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 25, 74);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1035, 597);
            ControlBox = false;
            Controls.Add(btnTodosSistemas);
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
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse4;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse5;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse6;
        private FontAwesome.Sharp.IconButton btnTodosSistemas;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse7;
    }
}