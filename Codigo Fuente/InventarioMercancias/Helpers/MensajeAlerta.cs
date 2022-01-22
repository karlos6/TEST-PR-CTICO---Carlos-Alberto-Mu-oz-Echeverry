using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioMercancias.Helpers
{
    /// <summary>
    /// Clase para controlar los mensajes
    /// </summary>
    public class MensajeAlerta
    {
        /// <summary>
        /// Metodo para mostrar un mensaje de error al usuario
        /// </summary>
        /// <param name="titulo">Titulo del mensaje</param>
        /// <param name="contenido">Contenido del mensaje</param>
        public void mensajeError(String titulo, String contenido)
        {
            MessageBox.Show(contenido, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        /// <summary>
        /// Metodo para mostrar un mensaje de informacion al ususario
        /// </summary>
        /// <param name="titulo">Titulo del mensaje</param>
        /// <param name="contenido">Contenido del mensaje</param>
        public void mensajeValidacion(String titulo, String contenido)
        {
            MessageBox.Show(contenido, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
