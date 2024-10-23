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
using System.Windows.Shapes;

namespace ClienteCalabozosDragones
{
    /// <summary>
    /// Lógica de interacción para VentanaCrearCuenta.xaml
    /// </summary>
    public partial class VentanaCrearCuenta : Window
    {
      
        readonly SolidColorBrush ColorRojoClaro = Constantes.ColorRojoClaro;
        readonly SolidColorBrush colorAmarillo = Constantes.ColorAmarillo;

        public VentanaCrearCuenta()
        {
            InitializeComponent();
        }

        private void TbNombre_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TbNombre.Text == "Giovanni")
            {
                TbNombre.Text = "";
                TbNombre.Foreground = colorAmarillo;
            }
        }

        private void TbNombre_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbNombre.Text))
            {
                TbNombre.Text = "Giovanni";
                TbNombre.Foreground = ColorRojoClaro;
            }
        }

        private void TbCorreo_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TbCorreo.Text == "gioviss2308@gmail.com")
            {
                TbCorreo.Text = "";
                TbCorreo.Foreground = colorAmarillo;
            }
        }

        private void TbCorreo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbCorreo.Text))
            {
                TbCorreo.Text = "gioviss2308@gmail.com";
                TbCorreo.Foreground = ColorRojoClaro;
            }
        }

        private void PsContrasena_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PsContrasena.Password == "*******")
            {
                PsContrasena.Password = "";
                PsContrasena.Foreground = colorAmarillo;
            }
        }

        private void PsContrasena_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PsContrasena.Password))
            {
                PsContrasena.Password= "*******";
                PsContrasena.Foreground= ColorRojoClaro;
            }
        }

        private void TbApodo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbApodo.Text))
            {
                TbApodo.Text = "GioMN";
                TbApodo.Foreground = ColorRojoClaro;
            }
        }

        private void TbApodo_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TbApodo.Text == "GioMN")
            {
                TbApodo.Text = "";
                TbApodo.Foreground = colorAmarillo;
            }
        }

       

        private void TbIniciarSesionClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void BtnCrearCuentaClick(object sender, RoutedEventArgs e)
        {
            var cuenta = new Cuenta()
            {
                Apodo = TbApodo.Text.ToString(),
                Contrasena = PsContrasena.Password.ToString(),
                Correo = TbCorreo.Text.ToString(),
                Nombre = TbNombre.Text.ToString(),
            };

            ServicioCalabozosDragones.GestionCuentaClient cliente = new ServicioCalabozosDragones.GestionCuentaClient();
            if (cliente.AgregarCuenta(cuenta))
            {
                Constantes.MostrarVentanaEmergente("Cuenta agregada exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Constantes.MostrarVentanaEmergente("No se pudo agregar la cuenta.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
