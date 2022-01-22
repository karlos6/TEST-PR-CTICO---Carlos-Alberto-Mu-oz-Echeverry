using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores
{
    /// <summary>
    ///  Clase abstracta de metodos que trasforman modelos de la capa de acceso a datos a 
    ///  modelos de la capa logica y viceversa que se utiliza para pasar la informacion a la capa logica 
    ///  o almacenar la informacion en la base de datos
    /// </summary>
    /// <typeparam name="Tipo1">Modelo que utiliza las tablas de la base de datos</typeparam>
    /// <typeparam name="Tipo2">Modelo que uliliza la capa de acceso a datos</typeparam>
    public abstract class MapeadorBaseDeDatos<Tipo1, Tipo2>
    {
        public abstract Tipo2 mapearTipo1Tipo2(Tipo1 entrada);
        public abstract IEnumerable<Tipo2> mapearTipo1Tipo2(IEnumerable<Tipo1> entrada);
        public abstract Tipo1 mapearTipo2Tipo1(Tipo2 entrada);

    }
}
