using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioMercancias.ModeloVista.Parametros
{
    /// <summary>
    /// Modelo BodegaModeloVista que utiliza la capa de vista.
    /// </summary>
    public class BodegaModeloVista
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
