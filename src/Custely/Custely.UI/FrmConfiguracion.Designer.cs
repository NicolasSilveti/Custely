namespace Custely.UI
{
    partial class FrmConfiguracion
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
            btnGuardarConfiguracion = new Button();
            label1 = new Label();
            txtPesosPorPunto = new TextBox();
            SuspendLayout();
            // 
            // btnGuardarConfiguracion
            // 
            btnGuardarConfiguracion.Location = new Point(247, 203);
            btnGuardarConfiguracion.Name = "btnGuardarConfiguracion";
            btnGuardarConfiguracion.Size = new Size(123, 23);
            btnGuardarConfiguracion.TabIndex = 0;
            btnGuardarConfiguracion.Text = "Guardar configuración";
            btnGuardarConfiguracion.UseVisualStyleBackColor = true;
            btnGuardarConfiguracion.Click += btnGuardarConfiguracion_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(271, 113);
            label1.Name = "label1";
            label1.Size = new Size(209, 15);
            label1.TabIndex = 1;
            label1.Text = "Pesos necesarios para obtener 1 punto";
            // 
            // txtPesosPorPunto
            // 
            txtPesosPorPunto.Location = new Point(406, 204);
            txtPesosPorPunto.Name = "txtPesosPorPunto";
            txtPesosPorPunto.Size = new Size(100, 23);
            txtPesosPorPunto.TabIndex = 2;
            // 
            // FrmConfiguracion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtPesosPorPunto);
            Controls.Add(label1);
            Controls.Add(btnGuardarConfiguracion);
            Name = "FrmConfiguracion";
            Text = "FrmConfiguracion";
            Load += FrmConfiguracion_Load;
            Click += btnAutorizar_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuardarConfiguracion;
        private Label label1;
        private TextBox txtPesosPorPunto;
    }
}