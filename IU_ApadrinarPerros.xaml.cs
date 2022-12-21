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
    /// Lógica de interacción para IU_ApadrinarPerros.xaml
    /// </summary>
    public partial class IU_ApadrinarPerros : Window
    {

        private IU_Padrinos pad;
        private String t;
        private Padrino p;
        private List<Perro> listadoperros;
        private String rutaXmlPerros;
        private String rutaXmlPadrinos;
        public IU_ApadrinarPerros()
        {
            InitializeComponent();
        }
        public IU_ApadrinarPerros(String t, Padrino p)
        {
                 
    
 
            String rutaBin = Directory.GetCurrentDirectory().ToString();
            int hasta = rutaBin.IndexOf("\\bin");
            String rutasub = rutaBin.Substring(0, hasta);
            this.rutaXmlPerros = String.Concat(rutasub, "\\Datos\\Perros.xml");
            this.rutaXmlPadrinos = String.Concat(rutasub, "\\Datos\\Padrinos.xml");
            InitializeComponent();
            this.t = t;
            this.p = p;
            cargarDatos();
        }
        private void Btn_Atras_Click(object sender, RoutedEventArgs e)
        {
            pad = new IU_Padrinos(t);
            pad.Show();
            this.Close();
        }

        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MessageBox.Show("Gracias por usar la aplicación:)!!");
        }
        private void cargarDatos()
        {
            listadoperros = CargarContenidoXML();
            lstbx_Perros.DataContext = listadoperros;
        }
        private List<Perro> CargarContenidoXML()
        {
            List<Perro> listado = new List<Perro>();
            XmlDocument doc = new XmlDocument();
            doc.Load(rutaXmlPerros);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoperro = new Perro(0, "", "", "", 0.0, 0, DateTime.Now, true, true, true, true, true, "", "", "", "", null);
                nuevoperro.IdPerro = Convert.ToInt32(node.Attributes["IdPerro"].Value);
                nuevoperro.Edad = Convert.ToInt32(node.Attributes["Edad"].Value);
                nuevoperro.Nombre = node.Attributes["Nombre"].Value;
                nuevoperro.Sexo = node.Attributes["Sexo"].Value;
                nuevoperro.Raza = node.Attributes["Raza"].Value;
                nuevoperro.Peso = Convert.ToDouble(node.Attributes["Peso"].Value);
                nuevoperro.FechaEntrada = Convert.ToDateTime(node.Attributes["FechaEntrada"].Value);
                nuevoperro.Chip = Convert.ToBoolean(node.Attributes["Chip"].Value);
                nuevoperro.PPP = Convert.ToBoolean(node.Attributes["PPP"].Value);
                nuevoperro.Vacunado = Convert.ToBoolean(node.Attributes["Vacunado"].Value);
                nuevoperro.Esterilizado = Convert.ToBoolean(node.Attributes["Esterilizado"].Value);
                nuevoperro.Apadrinado = Convert.ToBoolean(node.Attributes["Apadrinado"].Value);
                nuevoperro.Enfermedades = node.Attributes["Enfermedades"].Value;
                nuevoperro.Tratamientos = node.Attributes["Tratamientos"].Value;
                nuevoperro.DatosInteres = node.Attributes["OtrosDatos"].Value;
                nuevoperro.Estado = node.Attributes["Estado"].Value;
                nuevoperro.Foto = new Uri(Convert.ToString(node.Attributes["Foto"].Value),UriKind.Relative);
                if (node.Attributes["Apadrinado"].Value.Equals("False"))
                {
                    listado.Add(nuevoperro);
                }
                
            }
            return listado;
        }
        private void añadirApadrinamiento()
        {
            int index = lstbx_Perros.SelectedIndex;
            Perro perr = listadoperros[index];
            XmlNode perros;
            XmlElement perro;


            XmlDocument doc = new XmlDocument();
            doc.Load(rutaXmlPerros);
            XmlNode root = doc.SelectSingleNode("Perros");
            int id = listadoperros[lstbx_Perros.SelectedIndex].getsetIdPerro;
            XmlNode target = root.SelectSingleNode("Perro [@IdPerro = " + id.ToString() + "]");
            target.Attributes["Apadrinado"].Value = true.ToString();
            doc.Save(rutaXmlPerros);

            doc.Load(rutaXmlPadrinos);

            root = doc.SelectSingleNode("Padrinos");
            id = p.IdPersona;
            target = root.SelectSingleNode("Padrino [@IdPersona = " + id.ToString() + "]");
            if (!target.HasChildNodes){
                perros = doc.CreateElement("Perros");
                target.AppendChild(perros);
            }
             perros = target.SelectSingleNode("Perros");
             perro = doc.CreateElement("Perro");

            XmlAttribute idperro = doc.CreateAttribute("IdPerro");
            XmlAttribute nombre = doc.CreateAttribute("Nombre");
            XmlAttribute sexo = doc.CreateAttribute("Sexo");
            XmlAttribute raza = doc.CreateAttribute("Raza");
            XmlAttribute peso = doc.CreateAttribute("Peso");
            XmlAttribute edad = doc.CreateAttribute("Edad");
            XmlAttribute fechaentrada = doc.CreateAttribute("FechaEntrada");
            XmlAttribute chip = doc.CreateAttribute("Chip");
            XmlAttribute ppp = doc.CreateAttribute("PPP");
            XmlAttribute vacunado = doc.CreateAttribute("Vacunado");
            XmlAttribute esterilizado = doc.CreateAttribute("Esterilizado");
            XmlAttribute apadrinado = doc.CreateAttribute("Apadrinado");
            XmlAttribute enfermedades = doc.CreateAttribute("Enfermedades");
            XmlAttribute tratamientos = doc.CreateAttribute("Tratamientos");
            XmlAttribute datosinte = doc.CreateAttribute("OtrosDatos");
            XmlAttribute estado = doc.CreateAttribute("Estado");
            XmlAttribute foto = doc.CreateAttribute("Foto");
            XmlAttribute galeria = doc.CreateAttribute("Galeria");

            idperro.Value = perr.getsetIdPerro.ToString();
            nombre.Value = perr.getsetNombre.ToString();
            sexo.Value = perr.getsetSexo.ToString();
            raza.Value = perr.getsetRaza.ToString();
            peso.Value = perr.getsetPeso.ToString();
            edad.Value = perr.getsetEdad.ToString();
            fechaentrada.Value = perr.getsetFechaEntrada.ToString();
            chip.Value = perr.getsetChip.ToString();
            ppp.Value = perr.getsetPPP.ToString();
            vacunado.Value = perr.getsetVacunado.ToString();
            esterilizado.Value = perr.getsetEsterilizado.ToString();
            apadrinado.Value = true.ToString();
            enfermedades.Value = perr.getsetEnfermedades.ToString();
            tratamientos.Value = perr.getsetTratamientos.ToString();
            datosinte.Value = perr.getsetDatosInteres.ToString();
            estado.Value = perr.getsetEstado.ToString();
            foto.Value = perr.getsetFoto.ToString(); ;


            perro.Attributes.Append(idperro);
            perro.Attributes.Append(nombre);
            perro.Attributes.Append(sexo);
            perro.Attributes.Append(raza);
            perro.Attributes.Append(peso);
            perro.Attributes.Append(edad);
            perro.Attributes.Append(fechaentrada);
            perro.Attributes.Append(chip);
            perro.Attributes.Append(ppp);
            perro.Attributes.Append(vacunado);
            perro.Attributes.Append(esterilizado);
            perro.Attributes.Append(apadrinado);
            perro.Attributes.Append(enfermedades);
            perro.Attributes.Append(tratamientos);
            perro.Attributes.Append(datosinte);
            perro.Attributes.Append(estado);
            perro.Attributes.Append(foto);
            perro.Attributes.Append(galeria);

            perros.AppendChild(perro);
           
            doc.Save(rutaXmlPadrinos);

            MessageBox.Show(p.getsetNombre +" ha apadrinado a "+ nombre.Value.ToString());

        }
        private void lstbx_Perros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_Apadrinar.IsEnabled = true;
        }

        private void btn_Apadrinar_Click(object sender, RoutedEventArgs e)
        {
            añadirApadrinamiento();
            cargarDatos();        
            lstbx_Perros.Items.Refresh();
        }

        private void btn_Atras_Click_1(object sender, RoutedEventArgs e)
        {
            pad = new IU_Padrinos(t);
            pad.Show();
            this.Close();
        }
    }
}
