using ClienteCalabozosDragones.ServicioCalabozosDragones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClienteCalabozosDragones
{
    /// <summary>
    /// Lógica de interacción para VentanaInicioSesion.xaml
    /// </summary>
    public partial class VentanaInicioSesion : Window

    {
        
        readonly SolidColorBrush colorAmarillo = Constantes.ColorAmarillo;
        readonly SolidColorBrush colorRojo = Constantes.ColorRojo;
        public VentanaInicioSesion()
        {
             InitializeComponent();
        }

        private void TbCorreo_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TbCorreo.Text == "Ingresa tu correo")
            {
                TbCorreo.Text = "";
                TbCorreo.Foreground = colorAmarillo;
            }
        }

        private void TbCorreo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbCorreo.Text))
            {
                
                TbCorreo.Text = "Ingresa tu correo";
                TbCorreo.Foreground = colorRojo;
            }
        }


        private void PsContrasena_GotFocus(object sender, RoutedEventArgs e)
        {
            TbContrasena.Visibility = Visibility.Collapsed;
        }

        private void PsContrasena_LostFocus(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(PsContrasena.Password))
                {
                TbContrasena.Visibility = Visibility.Visible;
                }
           
        }

        private void BtnIniciarSesionClick(object sender, RoutedEventArgs e)
        {
            var cuenta = new Cuenta()
            {
                Correo = TbCorreo.Text.ToString(),
                Contrasena = PsContrasena.Password.ToString(),
            };
            ServicioCalabozosDragones.GestionCuentaClient cliente = new ServicioCalabozosDragones.GestionCuentaClient();


            if (cliente.VerificarInicioSesion(cuenta))
            {
                VentanaInicio ventanaInicio = new VentanaInicio();
                ventanaInicio.Show();
                this.Close();
            }
            else
            {
                Constantes.MostrarVentanaEmergente("No existe una cuenta con las credenciales, verifica tu correo y contraseña.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        private void TbCrearCuentaClick(object sender, MouseButtonEventArgs e)
        {
           VentanaCrearCuenta ventanaCrearCuenta = new VentanaCrearCuenta();
            ventanaCrearCuenta.ShowDialog();
        }

        private void BtnIniciarSesionInvitadoClick(object sender, RoutedEventArgs e)
        {
            //TODO
        }

       

        
    }
}
