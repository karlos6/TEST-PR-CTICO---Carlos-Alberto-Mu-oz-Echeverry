using AccesoDeDatos.Mapeadores.Parametros;
using AccesoDeDatos.ModeloDB.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Implementacion.Parametros
{
    public class ImplArticuloDatos
    {
        /// <summary>
        /// Metodo de eliminar un registro por id de la tabla dt_articulo
        /// </summary>
        /// <param name="id">Id del registro que va a eliminar de la tabla dt_articulo</param>
        /// <returns>true cuando el registro fue eliminado, false cuando el registro no pudo ser eliminado o otra excepción</returns>
        public bool eliminarRegistro(int id)
        {
            try
            {
                using (InventarioMercanciasEntities bd = new InventarioMercanciasEntities())
                {

                    //Verificación de la existencia de un registro con el mismo id
                    tb_articulo registo = bd.tb_articulo.Find(id);
                    if (registo == null )
                    {
                        return false;
                    }
                    else
                    {
                        bd.tb_articulo.Remove(registo);
                        bd.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Metodo para listar Registros de la tabla dt_articulo
        /// </summary>
        /// <returns>retorna la lista de articulos</returns>
        public IEnumerable<ArticuloModeloDb> listarRegistros()
        {
            var lista = new List<ArticuloModeloDb>();

            //coneccion base de datos
            using (InventarioMercanciasEntities bd = new InventarioMercanciasEntities())
            {
                var listaDatos = (from c in bd.tb_articulo
                                  select c).OrderBy(m => m.id).ToList();
                lista = new MapeadorArticuloDatos().mapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;
        }

        public IEnumerable<ArticuloModeloDb> listarRegistrosArticulosEnBodega(int id)
        {
            var lista = new List<ArticuloModeloDb>();

            //coneccion base de datos
            using (InventarioMercanciasEntities bd = new InventarioMercanciasEntities())
            {
                var listaDatos = (from c in bd.tb_articulo
                                  where c.id_bodega.Equals(id)
                                  select c).OrderBy(m => m.id).ToList();
                lista = new MapeadorArticuloDatos().mapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;
        }

        /// <summary>
        /// Metodo para almacenar un registro tipo articulo
        /// </summary>
        /// <param name="registro">Modelo de tipo articulo de la base de datos que entra a ser almacenado</param>
        /// <returns>true cuando almacena, false cuando existe un registro o una excepción/returns>
        public bool GuardarRegistro(ArticuloModeloDb registro)
        {
            try
            {
                using (InventarioMercanciasEntities bd = new InventarioMercanciasEntities())
                {        
                    
                    MapeadorArticuloDatos mapeador = new MapeadorArticuloDatos();
                    var reg = mapeador.mapearTipo2Tipo1(registro);
                    bd.tb_articulo.Add(reg);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método para editar un registro en la tabla dt_articulo
        /// </summary>
        /// <param name="registro"> Modelo de tipo articulo de la base de datos que entra a ser aditado</param>
        /// <returns>true cuando almacena, false cuando existe un registro o una excepción</returns>
        public bool editarRegistro(ArticuloModeloDb registro)
        {
            try
            {
                using (InventarioMercanciasEntities bd = new InventarioMercanciasEntities())
                {     
                    MapeadorArticuloDatos mapeador = new MapeadorArticuloDatos();
                    var reg = mapeador.mapearTipo2Tipo1(registro);
                    bd.Entry(reg).State = EntityState.Modified;
                    bd.SaveChanges();
                    return true;                    
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método de búsqueda de un registro
        /// </summary>
        /// <param name="id">Id del registro a buscar</param>
        /// <returns>el objeto con id buscado o null cuando no exista</returns>
        public ArticuloModeloDb buscarArticulo(int id)
        {
            using (InventarioMercanciasEntities bd = new InventarioMercanciasEntities())
            {
                tb_articulo registro = bd.tb_articulo.Find(id);
                return new MapeadorArticuloDatos().mapearTipo1Tipo2(registro);
            }
        }

        public ArticuloModeloDb extraerArticuloEnBodega(ArticuloModeloDb articulo, int idBodega)
        {

            var ArticuloRetorno = new ArticuloModeloDb();

            using (InventarioMercanciasEntities bd = new InventarioMercanciasEntities())
            {
                var Articulo = (from c in bd.tb_articulo
                                where c.id_bodega.Equals(idBodega) & c.nombre.Equals(articulo.Nombre) &
                                      c.descripcion.Equals(articulo.Descripcion)  &
                                      c.precio.Equals(articulo.Precio)
                                select c).First();

                return new MapeadorArticuloDatos().mapearTipo1Tipo2(Articulo);
            }

        }

        public bool comprobarExistenciaArticuloEnBodega(ArticuloModeloDb articulo)
        {
            try
            {
                using (InventarioMercanciasEntities bd = new InventarioMercanciasEntities())
                {
                    //Verificación de la existencia de un registro con el mismo nombre
                    if (bd.tb_articulo.Where(x => x.id_bodega.Equals(articulo.Id_bodega) & 
                                                  x.nombre.Equals(articulo.Nombre) &
                                                  x.descripcion.Equals(articulo.Descripcion) & 
                                                  x.cantidad.Equals(articulo.Cantidad) &
                                                  x.precio.Equals(articulo.Precio)).Count() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool comprobarExistenciaArticuloConDiferenteCantidad(ArticuloModeloDb articulo, int idBodega)
        {
            try
            {
                using (InventarioMercanciasEntities bd = new InventarioMercanciasEntities())
                {
                    //Verificación de la existencia de un registro con el mismo nombre
                    if (bd.tb_articulo.Where(x => x.id_bodega.Equals(idBodega) &
                                                  x.nombre.Equals(articulo.Nombre) &
                                                  x.descripcion.Equals(articulo.Descripcion) &                                                  
                                                  x.precio.Equals(articulo.Precio)).Count() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
