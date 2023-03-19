﻿namespace FutureLending
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnReparar = new FontAwesome.Sharp.IconButton();
            this.btnTodosSistemas = new FontAwesome.Sharp.IconButton();
            this.btnEstadoPagos = new FontAwesome.Sharp.IconButton();
            this.btnListas = new FontAwesome.Sharp.IconButton();
            this.btnIngresarClientes = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMenu = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.AccessibleName = "panelMenu";
            this.panelMenu.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panelMenu.Controls.Add(this.btnReparar);
            this.panelMenu.Controls.Add(this.btnTodosSistemas);
            this.panelMenu.Controls.Add(this.btnEstadoPagos);
            this.panelMenu.Controls.Add(this.btnListas);
            this.panelMenu.Controls.Add(this.btnIngresarClientes);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(230, 450);
            this.panelMenu.TabIndex = 0;
            // 
            // btnReparar
            // 
            this.btnReparar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReparar.FlatAppearance.BorderSize = 0;
            this.btnReparar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReparar.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReparar.ForeColor = System.Drawing.Color.White;
            this.btnReparar.IconChar = FontAwesome.Sharp.IconChar.Wrench;
            this.btnReparar.IconColor = System.Drawing.Color.White;
            this.btnReparar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReparar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReparar.Location = new System.Drawing.Point(0, 396);
            this.btnReparar.Name = "btnReparar";
            this.btnReparar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnReparar.Size = new System.Drawing.Size(230, 54);
            this.btnReparar.TabIndex = 4;
            this.btnReparar.Tag = "         Reparar";
            this.btnReparar.Text = "         Reparar";
            this.btnReparar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReparar.UseVisualStyleBackColor = true;
            // 
            // btnTodosSistemas
            // 
            this.btnTodosSistemas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTodosSistemas.FlatAppearance.BorderSize = 0;
            this.btnTodosSistemas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTodosSistemas.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTodosSistemas.ForeColor = System.Drawing.Color.White;
            this.btnTodosSistemas.IconChar = FontAwesome.Sharp.IconChar.Computer;
            this.btnTodosSistemas.IconColor = System.Drawing.Color.White;
            this.btnTodosSistemas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTodosSistemas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTodosSistemas.Location = new System.Drawing.Point(0, 263);
            this.btnTodosSistemas.Name = "btnTodosSistemas";
            this.btnTodosSistemas.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTodosSistemas.Size = new System.Drawing.Size(230, 54);
            this.btnTodosSistemas.TabIndex = 3;
            this.btnTodosSistemas.Tag = "Ver estado de todos los sistemas";
            this.btnTodosSistemas.Text = "Ver estado de todos los sistemas";
            this.btnTodosSistemas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTodosSistemas.UseVisualStyleBackColor = true;
            // 
            // btnEstadoPagos
            // 
            this.btnEstadoPagos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEstadoPagos.FlatAppearance.BorderSize = 0;
            this.btnEstadoPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadoPagos.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEstadoPagos.ForeColor = System.Drawing.Color.White;
            this.btnEstadoPagos.IconChar = FontAwesome.Sharp.IconChar.MoneyCheckAlt;
            this.btnEstadoPagos.IconColor = System.Drawing.Color.White;
            this.btnEstadoPagos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEstadoPagos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstadoPagos.Location = new System.Drawing.Point(0, 209);
            this.btnEstadoPagos.Name = "btnEstadoPagos";
            this.btnEstadoPagos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnEstadoPagos.Size = new System.Drawing.Size(230, 54);
            this.btnEstadoPagos.TabIndex = 2;
            this.btnEstadoPagos.Tag = "  Estado de pagos";
            this.btnEstadoPagos.Text = "  Estado de pagos";
            this.btnEstadoPagos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEstadoPagos.UseVisualStyleBackColor = true;
            // 
            // btnListas
            // 
            this.btnListas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnListas.FlatAppearance.BorderSize = 0;
            this.btnListas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListas.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnListas.ForeColor = System.Drawing.Color.White;
            this.btnListas.IconChar = FontAwesome.Sharp.IconChar.List12;
            this.btnListas.IconColor = System.Drawing.Color.White;
            this.btnListas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnListas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListas.Location = new System.Drawing.Point(0, 155);
            this.btnListas.Name = "btnListas";
            this.btnListas.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnListas.Size = new System.Drawing.Size(230, 54);
            this.btnListas.TabIndex = 1;
            this.btnListas.Tag = "  Listas completas";
            this.btnListas.Text = "  Listas completas";
            this.btnListas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnListas.UseVisualStyleBackColor = true;
            // 
            // btnIngresarClientes
            // 
            this.btnIngresarClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIngresarClientes.FlatAppearance.BorderSize = 0;
            this.btnIngresarClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarClientes.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIngresarClientes.ForeColor = System.Drawing.Color.White;
            this.btnIngresarClientes.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.btnIngresarClientes.IconColor = System.Drawing.Color.White;
            this.btnIngresarClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIngresarClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresarClientes.Location = new System.Drawing.Point(0, 101);
            this.btnIngresarClientes.Name = "btnIngresarClientes";
            this.btnIngresarClientes.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnIngresarClientes.Size = new System.Drawing.Size(230, 54);
            this.btnIngresarClientes.TabIndex = 0;
            this.btnIngresarClientes.Tag = "   Ingresar clientes";
            this.btnIngresarClientes.Text = "   Ingresar clientes";
            this.btnIngresarClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIngresarClientes.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 101);
            this.panel1.TabIndex = 0;
            // 
            // btnMenu
            // 
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.IconChar = FontAwesome.Sharp.IconChar.Bars;
            this.btnMenu.IconColor = System.Drawing.Color.White;
            this.btnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMenu.IconSize = 30;
            this.btnMenu.Location = new System.Drawing.Point(167, 20);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(60, 60);
            this.btnMenu.TabIndex = 0;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FutureLending.Properties.Resources.wise_mystical_tree1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.White;
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(230, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(570, 60);
            this.panelTitleBar.TabIndex = 1;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.SystemColors.Info;
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(230, 60);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(570, 390);
            this.panelDesktop.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Name = "Form1";
            this.Text = "FutureLending";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelMenu;
        private Panel panelTitleBar;
        private Panel panelDesktop;
        private Panel panel1;
        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnMenu;
        private FontAwesome.Sharp.IconButton btnIngresarClientes;
        private FontAwesome.Sharp.IconButton btnListas;
        private FontAwesome.Sharp.IconButton btnEstadoPagos;
        private FontAwesome.Sharp.IconButton btnTodosSistemas;
        private FontAwesome.Sharp.IconButton btnReparar;
    }
}