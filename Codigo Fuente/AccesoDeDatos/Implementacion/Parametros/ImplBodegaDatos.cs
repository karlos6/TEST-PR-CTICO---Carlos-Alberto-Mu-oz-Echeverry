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
    public class ImplBodegaDatos
    {

        /// <summary>
        /// Metodo de eliminar un registro por id de la tabla bodega
        /// </summary>
        /// <param name="id">Id del registro que va a eliminar de la tabla bodega</param>
        /// <returns>true cuando el registro fue eliminado, false cuando el registro no pudo ser eliminado o otra excepción</returns>
        public bool eliminarRegistro(int id)
        {
            try
            {
                using (InventarioMercanciasEntities bd = new InventarioMercanciasEntities())
                {

                    //Verificación de la existencia de un registro con el mismo id
                    tb_bodega registo = bd.tb_bodega.Find(id);
                    if (registo == null || registo.tb_articulo.Count() > 0)
                    {
                        return false;
                    }
                    else
                    {
                        bd.tb_bodega.Remove(registo);
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
        /// Metodo para listar Registros de la bodega
        /// </summary>
        /// <returns>retorna la lista de bodegas</returns>
        public IEnumerable<BodegaModeloDb> listarRegistros()
        {
            var lista = new List<BodegaModeloDb>();

            //coneccion base de datos
            using (InventarioMercanciasEntities bd = new InventarioMercanciasEntities())
            {
                var listaDatos = (from c in bd.tb_bodega
                                  select c).OrderBy(m => m.id).ToList();
                lista = new MapeadorBodegaDatos().mapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;
        }

        public IEnumerable<BodegaModeloDb> listarRegistrosBodegasDiferentes(int id)
        {
            var lista = new List<BodegaModeloDb>();

            //coneccion base de datos
            using (InventarioMercanciasEntities bd = new InventarioMercanciasEntities())
            {
                var listaDatos = (from c in bd.tb_bodega
                                  where c.id != id
                                  select c).OrderBy(m => m.id).ToList();
                lista = new MapeadorBodegaDatos().mapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;
        }

        /// <summary>
        /// Metodo para almacenar un registro tipo bodega
        /// </summary>
        /// <param name="registro">Modelo de tipo bodega de la base de datos que entra a ser almacenado</param>
        /// <returns>true cuando almacena, false cuando existe un registro o una excepción/returns>
        public bool GuardarRegistro(BodegaModeloDb registro)
        {
            try
            {
                using (InventarioMercanciasEntities bd = new InventarioMercanciasEntities())
                {
                    //Verificación de la existencia de un registro con el mismo nombre
                    if (bd.tb_bodega.Where(x => x.nombre.ToLower().Equals(registro.Nombre.ToLower())).Count() > 0)
                    {
                        return false;
                    }
                    else
                    {
                        MapeadorBodegaDatos mapeador = new MapeadorBodegaDatos();
                        var reg = mapeador.mapearTipo2Tipo1(registro);
                        bd.tb_bodega.Add(reg);
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
        /// Método para editar un registro en la tabla bodega
        /// </summary>
        /// <param name="registro"> Modelo de tipo bodega de la base de datos que entra a ser aditado</param>
        /// <returns>true cuando almacena, false cuando existe un registro o una excepción</returns>
        public bool editarRegistro(BodegaModeloDb registro)
        {
            try
            {
                using (InventarioMercanciasEntities bd = new InventarioMercanciasEntities())
                {
                    //Verificación de la existencia de un registro con el mismo id
                    if (bd.tb_bodega.Where(x => x.nombre.ToLower().Equals(registro.Nombre.ToLower())).Count() > 0)
                    {
                        return false;
                    }
                    else
                    {
                        MapeadorBodegaDatos mapeador = new MapeadorBodegaDatos();
                        var reg = mapeador.mapearTipo2Tipo1(registro);
                        bd.Entry(reg).State = EntityState.Modified;
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

    }
}
