using AccesoDeDatos.ModeloDB.Parametros;
using LogicaInventarioMercancias.ModeloLogica.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaInventarioMercancias.Mapeadores.Parametros
{
    public class MapeadorArticuloLogica : MapeadorBaseLogica<ArticuloModeloDb, ArticuloModeloLogica>
    {
        /// <summary>
        /// Mapeador que trasforma el modelo ArticuloModeloDb de la capa de acceso a datos
        /// a un  modelo ArticuloModeloLogica que se utiliza en la capa logica para pasar la informacion 
        /// a la capa de vistas.
        /// </summary>
        /// <param name="entrada"> Modelo ArticuloModeloDb del acceso a datos que se va a transformar</param>
        /// <returns> Retorna un modelo ArticuloModeloLogica</returns>
        public override ArticuloModeloLogica mapearTipo1Tipo2(ArticuloModeloDb entrada)
        {
            return new ArticuloModeloLogica()
            {
                Id = entrada.Id,
                Id_bodega = entrada.Id_bodega,
                Nombre = entrada.Nombre,
                Descripcion = entrada.Descripcion,
                Cantidad = entrada.Cantidad,
                Precio = entrada.Precio
            };
        }

        /// <summary>
        /// Mapeador que trasforma una lista de modelos ArticuloModeloDb de la capa de acceso a datos
        /// a una lista de modelos ArticuloModeloLogica que se utiliza en la capa logica para pasar la informacion 
        /// a la capa de vistas.
        /// </summary>
        /// <param name="entrada">Lista de modelos ArticuloModeloDb que se va a transformar</param>
        /// <returns> Retorna un lista de modelos ArticuloModeloLogica</returns>
        public override IEnumerable<ArticuloModeloLogica> mapearTipo1Tipo2(IEnumerable<ArticuloModeloDb> entrada)
        {
            foreach (var item in entrada)
            {
                yield return mapearTipo1Tipo2(item);
            }
        }

        /// <summary>
        /// Mapeador que trasforma el modelo ArticuloModeloLogica que uliliza la capa logica
        /// a un modelo un ArticuloModeloDb de la capa de base de datos que se utiliza para almacenar 
        /// un registro de Articulos. 
        /// </summary>
        /// <param name="entrada">Modelo ArticuloModeloLogica de la capa logica que se va a transformar</param>
        /// <returns>Retorna un modelo ArticuloModeloDb</returns>
        public override ArticuloModeloDb mapearTipo2Tipo1(ArticuloModeloLogica entrada)
        {
            return new ArticuloModeloDb()
            {
                Id = entrada.Id,
                Id_bodega = entrada.Id_bodega,
                Nombre = entrada.Nombre,
                Descripcion = entrada.Descripcion,
                Cantidad = entrada.Cantidad,
                Precio = entrada.Precio
            };
        }
    }
}
