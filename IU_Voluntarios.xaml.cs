using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para IU_Voluntarios.xaml
    /// </summary>
    public partial class IU_Voluntarios : Window
    {
        private Window2 win2;
        private String t;
        private List<Voluntario> listadovoluntarios;
        private AuxClass aux = new AuxClass();
        private String rutaXmlVoluntarios;
        public IU_Voluntarios(String t)
        {
            this.t = t;
            String rutaBin = Directory.GetCurrentDirectory().ToString();
            int hasta = rutaBin.IndexOf("\\bin");
            String rutasub = rutaBin.Substring(0, hasta);
            this.rutaXmlVoluntarios = String.Concat(rutasub, "\\Datos\\Voluntarios.xml");
            InitializeComponent();
            cargarDatos();
        }
        public IU_Voluntarios()
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
        private List<Voluntario> CargarContenidoXML()
        {
            List<Voluntario> listado = new List<Voluntario>();
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
           doc.Load(rutaXmlVoluntarios);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevovoluntario = new Voluntario(0, "", "", "", "", "", DateTime.Now, "", "", "", "", false);

                nuevovoluntario.IdPersona = Convert.ToInt32(node.Attributes["IdPersona"].Value);
                nuevovoluntario.Nombre = node.Attributes["Nombre"].Value;
                nuevovoluntario.Sexo = node.Attributes["Sexo"].Value;
                nuevovoluntario.Apellidos = node.Attributes["Apellidos"].Value;
                nuevovoluntario.Telefono = node.Attributes["Telefono"].Value;
                nuevovoluntario.DNI = node.Attributes["DNI"].Value;
                nuevovoluntario.FechaNacimiento = Convert.ToDateTime(node.Attributes["FechaNacimiento"].Value);
                nuevovoluntario.Domicilio = node.Attributes["Domicilio"].Value;
                nuevovoluntario.Email = node.Attributes["Email"].Value;
                nuevovoluntario.HorarioDisponibilidad = node.Attributes["HorarioDisponibilidad"].Value;
                nuevovoluntario.ZonaDisponibilidad = node.Attributes["ZonaDisponibilidad"].Value;
                nuevovoluntario.ConocimientosVeterinarios = Convert.ToBoolean(node.Attributes["ConocimientosVeterinarios"].Value);
                listado.Add(nuevovoluntario);
            }
            return listado;
        }
        private void añadirVoluntarios()
        {
            XmlDocument doc = new XmlDocument();
            aux = new AuxClass();
            doc.Load(rutaXmlVoluntarios);
            XmlNode root = doc.SelectSingleNode("Voluntarios");
            XmlElement voluntario = doc.CreateElement("Voluntario");
            root.AppendChild(voluntario);
            XmlAttribute idpersona = doc.CreateAttribute("IdPersona");
            XmlAttribute nombre = doc.CreateAttribute("Nombre");
            XmlAttribute apellidos = doc.CreateAttribute("Apellidos");
            XmlAttribute telefono = doc.CreateAttribute("Telefono");
            XmlAttribute DNI = doc.CreateAttribute("DNI");
            XmlAttribute sexo = doc.CreateAttribute("Sexo");
            XmlAttribute fechanacimiento = doc.CreateAttribute("FechaNacimiento");
            XmlAttribute domicilio = doc.CreateAttribute("Domicilio");
            XmlAttribute email = doc.CreateAttribute("Email");
            XmlAttribute horariodisponibilidad = doc.CreateAttribute("HorarioDisponibilidad");
            XmlAttribute zonadisponibilidad = doc.CreateAttribute("ZonaDisponibilidad");
            XmlAttribute conocimientosveterinarios = doc.CreateAttribute("ConocimientosVeterinarios");

            int valor = 0;
            if (listadovoluntarios.Count == 0)
            {
                valor = 0;
            }
            else
                valor = (listadovoluntarios[listadovoluntarios.Count - 1].getsetIdPersona + 1);



            idpersona.Value = valor.ToString();
            nombre.Value = txt_Nombre.Text;
            apellidos.Value = txtbox__Apellidos.Text;
            telefono.Value = txt_Tel.Text;
            DNI.Value = txtbox_DNI.Text;
            sexo.Value = cbGenero.Text.ToString();
            fechanacimiento.Value = dp_Fecha.Text;
            domicilio.Value = txt_domicilio.Text;
            



            email.Value = txtbox_email.Text;
            horariodisponibilidad.Value = txt_Horario.Text;
            conocimientosveterinarios.Value = chb_CVeterinarios.IsChecked.ToString();
            zonadisponibilidad.Value = txt_Zona.Text;



            voluntario.Attributes.Append(idpersona);
            voluntario.Attributes.Append(nombre);
            voluntario.Attributes.Append(apellidos);
            voluntario.Attributes.Append(telefono);
            voluntario.Attributes.Append(DNI);
            voluntario.Attributes.Append(sexo);
            voluntario.Attributes.Append(fechanacimiento);
            voluntario.Attributes.Append(domicilio);



            voluntario.Attributes.Append(email);
            voluntario.Attributes.Append(horariodisponibilidad);
            voluntario.Attributes.Append(zonadisponibilidad);



            voluntario.Attributes.Append(conocimientosveterinarios);



            doc.Save(rutaXmlVoluntarios);
        }
        private void btn_Añadir_Click(object sender, RoutedEventArgs e)
        {
            aux.ButtonSwitch(sender, e, btn_Añadir, btn_Editar, btn_Eliminar);
            if (comprobarAllControls())
            {
                añadirVoluntarios();
                btn_Limpiar_Click(sender, e);
                MessageBox.Show("Voluntario añadido con exito");

            }
            else
                MessageBox.Show("No se rellenó alguno de los campos obligatorios...");

        }

        private void cargarDatos()
        {
            listadovoluntarios = CargarContenidoXML();
            DataContext = listadovoluntarios;
        }

        private void btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            aux = new AuxClass();
            aux.ButtonSwitch(sender, e, btn_Eliminar, btn_Añadir, btn_Editar);
            XmlDocument doc = new XmlDocument();
            doc.Load(rutaXmlVoluntarios);
            XmlNode root = doc.SelectSingleNode("Voluntarios");
            int id = listadovoluntarios[lstbx_Voluntarios.SelectedIndex].getsetIdPersona;
            XmlNode target = root.SelectSingleNode("Voluntario [@IdPersona = " + id.ToString() + "]");
            root.RemoveChild(target);
            doc.Save(rutaXmlVoluntarios);
            MessageBox.Show(target.Attributes["Nombre"].Value.ToString() + " Eliminado.");
            btn_Limpiar_Click(sender, e);
        }

        private bool comprobarAllControls()
        {
            if (aux.comprobarControl(txt_Nombre) & aux.comprobarControl(txtbox__Apellidos)
                & aux.comprobarControl(txtbox_DNI) & aux.comprobarControl(txt_domicilio)
                & aux.comprobarControl(txt_Tel) & aux.comprobarControl(dp_Fecha)
                & aux.comprobarControl(cbGenero) & aux.comprobarControl(txtbox_email)
                & aux.comprobarControl(txt_Horario) & aux.comprobarControl(txt_Zona))
            {
                return true;
            }
            else
                return false;
        }
        private void editarVoluntarios()
        {
            XmlDocument doc = new XmlDocument();
            aux = new AuxClass();
            doc.Load(rutaXmlVoluntarios);
            XmlNode root = doc.SelectSingleNode("Voluntarios");
            int id = listadovoluntarios[lstbx_Voluntarios.SelectedIndex].getsetIdPersona;
            XmlNode target = root.SelectSingleNode("Voluntario [@IdPersona = " + id.ToString() + "]");



            target.Attributes["Nombre"].Value = txt_Nombre.Text;
            target.Attributes["Apellidos"].Value = txtbox__Apellidos.Text;
            target.Attributes["Telefono"].Value = txt_Tel.Text;
            target.Attributes["DNI"].Value = txtbox_DNI.Text;
            target.Attributes["Sexo"].Value = cbGenero.Text;
            target.Attributes["FechaNacimiento"].Value = dp_Fecha.Text;
            target.Attributes["Domicilio"].Value = txt_domicilio.Text;



            target.Attributes["Email"].Value = txtbox_email.Text;
            target.Attributes["HorarioDisponibilidad"].Value = txt_Horario.Text;
            target.Attributes["ZonaDisponibilidad"].Value = txt_Zona.Text;
            target.Attributes["ConocimientosVeterinarios"].Value = chb_CVeterinarios.IsChecked.ToString();



            doc.Save(rutaXmlVoluntarios);
        }
        private void btn_Editar_Click(object sender, RoutedEventArgs e)
        {
            aux.ButtonSwitch(sender, e, btn_Añadir, btn_Editar, btn_Eliminar);
            if (comprobarAllControls())
            {
                editarVoluntarios();
                btn_Limpiar_Click(sender, e);
                MessageBox.Show("Voluntario editado con exito");

            }
            else
                MessageBox.Show("No se rellenó alguno de los campos obligatorios...");

        }
        private void clear()
        {
            aux = new AuxClass();
            aux.clearDatosPrincipalesPersona(txt_Nombre, txt_Tel, txt_domicilio, txtbox__Apellidos, txt_domicilio, txtbox_DNI, cbGenero);
            txt_Zona.Text = "";
            txtbox_email.Text = "";
            txt_Horario.Text = "";


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
            aux.ResetBrush(txt_Horario);
            aux.ResetBrush(txtbox_email);
            aux.ResetBrush(txt_Zona);
        }
        private void btn_Limpiar_Click(object sender, RoutedEventArgs e)
        {
            cargarDatos();
            lstbx_Voluntarios.Items.Refresh();
            clear();
            btn_Editar.IsEnabled = false;
            btn_Eliminar.IsEnabled = false;
            btn_Añadir.IsEnabled = true;
            comprobarAllControls();
            ResetBrushes();
        }

        private void lstbx_Voluntarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_Editar.IsEnabled = true;
            btn_Eliminar.IsEnabled = true;
            btn_Añadir.IsEnabled = false;
        }
    }

}

