using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class clsListadoPersonas

    {

        public ObservableCollection<clsPersona> PersonList()
        {

            ObservableCollection<clsPersona> list = new ObservableCollection<clsPersona>();


            clsPersona person1 = new clsPersona("John Jr", "Doe", "05/01/2000", 654324121, "Calle Maria Pinta 22");
            clsPersona person2 = new clsPersona("Mary", "Doe", "04/02/2003", 765431211, "Calle Maria Pinta 22");
            clsPersona person3 = new clsPersona("Peter", "Doe", "12/09/1998", 685431411, "Calle Maria Pinta 22");
            clsPersona person4 = new clsPersona("Elizabeth", "Smith", "21/11/1972", 601431221, "Calle Maria Pinta 22");
            clsPersona person5 = new clsPersona("John", "Doe", "29/09/1970", 611431231, "Calle Maria Pinta 22");

            list.Add(person1);
            list.Add(person2);
            list.Add(person3);
            list.Add(person4);
            list.Add(person5);

            return list;

        }


    }
}
