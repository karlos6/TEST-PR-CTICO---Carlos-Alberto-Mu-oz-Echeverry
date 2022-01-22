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
    public class ImplBodegaLogica
    {
        /// Variable privada para acceder a la capa de acceso a datos
        private ImplBodegaDatos accesoDatos;

        public ImplBodegaLogica()
        {
            this.accesoDatos = new ImplBodegaDatos();
        }

        /// <summary>
        /// Metodo para extraer la lista de modelos del acceso a datos y 
        /// convertirlos en una lista de modelos BodegaModeloLogica que se utilizan 
        /// en la capa logica.
        /// </summary>
        /// <returns>retorna una lista de modelos BodegaModeloLogica</returns>
        public IEnumerable<BodegaModeloLogica> listarRegistros()
        {
            var listado = this.accesoDatos.listarRegistros();
            MapeadorBodegaLogica mapeador = new MapeadorBodegaLogica();
            return mapeador.mapearTipo1Tipo2(listado);
        }

        public IEnumerable<BodegaModeloLogica> listarRegistrosBodegasDiferentes(int id)
        {
            var listado = this.accesoDatos.listarRegistrosBodegasDiferentes(id);
            MapeadorBodegaLogica mapeador = new MapeadorBodegaLogica();
            return mapeador.mapearTipo1Tipo2(listado);
        }


        /// <summary>
        /// Metodo para eliminar un registro el cual recibe un id que proviene de la capa de vista y la capa envia  
        /// a la capa de acceso a datos para eliminar el registro. 
        /// </summary>
        /// <param name="id">id del registro que se desea eliminar</param>
        /// <returns>retorna verdadero si se elimino el registro y falso si no se pudo eliminar</returns>
        public Boolean eliminarRegistro(int id)
        {
            Boolean res = this.accesoDatos.eliminarRegistro(id);
            return res;
        }

        /// <summary>
        /// Metodo para editar la informacion de un registro.
        /// recibe un modelo BodegaModeloLogica que uliza la capa logica y lo trasforma en un modelo de 
        /// acceso a datos para poder ser enviado a la capa y actualizar el registro.
        /// </summary>
        /// <param name="registro"> modelo de tipo BodegaModeloLogica que se va a trasformar
        ///                         en un modelo de acceso a datos
        /// </param>
        /// <returns>retorna verdadero si el registro fue actualizado o falso si ocurrio alguna excepción </returns>
        public Boolean editarRegistro(BodegaModeloLogica registro)
        {
            MapeadorBodegaLogica mapeador = new MapeadorBodegaLogica();
            BodegaModeloDb reg = mapeador.mapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.editarRegistro(reg);
            return res;
        }

        /// <summary>
        /// Metodo para almacenar un registro 
        /// recibe un modelo BodegaModeloLogica que uliza la capa logica y lo trasforma en un modelo de 
        /// acceso a datos para poder ser enviado a la capa Y almacenar el registro.
        /// </summary>
        /// <param name="registro"></param>
        /// <returns></returns>
        public Boolean guardarRegistro(BodegaModeloLogica registro)
        {
            MapeadorBodegaLogica mapeador = new MapeadorBodegaLogica();
            BodegaModeloDb reg = mapeador.mapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }
    }
}
