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

namespace InventarioMercancias
{
    public partial class CrearBodega : Form
    {
        /// <summary>
        /// logica :        Atributo ImplBodegaLogica de la capa logica para poder acceder a los metodos.
        /// mensajeAlerta : Atributo de la clase helpers para controlar los mensajes en las ventanas.
        /// </summary>
        private ImplBodegaLogica logica = new ImplBodegaLogica();
        private MensajeAlerta mensajeAlerta = new MensajeAlerta();

        /// <summary>
        /// Metodo para inicializar los componentes de la ventana CrearBodega
        /// </summary>
        public CrearBodega()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Metodo para cargar los componentes por defecto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            llenarDatosGridView();
        }


        /// <summary>
        /// Metodo para insertar un registro de tipo bodega.
        /// El metodo se activa tras presional el boton insertar y trasforma el modelo de la capa de 
        /// vista al modelo de la capa logica y lo envia a la capa logica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            errorCampos.Clear();
            if (validarCampos())
            {
                MapeadorBodegaVista mapper = new MapeadorBodegaVista();
                BodegaModeloLogica BodegaDTO = mapper.mapearTipo2Tipo1(new BodegaModeloVista { Nombre = txtNombreBodega.Text });
                bool seGuardo = logica.guardarRegistro(BodegaDTO);

                //Mensaje para informar al usuario si el dato se almaceno u ocurrio un error
                if (!seGuardo)
                {
                    mensajeAlerta.mensajeError("Nombre Repetido", "El nombre de la bodega ya existe");
                }
                else
                {
                    mensajeAlerta.mensajeValidacion("Accion Realizada", "Registro Guardado");
                }

                limpiarBoxText();
                llenarDatosGridView();
            }

            
        }

        /// <summary>
        /// Metodo para actualizar un registro de tipo bodega.
        /// El metodo se activa tras presional el boton Actualizar y trasforma el modelo de la capa de 
        /// vista al modelo de la capa logica y lo envia a la capa logica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            errorCampos.Clear();
            if (validarCampos() && txtId.Text.Trim() != string.Empty)
            {
                MapeadorBodegaVista mapper = new MapeadorBodegaVista();
                BodegaModeloLogica BodegaModeloLogica = mapper.mapearTipo2Tipo1(new BodegaModeloVista { Id = Int32.Parse(txtId.Text), Nombre = txtNombreBodega.Text });
                bool seActualizo = logica.editarRegistro(BodegaModeloLogica);

                //Mensaje para informar al usuario si el dato fue actualizado u ocurrio un error
                if (!seActualizo)
                {
                    mensajeAlerta.mensajeError("Nombre Existente", "El nombre que desea actualizar ya existe");
                }
                else
                {
                    mensajeAlerta.mensajeValidacion("Accion Realizada", "Registro Actualizado");
                }
                limpiarBoxText();
                llenarDatosGridView();
            }
            else
            {
                errorCampos.SetError(txtId, "Seleccione la bodega a actualizar");
            }
        }

        /// <summary>
        /// Metodo para Eliminar un registro de tipo bodega.
        /// El metodo se activa tras presional el boton Eliminar y trasforma el modelo de la capa de 
        /// vista al modelo de la capa logica y lo envia a la capa logica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            errorCampos.Clear();

            if (txtId.Text.Trim() != string.Empty)
            {
                bool seElimino = logica.eliminarRegistro(Int32.Parse(txtId.Text));

                //Mensaje para informar al usuario si el dato fue eliminado u ocurrio un error
                if (!seElimino)
                {
                    mensajeAlerta.mensajeError("Datos Existentes", "La bodega contiene articulos");
                }
                else
                {
                    mensajeAlerta.mensajeValidacion("Registro Eliminado", "Accion Realizada");
                    llenarDatosGridView();
                }

                
            }
            else
            {
                errorCampos.SetError(txtId, "Seleccione la bodega a eliminar");
            }

            limpiarBoxText();           

        }

        /// <summary>
        /// Metodo para llenar los datos en el DataGridView.
        /// carga la lista del modelo de la capa logica y lo trasforma en el modelo que utiliza la capa de 
        /// vista para mostrar la informacion al usuario
        /// </summary>
        private void llenarDatosGridView()
        {
            IEnumerable<BodegaModeloLogica> listaDatos = logica.listarRegistros();
            MapeadorBodegaVista mapper = new MapeadorBodegaVista();
            IEnumerable<BodegaModeloVista> listaGUI = mapper.mapearTipo1Tipo2(listaDatos);
            dataGridView.DataSource = listaGUI.ToList();
        }

        /// <summary>
        /// Metodo para extraer la informacion tras presionar una celda del DataGridViewn y
        /// acrualizarla en los compos TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int fila = dataGridView.CurrentCell.RowIndex;
            txtId.Text = dataGridView[0, fila].Value.ToString();
            txtNombreBodega.Text = dataGridView[1, fila].Value.ToString();
        }

        /// <summary>
        /// Metodo para validar que el campo del nombre de la bodega no este vacio
        /// </summary>
        /// <returns></returns>
        private bool validarCampos()
        {
            bool sonCorrectos = true;

            if(txtNombreBodega.Text.Trim() == string.Empty)
            {
                sonCorrectos = false;
                errorCampos.SetError(txtNombreBodega, "El campo de no puede ser vacio");
            }
            return sonCorrectos;
        }        

        /// <summary>
        /// Metodo para limpiar los campos de los TextBoxs
        /// </summary>
        private void limpiarBoxText()
        {
            txtId.Text = "";
            txtNombreBodega.Text = "";
        }        
    }
}
