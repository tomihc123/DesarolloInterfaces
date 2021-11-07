﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Solaris
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Evento asociado al boton login, comprueba que tanto el username como la contraseña  no estan vacios y si no lo estan te redirecciona a la pagina de citas
        /// En caso de que alguno de estos campos este vacio te muestra un mensaje de error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            String mensajeError = "Ningun campo  puede estar vacio";

            if (String.IsNullOrWhiteSpace(tbxPassword.Password) || String.IsNullOrEmpty(tbxUsername.Text))
            {
                txtErrorUser.Text = mensajeError;
            }
            else
            {
                Frame.Navigate(typeof(PageCitas), tbxUsername.Text);
            }


        }
    }
}
