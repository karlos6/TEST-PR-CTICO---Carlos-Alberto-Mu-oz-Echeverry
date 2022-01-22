using InventarioMercancias.Helpers;
using InventarioMercancias.Ventanas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioMercancias
{
    public partial class GestionPrograma : Form
    {
        ///Objeto mensajeAlerta para mostrar informacion al usuario.
        private MensajeAlerta mensajeAlerta = new MensajeAlerta();
        public GestionPrograma()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Metodo IngresarBodega_Click:   
        ///  Redirecciona a la ventana crear bodega tras oprimir el botos insertar bodega,
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"></param>
        private void IngresarBodega_Click(object sender, EventArgs e)
        {
            mensajeAlerta.mensajeValidacion("Ayuda", "Boton Insertar: para insertar se toman en cuenta todos los campos a excepción del campo del id.\n\n" +
                                                     "Boton Actulizar: Para actualizar se toman en cuenta todos los campos sin excepción.\n\n " +
                                                     "Boton Eliminar: Para eliminar solo se necesita el campo del id de la bodega");
            using (CrearBodega ventanaBodega = new CrearBodega()) ventanaBodega.ShowDialog();
        }

        /// <summary>
        ///  Metodo btnIngresarArticulo_Click:   
        ///  Redirecciona a la ventana crear articulos tras oprimir el boton insertar articulo.
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"></param>
        private void btnIngresarArticulo_Click(object sender, EventArgs e)
        {
            mensajeAlerta.mensajeValidacion("Ayuda", "Boton Insertar: para insertar se toman en cuenta todos los campos a excepción del campo del id.\n\n" +
                                                     "Boton Actulizar: Para actualizar se toman en cuenta todos los campos sin excepción.\n\n " +
                                                     "Boton Eliminar: Para eliminar solo se necesita el campo del id del Articulo");
            using (CrearArticulo ventanaArticulo = new CrearArticulo()) ventanaArticulo.ShowDialog();

        }

        /// <summary>
        /// Metodo que se activa cuando precionan el boton log.
        /// Este metodo abre la ventana de lista log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLog_Click(object sender, EventArgs e)
        {
            using (ListaLog ventanaLog = new ListaLog()) ventanaLog.ShowDialog();
        }

        /// <summary>
        /// Metodo que se activa cuando precionan el boton inventario.
        /// Este metodo abre la ventana de inventario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInventario_Click(object sender, EventArgs e)
        {
            using (Inventario ventanaInventario = new Inventario()) ventanaInventario.ShowDialog();

        }

        /// <summary>
        /// Metodo que se activa cuando precionan el boton transferir articulo.
        /// Este metodo abre la ventana de trasferir articulo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTranferirArticulos_Click(object sender, EventArgs e)
        {
            mensajeAlerta.mensajeValidacion("Ayuda", "Boton Transferir: para trasferir un articulo se toman en cuenta todos los campos sin excepción.\n");
            using (TrasferenciaArticulos ventanaTrasferenciaArticulos = new TrasferenciaArticulos()) ventanaTrasferenciaArticulos.ShowDialog();
        }
    }
}
