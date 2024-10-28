using ClienteCalabozosDragones.ServicioCalabozosDragones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
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
    /// Lógica de interacción para VentanaModificarCuenta.xaml
    /// </summary>
    public partial class VentanaModificarCuenta : Window
    {
        private readonly SolidColorBrush ColorRojoClaro = Constantes.ColorRojoClaro;
        private readonly SolidColorBrush colorAmarillo = Constantes.ColorAmarillo;
        public delegate void CuentaModificadaEventHandler(Cuenta cuentaModificada);
        public event CuentaModificadaEventHandler CuentaModificada;

        private Cuenta cuenta;
        public VentanaModificarCuenta(Cuenta cuenta)
        {
            InitializeComponent();
            FotosListBox.ItemsSource = Constantes.CargarImagenes();
            this.cuenta = cuenta;
        }

        private void TbNombre_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TbNombre.Text == cuenta.Nombre)
            {
                TbNombre.Text = "";
                TbNombre.Foreground = colorAmarillo;
            }
        }

        private void TbNombre_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbNombre.Text))
            {
                TbNombre.Text = cuenta.Nombre;
                TbNombre.Foreground = ColorRojoClaro;
            }
        }

        
        private void TbApodo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbApodo.Text))
            {
                TbApodo.Text = cuenta.Apodo;
                TbApodo.Foreground = ColorRojoClaro;
            }
        }

        private void TbApodo_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TbApodo.Text == cuenta.Apodo)
            {
                TbApodo.Text = "";
                TbApodo.Foreground = colorAmarillo;
            }
        }

        private void BtnGuardarCambiosClick(object sender, RoutedEventArgs e)
        {
            var cuentaModificacion = new Cuenta
            {
                Nombre = TbNombre.Text.ToString(),
                Apodo = TbApodo.Text.ToString(),
                IdFoto = Constantes.ObtenerIdFotoSeleccionada(FotosListBox)
            };

            var cliente = new ServicioCalabozosDragones.GestionCuentaClient();
            string respuesta = cliente.ModificarCuenta(cuentaModificacion, cuenta);

            if(respuesta == "cambiosGuardados")
            {
                Constantes.MostrarVentanaEmergente("Se han realizado los cambios exitosamente", "Confirmación", MessageBoxButton.OK, MessageBoxImage.Information);
                CuentaModificada?.Invoke(cuentaModificacion); // Invoca el evento con la cuenta modificada
                this.Close();

            }
            else if (respuesta == "apodoRepetido")
            {
                Constantes.MostrarVentanaEmergente("Ya esta registrado el apodo, porfavor ingresa otro", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            else if (respuesta == "correoRepetido")
            {
                Constantes.MostrarVentanaEmergente("Ya esta registrado el correo, porfavor ingresa otro", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void TbModificarContrasenaClick(object sender, EventArgs e)
        {

        }
    }
}
