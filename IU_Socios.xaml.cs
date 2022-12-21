using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
using System.Xml;
using ProteCR.Otras_Clases;

namespace ProteCR
{
    /// <summary>
    /// Lógica de interacción para IU_Socios.xaml
    /// </summary>
   
    public partial class IU_Socios : Window
    {
        private List<Socio> listadosocios;
        private Window2 win2;
        private String t;
        private AuxClass aux = new AuxClass();
        private String rutaXmlSocios;

        public IU_Socios(String t)
        {
            
            this.t = t;
            String rutaBin = Directory.GetCurrentDirectory().ToString();
            int hasta = rutaBin.IndexOf("\\bin");
            String rutasub = rutaBin.Substring(0, hasta);
            this.rutaXmlSocios = String.Concat(rutasub, "\\Datos\\Socios.xml");
            InitializeComponent();
            cargarDatos();
        }

        public IU_Socios()
        {
            
            InitializeComponent();
        }
        private void Btn_Atras_Click(object sender, RoutedEventArgs e)
        {
            win2 = new Window2(t);
            win2.Show();
            this.Close();
        }

        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MessageBox.Show("Gracias por usar la aplicación:)!!");
        }

        
        private List<Socio> CargarContenidoXML()
        {
            List<Socio> listado = new List<Socio>();
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
          
            doc.Load(rutaXmlSocios);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoscio = new Socio(0, "", "", "", "", "", DateTime.Now, "", "", 0.0, "");

                nuevoscio.IdPersona = Convert.ToInt32(node.Attributes["IdPersona"].Value);
                nuevoscio.Nombre = node.Attributes["Nombre"].Value;
                nuevoscio.Apellidos = node.Attributes["Apellidos"].Value;
                nuevoscio.Telefono = node.Attributes["Telefono"].Value;
                nuevoscio.DNI = node.Attributes["DNI"].Value;
                nuevoscio.Sexo = node.Attributes["Sexo"].Value;
                nuevoscio.FechaNacimiento = Convert.ToDateTime(node.Attributes["FechaNacimiento"].Value);
                nuevoscio.Domicilio = node.Attributes["Domicilio"].Value;
                nuevoscio.NumeroCuenta = node.Attributes["NumeroCuenta"].Value;
                nuevoscio.CuantiaAyuda = Convert.ToDouble(node.Attributes["CuantiaAyuda"].Value);
                nuevoscio.FormaPago = node.Attributes["FormaPago"].Value;
                listado.Add(nuevoscio);
            }
            return listado;
        }

        private void btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            aux = new AuxClass();
            aux.ButtonSwitch(sender, e, btn_Eliminar, btn_Añadir, btn_Editar);
            XmlDocument doc = new XmlDocument();
            doc.Load(rutaXmlSocios);
            XmlNode root = doc.SelectSingleNode("Socios");
            int id = listadosocios[lstbx_Socios.SelectedIndex].getsetIdPersona;
            XmlNode target = root.SelectSingleNode("Socio [@IdPersona = " + id.ToString() + "]");
            root.RemoveChild(target);
            doc.Save(rutaXmlSocios);
            MessageBox.Show(target.Attributes["Nombre"].Value.ToString() + " Eliminado.");
            btn_Limpiar_Click(sender, e);
        }


        private void editarSocio()
        {
            XmlDocument doc = new XmlDocument();
            aux = new AuxClass();
            doc.Load(rutaXmlSocios);
            XmlNode root = doc.SelectSingleNode("Socios");
            int id = listadosocios[lstbx_Socios.SelectedIndex].getsetIdPersona;
            XmlNode target = root.SelectSingleNode("Socio [@IdPersona = " + id.ToString() + "]");

            target.Attributes["Nombre"].Value = txt_Nombre.Text;
            target.Attributes["Apellidos"].Value = txtbox__Apellidos.Text;
            target.Attributes["Telefono"].Value = txt_Tel.Text;
            target.Attributes["DNI"].Value = txtbox_DNI.Text;
            target.Attributes["Sexo"].Value = cbGenero.Text;
            target.Attributes["FechaNacimiento"].Value = dp_Fecha.Text;
            target.Attributes["Domicilio"].Value = txt_domicilio.Text;

            target.Attributes["CuantiaAyuda"].Value = txtbox_Cuantia.Text;
            target.Attributes["FormaPago"].Value = txtbox__FPago.Text;
            target.Attributes["NumeroCuenta"].Value = txt_NCuenta.Text;


            doc.Save(rutaXmlSocios);
            
        }
        private void ResetBrushes()
        {
            aux.ResetBrush(txt_Nombre);
            aux.ResetBrush(txtbox__Apellidos);
            aux.ResetBrush(txt_Tel);
            aux.ResetBrush(txtbox_DNI);
            aux.ResetBrush(txt_domicilio);
            aux.ResetBrush(dp_Fecha);
            aux.ResetBrush(cbGenero);
            aux.ResetBrush(txtbox_Cuantia);
            aux.ResetBrush(txtbox__FPago);
            aux.ResetBrush(txt_NCuenta);
        }
        private void btn_Editar_Click(object sender, RoutedEventArgs e)
        {
            aux.ButtonSwitch(sender, e, btn_Añadir, btn_Editar, btn_Eliminar);
            if (comprobarAllControls() & aux.intervalo(txtbox_Cuantia, 0, 1000))
            {
                editarSocio();
                btn_Limpiar_Click(sender, e);
                MessageBox.Show("Socio editado correctamente");

            }
            else
                MessageBox.Show("No se rellenó alguno de los campos obligatorios o el formato es incorrecto");

        }
    
        private bool comprobarAllControls()
        {
            if (aux.comprobarControl(txt_Nombre) & aux.comprobarControl(txtbox__Apellidos) 
                & aux.comprobarControl(txtbox_DNI) & aux.comprobarControl(txt_domicilio) 
                & aux.comprobarControl(txt_Tel) & aux.comprobarControl(dp_Fecha) 
                & aux.comprobarControl(cbGenero) & aux.comprobarControl(txtbox_Cuantia)
                & aux.comprobarControl(txtbox__FPago) & aux.comprobarControl(txt_NCuenta))
            {
                return true;
            }
            else
                return false;
        }

        private void cargarDatos()
        {
            listadosocios = CargarContenidoXML();
            lstbx_Socios.DataContext = listadosocios;
        }
        private void btn_Limpiar_Click(object sender, RoutedEventArgs e)
        {
            cargarDatos();
            lstbx_Socios.Items.Refresh();
            clear();
            btn_Editar.IsEnabled = false;
            btn_Eliminar.IsEnabled = false;
            btn_Añadir.IsEnabled = true;
            ResetBrushes();
        }
        private void añadirSocios()
        {
            XmlDocument doc = new XmlDocument();
            aux = new AuxClass();
            doc.Load(rutaXmlSocios);
            XmlNode root = doc.SelectSingleNode("Socios");
            XmlElement socio = doc.CreateElement("Socio");
            root.AppendChild(socio);
            XmlAttribute idpersona = doc.CreateAttribute("IdPersona");
            XmlAttribute nombre = doc.CreateAttribute("Nombre");
            XmlAttribute apellidos = doc.CreateAttribute("Apellidos");
            XmlAttribute telefono = doc.CreateAttribute("Telefono");
            XmlAttribute DNI = doc.CreateAttribute("DNI");
            XmlAttribute sexo = doc.CreateAttribute("Sexo");
            XmlAttribute fechanacimiento = doc.CreateAttribute("FechaNacimiento");
            XmlAttribute domicilio = doc.CreateAttribute("Domicilio");
            XmlAttribute cuantiaayuda = doc.CreateAttribute("CuantiaAyuda");
            XmlAttribute formapago = doc.CreateAttribute("FormaPago");
            XmlAttribute numerocuenta = doc.CreateAttribute("NumeroCuenta");
            int valor = 0;
            if (listadosocios.Count == 0)
            {
                valor = 0;
            }
            else
                valor = (listadosocios[listadosocios.Count - 1].getsetIdPersona + 1);



            idpersona.Value = valor.ToString();
            nombre.Value = txt_Nombre.Text;
            apellidos.Value = txtbox__Apellidos.Text;
            telefono.Value = txt_Tel.Text;
            DNI.Value = txtbox_DNI.Text;
            sexo.Value = cbGenero.Text.ToString();
            fechanacimiento.Value = dp_Fecha.Text;
            domicilio.Value = txt_domicilio.Text;

            cuantiaayuda.Value = txtbox_Cuantia.Text;
            formapago.Value = txtbox__FPago.Text;
            numerocuenta.Value = txt_NCuenta.Text;

            socio.Attributes.Append(idpersona);
            socio.Attributes.Append(nombre);
            socio.Attributes.Append(apellidos);
            socio.Attributes.Append(telefono);
            socio.Attributes.Append(DNI);
            socio.Attributes.Append(sexo);
            socio.Attributes.Append(fechanacimiento);
            socio.Attributes.Append(domicilio);

            socio.Attributes.Append(cuantiaayuda);
            socio.Attributes.Append(formapago);
            socio.Attributes.Append(numerocuenta);

            doc.Save(rutaXmlSocios);
        }
        private void btn_Añadir_Click(object sender, RoutedEventArgs e)
        {
            aux.ButtonSwitch(sender, e, btn_Añadir, btn_Editar, btn_Eliminar);
            if (comprobarAllControls() & aux.intervalo(txtbox_Cuantia, 0, 1000))
            {
                añadirSocios();
                btn_Limpiar_Click(sender, e);
                MessageBox.Show("Socio añadido con exito");

            }
            else
                MessageBox.Show("No se rellenó alguno de los campos obligatorios o el formato es incorrecto");

        }
        private void clear()
        {
            aux = new AuxClass();
            aux.clearDatosPrincipalesPersona(txt_Nombre, txt_Tel, txt_domicilio, txtbox__Apellidos, txt_domicilio, txtbox_DNI, cbGenero);
            txt_NCuenta.Text = "";
            txtbox__FPago.Text = "";
            txtbox_Cuantia.Text = "";


        }

        private void lstbx_Socios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_Editar.IsEnabled = true;
            btn_Eliminar.IsEnabled = true;
            btn_Añadir.IsEnabled = false;
        }
    }
}
  
