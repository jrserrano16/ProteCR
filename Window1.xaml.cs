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
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private IU_Perros dog;
        private Window2 win2;
        private String t;

        public Window1()
        {
            InitializeComponent();

        }

        public Window1(String t)
        {
            InitializeComponent();
            this.t = t;
            lbl_User.Content = t;

        }

        private void btn_GestionClientes_Click(object sender, RoutedEventArgs e)
        {
            win2 = new Window2(t);
            win2.Show();
            this.Close();
        }

        private void Btn_GestionPerros_Click(object sender, RoutedEventArgs e)
        {
            dog = new IU_Perros(t);
            dog.Show();
            this.Close();
        }

        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MessageBox.Show("Gracias por usar la aplicación:)!!");
        }
    }
}
