using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.Models
{
    class clsListado
    {

        public ObservableCollection<clsPersona> getListado()
        {

            ObservableCollection<clsPersona> list = new ObservableCollection<clsPersona>();

            clsPersona person1 = new clsPersona("Tomas", "Turbado", "05/01/2010", 423522344, "Besa Melano 1");
            clsPersona person2 = new clsPersona("Fernando", "Galiana", "05/01/2010", 99999999, "Besa Melano 2");
            clsPersona person3 = new clsPersona("Killua", "Zoldyck", "05/01/2010", 888888888, "Besa Melano 3");
            clsPersona person4 = new clsPersona("Sigma", "Walther", "05/01/2010", 777777777, "Besa Melano 4");
            clsPersona person5 = new clsPersona("Boom", "Shacalaca", "05/01/2010", 7777777, "Besa Melano 5");


            list.Add(person1);
            list.Add(person2);
            list.Add(person3);
            list.Add(person4);
            list.Add(person5);


            return list;


        }

    }
}
