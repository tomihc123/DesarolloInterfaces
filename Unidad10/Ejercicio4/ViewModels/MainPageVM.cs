using Ejercicio4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.ViewModels 
{
    class MainPageVM
    {

        private clsPersona selectedPerson = new clsPersona();
        private ObservableCollection<clsPersona> personList;


        public clsPersona SelectedPerson
        {
            get
            {
                return selectedPerson;
            }

            set
            {
                selectedPerson = value;
               
            }

        }




        public ObservableCollection<clsPersona> PersonList
        {

            get
            {
                return personList;
            }

        }


       public MainPageVM()
        {
            clsListado clsListado = new clsListado();
            this.personList = clsListado.getListado();
        }

    }
}
