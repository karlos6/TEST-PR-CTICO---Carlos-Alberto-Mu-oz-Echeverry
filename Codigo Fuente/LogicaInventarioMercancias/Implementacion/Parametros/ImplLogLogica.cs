using AccesoDeDatos.Implementacion.Parametros;
using AccesoDeDatos.ModeloDB.Parametros;
using LogicaInventarioMercancias.Mapeadores.Parametros;
using LogicaInventarioMercancias.ModeloLogica.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaInventarioMercancias.Implementacion.Parametros
{
    public class ImplLogLogica
    {
        /// Variable privada para acceder a la capa de acceso a datos
        private ImplLogDatos accesoDatos;

        public ImplLogLogica()
        {
            this.accesoDatos = new ImplLogDatos();
        }


        /// <summary>
        /// Metodo para extraer la lista de modelos del acceso a datos y 
        /// convertirlos en una lista de modelos LogModeloLogica que se utilizan 
        /// en la capa logica.
        /// </summary>
        /// <returns>retorna una lista de modelos LogModeloLogica</returns>
        public IEnumerable<LogModeloLogica> listarRegistros()
        {
            var listado = this.accesoDatos.listarRegistros();
            MapeadorLogLogica mapeador = new MapeadorLogLogica();
            return mapeador.mapearTipo1Tipo2(listado);
        }

        /// <summary>
        /// Metodo para almacenar un registro 
        /// recibe un modelo LogModeloLogica que uliza la capa logica y lo trasforma en un modelo de 
        /// acceso a datos para poder ser enviado a la capa Y almacenar el registro.
        /// </summary>
        /// <param name="registro"></param>
        /// <returns></returns>
        public Boolean guardarRegistro(LogModeloLogica registro)
        {
            MapeadorLogLogica mapeador = new MapeadorLogLogica();
            LogModeloDb reg = mapeador.mapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }
    }
}
