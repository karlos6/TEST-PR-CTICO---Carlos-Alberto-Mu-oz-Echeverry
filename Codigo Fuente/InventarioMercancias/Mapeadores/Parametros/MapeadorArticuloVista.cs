using InventarioMercancias.ModeloVista.Parametros;
using LogicaInventarioMercancias.ModeloLogica.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioMercancias.Mapeadores.Parametros
{
    public class MapeadorArticuloVista : MapeadorBaseVista<ArticuloModeloLogica, ArticuloModeloVista>
    {
        /// <summary>
        /// Mapeador que trasforma el modelo ArticuloModeloLogica de la capa logica 
        /// a un  modelo ArticuloModeloVista que se utiliza en la capa vista para pasar la informacion 
        /// para mostrar la informacion a los usuarios.
        /// </summary>
        /// <param name="entrada"> Modelo ArticuloModeloLogica de la capa logica que se va a transformar</param>
        /// <returns> Retorna un modelo ArticuloModeloVista</returns>
        public override ArticuloModeloVista mapearTipo1Tipo2(ArticuloModeloLogica entrada)
        {
            return new ArticuloModeloVista()
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
        /// Mapeador que trasforma una lista de modelos ArticuloModeloLogica de la capa logica
        /// a una lista de modelos ArticuloModeloVista que se utiliza en la capa de vista para mostrar 
        /// la informacion a los usuarios
        /// </summary>
        /// <param name="entrada">Lista de modelos BodegaModeloDb que se va a transformar</param>
        /// <returns> Retorna un lista de modelos ArticuloModeloLogica</returns>
        public override IEnumerable<ArticuloModeloVista> mapearTipo1Tipo2(IEnumerable<ArticuloModeloLogica> entrada)
        {
            foreach (var item in entrada)
            {
                yield return mapearTipo1Tipo2(item);
            }
        }

        /// <summary>
        /// Mapeador que trasforma el modelo ArticuloModeloVista que uliliza la capa de vista
        /// a un modelo ArticuloModeloLogica de la capa logica que se utiliza para almacenar 
        /// un registro de bodega. 
        /// </summary>
        /// <param name="entrada">Modelo ArticuloModeloVista de la capa logica que se va a transformar</param>
        /// <returns>Retorna un modelo ArticuloModeloLogica</returns>
        public override ArticuloModeloLogica mapearTipo2Tipo1(ArticuloModeloVista entrada)
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
    }
}
