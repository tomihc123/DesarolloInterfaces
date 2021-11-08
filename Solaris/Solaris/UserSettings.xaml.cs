using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Solaris
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class UserSettings : Page
    {
        public UserSettings()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Evento asociado al boton de de confirmar cambios cuando el usuario edita sus datos, en caso de que algun campo este vacio
        /// o las contraseñas no coincidan mostrare un mensaje de erorr dependiendo de cada caso
        /// Si todo esta correcto mostrara un mensaje de color verde diciendo que se han guardado los cambios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {


            String mensajeErrorCamposVacios = "Ningun campo  puede estar vacio";
            String contrasenaNoCoinciden = "Las contraseñas deben coincidir";


            if (String.IsNullOrWhiteSpace(tbxPassword.Password) || String.IsNullOrEmpty(tbxUsername.Text) || String.IsNullOrEmpty(tbxConfirmPassword.Password))
            {
                txtMensaje.Text = mensajeErrorCamposVacios;
            } else if (tbxPassword.Password != tbxConfirmPassword.Password)
            {
                txtMensaje.Text = contrasenaNoCoinciden;

            }
            else
            {
                txtMensaje.Foreground = new SolidColorBrush(Colors.Green); ;

                txtMensaje.Text = "Los cambios se han guardado";

            }


        }

        /// <summary>
        /// Evento asociado al boton Citas, en caso de que el usuario pulse, le llavara a la pagina de citas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

           // Frame.Navigate(typeof(PageCitas), "¿Que tal?"); Da un error asi que lo dejaremos comentado


        }
    }
}
