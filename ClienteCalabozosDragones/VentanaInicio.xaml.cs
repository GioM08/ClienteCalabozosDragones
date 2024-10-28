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
    /// Lógica de interacción para VentanaInicio.xaml
    /// </summary>
    public partial class VentanaInicio : Window
    {
        private readonly ServicioCalabozosDragones.GestionCuentaClient cliente = new ServicioCalabozosDragones.GestionCuentaClient();
        private readonly string correo;
        private readonly string contrasena;
        private Cuenta cuenta;


        public VentanaInicio(string contrasena, string correo)
        {
            InitializeComponent();
            this.contrasena = contrasena;
            this.correo = correo;
            
            ActualizarInterfaz();
            

        }
        private void ActualizarInterfaz()
        {
            var cuenta = cliente.ObtenerCuenta(correo, contrasena);
            ImagenPerfil.Source = ObtenerFotoPerfil(cuenta);
            TbApodo.Text = "Bienvenido " + cuenta.Apodo;
        }


        private BitmapImage ObtenerFotoPerfil(Cuenta cuenta)
        {   
            string ruta = cliente.ObtenerRuta(cuenta.IdFoto);
            return new BitmapImage(new Uri(ruta, UriKind.RelativeOrAbsolute));
        }

        private void BtnAnadirAmigos(object sender, RoutedEventArgs e)
        {

        }

        private void BtnModificarPerfilClick(object sender, RoutedEventArgs e)
        {
            var cuenta = cliente.ObtenerCuenta(correo, contrasena);
            var ventanaModificar = new VentanaModificarCuenta(cuenta);
            ventanaModificar.CuentaModificada += (cuentaModificada) =>
            {
                this.cuenta = cuentaModificada;
                ActualizarInterfaz(); // Refresca la interfaz con los datos actualizados
            };
            ventanaModificar.ShowDialog();
        }

        private void BtnHistorialPartidaClick(object sender, RoutedEventArgs e)
        {

        }

        

        private void BtnCrearSalaClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
