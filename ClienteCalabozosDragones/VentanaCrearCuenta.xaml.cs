using ClienteCalabozosDragones.ServicioCalabozosDragones;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
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
    /// 
   
    public partial class VentanaCrearCuenta : Window
    {
      
        readonly SolidColorBrush ColorRojoClaro = Constantes.ColorRojoClaro;
        readonly SolidColorBrush colorAmarillo = Constantes.ColorAmarillo;
        
        public ObservableCollection<Foto> Items { get; set; }


        public VentanaCrearCuenta()
        {
            InitializeComponent();
            FotosListBox.ItemsSource = Constantes.CargarImagenes();
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
            try
            {
                var cuenta = new Cuenta()
                {
                    Apodo = TbApodo.Text,
                    Contrasena = PsContrasena.Password,
                    Correo = TbCorreo.Text,
                    Nombre = TbNombre.Text,
                    IdFoto = Constantes.ObtenerIdFotoSeleccionada(FotosListBox)
                };

                var cliente = new ServicioCalabozosDragones.GestionCuentaClient();

                var respuesta = cliente.AgregarCuenta(cuenta);

                if (respuesta == "correoRepetido")
                {
                    Constantes.MostrarVentanaEmergente("Ya esta registrado el correo, porfavor ingresa otro", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (respuesta == "apodoRepetido")
                {
                    Constantes.MostrarVentanaEmergente("Ya esta registrado el apodo, porfavor ingresa otro", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                else if (respuesta == "guardadoExito")
                {
                    Constantes.MostrarVentanaEmergente("Cuenta registrada exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch(InvalidOperationException ex)
            {
                Constantes.MostrarVentanaEmergente("Porfavor selecciona una foto de perfil.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                Console.WriteLine(ex);
            }
            
                
            
        }


    }
}
