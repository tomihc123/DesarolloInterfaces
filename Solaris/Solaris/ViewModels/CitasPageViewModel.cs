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

        public event PropertyChangedEventHandler PropertyChanged;
        private clsCita citaSeleccionada = new clsCita();
        private ObservableCollection<clsCita> citaLista;




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


        public ObservableCollection<clsCita> CitaLista
        {

            get
            {
                return citaLista;
            }

        }

        public CitasPageViewModel()
        {
            clsListadoCitas clsListado = new clsListadoCitas();
            citaLista = clsListado.getListado();
        }


        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}