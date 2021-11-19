using Dal;
using Ejercicio1.ViewModels.Uitls;
using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Ejercicio1.ViewModels
{
    public class MainPageVM : clsVMBase
    {

        public clsPersona selectedPerson;
        private ObservableCollection<clsPersona> personList;
        private ObservableCollection<clsPersona> personListFiltrada = new ObservableCollection<clsPersona> { }; 
        private DelegateCommands deleteComand;
        private DelegateCommands searchComand;
        private String nombreBusqueda;

        public MainPageVM()
        {
            this.personList = new clsListadoPersonas().PersonList();
            this.deleteComand = new DelegateCommands(deleteComand_execute, deleteComand_canExecute);
            this.searchComand = new DelegateCommands(searchComand_execute, searchComand_canExecute);
            this.personListFiltrada = new ObservableCollection<clsPersona>(personList);
        }


        public DelegateCommands DeleteComand
        {

            get
            {
                return deleteComand;
            }

        }


       public DelegateCommands SearchComand
        {

            get
            {
                return searchComand;
            }

        } 


        public String NombreBusqueda
        {

            get
            {
                return nombreBusqueda;
                
            }


            set
            {
                nombreBusqueda = value;
                searchComand.RaiseCanExecuteChanged();
                searchComand_execute();

            }


        }

        public ObservableCollection<clsPersona> PersonListFiltrada
        {
            get
            {
                return personListFiltrada;
            }

            set
            {
                personListFiltrada = value;

            }

        }


        public clsPersona SelectedPerson
        {
            get
            {
                return selectedPerson;
            }

            set
            {
                selectedPerson = value;
                deleteComand.RaiseCanExecuteChanged();
            }
        }



        private async void deleteComand_execute()
        {

            ContentDialog dialog = new ContentDialog()
            {
                Title = "Delete",
                Content = "Are you sure to delete selected person?",
                PrimaryButtonText = "Yes",
                SecondaryButtonText = "No"

            };

            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                personList.Remove(SelectedPerson);
                personListFiltrada.Remove(SelectedPerson);
            }


        }

        private bool deleteComand_canExecute()
        {
            bool personSelected = true;

            if (selectedPerson == null)
            {
                personSelected = false;
            }

            return personSelected;
        }


        private bool searchComand_canExecute()
        {
            bool searchPerson = true;

            if (String.IsNullOrEmpty(nombreBusqueda))
            {
                searchPerson = false;
            }

            return searchPerson;
        }

        private void searchComand_execute()
        {

            bool encontrada = false;
            
            if (String.IsNullOrEmpty(nombreBusqueda))
            {
                this.personListFiltrada = new ObservableCollection<clsPersona>(personList);
                NotifyPropertyChanged("PersonListFiltrada");


            }
            else
            {

                personListFiltrada.Clear();

                for (int i = 0; i < personList.Count && !encontrada; i++)
                {
                    if (personList[i].name.Contains(nombreBusqueda) || personList[i].lastName.Contains(nombreBusqueda))
                    {
                        personListFiltrada.Add(personList[i]);
                    }

                }
            }

        }

    }
}
