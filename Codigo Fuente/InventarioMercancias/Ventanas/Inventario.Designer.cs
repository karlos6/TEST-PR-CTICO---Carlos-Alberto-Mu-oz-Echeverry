
namespace InventarioMercancias.Ventanas
{
    partial class Inventario
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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewBodega = new System.Windows.Forms.DataGridView();
            this.dataGridViewArticulos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscarArticulosBodega = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscarArticuloBodega = new System.Windows.Forms.TextBox();
            this.errorCampoBusqueda = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBodega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorCampoBusqueda)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewBodega
            // 
            this.dataGridViewBodega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBodega.Location = new System.Drawing.Point(29, 215);
            this.dataGridViewBodega.Name = "dataGridViewBodega";
            this.dataGridViewBodega.Size = new System.Drawing.Size(324, 163);
            this.dataGridViewBodega.TabIndex = 0;
            this.dataGridViewBodega.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBodega_CellClick);
            // 
            // dataGridViewArticulos
            // 
            this.dataGridViewArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArticulos.Location = new System.Drawing.Point(409, 215);
            this.dataGridViewArticulos.Name = "dataGridViewArticulos";
            this.dataGridViewArticulos.Size = new System.Drawing.Size(425, 163);
            this.dataGridViewArticulos.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(348, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inventario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seleccione la bodega:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Lista de articulos";
            // 
            // btnBuscarArticulosBodega
            // 
            this.btnBuscarArticulosBodega.BackColor = System.Drawing.Color.Turquoise;
            this.btnBuscarArticulosBodega.Location = new System.Drawing.Point(219, 20);
            this.btnBuscarArticulosBodega.Name = "btnBuscarArticulosBodega";
            this.btnBuscarArticulosBodega.Size = new System.Drawing.Size(99, 28);
            this.btnBuscarArticulosBodega.TabIndex = 5;
            this.btnBuscarArticulosBodega.Text = "Buscar Articulos";
            this.btnBuscarArticulosBodega.UseVisualStyleBackColor = false;
            this.btnBuscarArticulosBodega.Click += new System.EventHandler(this.btnBuscarArticulosBodega_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Id Bodega:";
            // 
            // txtBuscarArticuloBodega
            // 
            this.txtBuscarArticuloBodega.Enabled = false;
            this.txtBuscarArticuloBodega.Location = new System.Drawing.Point(83, 25);
            this.txtBuscarArticuloBodega.Name = "txtBuscarArticuloBodega";
            this.txtBuscarArticuloBodega.Size = new System.Drawing.Size(100, 20);
            this.txtBuscarArticuloBodega.TabIndex = 7;
            // 
            // errorCampoBusqueda
            // 
            this.errorCampoBusqueda.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnBuscarArticulosBodega);
            this.panel1.Controls.Add(this.txtBuscarArticuloBodega);
            this.panel1.Location = new System.Drawing.Point(243, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 66);
            this.panel1.TabIndex = 8;
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewArticulos);
            this.Controls.Add(this.dataGridViewBodega);
            this.Name = "Inventario";
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.Inventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBodega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorCampoBusqueda)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewBodega;
        private System.Windows.Forms.DataGridView dataGridViewArticulos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscarArticulosBodega;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBuscarArticuloBodega;
        private System.Windows.Forms.ErrorProvider errorCampoBusqueda;
        private System.Windows.Forms.Panel panel1;
    }
}