namespace SistPuntos_Heladeria.UI
{
    partial class FrmCambiarClave
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
            label2 = new Label();
            txtNuevaClave = new TextBox();
            txtRepetirClave = new TextBox();
            btnCambiarClave = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(202, 122);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 0;
            label1.Text = "Nueva clave";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(202, 173);
            label2.Name = "label2";
            label2.Size = new Size(109, 15);
            label2.TabIndex = 1;
            label2.Text = "Repetir nueva clave";
            // 
            // txtNuevaClave
            // 
            txtNuevaClave.Location = new Point(486, 143);
            txtNuevaClave.Name = "txtNuevaClave";
            txtNuevaClave.Size = new Size(100, 23);
            txtNuevaClave.TabIndex = 2;
            txtNuevaClave.UseSystemPasswordChar = true;
            // 
            // txtRepetirClave
            // 
            txtRepetirClave.Location = new Point(486, 193);
            txtRepetirClave.Name = "txtRepetirClave";
            txtRepetirClave.Size = new Size(100, 23);
            txtRepetirClave.TabIndex = 3;
            txtRepetirClave.UseSystemPasswordChar = true;
            // 
            // btnCambiarClave
            // 
            btnCambiarClave.Location = new Point(366, 304);
            btnCambiarClave.Name = "btnCambiarClave";
            btnCambiarClave.Size = new Size(93, 31);
            btnCambiarClave.TabIndex = 4;
            btnCambiarClave.Text = "Cambiar clave";
            btnCambiarClave.UseVisualStyleBackColor = true;
            btnCambiarClave.Click += btnCambiarClave_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(556, 304);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(88, 31);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmCambiarClave
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnCambiarClave);
            Controls.Add(txtRepetirClave);
            Controls.Add(txtNuevaClave);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmCambiarClave";
            Text = "FrmCambiarClave";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNuevaClave;
        private TextBox txtRepetirClave;
        private Button btnCambiarClave;
        private Button btnCancelar;
    }
}