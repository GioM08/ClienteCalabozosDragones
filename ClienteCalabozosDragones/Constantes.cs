using ClienteCalabozosDragones.ServicioCalabozosDragones;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ClienteCalabozosDragones
{
    public  class Constantes
    {
        public static readonly SolidColorBrush ColorRojo = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFBC3908"));
        public static readonly SolidColorBrush ColorAmarillo = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF6AA1C"));
        public static readonly SolidColorBrush ColorRojoClaro = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB59A90"));
        public static ObservableCollection<Foto> Items { get; set; }

        public  static MessageBoxResult MostrarVentanaEmergente(string mensaje, string titulo, MessageBoxButton tipo, MessageBoxImage icono)
        {
            return MessageBox.Show(mensaje, titulo, tipo, icono);
        }

        public static ObservableCollection<Foto> CargarImagenes()
        {

            return Items = new ObservableCollection<Foto>
            {
            new Foto { Id = 1, Ruta = "Recursos/Astronauta.png" },
            new Foto { Id = 2, Ruta = "Recursos/Calavera.png" },
            new Foto { Id = 3, Ruta = "Recursos/Dragon.png" },
            new Foto { Id = 4, Ruta = "Recursos/Espada.png" },
            new Foto { Id = 5, Ruta = "Recursos/Gato.png" },
            new Foto { Id = 6, Ruta = "Recursos/Guerrero.png" }
            };
            

        }
        public static int ObtenerIdFotoSeleccionada(ListBox fotosListBox)
        {
            // Obtén la foto seleccionada
            var fotoSeleccionada = (Foto)fotosListBox.SelectedItem;

            // Verifica que se haya seleccionado una imagen
            if (fotoSeleccionada == null)
            {
                throw new InvalidOperationException("Por favor selecciona una imagen de perfil.");
            }

            return fotoSeleccionada.Id;
        }

    }
}
