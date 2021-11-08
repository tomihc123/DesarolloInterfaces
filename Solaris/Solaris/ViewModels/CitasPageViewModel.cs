using Dal;
using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Solaris.ViewModels
{
    public class CitasPageViewModel : INotifyPropertyChanged
    {

        #region
        //Propiedades
        public event PropertyChangedEventHandler PropertyChanged;
        private clsCita citaSeleccionada = new clsCita();
        private ObservableCollection<clsCita> citaLista;
        #endregion


        /// <summary>
        /// Getters y setters de citaSeleccionada
        /// </summary>
        public clsCita CitaSeleccionada
        {

            get
            {
                return citaSeleccionada;
            }

            set
            {

                citaSeleccionada = value;
                OnPropertyChanged("CitaSeleccionada");

            }

        }

        /// <summary>
        /// Devuelve la lisa de citas para que la vista la bindee
        /// </summary>
        public ObservableCollection<clsCita> CitaLista
        {

            get
            {
                return citaLista;
            }

        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CitasPageViewModel()
        {
            clsListadoCitas clsListado = new clsListadoCitas();
            citaLista = clsListado.getListado();
        }

        /// <summary>
        /// Este metodo se invoca en el set de las propiedades para cuando haya cambiado el valor que lo notifique
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}