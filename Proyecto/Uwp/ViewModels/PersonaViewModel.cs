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
    public class PersonaViewModel : clsVMBase
    {


        //Persona seleccionada
        public clsPerson selectedPerson;

        //La lista con las personas
        private ObservableCollection<clsPerson> personList;
        //La lista filtrada y que ofrecemos a la vista
        private ObservableCollection<clsPerson> personListFiltrada = new ObservableCollection<clsPerson> { };
        private ObservableCollection<clsDepartament> listDeparments = new ObservableCollection<clsDepartament>{ };

        //Comandos
        private DelegateCommand deleteComand;
        private DelegateCommand searchComand;
        private DelegateCommand addComand;
        private DelegateCommand saveCommand;

        //Mensajes de errores y texto para el nombre de busqueda
        private String mensajeError;
        private String nombreBusqueda;

        #region Constructor
        public PersonaViewModel()
        {
            this.personList = new ObservableCollection<clsPerson>(new clsPersonListBL().getPersons());
            this.listDeparments = new ObservableCollection<clsDepartament>(new clsDepartamentListBL().getDepartaments());
            this.deleteComand = new DelegateCommand(deleteComand_execute, deleteComand_canExecute);
            this.searchComand = new DelegateCommand(searchComand_execute, searchComand_canExecute);
            this.saveCommand = new DelegateCommand(saveComand_execute);
            this.addComand = new DelegateCommand(addComand_execute);
            this.personListFiltrada = new ObservableCollection<clsPerson>(personList);
            selectedPerson = new clsPerson();
        }

        #endregion


        #region Properties


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

        public ObservableCollection<clsPerson> PersonListFiltrada
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


        public ObservableCollection<clsDepartament> ListDepartaments
        {
            get
            {
                return listDeparments;
            }
        }

        public clsPerson SelectedPerson
        {
            get
            {
                return selectedPerson;
            }

            set
            {
                selectedPerson = value;
                NotifyPropertyChanged("SelectedPerson");
                deleteComand.RaiseCanExecuteChanged();
                saveCommand.RaiseCanExecuteChanged();
                mensajeError = "";
                NotifyPropertyChanged("MensajeError");

            }
        }

        public DelegateCommand DeleteComand
        {
            get
            {
                return deleteComand;
            }
        }


        public DelegateCommand SearchComand
        {
            get
            {
                return searchComand;
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

        #endregion






        #region Comand

        /// <summary>
        /// Comando para añadir una persona, genera una persona selecciona por defecto para poner los campos vacios
        /// </summary>
        private void addComand_execute()
        {
            //En caso de que haya alguna persona seleccionada en la lista la quita
            this.personList = new ObservableCollection<clsPerson>(new clsPersonListBL().getPersons());
            personListFiltrada = new ObservableCollection<clsPerson>(personList);
            NotifyPropertyChanged("PersonListFiltrada");
            selectedPerson = new clsPerson();
            NotifyPropertyChanged("SelectedPerson");
            mensajeError = "";
            NotifyPropertyChanged("MensajeError");
        }



        /// <summary>
        /// Comando para salvar siempre se puede ejecutar, si controlamos cuando se puede o no, no haria falta el mensaje de error
        /// </summary>
        private void saveComand_execute()
        {
            //Si todos los campos estan rellenos
            if (!String.IsNullOrEmpty(selectedPerson.name) && !String.IsNullOrEmpty(selectedPerson.lastName) && selectedPerson.birthDate != null && !String.IsNullOrEmpty(selectedPerson.phoneNumber) && !String.IsNullOrEmpty(selectedPerson.address))
            {
                //Si la id es 0 la persona se inserta
                if (selectedPerson.id == 0)
                {
                    new clsHandlerPersonBL().insertPerson(selectedPerson);

                }
                else
                {
                    //Se edita
                    new clsHandlerPersonBL().updatePerson(selectedPerson);
                }

                //Actualizamos la lista
                this.personList = new ObservableCollection<clsPerson>(new clsPersonListBL().getPersons());
                personListFiltrada = new ObservableCollection<clsPerson>(personList);
                NotifyPropertyChanged("PersonListFiltrada");
                //Borramos los mensajes
                mensajeError = "";
                NotifyPropertyChanged("MensajeError");
                selectedPerson = new clsPerson();
                NotifyPropertyChanged("SelectedPerson");

            }
            else
            {
                mensajeError = "Los campos no pueden estar vacios";
                NotifyPropertyChanged("MensajeError");
            }



        }

        /// <summary>
        /// Ejecuta el comando eliminar
        /// </summary>
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
                new clsHandlerPersonBL().deletePerson(SelectedPerson.id);
                this.personList = new ObservableCollection<clsPerson>(new clsPersonListBL().getPersons());
                personListFiltrada = new ObservableCollection<clsPerson>(personList);
                NotifyPropertyChanged("PersonListFiltrada");
            }

            selectedPerson = new clsPerson();
            NotifyPropertyChanged("SelectedPerson");
            mensajeError = "";
            NotifyPropertyChanged("MensajeError");
        }

        /// <summary>
        /// Metodo para saber cuando se puede ejecutar el comando eliminar
        /// </summary>
        /// <returns>booleano si se puede ejecutar el comando eliminar</returns>
        private bool deleteComand_canExecute()
        {
            bool personSelected = true;



            if (selectedPerson == null)
            {
                personSelected = false;
            }
            else if (String.IsNullOrEmpty(selectedPerson.name))
            {
                personSelected = false;
            }


            return personSelected;
        }

        /// <summary>
        /// Metodo para habilitar o deshabilitar el comando search
        /// </summary>
        /// <returns>booleano si se puede ejecutar o no</returns>
        private bool searchComand_canExecute()
        {
            bool searchPerson = true;

            if (String.IsNullOrEmpty(nombreBusqueda))
            {
                searchPerson = false;
            }

            return searchPerson;
        }

        /// <summary>
        /// Ejecuta el comando buscar
        /// </summary>
        private void searchComand_execute()
        {

            bool encontrada = false;

            if (String.IsNullOrEmpty(nombreBusqueda))
            {
                this.personListFiltrada = new ObservableCollection<clsPerson>(personList);
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

            selectedPerson = new clsPerson();
            NotifyPropertyChanged("SelectedPerson");

        }


        #endregion


    }
}
