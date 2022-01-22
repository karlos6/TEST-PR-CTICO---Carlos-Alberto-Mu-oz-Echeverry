using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaInventarioMercancias.Mapeadores
{
    /// <summary>
    /// Clase abstracta de metodoa que trasforman modelos de de la capa de datos a modelos
    /// de la capa logica viceversa que se utiliza para pasar la informacion de la capa de vistas o para trasformar 
    /// la informacion en un modelo de la capa logica. 
    /// </summary>
    /// <typeparam name="Tipo1">Modelo que utiliza la capa de acceso a datos</typeparam>
    /// <typeparam name="Tipo2">Modelo que utiliza la capa de logica</typeparam>
    public abstract class MapeadorBaseLogica<Tipo1, Tipo2>
    {
        public abstract Tipo2 mapearTipo1Tipo2(Tipo1 entrada);
        public abstract IEnumerable<Tipo2> mapearTipo1Tipo2(IEnumerable<Tipo1> entrada);

        public abstract Tipo1 mapearTipo2Tipo1(Tipo2 entrada);
    }
}
