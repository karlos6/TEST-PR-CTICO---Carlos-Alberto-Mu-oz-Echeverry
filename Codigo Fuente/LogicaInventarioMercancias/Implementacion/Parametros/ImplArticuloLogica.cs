using AccesoDeDatos.Implementacion.Parametros;
using AccesoDeDatos.ModeloDB.Parametros;
using LogicaInventarioMercancias.Mapeadores.Parametros;
using LogicaInventarioMercancias.ModeloLogica.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaInventarioMercancias.Implementacion.Parametros
{
    public class ImplArticuloLogica
    {
        /// Variable privada para acceder a la capa de acceso a datos
        private ImplArticuloDatos accesoDatos;

        public ImplArticuloLogica()
        {
            this.accesoDatos = new ImplArticuloDatos();
        }

        /// <summary>
        /// Metodo para extraer la lista de modelos del acceso a datos y 
        /// convertirlos en una lista de modelos ArticuloModeloLogica que se utilizan 
        /// en la capa logica.
        /// </summary>
        /// <returns>retorna una lista de modelos ArticuloModeloLogica</returns>
        public IEnumerable<ArticuloModeloLogica> listarRegistros()
        {
            var listado = this.accesoDatos.listarRegistros();
            MapeadorArticuloLogica mapeador = new MapeadorArticuloLogica();
            return mapeador.mapearTipo1Tipo2(listado);
        }

        /// <summary>
        /// Metodo que retorna una lista de articulos de una bodega especificada a la vista para ser visualizados
        /// por el usuario
        /// </summary>
        /// <param name="id"> id de la bodega a la cual se le van a extraer los articulos</param>
        /// <returns>Retorna una lista de articulos de a la vista</returns>
        public IEnumerable<ArticuloModeloLogica> listarRegistrosArticulosEnBodega(int id)
        {
            var listado = this.accesoDatos.listarRegistrosArticulosEnBodega(id);
            MapeadorArticuloLogica mapeador = new MapeadorArticuloLogica();
            return mapeador.mapearTipo1Tipo2(listado);
        }

        /// <summary>
        /// Metodo para eliminar un registro el cual recibe un id que proviene de la capa de vista y la capa envia  
        /// a la capa de acceso a datos para eliminar el registro. 
        /// </summary>
        /// <param name="id">id del registro que se desea eliminar</param>
        /// <returns>retorna verdadero si se elimino el registro y falso si no se pudo eliminar</returns>
        public Boolean eliminarRegistro(int id)
        {
            Boolean res = this.accesoDatos.eliminarRegistro(id);
            return res;
        }

        /// <summary>
        /// Metodo para editar la informacion de un registro.
        /// recibe un modelo ArticuloModeloLogica que uliza la capa logica y lo trasforma en un modelo de 
        /// acceso a datos para poder ser enviado a la capa y actualizar el registro.
        /// </summary>
        /// <param name="registro"> modelo de tipo ArticuloModeloLogica que se va a trasformar
        ///                         en un modelo de acceso a datos
        /// </param>
        /// <returns>retorna verdadero si el registro fue actualizado o falso si ocurrio alguna excepción </returns>
        public Boolean editarRegistro(ArticuloModeloLogica registro)
        {
            MapeadorArticuloLogica mapeador = new MapeadorArticuloLogica();
            ArticuloModeloDb reg = mapeador.mapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.editarRegistro(reg);
            return res;
        }

        /// <summary>
        /// Metodo para almacenar un registro 
        /// recibe un modelo ArticuloModeloLogica que uliza la capa logica y lo trasforma en un modelo de 
        /// acceso a datos para poder ser enviado a la capa Y almacenar el registro.
        /// </summary>
        /// <param name="registro"></param>
        /// <returns></returns>
        public Boolean guardarRegistro(ArticuloModeloLogica registro)
        {
            MapeadorArticuloLogica mapeador = new MapeadorArticuloLogica();
            ArticuloModeloDb reg = mapeador.mapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        /// <summary>
        /// Metodo para enviar un articulo a otra bodega.
        /// Recibe un id para buscarlo y actualizarlo en la bodega actual, un id de la bodega
        /// para extraer el articulo si existe en una bodega diferente y actualizar su cantidad,
        /// si no existe crea el articulo en la bodega de destino, tambien se tiene un cantidad de 
        /// articulos a trasferir para restar o sumar la cantidad de articulos.
        /// </summary>
        /// <param name="idArticulo">Id del articulo</param>
        /// <param name="idBodegaDestino">Id de la bodega de destino</param>
        /// <param name="cantidadArticuloTrasferir">Cantidad de articulos a trasferir</param>
        public void trasferenciaArticulo(int idArticulo, int idBodegaDestino , int cantidadArticuloTrasferir)
        {
            ArticuloModeloLogica articuloBuscado = this.buscarArticulo(idArticulo);            
            articuloBuscado.Cantidad = articuloBuscado.Cantidad - cantidadArticuloTrasferir;
            this.editarRegistro(articuloBuscado);

            //Comprueba si el articulo existe o no en la bodega que se desea trasferir, si no existe lo crea.
            if (this.comprobarExistenciaArticuloConDiferenteCantidad(articuloBuscado, idBodegaDestino))
            {
                
                ArticuloModeloLogica articuloExtraio = this.extraerArticuloEnBodega(articuloBuscado, idBodegaDestino);
                articuloExtraio.Cantidad = articuloExtraio.Cantidad + cantidadArticuloTrasferir;
                articuloExtraio.Id_bodega = idBodegaDestino;
                this.editarRegistro(articuloExtraio);
            }
            else 
            {
                articuloBuscado.Cantidad = cantidadArticuloTrasferir;
                articuloBuscado.Id_bodega = idBodegaDestino;
                this.guardarRegistro(articuloBuscado);
            }            
        }

        /// <summary>
        /// Metodo para buscar y traer un articulo de la base de datos.
        /// </summary>
        /// <param name="id">id del articulo que se desea extraer</param>
        /// <returns></returns>
        public ArticuloModeloLogica buscarArticulo(int id)
        {
            var registro = this.accesoDatos.buscarArticulo(id);
            MapeadorArticuloLogica mapeador = new MapeadorArticuloLogica();
            return mapeador.mapearTipo1Tipo2(registro);
        }

        /// <summary>
        /// Metodo que comprueba que el articulo exista en bodega.
        /// </summary>
        /// <param name="modeloArticuloLogica">Modelo del articulo de la capa logica</param>
        /// <returns></returns>
        public bool comprobarExistenciaArticuloEnBodega(ArticuloModeloLogica modeloArticuloLogica) 
        { 
            MapeadorArticuloLogica mapeador = new MapeadorArticuloLogica();            
            ArticuloModeloDb reg = mapeador.mapearTipo2Tipo1(modeloArticuloLogica);
            bool registro = this.accesoDatos.comprobarExistenciaArticuloEnBodega(reg);           
            return registro;           
        }

        /// <summary>
        /// Metodo que comprueba que el que el modelo envidado exista sin tomar en cuenta 
        /// la cantidad, para asi poder actulizarlo y no crear articulos repetidos con 
        /// diferente cantidad.
        /// </summary>
        /// <param name="modeloArticuloLogica">Modelo para comprobar su existencia en diferente bodega</param>
        /// <param name="idBodega">id de la bodega para comprobar si existe</param>
        /// <returns></returns>
        public bool comprobarExistenciaArticuloConDiferenteCantidad(ArticuloModeloLogica modeloArticuloLogica, int idBodega)
        {
            MapeadorArticuloLogica mapeador = new MapeadorArticuloLogica();
            ArticuloModeloDb reg = mapeador.mapearTipo2Tipo1(modeloArticuloLogica);
            bool registro = this.accesoDatos.comprobarExistenciaArticuloConDiferenteCantidad(reg, idBodega);
            return registro;
        }

        /// <summary>
        /// Metodo para actraer un articulo de una bodega especifica.
        /// </summary>
        /// <param name="articulo">Modelo del articulo</param>
        /// <param name="idBodega"> id de la bodega la cual se desea extraer</param>
        /// <returns></returns>
        public ArticuloModeloLogica extraerArticuloEnBodega(ArticuloModeloLogica articulo, int idBodega)
        {
            MapeadorArticuloLogica mapeador = new MapeadorArticuloLogica();
            ArticuloModeloDb reg = mapeador.mapearTipo2Tipo1(articulo);
            ArticuloModeloDb registro = this.accesoDatos.extraerArticuloEnBodega(reg, idBodega);
            return mapeador.mapearTipo1Tipo2(registro);
        }
    }
}
