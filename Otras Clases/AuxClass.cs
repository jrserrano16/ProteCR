using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;

namespace ProteCR.Otras_Clases
{
    public class AuxClass
    {
        public void ButtonSwitch(object sender, RoutedEventArgs e, Button b, Button b1, Button b2)
        {
            b.Background = Brushes.LightSkyBlue;
            b1.Background = Brushes.PowderBlue;
            b2.Background = Brushes.PowderBlue;
            b.BorderBrush = Brushes.RoyalBlue;
            b1.BorderBrush = Brushes.LightSteelBlue;
            b2.BorderBrush = Brushes.LightSteelBlue;
        }
        public void clearDatosPrincipalesPersona(TextBox t, TextBox t1, TextBox t2, TextBox t3, TextBox t4, TextBox t5, ComboBox cb)
        {
            t.Text = "";
            t1.Text = "";
            t2.Text = "";
            t3.Text = "";
            t4.Text = "";
            t5.Text = "";

            cb.Text = "";
        }
        public string txbSinDatos(TextBox c)
        {
            if (c.Text == string.Empty)
            {
                return  "No registrado";
            }
            else
                return c.Text;
        }
       public BitmapImage abrirImagen()
        {
            BitmapImage img = null;
            OpenFileDialog abrirDialog = new OpenFileDialog();
            abrirDialog.Title = "Seleccionar foto del perro";
            abrirDialog.Filter = "Images|*.jpg;*.bmp;*.png;*.jpeg";
            String rutaBin = Directory.GetCurrentDirectory().ToString();
            int hasta = rutaBin.IndexOf("\\bin");
            String rutasub = rutaBin.Substring(0, hasta);

            String rutafotos = String.Concat(rutasub, "\\src\\Perros\\");
            abrirDialog.InitialDirectory = rutafotos;
            
            if (abrirDialog.ShowDialog() == true)
            {
                try
                {
                    String image = abrirDialog.FileName;
                    img = new BitmapImage(new Uri(image, UriKind.Relative));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }

            }
            return img;
        }
     public bool intervalo(TextBox t, int min, int max)
        {
            int temp = 0;

            if (int.TryParse(t.Text, out temp))
            {

            
                int valor = Convert.ToInt32(t.Text);
            if (valor < min || valor > max)
            {
                t.BorderBrush = Brushes.Red;
                return false;
            }
            else
            {
                t.BorderBrush = Brushes.Green;
                return true;
            }
            }
            else
            {
                t.BorderBrush = Brushes.Red;
                return false;
            }
        }
        public bool comprobarControl(Control c)
        {

            if (c is TextBox)
            {
                if (((TextBox)c).Text == string.Empty)
                {
                    ((TextBox)c).BorderBrush = Brushes.Red;
                    return false;
                }
                else
                {
                    ((TextBox)c).BorderBrush = Brushes.Green;
                    return true;
                }


            }
            else if (c is ComboBox)
            {
                if (((ComboBox)c).Text == string.Empty)
                {
                    ((ComboBox)c).BorderBrush = Brushes.Red;
                    return false;
                }
                else
                {
                    ((ComboBox)c).BorderBrush = Brushes.Green;
                    return true;
                }
            }

            else if (c is DatePicker)
            {
                if (((DatePicker)c).Text == string.Empty)
                {
                    ((DatePicker)c).BorderBrush = Brushes.Red;
                    return false;
                }
                else
                {
                    ((DatePicker)c).BorderBrush = Brushes.Green;
                    return true;
                }
            }
            return true;

        }

        public void ResetBrush(Control c)
        {
            if (c is TextBox)
            {
                ((TextBox)c).BorderBrush = Brushes.RoyalBlue;
            }
            else if (c is ComboBox)
            {              
                    ((ComboBox)c).BorderBrush = Brushes.RoyalBlue;             
            }

            else if (c is DatePicker)
            {
                    ((DatePicker)c).BorderBrush = Brushes.RoyalBlue;
            }
        }
    }
   
}
    

