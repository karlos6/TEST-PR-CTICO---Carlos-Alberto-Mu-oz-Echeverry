using AccesoDeDatos.Mapeadores.Parametros;
using AccesoDeDatos.ModeloDB.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Implementacion.Parametros
{
    public class ImplLogDatos
    {
        /// <summary>
        /// Metodo para listar Registros de la log
        /// </summary>
        /// <returns>retorna la lista de tipo log</returns>
        public IEnumerable<LogModeloDb> listarRegistros()
        {
            var lista = new List<LogModeloDb>();

            //coneccion base de datos
            using (InventarioMercanciasEntities bd = new InventarioMercanciasEntities())
            {
                var listaDatos = (from c in bd.tb_log
                                  select c).OrderBy(m => m.id).ToList();
                lista = new MapeadorLogDatos().mapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;
        }


        /// <summary>
        /// Metodo para almacenar un registro tipo log
        /// </summary>
        /// <param name="registro">Modelo de tipo log de la base de datos que entra a ser almacenado</param>
        /// <returns>retorna true cuando almacena, false cuando existe un registro o una excepción/returns>
        public bool GuardarRegistro(LogModeloDb registro)
        {
            try
            {
                using (InventarioMercanciasEntities bd = new InventarioMercanciasEntities())
                {                              
                    MapeadorLogDatos mapeador = new MapeadorLogDatos();
                    var reg = mapeador.mapearTipo2Tipo1(registro);
                    bd.tb_log.Add(reg);
                    bd.SaveChanges();
                    return true;                 
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
