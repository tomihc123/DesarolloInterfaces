using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class clsListadoCitas
    {
        /// <summary>
        /// Funcion que simula la conexion a una base de datos, devolvera una lista con datos para probar
        /// </summary>
        /// <returns>
        /// ObservableCollections<clsCitas> listado de clsCitas
        /// </returns>
        public ObservableCollection<clsCita> getListado()
        {

            ObservableCollection<clsCita> list = new ObservableCollection<clsCita>();

            clsCita cita1 = new clsCita("Lunes", "28/10", "9:00", "c/ Urbano" ,41400, "Sevilla", 37.3826, -5.99629);
            clsCita cita2 = new clsCita("Martes", "31/11", "10:00", "c/Prado" ,41489, "Madrid", 40.4165, -3.70256);
            clsCita cita3 = new clsCita("Miercoles", "1/12", "11:00", "c/Akihabara", 34512, "Tokio", 35.6894, 139.692);
            clsCita cita4 = new clsCita("Jueves", "3/12", "12:00", "c/Lao Tse", 47500, "Pekin", 35.86166, 104.195397);
            clsCita cita5 = new clsCita("Viernes", "4/12", "13:00",  "c/Rasputin", 45600, "Mosku", 55.7508, 37.6172);
            

            list.Add(cita1);
            list.Add(cita2);
            list.Add(cita3);
            list.Add(cita4);
            list.Add(cita5);


            return list;


        }
    }
}