namespace SistPuntos_Heladeria.UI
{
    partial class FrmConfiguracionInicial
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
            label1 = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtNombreUsuario = new TextBox();
            txtClave = new TextBox();
            txtRepetirClave = new TextBox();
            btnCrearAdministrador = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(328, 52);
            label1.Name = "label1";
            label1.Size = new Size(179, 15);
            label1.TabIndex = 0;
            label1.Text = "Configuración inicial del sistema";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(374, 146);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(374, 194);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 2;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(374, 233);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(100, 23);
            txtNombreUsuario.TabIndex = 3;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(374, 275);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(100, 23);
            txtClave.TabIndex = 4;
            txtClave.UseSystemPasswordChar = true;
            // 
            // txtRepetirClave
            // 
            txtRepetirClave.Location = new Point(374, 313);
            txtRepetirClave.Name = "txtRepetirClave";
            txtRepetirClave.Size = new Size(100, 23);
            txtRepetirClave.TabIndex = 5;
            txtRepetirClave.UseSystemPasswordChar = true;
            // 
            // btnCrearAdministrador
            // 
            btnCrearAdministrador.Location = new Point(350, 365);
            btnCrearAdministrador.Name = "btnCrearAdministrador";
            btnCrearAdministrador.Size = new Size(144, 23);
            btnCrearAdministrador.TabIndex = 6;
            btnCrearAdministrador.Text = "Crear administrador";
            btnCrearAdministrador.UseVisualStyleBackColor = true;
            btnCrearAdministrador.Click += btnCrearAdministrador_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(306, 149);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 7;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(306, 197);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 8;
            label3.Text = "Apellido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(263, 241);
            label4.Name = "label4";
            label4.Size = new Size(94, 15);
            label4.TabIndex = 9;
            label4.Text = "Nombre Usuario";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(321, 278);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 10;
            label5.Text = "Clave";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(281, 316);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 11;
            label6.Text = "Repetir Clave";
            // 
            // FrmConfiguracionInicial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCrearAdministrador);
            Controls.Add(txtRepetirClave);
            Controls.Add(txtClave);
            Controls.Add(txtNombreUsuario);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Name = "FrmConfiguracionInicial";
            Text = "FrmConfiguracionInicial";
            Load += FrmConfiguracionInicial_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtNombreUsuario;
        private TextBox txtClave;
        private TextBox txtRepetirClave;
        private Button btnCrearAdministrador;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}