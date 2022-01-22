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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioMercancias.Ventanas
{
    public partial class CrearArticulo : Form
    {
        ///Objeto logicaArticulos para acceder a la capa logica de articulos.       
        private ImplArticuloLogica logicaArticulos = new ImplArticuloLogica();
        ///Objeto logicaBodega para acceder a la capa logica de bodega.
        private ImplBodegaLogica logicaBodega = new ImplBodegaLogica();
        ///Objeto mensajeAlerta para mostrar informacion al usuario.
        private MensajeAlerta mensajeAlerta = new MensajeAlerta();

        /// <summary>
        /// Inicializacion componentes de la ventana articulos.
        /// </summary>
        public CrearArticulo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo que carga funciones y metodos de incializacion de la ventana crear articulos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CrearArticulo_Load(object sender, EventArgs e)
        {
            llenarListaDeBodegas();
            llenarListaDeArticulos();
            txtCantidadArticulo.Text = "0";
            txtPrecioArticulo.Text = "0";

        }

        /// <summary>
        /// Metodo para insertar un registro de tipo Articulo.
        /// El metodo se activa tras presional el boton insertar y trasforma el modelo de la capa de 
        /// vista al modelo de la capa logica y lo envia a la capa logica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertarArticulo_Click(object sender, EventArgs e)
        {
            errorInsertar.Clear();

            if (validarCampos())
            {
                MapeadorArticuloVista mapper = new MapeadorArticuloVista();
                ArticuloModeloLogica ArticuloDTO = mapper.mapearTipo2Tipo1(new ArticuloModeloVista
                {
                    Id_bodega = Int32.Parse(txtIdBodega.Text),
                    Nombre = txtNombreArticulo.Text,
                    Descripcion = txtDescripcionArticulo.Text,
                    Cantidad = Int32.Parse(txtCantidadArticulo.Text),
                    Precio = Int32.Parse(txtPrecioArticulo.Text)
                });

                if (logicaArticulos.comprobarExistenciaArticuloEnBodega(ArticuloDTO))
                {
                    mensajeAlerta.mensajeError("Error al guardar", "Todos los campos del registro coinciden con un registro ya existente");
                }
                else
                {
                    logicaArticulos.guardarRegistro(ArticuloDTO);
                    mensajeAlerta.mensajeValidacion("Accion Realizada", "Registro Guardado");
                }
                limpiarBoxText();
                llenarListaDeArticulos();

            }           
        }

        /// <summary>
        /// Metodo para Eliminar un registro de tipo articulo.
        /// El metodo se activa tras presional el boton Eliminar y envia el id de la capa de  
        /// vista a la capa logica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            if (txtIdArticulo.Text.Trim() != string.Empty)
            {
                logicaArticulos.eliminarRegistro(Int32.Parse(txtIdArticulo.Text));
                mensajeAlerta.mensajeValidacion("Accion Realizada", "Registro Eliminado");
                
            }
            else
            {
                errorInsertar.SetError(txtIdArticulo,"Seleccione el articulo el cual desea eliminar");
            }
            limpiarBoxText();
            llenarListaDeArticulos();


        }

        /// <summary>
        /// Metodo para actualizar un registro de tipo articulo.
        /// El metodo se activa tras presional el boton Actualizar y trasforma el modelo de la capa de 
        /// vista al modelo de la capa logica y lo envia a la capa logica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualizarArticulo_Click(object sender, EventArgs e)
        {

            if(validarCampos() && txtIdArticulo.Text.Trim() != string.Empty)
            {
                MapeadorArticuloVista mapper = new MapeadorArticuloVista();
                ArticuloModeloLogica ArticuloModeloLogica = mapper.mapearTipo2Tipo1(new ArticuloModeloVista
                {
                    Id = Int32.Parse(txtIdArticulo.Text),
                    Id_bodega = Int32.Parse(txtIdBodega.Text),
                    Nombre = txtNombreArticulo.Text,
                    Descripcion = txtDescripcionArticulo.Text,
                    Cantidad = Int32.Parse(txtCantidadArticulo.Text),
                    Precio = Int32.Parse(txtPrecioArticulo.Text)
                });

                bool seActualizo = logicaArticulos.editarRegistro(ArticuloModeloLogica);

                //Mensaje para informar al usuario si el dato fue actualizado u ocurrio un error
                if (seActualizo)
                {
                    mensajeAlerta.mensajeValidacion("Accion Realizada", "Registro Actualizado");
                }
                limpiarBoxText();
                llenarListaDeArticulos();
            }
            else
            {
                errorInsertar.SetError(txtIdArticulo, "Seleccione el Articulo el cual desea modificar");
            }

            
        }

        /// <summary>
        /// Metodo para limpiar los campos de los TextBoxs
        /// </summary>
        private void limpiarBoxText()
        {
            txtIdArticulo.Text = "";
            txtNombreArticulo.Text = "";
            txtCantidadArticulo.Text = "0";
            txtPrecioArticulo.Text = "0";
            txtDescripcionArticulo.Text = "";
            txtIdBodega.Text = "";
        }

        /// <summary>
        /// Metodo para llenar los datos en el DataGridView1 que son registros de tipo bodega.
        /// carga la lista del modelo de la capa logica y lo trasforma en el modelo que utiliza la capa de 
        /// vista para mostrar la informacion al usuario
        /// </summary>
        private void llenarListaDeBodegas()
        {
            IEnumerable<BodegaModeloLogica> listaDatos = logicaBodega.listarRegistros();
            MapeadorBodegaVista mapper = new MapeadorBodegaVista();
            IEnumerable<BodegaModeloVista> listaGUI = mapper.mapearTipo1Tipo2(listaDatos);
            dataGridView1.DataSource = listaGUI.ToList();

        }

        /// <summary>
        /// Metodo para llenar los datos en el DataGridView2 que son registros de tipo articulo.
        /// carga la lista del modelo de la capa logica y lo trasforma en el modelo que utiliza la capa de 
        /// vista para mostrar la informacion al usuario.
        /// </summary>
        private void llenarListaDeArticulos()
        {
            IEnumerable<ArticuloModeloLogica> listaDatos = logicaArticulos.listarRegistros();
            MapeadorArticuloVista mapper = new MapeadorArticuloVista();
            IEnumerable<ArticuloModeloVista> listaGUI = mapper.mapearTipo1Tipo2(listaDatos);
            dataGridView2.DataSource = listaGUI.ToList();
        }

        /// <summary>
        /// Metodo para extraer la informacion tras presionar una celda del DataGridViewn1 que
        /// es un lista de bodegas y actualizar el campo TextBox del idBodeda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;
            txtIdBodega.Text = dataGridView1[0, fila].Value.ToString();
        }

        /// <summary>
        /// Metodo para extraer la informacion tras presionar una celda del DataGridViewn2 que
        /// es un lista de articulos y actualizar la informacion de los campos TextBox
        /// de los campos correspondientes a los articulos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView2.CurrentCell.RowIndex;
            txtIdArticulo.Text = dataGridView2[0, fila].Value.ToString();
            txtNombreArticulo.Text = dataGridView2[2, fila].Value.ToString();
            txtDescripcionArticulo.Text = dataGridView2[3, fila].Value.ToString();
            txtCantidadArticulo.Text = dataGridView2[4, fila].Value.ToString();
            txtPrecioArticulo.Text = dataGridView2[5, fila].Value.ToString();

        }       

        /// <summary>
        /// valida los campos de entrada e impide que se envien campos vacios, letras o caractes
        /// especiales en campos numericos
        /// </summary>
        /// <returns></returns>
        private bool validarCampos()
        {
            bool bandera = true;
            if (txtNombreArticulo.Text == "")
            {
                bandera = false;
                errorInsertar.SetError(txtNombreArticulo, "El campo no puede ser vacio");
            }
            if (txtDescripcionArticulo.Text == "")
            {
                bandera = false;
                errorInsertar.SetError(txtDescripcionArticulo, "El campo no puede ser vacio");
            }
            if (!Regex.IsMatch(txtCantidadArticulo.Text, @"^[1-9][0-9]*$") || txtCantidadArticulo.Text == "")
            {
                bandera = false;
                errorInsertar.SetError(txtCantidadArticulo, "El campo no puede ser vacio \nEl campo no puede contener letras");
            }
            if (!Regex.IsMatch(txtPrecioArticulo.Text, @"^[1-9][0-9]*$") || txtPrecioArticulo.Text == "")
            {
                bandera = false;
                errorInsertar.SetError(txtPrecioArticulo, "El campo no puede ser vacio \nEl campo no puede contener letras");
            }
            if (txtIdBodega.Text == "")
            {
                bandera = false;
                errorInsertar.SetError(txtIdBodega, "Seleccione la bodega donde se va a almacenar el articulo");
            }
            return bandera;
        }
    }
}
