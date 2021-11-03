using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Ejercicio4.ViewModels 
{
    class MainPageVM : INotifyPropertyChanged
    {

        private clsPersona selectedPerson = new clsPersona();
        private ObservableCollection<clsPersona> personList;

        public event PropertyChangedEventHandler PropertyChanged;

        public clsPersona SelectedPerson
        {
            get
            {
                return selectedPerson;
            }

            set
            {
                selectedPerson = value;
                OnPropertyChanged("SelectedPerson");
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
            personList = clsListado.getListado();
        }


        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
