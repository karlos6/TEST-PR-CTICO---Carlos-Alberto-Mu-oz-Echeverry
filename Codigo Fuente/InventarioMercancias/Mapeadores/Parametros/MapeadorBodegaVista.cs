using InventarioMercancias.ModeloVista.Parametros;
using LogicaInventarioMercancias.ModeloLogica.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioMercancias.Mapeadores.Parametros
{
    public class MapeadorBodegaVista : MapeadorBaseVista<BodegaModeloLogica, BodegaModeloVista>
    {
        /// <summary>
        /// Mapeador que trasforma el modelo BodegaModeloLogica de la capa logica 
        /// a un  modelo BodegaModeloVista que se utiliza en la capa vista para pasar la informacion 
        /// para mostrar la informacion a los usuarios.
        /// </summary>
        /// <param name="entrada"> Modelo BodegaModeloLogica de la capa logica que se va a transformar</param>
        /// <returns> Retorna un modelo BodegaModeloVista</returns>
        public override BodegaModeloVista mapearTipo1Tipo2(BodegaModeloLogica entrada)
        {
            return new BodegaModeloVista()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre
            };
        }

        /// <summary>
        /// Mapeador que trasforma una lista de modelos BodegaModeloLogica de la capa logica
        /// a una lista de modelos BodegaModeloVista que se utiliza en la capa de vista para mostrar 
        /// la informacion a los usuarios
        /// </summary>
        /// <param name="entrada">Lista de modelos BodegaModeloDb que se va a transformar</param>
        /// <returns> Retorna un lista de modelos BodegaModeloLogica</returns>
        public override IEnumerable<BodegaModeloVista> mapearTipo1Tipo2(IEnumerable<BodegaModeloLogica> entrada)
        {
            foreach (var item in entrada)
            {
                yield return mapearTipo1Tipo2(item);
            }
        }

        /// <summary>
        /// Mapeador que trasforma el modelo BodegaModeloVista que uliliza la capa de vista
        /// a un modelo BodegaModeloLogica de la capa logica que se utiliza para almacenar 
        /// un registro de bodega. 
        /// </summary>
        /// <param name="entrada">Modelo BodegaModeloVista de la capa logica que se va a transformar</param>
        /// <returns>Retorna un modelo BodegaModeloLogica</returns>
        public override BodegaModeloLogica mapearTipo2Tipo1(BodegaModeloVista entrada)
        {
            return new BodegaModeloLogica()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre
            };
        }
    }
}
