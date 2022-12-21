using ProteCR.Otras_Clases;
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




namespace ProteCR
{
    /// <summary>
    /// Lógica de interacción para IU_Padrinos.xaml
    /// </summary>
    public partial class IU_Padrinos : Window
    {
       
      
        private Window2 win2; 
        private IU_ApadrinarPerros pad;
        private AuxClass aux = new AuxClass();
        private String t;
        private String rutaXmlPadrinos;
        private String rutaXmlPerros;
        private List<Padrino> listadopadrinos;
       
        public IU_Padrinos(String t)
        {
            this.t = t;
            String rutaBin = Directory.GetCurrentDirectory().ToString();
            int hasta = rutaBin.IndexOf("\\bin");
            String rutasub = rutaBin.Substring(0, hasta);

            this.rutaXmlPadrinos = String.Concat(rutasub,"\\Datos\\Padrinos.xml");
            this.rutaXmlPerros = String.Concat(rutasub, "\\Datos\\Perros.xml");
            InitializeComponent();
            cargarDatos();
         


        }

        private void cargarDatos()
        {
            listadopadrinos = CargarContenidoXML();
            lstbx_Padrinos.DataContext = listadopadrinos;





        }

        public IU_Padrinos()
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
        }

        private void btn_Apadrinar_Click(object sender, RoutedEventArgs e)
        {
            int index = lstbx_Padrinos.SelectedIndex;
            Padrino p = listadopadrinos[index];
            pad = new IU_ApadrinarPerros(t, p);
            pad.Show();
            this.Close();
        }

        private void añadirPadrino()
        {
            XmlDocument doc = new XmlDocument();
            aux = new AuxClass();
            doc.Load(rutaXmlPadrinos);
            XmlNode root = doc.SelectSingleNode("Padrinos");
            XmlElement padrino = doc.CreateElement("Padrino");
            root.AppendChild(padrino);
            XmlAttribute idpersona = doc.CreateAttribute("IdPersona");
            XmlAttribute nombre = doc.CreateAttribute("Nombre");
            XmlAttribute apellidos = doc.CreateAttribute("Apellidos");
            XmlAttribute telefono = doc.CreateAttribute("Telefono");
            XmlAttribute DNI = doc.CreateAttribute("DNI");
            XmlAttribute sexo = doc.CreateAttribute("Sexo");
            XmlAttribute fechanacimiento = doc.CreateAttribute("FechaNacimiento");
            XmlAttribute domicilio = doc.CreateAttribute("Domicilio");
            XmlAttribute aportacionmensual = doc.CreateAttribute("AportacionMensual");
            XmlAttribute formapago = doc.CreateAttribute("FormaPago");
            XmlAttribute numerocuenta = doc.CreateAttribute("NumeroCuenta");

            int valor = 0;
            if (listadopadrinos.Count == 0)
            {
                valor = 0;
            }
            else
                valor = (listadopadrinos[listadopadrinos.Count - 1].getsetIdPersona + 1);
            idpersona.Value = valor.ToString();
            nombre.Value = txt_Nombre.Text;
            apellidos.Value = txtbox__Apellidos.Text;
            telefono.Value = txt_Tel.Text;
            DNI.Value = txtbox_DNI.Text;
            sexo.Value = cbGenero.Text.ToString();
            fechanacimiento.Value = dp_Fecha.Text;
            domicilio.Value = txt_domicilio.Text;
            aportacionmensual.Value = txtbox_Aportacion.Text;
            formapago.Value = txtbox__FPago.Text;
            numerocuenta.Value = aux.txbSinDatos(txt_NCuenta);
            padrino.Attributes.Append(idpersona);
            padrino.Attributes.Append(nombre);
            padrino.Attributes.Append(apellidos);
            padrino.Attributes.Append(telefono);
            padrino.Attributes.Append(DNI);
            padrino.Attributes.Append(sexo);
            padrino.Attributes.Append(fechanacimiento);
            padrino.Attributes.Append(domicilio);

            padrino.Attributes.Append(aportacionmensual);
            padrino.Attributes.Append(formapago);
            padrino.Attributes.Append(numerocuenta);


            doc.Save(rutaXmlPadrinos);
        }
        private void btn_Añadir_Click(object sender, RoutedEventArgs e)
        {
            aux.ButtonSwitch(sender, e, btn_Añadir, btn_Editar, btn_Eliminar);
            if (comprobarAllControls() & aux.intervalo(txtbox_Aportacion, 0, 1000))
            {
                añadirPadrino();
                btn_Limpiar_Click(sender, e);
                MessageBox.Show("Padrino añadido correctamente");

            }
            else
                MessageBox.Show("No se rellenó alguno de los campos obligatorios o el formato es incorrecto");


        }

        private void btn_Limpiar_Click(object sender, RoutedEventArgs e)
        {
            listadopadrinos = CargarContenidoXML();
            lstbx_Padrinos.DataContext = listadopadrinos;
           
            aux = new AuxClass();
            aux.clearDatosPrincipalesPersona(txt_Nombre, txt_Tel, txt_domicilio, txtbox__Apellidos, txt_domicilio, txtbox_DNI, cbGenero);
            txt_NCuenta.Text = "";
            txtbox__FPago.Text = "";
            txtbox_Aportacion.Text = "";
            btn_Apadrinar.IsEnabled = false;
            cargarDatos();
            lstbx_Padrinos.Items.Refresh();
          
            btn_Editar.IsEnabled = false;
            btn_Eliminar.IsEnabled = false;
            btn_Añadir.IsEnabled = true;

            ResetBrushes();
        }

        private void btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            aux = new AuxClass();
            aux.ButtonSwitch(sender, e, btn_Eliminar, btn_Añadir, btn_Editar);
            XmlDocument doc = new XmlDocument();
            doc.Load(rutaXmlPadrinos);
            XmlNode root = doc.SelectSingleNode("Padrinos");
            int id = listadopadrinos[lstbx_Padrinos.SelectedIndex].getsetIdPersona;
            if (listadopadrinos[lstbx_Padrinos.SelectedIndex].getsetListadoPerros.Count != 0)
            {
                XmlDocument doc1 = new XmlDocument();
                doc1.Load(rutaXmlPerros);
                foreach (Perro p in listadopadrinos[lstbx_Padrinos.SelectedIndex].getsetListadoPerros)
                {

                    XmlNode root1 = doc1.SelectSingleNode("Perros");
                    int id1 = p.getsetIdPerro;
                    XmlNode target1 = root1.SelectSingleNode("Perro [@IdPerro = " + id1.ToString() + "]");
                    target1.Attributes["Apadrinado"].Value = false.ToString();
                }
                doc1.Save(rutaXmlPerros);
            } 
            XmlNode target = root.SelectSingleNode("Padrino [@IdPersona = " + id.ToString() + "]");
            root.RemoveChild(target);
            doc.Save(rutaXmlPadrinos);
            MessageBox.Show(target.Attributes["Nombre"].Value.ToString() + " Eliminado.");
            btn_Limpiar_Click(sender, e);
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
            aux.ResetBrush(txt_NCuenta);
            aux.ResetBrush(txtbox__FPago);
            aux.ResetBrush(txtbox_Aportacion);

        }
        private void editarPadrino()
        {
            XmlDocument doc = new XmlDocument();
            aux = new AuxClass();
            doc.Load(rutaXmlPadrinos);
            XmlNode root = doc.SelectSingleNode("Padrinos");
            int id = listadopadrinos[lstbx_Padrinos.SelectedIndex].getsetIdPersona;
            XmlNode target = root.SelectSingleNode("Padrino [@IdPersona = " + id.ToString() + "]");

            target.Attributes["Nombre"].Value = txt_Nombre.Text;
            target.Attributes["Apellidos"].Value = txtbox__Apellidos.Text;
            target.Attributes["Telefono"].Value = txt_Tel.Text;
            target.Attributes["DNI"].Value = txtbox_DNI.Text;
            target.Attributes["Sexo"].Value = cbGenero.Text;
            target.Attributes["FechaNacimiento"].Value = dp_Fecha.Text;
            target.Attributes["Domicilio"].Value = txt_domicilio.Text;

            target.Attributes["AportacionMensual"].Value = txtbox_Aportacion.Text;
            target.Attributes["FormaPago"].Value = txtbox__FPago.Text;
            target.Attributes["NumeroCuenta"].Value = txt_NCuenta.Text;

            doc.Save(rutaXmlPadrinos);
        }
        private void btn_Editar_Click(object sender, RoutedEventArgs e)
        {
            aux.ButtonSwitch(sender, e, btn_Añadir, btn_Editar, btn_Eliminar);
            if (comprobarAllControls() & aux.intervalo(txtbox_Aportacion,0,1000))
            {
                editarPadrino();
                btn_Limpiar_Click(sender, e);
                MessageBox.Show("Padrino editado correctamente");

            }
            else
                MessageBox.Show("No se rellenó alguno de los campos obligatorios o el formato es incorrecto");

        }

        private bool comprobarAllControls()
        {
            if (aux.comprobarControl(txt_Nombre) & aux.comprobarControl(txtbox__Apellidos)
                & aux.comprobarControl(txtbox_DNI) & aux.comprobarControl(txt_domicilio)
                & aux.comprobarControl(txt_Tel) & aux.comprobarControl(dp_Fecha)
                & aux.comprobarControl(cbGenero) & aux.comprobarControl(txtbox_Aportacion)
                & aux.comprobarControl(txtbox__FPago) & aux.comprobarControl(txt_NCuenta))
            {
                return true;
            }
            else
                return false;
        }

        private List<Padrino> CargarContenidoXML()
        {
            List<Padrino> listado = new List<Padrino>();
            XmlDocument doc = new XmlDocument();
            doc.Load(rutaXmlPadrinos);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevopadrino = new Padrino(0, "", "", "", "", "", DateTime.Now, "", 0.0, "", "");

                nuevopadrino.IdPersona = Convert.ToInt32(node.Attributes["IdPersona"].Value);
                nuevopadrino.Nombre = node.Attributes["Nombre"].Value;
                nuevopadrino.Apellidos = node.Attributes["Apellidos"].Value;
                nuevopadrino.Telefono = node.Attributes["Telefono"].Value;
                nuevopadrino.DNI = node.Attributes["DNI"].Value;
                nuevopadrino.Sexo = node.Attributes["Sexo"].Value;
                nuevopadrino.FechaNacimiento = Convert.ToDateTime(node.Attributes["FechaNacimiento"].Value);
                nuevopadrino.Domicilio = node.Attributes["Domicilio"].Value;
                nuevopadrino.AportacionMensual = Convert.ToDouble(node.Attributes["AportacionMensual"].Value);
                nuevopadrino.FormaPago = node.Attributes["FormaPago"].Value;
                nuevopadrino.NumeroCuenta = node.Attributes["NumeroCuenta"].Value;

                if (node.HasChildNodes)
                {
                    foreach(XmlNode subnode0 in node.ChildNodes){
                        if (subnode0.HasChildNodes)
                        {
                            foreach (XmlNode subnode in subnode0.ChildNodes)
                            {
                                var nuevoperro = new Perro(0, "", "", "", 0.0, 0, DateTime.Now, true, true, true, true, true, "", "", "", "", null);
                                nuevoperro.IdPerro = Convert.ToInt32(subnode.Attributes["IdPerro"].Value);
                                nuevoperro.Edad = Convert.ToInt32(subnode.Attributes["Edad"].Value);
                                nuevoperro.Nombre = subnode.Attributes["Nombre"].Value;
                                nuevoperro.Sexo = subnode.Attributes["Sexo"].Value;
                                nuevoperro.Raza = subnode.Attributes["Raza"].Value;
                                nuevoperro.Peso = Convert.ToDouble(subnode.Attributes["Peso"].Value);
                                nuevoperro.FechaEntrada = Convert.ToDateTime(subnode.Attributes["FechaEntrada"].Value);
                                nuevoperro.Chip = Convert.ToBoolean(subnode.Attributes["Chip"].Value);
                                nuevoperro.PPP = Convert.ToBoolean(subnode.Attributes["PPP"].Value);
                                nuevoperro.Vacunado = Convert.ToBoolean(subnode.Attributes["Vacunado"].Value);
                                nuevoperro.Esterilizado = Convert.ToBoolean(subnode.Attributes["Esterilizado"].Value);
                                nuevoperro.Apadrinado = Convert.ToBoolean(subnode.Attributes["Apadrinado"].Value);
                                nuevoperro.Enfermedades = subnode.Attributes["Enfermedades"].Value;
                                nuevoperro.Tratamientos = subnode.Attributes["Tratamientos"].Value;
                                nuevoperro.DatosInteres = subnode.Attributes["OtrosDatos"].Value;
                                nuevoperro.Estado = subnode.Attributes["Estado"].Value;
                                nuevoperro.Foto = new Uri(Convert.ToString(subnode.Attributes["Foto"].Value),UriKind.Relative);
                                nuevopadrino.ListadoPerros.Add(nuevoperro);
                            }
                        }
                       
                    }
                    }
                listado.Add(nuevopadrino);

            }

            return listado;


        }

        private void lstbx_Padrinos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                int index = lstbx_Padrinos.SelectedIndex;
            if (index != -1)
            {
                lstbx_Padrinos.Items.Refresh();
                Padrino padrino = listadopadrinos[index];
                lstbx_Apadrinamientos.DataContext = padrino.ListadoPerros;
                btn_Apadrinar.IsEnabled = true;
                btn_Editar.IsEnabled = true;
                btn_Eliminar.IsEnabled = true;
                btn_Añadir.IsEnabled = false;
                lstbx_Apadrinamientos.Items.Refresh();
            }
            
            
        }
    }
}

