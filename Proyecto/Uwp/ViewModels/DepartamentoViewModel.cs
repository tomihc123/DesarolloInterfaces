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

        //La lista de departamentos
        private ObservableCollection<clsDepartament> listDeparments;
        //La lista cuando se filtra
        private ObservableCollection<clsDepartament> listDepartamentsFiltrada = new ObservableCollection<clsDepartament> { };
        //Lista de personas por departamento
        private ObservableCollection<clsPerson> listPersonByDepartament;


        //Departamento seleccionado
        private clsDepartament departamentSeleccionado;
        //Comandos
        private DelegateCommand deleteComand;
        private DelegateCommand searchComand;
        private DelegateCommand addComand;
        private DelegateCommand saveCommand;

        //Mensajes de error y texto para busqueda
        private String mensajeError;
        private String nombreBusqueda;

        #region Costructor
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
        #endregion


        #region Properties

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
                //En caso de que no sea null podemos buscar las personas de ese departamento
                if (departamentSeleccionado != null)
                {
                    listPersonByDepartament = new ObservableCollection<clsPerson>(new clsPersonListBL().getPersonsByDepartament(departamentSeleccionado.id));
                    NotifyPropertyChanged("PersonasPorDepartamento");
                }
                //Cada vez que seleccionamos se borra el mensaje anterior
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


        public DelegateCommand DeleteCommand
        {
            get
            {
                return deleteComand;
            }

        }

        #endregion




        #region Comandos


        /// <summary>
        /// Genera un departamento seleccionado con valores por defecto para que los campos  de texto se vacien
        /// </summary>
        private void addComand_execute()
        {
            //Quitamos si hay algun departamento seleccionado de la lista
            this.listDeparments = new ObservableCollection<clsDepartament>(new clsDepartamentListBL().getDepartaments());
            listDepartamentsFiltrada = new ObservableCollection<clsDepartament>(listDeparments);
            NotifyPropertyChanged("DepartamentsFiltrada");
            //Un nuevo departamento
            DepartamentSeleccionado = new clsDepartament();
            mensajeError = "";
            NotifyPropertyChanged("MensajeError");
        }

        /// <summary>
        /// Comprobar si se puede salvar el departamento seleccionada actual
        /// </summary>
        private void saveComand_execute()
        {

            ///Si se ha introducido algun nombre
            if (!String.IsNullOrEmpty(departamentSeleccionado.name))
            {
                ///Si la id es 0 quiere decir que la estamos insertando
                if (departamentSeleccionado.id == 0)
                {
                    new clsHandlerDepartamentBL().insertDepartament(departamentSeleccionado);

                }
                else
                {
                    ///Existe y es para editar
                    new clsHandlerDepartamentBL().updateDepartament(departamentSeleccionado);
                }

                ///Actualizamos la lista
                this.listDeparments = new ObservableCollection<clsDepartament>(new clsDepartamentListBL().getDepartaments());
                listDepartamentsFiltrada = new ObservableCollection<clsDepartament>(listDeparments);
                NotifyPropertyChanged("DepartamentsFiltrada");
                ///Seteamos los campos de texto
                departamentSeleccionado = new clsDepartament();
                NotifyPropertyChanged("DepartamentSeleccionado");
                ///Mnesajes de error vacios
                mensajeError = "";
                NotifyPropertyChanged("MensajeError");

            }
            else
            {
                ///No te ha dejado salvar y se pone un mensaje de error
                mensajeError = "Los campos no pueden estar vacios";
                NotifyPropertyChanged("MensajeError");
            }

        }

        /// <summary>
        /// Si se ha introducido algo en el campo de busqueda se puede filtrar
        /// Metodo para saber si se puede habilitar el comando search
        /// </summary>
        /// <returns>booleano para saber si se puede</returns>

        private bool searchComand_canExecute()
        {
            bool searchDepartament = true;

            if (String.IsNullOrEmpty(nombreBusqueda))
            {
                searchDepartament = false;
            }

            return searchDepartament;
        }

        /// <summary>
        /// Ejecuta el comando para buscar
        /// </summary>
        private void searchComand_execute()
        {
            bool encontrada = false;

            if (String.IsNullOrEmpty(nombreBusqueda))
            {
                ///Se muestran todos los departamentos
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

        /// <summary>
        /// Comando para eliminar el departamento seleccionado
        /// </summary>
        private async void deleteComand_execute()
        {
            bool seElimino = false;

            ContentDialog dialog = new ContentDialog()
            {
                Title = "Delete",
                Content = "Are you sure to delete selected departament?",
                PrimaryButtonText = "Yes",
                SecondaryButtonText = "No"

            };

            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                if(listPersonByDepartament.Count() == 0)
                {
                    ///Eliminamos
                    new clsHandlerDepartamentBL().deleteDepartament(DepartamentSeleccionado.id);
                    ///Actualizamos la lista
                    this.listDeparments = new ObservableCollection<clsDepartament>(new clsDepartamentListBL().getDepartaments());
                    this.listDepartamentsFiltrada = new ObservableCollection<clsDepartament>(listDeparments);
                    NotifyPropertyChanged("DepartamentsFiltrada");
                    seElimino = true;
                }


            }

            if(seElimino)
            {
                ///Mensajes de error vacios
                mensajeError = "";
                NotifyPropertyChanged("MensajeError");
            } else
            {
                mensajeError = "No se pudo eliminar porque hay personas en el departamento";
                NotifyPropertyChanged("MensajeError");
            }

        }

        /// <summary>
        /// Metodo para saber cuando se puede habilitar el comando delete
        /// </summary>
        /// <returns>booleano si se puede eliminar</returns>
        private bool deleteComand_canExecute()
        {
            bool departamentSelected = true;

            if (departamentSeleccionado == null)
            {

                departamentSelected = false;

            }
            else if (String.IsNullOrEmpty(departamentSeleccionado.name))
            {
                departamentSelected = false;

            }

            return departamentSelected;
        }
        #endregion
    }
}
