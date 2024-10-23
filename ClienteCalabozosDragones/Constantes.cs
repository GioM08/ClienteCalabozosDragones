using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ClienteCalabozosDragones
{
    public  class Constantes
    {
        public static readonly SolidColorBrush ColorRojo = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFBC3908"));
        public static readonly SolidColorBrush ColorAmarillo = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF6AA1C"));
        public static readonly SolidColorBrush ColorRojoClaro = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB59A90"));

        public  static MessageBoxResult MostrarVentanaEmergente(string mensaje, string titulo, MessageBoxButton tipo, MessageBoxImage icono)
        {
            return MessageBox.Show(mensaje, titulo, tipo, icono);
        }


    }
}
