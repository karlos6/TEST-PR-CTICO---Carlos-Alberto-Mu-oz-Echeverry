using AccesoDeDatos.ModeloDB.Parametros;
using LogicaInventarioMercancias.ModeloLogica.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaInventarioMercancias.Mapeadores.Parametros
{
    public class MapeadorBodegaLogica : MapeadorBaseLogica<BodegaModeloDb, BodegaModeloLogica>
    {
        /// <summary>
        /// Mapeador que trasforma el modelo BodegaModeloDb de la capa de acceso a datos
        /// a un  modelo BodegaModeloLogica que se utiliza en la capa logica para pasar la informacion 
        /// a la capa de vistas.
        /// </summary>
        /// <param name="entrada"> Modelo BodegaModeloDb del acceso a datos que se va a transformar</param>
        /// <returns> Retorna un modelo BodegaModeloLogica</returns>
        public override BodegaModeloLogica mapearTipo1Tipo2(BodegaModeloDb entrada)
        {
            return new BodegaModeloLogica()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre
            };
        }

        /// <summary>
        /// Mapeador que trasforma una lista de modelos BodegaModeloDb de la capa de acceso a datos
        /// a una lista de modelos BodegaModeloLogica que se utiliza en la capa logica para pasar la informacion 
        /// a la capa de vastas.
        /// </summary>
        /// <param name="entrada">Lista de modelos BodegaModeloDb que se va a transformar</param>
        /// <returns> Retorna un lista de modelos BodegaModeloLogica</returns>
        public override IEnumerable<BodegaModeloLogica> mapearTipo1Tipo2(IEnumerable<BodegaModeloDb> entrada)
        {
            foreach (var item in entrada)
            {
                yield return mapearTipo1Tipo2(item);
            }
        }

        /// <summary>
        /// Mapeador que trasforma el modelo BodegaModeloLogica que uliliza la capa logica
        /// a un modelo un BodegaModeloDb de la capa de base de datos que se utiliza para almacenar 
        /// un registro de bodega. 
        /// </summary>
        /// <param name="entrada">Modelo BodegaModeloLogica de la capa logica que se va a transformar</param>
        /// <returns>Retorna un modelo BodegaModeloDb</returns>
        public override BodegaModeloDb mapearTipo2Tipo1(BodegaModeloLogica entrada)
        {
            return new BodegaModeloDb()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre
            };
        }
    }
}
