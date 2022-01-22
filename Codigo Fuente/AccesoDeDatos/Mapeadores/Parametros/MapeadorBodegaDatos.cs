using AccesoDeDatos.ModeloDB.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorBodegaDatos: MapeadorBaseDeDatos<tb_bodega,BodegaModeloDb>
    {
        /// <summary>
        /// Mapeador que trasforma el modelo de la tabla tb_bodega de la base de datos 
        /// al modelo BodegaModeloDb que se utiliza en acceso a datos para pasar la informacion 
        /// a la capa logica.
        /// </summary>
        /// <param name="entrada"> Modelo de la tabla tb_bodega de la base que se va a transformar</param>
        /// <returns> Retorna un modelo BodegaModeloDb</returns>
        public override BodegaModeloDb mapearTipo1Tipo2(tb_bodega entrada)
        {
            return new BodegaModeloDb()
            {
                Id = entrada.id,
                Nombre = entrada.nombre
            };
        }

        /// <summary>
        /// Mapeador que trasforma una lista de modelos tb_bodega de la base de datos 
        /// a una lista de modelos BodegaModeloDb que se utiliza en acceso a datos para pasar la informacion 
        /// a la capa logica.
        /// </summary>
        /// <param name="entrada"> Lista de modelos de la tabla tb_bodega que se va a transformar</param>
        /// <returns> Retorna un lista de modelos BodegaModeloDb</returns>
        public override IEnumerable<BodegaModeloDb> mapearTipo1Tipo2(IEnumerable<tb_bodega> entrada)
        {
            foreach (var item in entrada)
            {
                yield return mapearTipo1Tipo2(item);
            }
        }

        /// <summary>
        /// Mapeador que trasforma el modelo BodegaModeloDb que uliliza el acceso a datos
        /// a un modelo de la tabla tb_bodega de la base de datos que se utiliza para almacenar 
        /// un registro de bodega. 
        /// </summary>
        /// <param name="entrada"> Modelo BodegaModeloDb que se va a trasformar</param>
        /// <returns> Retorna un modelo tb_bodega</returns>
        public override tb_bodega mapearTipo2Tipo1(BodegaModeloDb entrada)
        {
            return new tb_bodega()
            {
                id = entrada.Id,
                nombre = entrada.Nombre
            };
        }
    }
}
