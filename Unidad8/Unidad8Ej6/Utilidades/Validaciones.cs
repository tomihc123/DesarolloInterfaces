using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad8Ej6
{
    class Validaciones
    {

        /// <summary>
        /// Funcion para validar si una cadena es una fecha o no
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns>Devuelve un booleano para saber si es valida o no</returns>
        public static bool validarFecha(String fecha)
        {
            DateTime fec;

            return DateTime.TryParse(fecha, out fec);

        }

    }
}
