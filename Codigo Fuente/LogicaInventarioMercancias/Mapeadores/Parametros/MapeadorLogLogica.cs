using AccesoDeDatos.ModeloDB.Parametros;
using LogicaInventarioMercancias.ModeloLogica.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaInventarioMercancias.Mapeadores.Parametros
{
    class MapeadorLogLogica : MapeadorBaseLogica<LogModeloDb, LogModeloLogica>
    {
        /// <summary>
        /// Mapeador que trasforma el modelo de la tabla LogModeloDb de la base de datos 
        /// al modelo LogModeloLogica que se utiliza en acceso a datos para pasar la informacion 
        /// a la capa logica.
        /// </summary>
        /// <param name="entrada"> Modelo de la tabla LogModeloDb de la base que se va a transformar</param>
        /// <returns> Retorna un modelo LogModeloLogica</returns>
        public override LogModeloLogica mapearTipo1Tipo2(LogModeloDb entrada)
        {
            return new LogModeloLogica()
            {
                Id = entrada.Id,
                Fecha = entrada.Fecha,
                Hora = entrada.Hora,
                Id_bodega_origen = entrada.Id_bodega_origen,
                Id_bodega_destino = entrada.Id_bodega_destino,
                Id_articulo = entrada.Id_articulo,
                CantidadTranferidas = entrada.CantidadTranferidas
            };
        }

        /// <summary>
        /// Mapeador que trasforma una lista de modelos LogModeloDb de la base de datos 
        /// a una lista de modelos LogModeloLogica que se utiliza en acceso a datos para pasar la informacion 
        /// a la capa logica.
        /// </summary>
        /// <param name="entrada"> Lista de modelos de la tabla LogModeloDb que se va a transformar</param>
        /// <returns> Retorna un lista de modelos LogModeloLogica</returns>
        public override IEnumerable<LogModeloLogica> mapearTipo1Tipo2(IEnumerable<LogModeloDb> entrada)
        {
            foreach (var item in entrada)
            {
                yield return mapearTipo1Tipo2(item);
            }
        }

        /// <summary>
        /// Mapeador que trasforma el modelo LogModeloLogica que uliliza el acceso a datos
        /// a un modelo de la tabla LogModeloDb de la base de datos que se utiliza para almacenar 
        /// un registro de tipo Log. 
        /// </summary>
        /// <param name="entrada"> Modelo LogModeloLogica que se va a trasformar</param>
        /// <returns> Retorna un modelo LogModeloDb</returns>
        public override LogModeloDb mapearTipo2Tipo1(LogModeloLogica entrada)
        {
            return new LogModeloDb()
            {
                Id = entrada.Id,
                Fecha = entrada.Fecha,
                Hora = entrada.Hora,
                Id_bodega_origen = entrada.Id_bodega_origen,
                Id_bodega_destino = entrada.Id_bodega_destino,
                Id_articulo = entrada.Id_articulo,
                CantidadTranferidas = entrada.CantidadTranferidas
            };
        }
    }
}
