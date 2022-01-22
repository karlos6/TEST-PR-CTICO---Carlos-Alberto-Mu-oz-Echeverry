using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioMercancias.Mapeadores
{
    /// <summary>
    /// Clase abstracta de metodoa que trasforman modelos de la capa de vista a 
    /// a modelos que utiliza la capa logica y viceversa que se utiliza para pasar la informacion 
    /// de la capa de vista a un modelo de la capa logica. 
    /// </summary>
    /// <typeparam name="Tipo1">Modelo que utiliza la capa logica</typeparam>
    /// <typeparam name="Tipo2">Modelo que utiliza la capa de vista</typeparam>
    public abstract class MapeadorBaseVista<Tipo1, Tipo2>
    {
        public abstract Tipo2 mapearTipo1Tipo2(Tipo1 entrada);
        public abstract IEnumerable<Tipo2> mapearTipo1Tipo2(IEnumerable<Tipo1> entrada);

        public abstract Tipo1 mapearTipo2Tipo1(Tipo2 entrada);
    }
}
