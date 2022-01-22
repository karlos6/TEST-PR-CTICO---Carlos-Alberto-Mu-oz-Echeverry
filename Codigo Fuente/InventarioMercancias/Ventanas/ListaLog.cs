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
    public partial class ListaLog : Form
    {
        ///Objeto ImplLogLogica para acceder a la capa logica de logs.
        private ImplLogLogica logicaLog = new ImplLogLogica();
        public ListaLog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo que carga los valores por default de la ventana log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListaLog_Load(object sender, EventArgs e)
        {
            llenarListaLogs();

        }

        /// <summary>
        /// Metodo que llena un dataGrigView con una lista de logs para ser visualizada
        /// por el usuario
        /// </summary>
        private void llenarListaLogs()
        {
            IEnumerable<LogModeloLogica> listaDatos = logicaLog.listarRegistros();
            MapeadorLogVista mapper = new MapeadorLogVista();
            IEnumerable<LogModeloVista> listaGUI = mapper.mapearTipo1Tipo2(listaDatos);
            vistaListaLogs.DataSource = listaGUI.ToList();
        }
    }
}
