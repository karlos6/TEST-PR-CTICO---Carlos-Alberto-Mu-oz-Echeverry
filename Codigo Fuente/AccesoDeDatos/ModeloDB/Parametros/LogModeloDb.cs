using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.ModeloDB.Parametros
{

    /// <summary>
    /// Modelo LogModeloDb que utiliza el acceso a datos.
    /// </summary>
    public class LogModeloDb
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string fecha;

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private string hora;

        public string Hora
        {
            get { return hora; }
            set { hora = value; }
        }

        private int id_bodega_origen;

        public int Id_bodega_origen
        {
            get { return id_bodega_origen; }
            set { id_bodega_origen = value; }
        }

        private int id_bodega_destino;

        public int Id_bodega_destino
        {
            get { return id_bodega_destino; }
            set { id_bodega_destino = value; }
        }

        private int id_articulo;

        public int Id_articulo
        {
            get { return id_articulo; }
            set { id_articulo = value; }
        }

        private int cantidadTranferidas;

        public int CantidadTranferidas
        {
            get { return cantidadTranferidas; }
            set { cantidadTranferidas = value; }
        }
    }
}
