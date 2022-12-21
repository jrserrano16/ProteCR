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

namespace ProteCR
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private Window1 win1;
        private IU_Socios soc;
        private IU_Padrinos pad;
        private IU_Voluntarios vol;
        private String t;
        public Window2(String t)
        {
            this.t = t;
            InitializeComponent();
        }

        public Window2()
        {
            InitializeComponent();
        }

        private void btn_GestionSocios_Click(object sender, RoutedEventArgs e)
        {
            soc = new IU_Socios(t);
            soc.Show();
            this.Close();
        }

        private void Btn_GestionPadrinos_Click(object sender, RoutedEventArgs e)
        {
            pad = new IU_Padrinos(t);
            pad.Show();
            this.Close();
        }

        private void Btn_GestionVoluntarios_Click(object sender, RoutedEventArgs e)
        {
            vol = new IU_Voluntarios(t);
            vol.Show();
            this.Close();
        }

        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MessageBox.Show("Gracias por usar la aplicación:)!!");
        }

       

        private void btn_Atras_Click(object sender, RoutedEventArgs e)
        {
            win1 = new Window1(t);
            win1.Show();
            this.Close();
        }
    }
}
