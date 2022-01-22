
namespace InventarioMercancias.Ventanas
{
    partial class TrasferenciaArticulos
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
            this.vistaListaArticulosBodega = new System.Windows.Forms.DataGridView();
            this.vistaListaBodegaOrigen = new System.Windows.Forms.DataGridView();
            this.vistaListaBodegaDestino = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdBodegaOrigen = new System.Windows.Forms.TextBox();
            this.txtIdBodegaDestino = new System.Windows.Forms.TextBox();
            this.txtIdArticuloBodega = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCantidadArticulosTransferir = new System.Windows.Forms.TextBox();
            this.btnTrasferirArticulo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.errorTrasferencia = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.vistaListaArticulosBodega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaListaBodegaOrigen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaListaBodegaDestino)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorTrasferencia)).BeginInit();
            this.SuspendLayout();
            // 
            // vistaListaArticulosBodega
            // 
            this.vistaListaArticulosBodega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vistaListaArticulosBodega.Location = new System.Drawing.Point(277, 267);
            this.vistaListaArticulosBodega.Name = "vistaListaArticulosBodega";
            this.vistaListaArticulosBodega.Size = new System.Drawing.Size(334, 150);
            this.vistaListaArticulosBodega.TabIndex = 0;
            this.vistaListaArticulosBodega.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vistaListaArticulosBodega_CellClick);
            // 
            // vistaListaBodegaOrigen
            // 
            this.vistaListaBodegaOrigen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vistaListaBodegaOrigen.Location = new System.Drawing.Point(15, 267);
            this.vistaListaBodegaOrigen.Name = "vistaListaBodegaOrigen";
            this.vistaListaBodegaOrigen.Size = new System.Drawing.Size(240, 150);
            this.vistaListaBodegaOrigen.TabIndex = 1;
            this.vistaListaBodegaOrigen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VistaListaBodegaOrigen_CellClick);
            // 
            // vistaListaBodegaDestino
            // 
            this.vistaListaBodegaDestino.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vistaListaBodegaDestino.Location = new System.Drawing.Point(634, 267);
            this.vistaListaBodegaDestino.Name = "vistaListaBodegaDestino";
            this.vistaListaBodegaDestino.Size = new System.Drawing.Size(240, 150);
            this.vistaListaBodegaDestino.TabIndex = 2;
            this.vistaListaBodegaDestino.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vistaListaBodegaDestino_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seleccione la bodega:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Seleccione el articulo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(631, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Seleccione la bodega a trasferir:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Bodega Origen:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(239, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Bodega Destino:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Articulo:";
            // 
            // txtIdBodegaOrigen
            // 
            this.txtIdBodegaOrigen.Enabled = false;
            this.txtIdBodegaOrigen.Location = new System.Drawing.Point(106, 31);
            this.txtIdBodegaOrigen.Name = "txtIdBodegaOrigen";
            this.txtIdBodegaOrigen.Size = new System.Drawing.Size(100, 20);
            this.txtIdBodegaOrigen.TabIndex = 9;
            // 
            // txtIdBodegaDestino
            // 
            this.txtIdBodegaDestino.Enabled = false;
            this.txtIdBodegaDestino.Location = new System.Drawing.Point(332, 30);
            this.txtIdBodegaDestino.Name = "txtIdBodegaDestino";
            this.txtIdBodegaDestino.Size = new System.Drawing.Size(100, 20);
            this.txtIdBodegaDestino.TabIndex = 10;
            // 
            // txtIdArticuloBodega
            // 
            this.txtIdArticuloBodega.Enabled = false;
            this.txtIdArticuloBodega.Location = new System.Drawing.Point(106, 77);
            this.txtIdArticuloBodega.Name = "txtIdArticuloBodega";
            this.txtIdArticuloBodega.Size = new System.Drawing.Size(100, 20);
            this.txtIdArticuloBodega.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(227, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Cantidad a trasferir:";
            // 
            // txtCantidadArticulosTransferir
            // 
            this.txtCantidadArticulosTransferir.Location = new System.Drawing.Point(332, 77);
            this.txtCantidadArticulosTransferir.Name = "txtCantidadArticulosTransferir";
            this.txtCantidadArticulosTransferir.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadArticulosTransferir.TabIndex = 13;
            // 
            // btnTrasferirArticulo
            // 
            this.btnTrasferirArticulo.Location = new System.Drawing.Point(181, 119);
            this.btnTrasferirArticulo.Name = "btnTrasferirArticulo";
            this.btnTrasferirArticulo.Size = new System.Drawing.Size(75, 23);
            this.btnTrasferirArticulo.TabIndex = 14;
            this.btnTrasferirArticulo.Text = "Transferir";
            this.btnTrasferirArticulo.UseVisualStyleBackColor = true;
            this.btnTrasferirArticulo.Click += new System.EventHandler(this.btnTrasferirArticulo_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnTrasferirArticulo);
            this.panel2.Controls.Add(this.txtIdBodegaDestino);
            this.panel2.Controls.Add(this.txtIdArticuloBodega);
            this.panel2.Controls.Add(this.txtCantidadArticulosTransferir);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtIdBodegaOrigen);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(217, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(457, 161);
            this.panel2.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(335, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(276, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "Trasferencia de Articulos";
            // 
            // errorTrasferencia
            // 
            this.errorTrasferencia.ContainerControl = this;
            // 
            // TrasferenciaArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(902, 458);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vistaListaBodegaDestino);
            this.Controls.Add(this.vistaListaBodegaOrigen);
            this.Controls.Add(this.vistaListaArticulosBodega);
            this.Name = "TrasferenciaArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrasferenciaArticulos";
            this.Load += new System.EventHandler(this.TrasferenciaArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vistaListaArticulosBodega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaListaBodegaOrigen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaListaBodegaDestino)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorTrasferencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView vistaListaArticulosBodega;
        private System.Windows.Forms.DataGridView vistaListaBodegaOrigen;
        private System.Windows.Forms.DataGridView vistaListaBodegaDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdBodegaOrigen;
        private System.Windows.Forms.TextBox txtIdBodegaDestino;
        private System.Windows.Forms.TextBox txtIdArticuloBodega;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCantidadArticulosTransferir;
        private System.Windows.Forms.Button btnTrasferirArticulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider errorTrasferencia;
    }
}