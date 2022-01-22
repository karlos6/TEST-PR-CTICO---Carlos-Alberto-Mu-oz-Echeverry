using AccesoDeDatos.ModeloDB.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorArticuloDatos : MapeadorBaseDeDatos<tb_articulo, ArticuloModeloDb>
    {
        /// <summary>
        /// Mapeador que trasforma el modelo de la tabla tb_articulo de la base de datos 
        /// al modelo ArticuloModeloDb que se utiliza en acceso a datos para pasar la informacion 
        /// a la capa logica.
        /// </summary>
        /// <param name="entrada"> Modelo de la tabla tb_articulo de la base que se va a transformar</param>
        /// <returns> Retorna un modelo ArticuloModeloDb</returns>
        public override ArticuloModeloDb mapearTipo1Tipo2(tb_articulo entrada)
        {
            return new ArticuloModeloDb()
            {
                Id = entrada.id,
                Id_bodega = entrada.id_bodega,
                Nombre = entrada.nombre,
                Descripcion = entrada.descripcion,
                Cantidad = entrada.cantidad,
                Precio = entrada.precio
            };
        }

        /// <summary>
        /// Mapeador que trasforma una lista de modelos tb_articulo de la base de datos 
        /// a una lista de modelos ArticuloModeloDb que se utiliza en acceso a datos para pasar la informacion 
        /// a la capa logica.
        /// </summary>
        /// <param name="entrada"> Lista de modelos de la tabla tb_articulo que se va a transformar</param>
        /// <returns> Retorna un lista de modelos ArticuloModeloDb</returns>
        public override IEnumerable<ArticuloModeloDb> mapearTipo1Tipo2(IEnumerable<tb_articulo> entrada)
        {
            foreach (var item in entrada)
            {
                yield return mapearTipo1Tipo2(item);
            }
        }

        /// <summary>
        /// Mapeador que trasforma el modelo ArticuloModeloDb que uliliza el acceso a datos
        /// a un modelo de la tabla tb_articulo de la base de datos que se utiliza para almacenar 
        /// un registro de tipo Articulo. 
        /// </summary>
        /// <param name="entrada"> Modelo ArticuloModeloDb que se va a trasformar</param>
        /// <returns> Retorna un modelo tb_articulo</returns>
        public override tb_articulo mapearTipo2Tipo1(ArticuloModeloDb entrada)
        {
            return new tb_articulo()
            {
                id = entrada.Id,
                id_bodega = entrada.Id_bodega,
                nombre = entrada.Nombre,
                descripcion = entrada.Descripcion,
                cantidad = entrada.Cantidad,
                precio = entrada.Precio
            };
        }

    }
}
