namespace SistPuntos_Heladeria.UI
{
    partial class FrmPuntos
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
            txtDni = new TextBox();
            txtMontoCompra = new TextBox();
            btnBuscarCliente = new Button();
            btnRegistrarCompra = new Button();
            lblPuntosActuales = new Label();
            lblCliente = new Label();
            label4 = new Label();
            dgvMovimientos = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            txtPuntosCanje = new TextBox();
            btnCanjearPuntos = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 78);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 0;
            label1.Text = "DNI del cliente";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(129, 75);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 1;
            // 
            // txtMontoCompra
            // 
            txtMontoCompra.Location = new Point(143, 191);
            txtMontoCompra.Name = "txtMontoCompra";
            txtMontoCompra.Size = new Size(100, 23);
            txtMontoCompra.TabIndex = 2;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.Location = new Point(291, 116);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(97, 23);
            btnBuscarCliente.TabIndex = 3;
            btnBuscarCliente.Text = "Buscar cliente";
            btnBuscarCliente.UseVisualStyleBackColor = true;
            btnBuscarCliente.Click += btnBuscarCliente_Click;
            // 
            // btnRegistrarCompra
            // 
            btnRegistrarCompra.Location = new Point(290, 168);
            btnRegistrarCompra.Name = "btnRegistrarCompra";
            btnRegistrarCompra.Size = new Size(98, 23);
            btnRegistrarCompra.TabIndex = 4;
            btnRegistrarCompra.Text = "Registrar compra";
            btnRegistrarCompra.UseVisualStyleBackColor = true;
            btnRegistrarCompra.Click += btnRegistrarCompra_Click;
            // 
            // lblPuntosActuales
            // 
            lblPuntosActuales.AutoSize = true;
            lblPuntosActuales.Location = new Point(11, 153);
            lblPuntosActuales.Name = "lblPuntosActuales";
            lblPuntosActuales.Size = new Size(102, 15);
            lblPuntosActuales.TabIndex = 5;
            lblPuntosActuales.Text = "Puntos actuales: 0\n";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(58, 120);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(55, 15);
            lblCliente.TabIndex = 6;
            lblCliente.Text = "Cliente: -";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 194);
            label4.Name = "label4";
            label4.Size = new Size(115, 15);
            label4.TabIndex = 7;
            label4.Text = "Monto de la compra";
            // 
            // dgvMovimientos
            // 
            dgvMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimientos.Location = new Point(409, 45);
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.Size = new Size(362, 362);
            dgvMovimientos.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(532, 18);
            label2.Name = "label2";
            label2.Size = new Size(140, 15);
            label2.TabIndex = 9;
            label2.Text = "Historial de movimientos";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(166, 262);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 10;
            label3.Text = "Puntos a canjear";
            // 
            // txtPuntosCanje
            // 
            txtPuntosCanje.Location = new Point(143, 289);
            txtPuntosCanje.Name = "txtPuntosCanje";
            txtPuntosCanje.Size = new Size(138, 23);
            txtPuntosCanje.TabIndex = 11;
            // 
            // btnCanjearPuntos
            // 
            btnCanjearPuntos.Location = new Point(168, 318);
            btnCanjearPuntos.Name = "btnCanjearPuntos";
            btnCanjearPuntos.Size = new Size(75, 23);
            btnCanjearPuntos.TabIndex = 12;
            btnCanjearPuntos.Text = "Canjear puntos";
            btnCanjearPuntos.UseVisualStyleBackColor = true;
            btnCanjearPuntos.Click += btnCanjearPuntos_Click;
            // 
            // FrmPuntos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCanjearPuntos);
            Controls.Add(txtPuntosCanje);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dgvMovimientos);
            Controls.Add(label4);
            Controls.Add(lblCliente);
            Controls.Add(lblPuntosActuales);
            Controls.Add(btnRegistrarCompra);
            Controls.Add(btnBuscarCliente);
            Controls.Add(txtMontoCompra);
            Controls.Add(txtDni);
            Controls.Add(label1);
            Name = "FrmPuntos";
            Text = "FrmPuntos";
            Load += FrmPuntos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtDni;
        private TextBox txtMontoCompra;
        private Button btnBuscarCliente;
        private Button btnRegistrarCompra;
        private Label lblPuntosActuales;
        private Label lblCliente;
        private Label label4;
        private DataGridView dgvMovimientos;
        private Label label2;
        private Label label3;
        private TextBox txtPuntosCanje;
        private Button btnCanjearPuntos;
    }
}