using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaInventarioMercancias.ModeloLogica.Parametros
{
    /// <summary>
    /// Modelo BodegaModeloLogica que utiliza la capa logica.
    /// </summary>
    public class BodegaModeloLogica
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
