
namespace InventarioMercancias
{
    partial class GestionPrograma
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.IngresarBodega = new System.Windows.Forms.Button();
            this.btnIngresarArticulo = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnTranferirArticulos = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IngresarBodega
            // 
            this.IngresarBodega.Location = new System.Drawing.Point(35, 23);
            this.IngresarBodega.Name = "IngresarBodega";
            this.IngresarBodega.Size = new System.Drawing.Size(124, 45);
            this.IngresarBodega.TabIndex = 1;
            this.IngresarBodega.Text = "Ingresar Bodega";
            this.IngresarBodega.UseVisualStyleBackColor = true;
            this.IngresarBodega.Click += new System.EventHandler(this.IngresarBodega_Click);
            // 
            // btnIngresarArticulo
            // 
            this.btnIngresarArticulo.Location = new System.Drawing.Point(202, 22);
            this.btnIngresarArticulo.Name = "btnIngresarArticulo";
            this.btnIngresarArticulo.Size = new System.Drawing.Size(124, 46);
            this.btnIngresarArticulo.TabIndex = 3;
            this.btnIngresarArticulo.Text = "Ingresar Articulo";
            this.btnIngresarArticulo.UseVisualStyleBackColor = true;
            this.btnIngresarArticulo.Click += new System.EventHandler(this.btnIngresarArticulo_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.Location = new System.Drawing.Point(35, 107);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(124, 47);
            this.btnInventario.TabIndex = 4;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnTranferirArticulos
            // 
            this.btnTranferirArticulos.Location = new System.Drawing.Point(202, 105);
            this.btnTranferirArticulos.Name = "btnTranferirArticulos";
            this.btnTranferirArticulos.Size = new System.Drawing.Size(124, 49);
            this.btnTranferirArticulos.TabIndex = 5;
            this.btnTranferirArticulos.Text = "Tranferir Articulos";
            this.btnTranferirArticulos.UseVisualStyleBackColor = true;
            this.btnTranferirArticulos.Click += new System.EventHandler(this.btnTranferirArticulos_Click);
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(121, 186);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(124, 42);
            this.btnLog.TabIndex = 6;
            this.btnLog.Text = "Log";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.IngresarBodega);
            this.panel1.Controls.Add(this.btnInventario);
            this.panel1.Controls.Add(this.btnLog);
            this.panel1.Controls.Add(this.btnIngresarArticulo);
            this.panel1.Controls.Add(this.btnTranferirArticulos);
            this.panel1.Location = new System.Drawing.Point(267, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 253);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(324, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Panel de control";
            // 
            // GestionPrograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(864, 411);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GestionPrograma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion Inventario de Mercancias";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button IngresarBodega;
        private System.Windows.Forms.Button btnIngresarArticulo;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnTranferirArticulos;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

