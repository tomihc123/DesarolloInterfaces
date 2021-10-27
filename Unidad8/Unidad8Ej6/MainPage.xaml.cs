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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Unidad8Ej6
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

        private void eliminarCampos()
        {
            Nombre.Text = "";
            Apellidos.Text = "";
            Fecha.Text = "";
            MensajeNombre.Text = "";
            MensajeApellido.Text = "";
            MensajeFecha.Text = "";
        }

        /// <summary>
        /// Evento asociado al boton anadir, al pulsar vaciara los campos
        /// <returns>void</returns>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void Anadir_Click(object sender, RoutedEventArgs e)
        {

            eliminarCampos();

        }

        /// <summary>
        /// Evento asociado al boton salvar, validara los campos de los formularios y pondra un mensaje de error en rojo en los que 
        /// lo que usuario haya introducido sea erroneo, si todos los campos son validos, pondra un mensaje en verde diciendo que se han guardado los datos y
        /// podra vacio todos los campos y sus posibles mensajes de errores.
        /// <returns>void</returns>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            bool esCorrecto = true;   

               if(string.IsNullOrEmpty(Nombre.Text))
                {
                    MensajeNombre.Text = "Nombre no puede estar vacio";
                    MensajeNombre.Foreground = new SolidColorBrush(Colors.Red);
                    esCorrecto = false;
                } else
                {
                    MensajeNombre.Text = "";
                }

               if(string.IsNullOrEmpty(Apellidos.Text))
                {
                    MensajeApellido.Text = "Apellido no puede estar vacio";
                    MensajeApellido.Foreground = new SolidColorBrush(Colors.Red);
                    esCorrecto = false;
            }
            else
                {
                    MensajeApellido.Text = "";
                }

               if(!Validaciones.validarFecha(Fecha.Text))
                {
                    MensajeFecha.Text = "La fecha debe ser valida";
                    MensajeFecha.Foreground = new SolidColorBrush(Colors.Red);
                    esCorrecto = false;
            }
            else
                {
                    MensajeFecha.Text = "";

                }


               if(esCorrecto)
            {
                MensajeResultado.Text = "Se ha guardado correctamente";
                MensajeResultado.Foreground = new SolidColorBrush(Colors.Green);
                eliminarCampos();

            }

            }
        

        /// <summary>
        /// Evento asociado al boton eliminar
        /// Al pulsar el boton, saltara un un dialogo para que el usuario confirme si desea elimianr realmente
        /// En casa de que desee eliminar, se pondran vacios los campos de los formularios y sus posibles mensajes de errores
        /// <returns>void</returns>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog deleteFileDialog = new ContentDialog
            {
                Title = "Delete file permanently?",
                Content = "If you delete this file, you won't be able to recover it. Do you want to delete it?",
                PrimaryButtonText = "Delete",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await deleteFileDialog.ShowAsync();

            // Delete the file if the user clicked the primary button.
            /// Otherwise, do nothing.
            if (result == ContentDialogResult.Primary)
            {
                MensajeResultado.Text = "Se ha eliminado";
                MensajeResultado.Foreground = new SolidColorBrush(Colors.Green);
                eliminarCampos();    

            }
 
        }
    }
}
