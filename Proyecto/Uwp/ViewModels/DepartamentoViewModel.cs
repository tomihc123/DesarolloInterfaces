using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using BL.Handler;
using BL.Lists;
using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Uwp.ViewModels
{
    public class DepartamentoViewModel : clsVMBase
    {

        private ObservableCollection<clsDepartament> listDeparments;
        private ObservableCollection<clsDepartament> listDepartamentsFiltrada = new ObservableCollection<clsDepartament> { };
        private ObservableCollection<clsPerson> listPersonByDepartament;



        private clsDepartament departamentSeleccionado;

        private DelegateCommand deleteComand;
        private DelegateCommand searchComand;
        private DelegateCommand addComand;
        private DelegateCommand saveCommand;


        private String mensajeError;
        private String nombreBusqueda;

        public DepartamentoViewModel()
        {

            this.listDeparments = new ObservableCollection<clsDepartament>(new clsDepartamentListBL().getDepartaments());
            this.listDepartamentsFiltrada = new ObservableCollection<clsDepartament>(listDeparments);

            departamentSeleccionado = new clsDepartament();

            this.deleteComand = new DelegateCommand(deleteComand_execute, deleteComand_canExecute);
            this.searchComand = new DelegateCommand(searchComand_execute, searchComand_canExecute);
            this.saveCommand = new DelegateCommand(saveComand_execute);
            this.addComand = new DelegateCommand(addComand_execute);



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

        public ObservableCollection<clsDepartament> DepartamentsFiltrada
        {
            get
            {
                return listDepartamentsFiltrada;
            }

            set
            {
                listDepartamentsFiltrada = value;
                NotifyPropertyChanged("DepartamentsFiltrada");

            }

        }


        public ObservableCollection<clsPerson> PersonasPorDepartamento
        {
            get
            {
                return listPersonByDepartament;
            }

            set
            {
                listPersonByDepartament = value;
                NotifyPropertyChanged("PersonasPorDepartamento");

            }

        }

        public DelegateCommand AddComand
        {
            get
            {
                return addComand;
            }
        }


        public DelegateCommand SaveComand
        {
            get
            {
                return saveCommand;
            }
        }

        public clsDepartament DepartamentSeleccionado
        {

            get
            {
                return departamentSeleccionado;
            }

            set
            {
                departamentSeleccionado = value;
                NotifyPropertyChanged("DepartamentSeleccionado");
                deleteComand.RaiseCanExecuteChanged();
                saveCommand.RaiseCanExecuteChanged();
                if(departamentSeleccionado != null)
                {
                    listPersonByDepartament = new ObservableCollection<clsPerson>(new clsPersonListBL().getPersonsByDepartament(departamentSeleccionado.id));
                    NotifyPropertyChanged("PersonasPorDepartamento");
                }

                mensajeError = "";
                NotifyPropertyChanged("MensajeError");
            }

        }


        public String MensajeError
        {
            get
            {
                return mensajeError;
            }

            set
            {
                mensajeError = value;
                NotifyPropertyChanged("MensajeError");
            }

        }


        public DelegateCommand DeleteCommand
        {

            get {

                return deleteComand;
            }


        }

        private void addComand_execute()
        {
            this.listDeparments = new ObservableCollection<clsDepartament>(new clsDepartamentListBL().getDepartaments());
            listDepartamentsFiltrada = new ObservableCollection<clsDepartament>(listDeparments);
            NotifyPropertyChanged("DepartamentsFiltrada");
            DepartamentSeleccionado = new clsDepartament();
            mensajeError = "";
            NotifyPropertyChanged("MensajeError");
        }

        private void saveComand_execute()
        {


            if (!String.IsNullOrEmpty(departamentSeleccionado.name))
            {

                if (departamentSeleccionado.id == 0)
                {
                    new clsHandlerDepartamentBL().insertDepartament(departamentSeleccionado);

                }
                else
                {
                    new clsHandlerDepartamentBL().updateDepartament(departamentSeleccionado);
                }

                this.listDeparments = new ObservableCollection<clsDepartament>(new clsDepartamentListBL().getDepartaments());
                listDepartamentsFiltrada = new ObservableCollection<clsDepartament>(listDeparments);
                NotifyPropertyChanged("DepartamentsFiltrada");
                departamentSeleccionado = new clsDepartament();
                NotifyPropertyChanged("DepartamentSeleccionado");
                mensajeError = "";
                NotifyPropertyChanged("MensajeError");

            }
            else
            {
                mensajeError = "Los campos no pueden estar vacios";
                NotifyPropertyChanged("MensajeError");
            }

        }

        private bool searchComand_canExecute()
        {
            bool searchDepartament = true;

            if (String.IsNullOrEmpty(nombreBusqueda))
            {
                searchDepartament = false;
            }

            return searchDepartament;
        }

        private void searchComand_execute()
        {
            bool encontrada = false;

            if (String.IsNullOrEmpty(nombreBusqueda))
            {
                this.listDepartamentsFiltrada = new ObservableCollection<clsDepartament>(listDeparments);
                NotifyPropertyChanged("DepartamentsFiltrada");


            }
            else
            {

                listDepartamentsFiltrada.Clear();

                for (int i = 0; i < listDeparments.Count && !encontrada; i++)
                {
                    if (listDeparments[i].name.Contains(nombreBusqueda))
                    {
                        listDepartamentsFiltrada.Add(listDeparments[i]);
                    }

                }
            }

            departamentSeleccionado = new clsDepartament();
            NotifyPropertyChanged("SelectedPerson");
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
     
                    new clsHandlerDepartamentBL().deleteDepartament(DepartamentSeleccionado.id);
                    this.listDeparments = new ObservableCollection<clsDepartament>(new clsDepartamentListBL().getDepartaments());
                    this.listDepartamentsFiltrada = new ObservableCollection<clsDepartament>(listDeparments);
                    NotifyPropertyChanged("DepartamentsFiltrada");
   
            }

            departamentSeleccionado = new clsDepartament();
            NotifyPropertyChanged("DepartamentSeleccionado");
            mensajeError = "";
            NotifyPropertyChanged("MensajeError");
        }

        private bool deleteComand_canExecute()
        {
            bool departamentSelected = true;

            if(departamentSeleccionado != null)
            {

                if (String.IsNullOrEmpty(departamentSeleccionado.name))
                {
                    departamentSelected = false;
                }


            }


            return departamentSelected;
        }


    }
}
