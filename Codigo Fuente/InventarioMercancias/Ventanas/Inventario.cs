using InventarioMercancias.Helpers;
using InventarioMercancias.Mapeadores.Parametros;
using InventarioMercancias.ModeloVista.Parametros;
using LogicaInventarioMercancias.Implementacion.Parametros;
using LogicaInventarioMercancias.ModeloLogica.Parametros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioMercancias.Ventanas
{
    public partial class Inventario : Form
    {
        ///Objeto logicaBodega para acceder a la capa logica de bodega.
        private ImplBodegaLogica logicaBodega = new ImplBodegaLogica();
        ///Objeto logicaArticulos para acceder a la capa logica de articulos.       
        private ImplArticuloLogica logicaArticulos = new ImplArticuloLogica();
        public Inventario()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo que carga todos los componentes por default al iniciar la ventana inventario.
        /// Carga un lista de bodegas en el dataGrigView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Inventario_Load(object sender, EventArgs e)
        {
            llenarListaDeBodegas();

        }

        /// <summary>
        /// Metodo que captura la informacion cuando un usuario presiona una celda 
        /// del dataGrigView de bodegas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewBodega_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridViewBodega.CurrentCell.RowIndex;
            txtBuscarArticuloBodega.Text = dataGridViewBodega[0, fila].Value.ToString();

        }

        /// <summary>
        /// Metodo que llena el dataGrigView con la lista de bodegas que viene de la 
        /// capa logica y muestra la visualizacion al usuario.
        /// </summary>
        private void llenarListaDeBodegas()
        {
            IEnumerable<BodegaModeloLogica> listaDatos = logicaBodega.listarRegistros();
            MapeadorBodegaVista mapper = new MapeadorBodegaVista();
            IEnumerable<BodegaModeloVista> listaGUI = mapper.mapearTipo1Tipo2(listaDatos);
            dataGridViewBodega.DataSource = listaGUI.ToList();

        }

        /// <summary>
        /// Metodo se activa cuando el usuario presiona buscar el cual busca los articulos de la bodega
        /// y los incorpora al dataGrigView para ser visualizados por el usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarArticulosBodega_Click(object sender, EventArgs e)
        {
            if (validarCampo()) 
            {
                IEnumerable<ArticuloModeloLogica> listaDatos = logicaArticulos.listarRegistrosArticulosEnBodega(Int32.Parse(txtBuscarArticuloBodega.Text));
                MapeadorArticuloVista mapper = new MapeadorArticuloVista();
                IEnumerable<ArticuloModeloVista> listaGUI = mapper.mapearTipo1Tipo2(listaDatos);
                dataGridViewArticulos.DataSource = listaGUI.ToList();
                limpiarTxtBuscarArticulosBodega();

            }
            

        }

        /// <summary>
        /// Metodo que se utiliza para validar el campo de busqueda y controlar excepciones
        /// </summary>
        /// <returns></returns>
        private bool validarCampo()
        {
            bool esCorrecto = true;
            if(txtBuscarArticuloBodega.Text.Trim() == string.Empty)
            {
                esCorrecto = false;
                errorCampoBusqueda.SetError(txtBuscarArticuloBodega, "Seleccione una bodega");
            }
            return esCorrecto;
        }

        /// <summary>
        /// Limpia el campo de texto del id a buscar
        /// </summary>
        private void limpiarTxtBuscarArticulosBodega()
        {
            txtBuscarArticuloBodega.Text = "";

        }
    }
}
