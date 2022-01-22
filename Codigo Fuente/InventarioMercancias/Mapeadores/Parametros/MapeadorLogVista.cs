using InventarioMercancias.ModeloVista.Parametros;
using LogicaInventarioMercancias.ModeloLogica.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioMercancias.Mapeadores.Parametros
{
    public class MapeadorLogVista : MapeadorBaseVista<LogModeloLogica, LogModeloVista>
    {
        /// <summary>
        /// Mapeador que trasforma el modelo de la tabla LogModeloLogica de la capa logica 
        /// al modelo LogModeloVista que se utiliza en la capa de vista para pasar la informacion 
        /// a la capa logica.
        /// </summary>
        /// <param name="entrada"> Modelo de la tabla LogModeloLogica de la base que se va a transformar</param>
        /// <returns> Retorna un modelo LogModeloVista</returns>
        public override LogModeloVista mapearTipo1Tipo2(LogModeloLogica entrada)
        {
            return new LogModeloVista()
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
        /// Mapeador que trasforma una lista de modelos LogModeloLogica de la capa logica 
        /// a una lista de modelos LogModeloVista que se utiliza la capa de vista para pasar la informacion 
        /// a la vista.
        /// </summary>
        /// <param name="entrada"> Lista de modelos de la tabla LogModeloLogica que se va a transformar</param>
        /// <returns> Retorna un lista de modelos LogModeloVista</returns>
        public override IEnumerable<LogModeloVista> mapearTipo1Tipo2(IEnumerable<LogModeloLogica> entrada)
        {
            foreach (var item in entrada)
            {
                yield return mapearTipo1Tipo2(item);
            }
        }

        /// <summary>
        /// Mapeador que trasforma el modelo LogModeloVista que uliliza el de la capa de vista
        /// a un modelo de la tabla LogModeloLogica de la capa logica que se utiliza para almacenar 
        /// un registro de tipo Log. 
        /// </summary>
        /// <param name="entrada"> Modelo LogModeloVista que se va a trasformar</param>
        /// <returns> Retorna un modelo LogModeloLogica</returns>
        public override LogModeloLogica mapearTipo2Tipo1(LogModeloVista entrada)
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

    }
}
