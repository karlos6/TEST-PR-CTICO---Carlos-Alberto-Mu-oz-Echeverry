using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.ModeloDB.Parametros
{
    /// <summary>
    /// Modelo ArticuloModeloDb que utiliza el acceso a datos.
    /// </summary>
    public class ArticuloModeloDb
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int id_bodega;

        public int Id_bodega
        {
            get { return id_bodega; }
            set { id_bodega = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private int precio;

        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }
    }
}
