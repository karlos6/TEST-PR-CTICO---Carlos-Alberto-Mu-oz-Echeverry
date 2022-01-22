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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioMercancias.Ventanas
{
    public partial class TrasferenciaArticulos : Form
    {
        ///Objeto logicaArticulos para acceder a la capa logica de articulos.       
        private ImplArticuloLogica logicaArticulos = new ImplArticuloLogica();
        ///Objeto logicaBodega para acceder a la capa logica de bodega.
        private ImplBodegaLogica logicaBodega = new ImplBodegaLogica();
        ///Objeto logicaLog para acceder a la capa logica de log
        private ImplLogLogica logicaLog = new ImplLogLogica();

        private int cantidadArticulo = 0;
        public TrasferenciaArticulos()
        {
            InitializeComponent();
        }      

        
        /// <summary>
        /// Carga los datos por default que va a tener la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrasferenciaArticulos_Load(object sender, EventArgs e)
        {
            llenarListaDeBodegasOrigen();

        }

        /// <summary>
        /// Metodo que llena el dataGrigView con una lista de bodegas para ser 
        /// visualizada y seleccionada por el usuario.
        /// </summary>
        private void llenarListaDeBodegasOrigen()
        {
            IEnumerable<BodegaModeloLogica> listaDatos = logicaBodega.listarRegistros();
            MapeadorBodegaVista mapper = new MapeadorBodegaVista();
            IEnumerable<BodegaModeloVista> listaGUI = mapper.mapearTipo1Tipo2(listaDatos);
            vistaListaBodegaOrigen.DataSource = listaGUI.ToList();

        }

        /// <summary>
        /// Metodo que llena el dataGrigView con un lista de articulos segun la 
        /// bodega seleccionada
        /// </summary>
        private void llenarListaDeArticulosBodega()
        {
            IEnumerable<ArticuloModeloLogica> listaDatos = logicaArticulos.listarRegistrosArticulosEnBodega(Int32.Parse(txtIdBodegaOrigen.Text));
            MapeadorArticuloVista mapper = new MapeadorArticuloVista();
            IEnumerable<ArticuloModeloVista> listaGUI = mapper.mapearTipo1Tipo2(listaDatos);
            vistaListaArticulosBodega.DataSource = listaGUI.ToList();
        }

        /// <summary>
        /// Metodo que llena el dataGrigView con un lista de bodegas difetentes  
        /// a la bodega de origen seleccionada por el usuario, estas bodegas 
        /// se usaran como destino.
        /// </summary>
        private void llenarListaDeBodegasDestino()
        {
            IEnumerable<BodegaModeloLogica> listaDatos = logicaBodega.listarRegistrosBodegasDiferentes(Int32.Parse(txtIdBodegaOrigen.Text));
            MapeadorBodegaVista mapper = new MapeadorBodegaVista();
            IEnumerable<BodegaModeloVista> listaGUI = mapper.mapearTipo1Tipo2(listaDatos);
            vistaListaBodegaDestino.DataSource = listaGUI.ToList();
        }

        /// <summary>
        /// Metodo para trasferir el id y cargar la bodega de destino y los articulos
        /// que posee la bedega de origen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VistaListaBodegaOrigen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = vistaListaBodegaOrigen.CurrentCell.RowIndex;
            txtIdBodegaOrigen.Text = vistaListaBodegaOrigen[0, fila].Value.ToString();

            llenarListaDeArticulosBodega();
            llenarListaDeBodegasDestino();

        }

        /// <summary>
        /// Metodo para caprurar el id y la cantidad del articulo seleccionado por el usuario 
        /// en el dataGrigView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vistaListaArticulosBodega_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = vistaListaArticulosBodega.CurrentCell.RowIndex;
            txtIdArticuloBodega.Text = vistaListaArticulosBodega[0, fila].Value.ToString();
            txtCantidadArticulosTransferir.Text = vistaListaArticulosBodega[4, fila].Value.ToString();
            cantidadArticulo = Int32.Parse(vistaListaArticulosBodega[4, fila].Value.ToString());
        }

        /// <summary>
        /// Metodo que extrae el id de destino que el usuario selecciono en el 
        /// dataGrigView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vistaListaBodegaDestino_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = vistaListaBodegaDestino.CurrentCell.RowIndex;
            txtIdBodegaDestino.Text = vistaListaBodegaDestino[0, fila].Value.ToString();
        }

        /// <summary>
        /// Metodo para validar los campos y evitar que esten vacios, que campos numericos 
        /// tengan letras o caracteres especiales seleccionados.
        /// </summary>
        /// <returns></returns>
        private bool validarTrasferencia()
        {
            bool esCorrecto = true;
            //metodo para validar que el campo de la cantidad del articulo no se envie con un string.
            if(txtCantidadArticulosTransferir.Text.Trim() == string.Empty)
            {
                txtCantidadArticulosTransferir.Text = "0";
            }
            //metodo para evitar que el campo de la cantidad no posea letras ni caracteres especiales.
            if (Regex.IsMatch(txtCantidadArticulosTransferir.Text, @"^[a-z]*$") == false)
            {
                txtCantidadArticulosTransferir.Text = "0";
                esCorrecto = false;
                errorTrasferencia.SetError(txtCantidadArticulosTransferir, "no puede contener letras");
            }
            if (Regex.IsMatch(txtCantidadArticulosTransferir.Text, @"^[A-Z]*$") == false)
            {
                txtCantidadArticulosTransferir.Text = "0";
                esCorrecto = false;
                errorTrasferencia.SetError(txtCantidadArticulosTransferir, "no puede contener letras");
            }
            //metodo para evitar que el campo de la cantidad no posea letras ni caracteres especiales.
            if (Regex.IsMatch(txtCantidadArticulosTransferir.Text, @"^[1-9][0-9]*$")== false)
            {
                esCorrecto = false;
                errorTrasferencia.SetError(txtCantidadArticulosTransferir, "El campo no puede contener letras ");
            }
            //metodo para validar que la cantidad no sea mayor a la cantidad del articulo disponible.
            if (Int32.Parse(txtCantidadArticulosTransferir.Text)>cantidadArticulo)
            {
                esCorrecto = false;
                errorTrasferencia.SetError(txtCantidadArticulosTransferir, "La cantidad de articulos a trasferir no puede ser mayor \n a la cantidad de articulos disponibles en bodega o estar vacio.");
            }
            if (txtIdBodegaOrigen.Text.Trim() == string.Empty)
            {
                esCorrecto = false;
                errorTrasferencia.SetError(txtIdBodegaOrigen, "Seleccione una bodega origen.");
            }
            if (txtIdArticuloBodega.Text.Trim() == string.Empty)
            {
                esCorrecto = false;
                errorTrasferencia.SetError(txtIdArticuloBodega, "Seleccione una articulo a trasferir.");
            }
            if (txtIdBodegaDestino.Text.Trim() == string.Empty)
            {
                esCorrecto = false;
                errorTrasferencia.SetError(txtIdBodegaDestino, "Seleccione una bodega de destino.");
            }

            return esCorrecto;
        }

        /// <summary>
        /// Metodo que se activa tras dar click en el boton trasferir
        /// envia la informacion a la capa logica para ser tratada despues de ser validada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrasferirArticulo_Click(object sender, EventArgs e)
        {
            if (validarTrasferencia())
            {
                errorTrasferencia.Clear();
                logicaArticulos.trasferenciaArticulo(Int32.Parse(txtIdArticuloBodega.Text), Int32.Parse(txtIdBodegaDestino.Text), Int32.Parse(txtCantidadArticulosTransferir.Text));
                string hora = DateTime.Now.ToString("hh:mm:ss tt");
                string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                MapeadorLogVista mapper = new MapeadorLogVista();
                LogModeloLogica LogDTO = mapper.mapearTipo2Tipo1(new LogModeloVista
                {
                    Fecha = fecha,
                    Hora = hora,
                    Id_bodega_origen = Int32.Parse(txtIdBodegaOrigen.Text),
                    Id_bodega_destino = Int32.Parse(txtIdBodegaDestino.Text),
                    Id_articulo = Int32.Parse(txtIdArticuloBodega.Text),
                    CantidadTranferidas= Int32.Parse(txtCantidadArticulosTransferir.Text)
                });
                logicaLog.guardarRegistro(LogDTO);


                limpiarDatosCajasDeTexto();
                llenarListaDeArticulosBodega();
            }


        }

        /// <summary>
        /// Metodo para limpiar los campos de texto de la ventana.
        /// </summary>
        private void limpiarDatosCajasDeTexto()
        {
            txtIdArticuloBodega.Text = "";
            txtIdBodegaDestino.Text = "";
            txtCantidadArticulosTransferir.Text = "";
        }
    }
}
