using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.ModeloDB.Parametros
{
    /// <summary>
    /// Modelo BodegaModeloDb que utiliza el acceso a datos.
    /// </summary>
    public class BodegaModeloDb
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
