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


        public clsPerson selectedPerson;

        private ObservableCollection<clsPerson> personList;
        private ObservableCollection<clsPerson> personListFiltrada = new ObservableCollection<clsPerson> { };
        private ObservableCollection<clsDepartament> listDeparments = new ObservableCollection<clsDepartament>{ };

        private DelegateCommand deleteComand;
        private DelegateCommand searchComand;
        private DelegateCommand addComand;
        private DelegateCommand searchCommand;
        private DelegateCommand saveCommand;






        private String nombreBusqueda;

        public PersonaViewModel()
        {
            this.personList = new ObservableCollection<clsPerson>(new clsPersonListBL().getPersons());
            this.listDeparments = new ObservableCollection<clsDepartament>(new clsDepartamentListBL().getDepartaments());
            this.deleteComand = new DelegateCommand(deleteComand_execute, deleteComand_canExecute);
            this.searchComand = new DelegateCommand(searchComand_execute, searchComand_canExecute);
            this.saveCommand = new DelegateCommand(saveComand_execute, saveComand_canExecute);
            this.addComand = new DelegateCommand(addComand_execute);
            this.personListFiltrada = new ObservableCollection<clsPerson>(personList);
            SelectedPerson = new clsPerson();

        }



        private void addComand_execute()
        {
            selectedPerson = new clsPerson();
            personListFiltrada = new ObservableCollection<clsPerson>(new ObservableCollection<clsPerson>(new clsPersonListBL().getPersons()));
            selectedPerson = new clsPerson();
            NotifyPropertyChanged("PersonListFiltrada");
        }

        private bool saveComand_canExecute()
        {

            bool sePuede = false;

            if(selectedPerson != null)
            {
                if(selectedPerson.name != null)
                {
                    sePuede = true;
                }
                            
            }

            return sePuede;    
        }

        private void saveComand_execute()
        {
            if(selectedPerson.id == 0)
            {
                new clsHandlerPersonBL().insertPerson(selectedPerson);

            } else
            {
                new clsHandlerPersonBL().updatePerson(selectedPerson);
            }

            personListFiltrada = new ObservableCollection<clsPerson>(new ObservableCollection<clsPerson>(new clsPersonListBL().getPersons()));
            NotifyPropertyChanged("PersonListFiltrada");

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
                new clsHandlerPersonBL().deletePerson(SelectedPerson.id);
                personListFiltrada = new ObservableCollection<clsPerson>(new ObservableCollection<clsPerson>(new clsPersonListBL().getPersons()));
                NotifyPropertyChanged("PersonListFiltrada");
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

        }

        public void form_Changed(object sender, TextChangedEventArgs e)
        {
            saveCommand.RaiseCanExecuteChanged();
        }


    }
}
