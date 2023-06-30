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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(254, 80);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(131, 118);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.x_circle_icon;
            pictureBox2.Location = new Point(10, 9);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(41, 34);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            pictureBox2.Click += PictureBox2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.InactiveCaption;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(28, 41, 86);
            label1.Location = new Point(206, 28);
            label1.Name = "label1";
            label1.Size = new Size(204, 45);
            label1.TabIndex = 2;
            label1.Text = "Iniciar sesión";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Corbel", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(151, 206);
            label2.Name = "label2";
            label2.Size = new Size(76, 24);
            label2.TabIndex = 3;
            label2.Text = "Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Corbel", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(151, 304);
            label3.Name = "label3";
            label3.Size = new Size(108, 24);
            label3.TabIndex = 4;
            label3.Text = "Contraseña";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.ScrollBar;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(151, 235);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(354, 47);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(151, 332);
            pictureBox4.Margin = new Padding(3, 2, 3, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(354, 47);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            // 
            // TextUsuario
            // 
            TextUsuario.BackColor = Color.FromArgb(28, 41, 86);
            TextUsuario.BorderStyle = BorderStyle.None;
            TextUsuario.Font = new Font("Corbel", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            TextUsuario.ForeColor = Color.White;
            TextUsuario.Location = new Point(159, 245);
            TextUsuario.Margin = new Padding(3, 2, 3, 2);
            TextUsuario.Name = "TextUsuario";
            TextUsuario.Size = new Size(331, 27);
            TextUsuario.TabIndex = 7;
            TextUsuario.TextAlign = HorizontalAlignment.Center;
            TextUsuario.TextChanged += TextUsuario_TextChanged;
            // 
            // TextContra
            // 
            TextContra.BackColor = Color.FromArgb(28, 41, 86);
            TextContra.BorderStyle = BorderStyle.None;
            TextContra.Font = new Font("Corbel", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            TextContra.ForeColor = SystemColors.InactiveBorder;
            TextContra.Location = new Point(159, 345);
            TextContra.Margin = new Padding(3, 2, 3, 2);
            TextContra.Name = "TextContra";
            TextContra.Size = new Size(331, 27);
            TextContra.TabIndex = 8;
            TextContra.TextAlign = HorizontalAlignment.Center;
            TextContra.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Dubai", 16.1999989F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.FromArgb(28, 41, 86);
            button1.Location = new Point(234, 416);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(172, 42);
            button1.TabIndex = 9;
            button1.Text = "Acceder";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Button1_Click;
            // 
            // Mensaje
            // 
            Mensaje.AutoSize = true;
            Mensaje.Font = new Font("Corbel Light", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            Mensaje.ForeColor = Color.Red;
            Mensaje.Location = new Point(206, 381);
            Mensaje.Name = "Mensaje";
            Mensaje.Size = new Size(0, 23);
            Mensaje.TabIndex = 10;
            // 
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 25;
            bunifuElipse1.TargetControl = this;
            // 
            // bunifuElipse2
            // 
            bunifuElipse2.ElipseRadius = 20;
            bunifuElipse2.TargetControl = pictureBox1;
            // 
            // bunifuElipse3
            // 
            bunifuElipse3.ElipseRadius = 400;
            bunifuElipse3.TargetControl = pictureBox2;
            // 
            // bunifuElipse4
            // 
            bunifuElipse4.ElipseRadius = 10;
            bunifuElipse4.TargetControl = button1;
            // 
            // bunifuElipse5
            // 
            bunifuElipse5.ElipseRadius = 20;
            bunifuElipse5.TargetControl = pictureBox3;
            // 
            // bunifuElipse6
            // 
            bunifuElipse6.ElipseRadius = 20;
            bunifuElipse6.TargetControl = pictureBox4;
            // 
            // btnTodosSistemas
            // 
            btnTodosSistemas.FlatAppearance.BorderSize = 0;
            btnTodosSistemas.FlatStyle = FlatStyle.Flat;
            btnTodosSistemas.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnTodosSistemas.ForeColor = Color.Gray;
            btnTodosSistemas.IconChar = FontAwesome.Sharp.IconChar.Wrench;
            btnTodosSistemas.IconColor = Color.White;
            btnTodosSistemas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTodosSistemas.ImageAlign = ContentAlignment.MiddleLeft;
            btnTodosSistemas.Location = new Point(573, 425);
            btnTodosSistemas.Name = "btnTodosSistemas";
            btnTodosSistemas.Padding = new Padding(10, 0, 0, 0);
            btnTodosSistemas.Size = new Size(60, 56);
            btnTodosSistemas.TabIndex = 11;
            btnTodosSistemas.Tag = "Reparar";
            btnTodosSistemas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTodosSistemas.UseVisualStyleBackColor = true;
            btnTodosSistemas.Click += BtnTodosSistemas_Click;
            // 
            // Inicio_Sesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(635, 474);
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
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Inicio_Sesion";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio_Sesion";
            FormClosing += Inicio_Sesion_FormClosing;
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
    }
}