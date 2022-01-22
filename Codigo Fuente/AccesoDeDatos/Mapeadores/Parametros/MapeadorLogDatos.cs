using AccesoDeDatos.ModeloDB.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorLogDatos : MapeadorBaseDeDatos<tb_log, LogModeloDb>
    {

        /// <summary>
        /// Mapeador que trasforma el modelo de la tabla tb_log de la base de datos 
        /// al modelo LogModeloDb que se utiliza en acceso a datos para pasar la informacion 
        /// a la capa logica.
        /// </summary>
        /// <param name="entrada"> Modelo de la tabla tb_log de la base que se va a transformar</param>
        /// <returns> Retorna un modelo LogModeloDb</returns>
        public override LogModeloDb mapearTipo1Tipo2(tb_log entrada)
        {
            return new LogModeloDb()
            {
                Id = entrada.id,
                Fecha = entrada.fecha,
                Hora = entrada.hora,
                Id_bodega_origen = entrada.id_bodega_origen,
                Id_bodega_destino = entrada.id_bodega_destino,
                Id_articulo = entrada.id_articulo,
                CantidadTranferidas = entrada.cantidadTranferidas
            };
        }

        /// <summary>
        /// Mapeador que trasforma una lista de modelos tb_log de la base de datos 
        /// a una lista de modelos LogModeloDb que se utiliza en acceso a datos para pasar la informacion 
        /// a la capa logica.
        /// </summary>
        /// <param name="entrada"> Lista de modelos de la tabla tb_log que se va a transformar</param>
        /// <returns> Retorna un lista de modelos LogModeloDb</returns>
        public override IEnumerable<LogModeloDb> mapearTipo1Tipo2(IEnumerable<tb_log> entrada)
        {
            foreach (var item in entrada)
            {
                yield return mapearTipo1Tipo2(item);
            }
        }

        /// <summary>
        /// Mapeador que trasforma el modelo LogModeloDb que uliliza el acceso a datos
        /// a un modelo de la tabla tb_log de la base de datos que se utiliza para almacenar 
        /// un registro de tipo Log. 
        /// </summary>
        /// <param name="entrada"> Modelo LogModeloDb que se va a trasformar</param>
        /// <returns> Retorna un modelo tb_log</returns>
        public override tb_log mapearTipo2Tipo1(LogModeloDb entrada)
        {
            return new tb_log()
            {
                id = entrada.Id,
                fecha = entrada.Fecha,
                hora = entrada.Hora,
                id_bodega_origen = entrada.Id_bodega_origen,
                id_bodega_destino = entrada.Id_bodega_destino,
                id_articulo = entrada.Id_articulo,
                cantidadTranferidas = entrada.CantidadTranferidas
            };
        }
    }
}
