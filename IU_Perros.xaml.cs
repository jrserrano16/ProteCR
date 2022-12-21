using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using Microsoft.Win32;
using ProteCR.Otras_Clases;
using Brushes = System.Windows.Media.Brushes;

namespace ProteCR
{
    /// <summary>
    /// Lógica de interacción para IU_Perros.xaml
    /// </summary>
    public partial class IU_Perros : Window
    {
        private List<Perro> listadoperros;
        private AuxClass aux= new AuxClass();
        private Window1 win1;
        private String t;
        private String rutaXmlPadrinos;
        private String rutaXmlPerros;

        public IU_Perros(String t)
        {
            this.t = t;
            String rutaBin = Directory.GetCurrentDirectory().ToString();
            int hasta = rutaBin.IndexOf("\\bin");
            String rutasub = rutaBin.Substring(0, hasta);

            this.rutaXmlPadrinos = String.Concat(rutasub, "\\Datos\\Padrinos.xml");
            this.rutaXmlPerros = String.Concat(rutasub, "\\Datos\\Perros.xml");
            InitializeComponent();
            clear();
            cargarDatos();


        }

        private void cargarDatos()
        {
            listadoperros = CargarContenidoXML();
            lstbx_Perros.DataContext = listadoperros;
        }
        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MessageBox.Show("Gracias por usar la aplicación:)!!");
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
                listado.Add(nuevoperro);
            }
            return listado;
        }
        private bool comprobarAllControls()
        {
            if (aux.comprobarControl(txt_Nombre) & aux.comprobarControl(txt_Edad) & aux.comprobarControl(txtbox_Raza) & aux.comprobarControl(txtbox_Peso) & aux.comprobarControl(txt_Nombre) & aux.comprobarControl(dp_Fecha) & aux.comprobarControl(cbGenero) & aux.comprobarControl(cb_Estado))
            {
                return true;
            }
            else
                return false;
        }

        private bool comprobarInt()
        {
            if (aux.intervalo(txt_Edad,0,20) & aux.intervalo(txtbox_Peso, 0, 100))
            {
                return true;
            }
            else
                return false;
        }
        private void MostrarFoto(int id)
        {
            BitmapImage b;
            if (id >= 0)
            {
                b = new BitmapImage(new Uri(listadoperros[id].getsetFoto.ToString(), UriKind.Relative));
                img_Perro.Source = b;
            }
            else
                b = new BitmapImage(new Uri("/src/Perros/no_dog.png", UriKind.Relative));
            img_Perro.Source = b;
           
        }
        private void añadirPerros()
        {
            
           
            XmlDocument doc = new XmlDocument();
            doc.Load(rutaXmlPerros);
            XmlNode root = doc.SelectSingleNode("Perros");
            XmlElement perro = doc.CreateElement("Perro");
            root.AppendChild(perro);

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

            int valor = 0;
            if (listadoperros.Count == 0)
            {
                valor = 0;
            }
            else
                valor = (listadoperros[listadoperros.Count - 1].getsetIdPerro + 1);



            idperro.Value = valor.ToString();
            int id = (listadoperros[listadoperros.Count - 1].getsetIdPerro + 1);
            idperro.Value = id.ToString();
            nombre.Value = txt_Nombre.Text;
            sexo.Value = cbGenero.Text;
            raza.Value = txtbox_Raza.Text;
            peso.Value = txtbox_Peso.Text;
            edad.Value = txt_Edad.Text;
            fechaentrada.Value = dp_Fecha.Text;
            chip.Value = chb_Chip.IsChecked.ToString();
            ppp.Value = chb_ppp.IsChecked.ToString();
            vacunado.Value = chb_vacunado.IsChecked.ToString();
            esterilizado.Value = chb_esterilizado.IsChecked.ToString();
            apadrinado.Value = chb_padrino.IsChecked.ToString();
            enfermedades.Value = aux.txbSinDatos(txt_Enfermedades);           
            tratamientos.Value = aux.txbSinDatos(txt_Tratamiento1);
            datosinte.Value = aux.txbSinDatos(txt_OtrosDtos);
            estado.Value = cb_Estado.Text;
            BitmapImage b = aux.abrirImagen();
            img_Perro.Source = b;
          
                String nombrefile = Path.GetFileNameWithoutExtension(img_Perro.Source.ToString());
                String extension = Path.GetExtension(img_Perro.Source.ToString());
                foto.Value = String.Concat("/src/Perros/",nombrefile,extension);


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


            doc.Save(rutaXmlPerros);
            
        }

        

        private void lstbx_Perros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_Editar.IsEnabled = true;
            btn_Eliminar.IsEnabled = true;
            btn_Añadir.IsEnabled = false;
            btn_add_imagenPrin.IsEnabled = true;
            MostrarFoto(lstbx_Perros.SelectedIndex);
        }
        private void ResetBrushes()
        {
            aux.ResetBrush(txt_Nombre);
            aux.ResetBrush(txt_Edad);
            aux.ResetBrush(txtbox_Raza);
            aux.ResetBrush(txtbox_Peso);
            aux.ResetBrush(txt_Nombre);
            aux.ResetBrush(dp_Fecha);
            aux.ResetBrush(cbGenero);
            aux.ResetBrush(cb_Estado);
        }
        private void btn_Limpiar_Click(object sender, RoutedEventArgs e)
        {
            cargarDatos();
            lstbx_Perros.Items.Refresh();
            clear();
            btn_Editar.IsEnabled = false;
            btn_Eliminar.IsEnabled = false;
            btn_Añadir.IsEnabled = true;
            btn_add_imagenPrin.IsEnabled = true;
            btn_add_imagenPrin.IsEnabled = false;
            ResetBrushes();
        }
        private void clear()
        {
            txtbox_Peso.Text = string.Empty;
            txt_Nombre.Text = string.Empty;
            txt_Edad.Text = string.Empty;
            txtbox_Raza.Text = string.Empty;
            txt_Enfermedades.Text = string.Empty;
            txt_Tratamiento1.Text = string.Empty;
            txt_OtrosDtos.Text = string.Empty;

           
            cbGenero.Text = String.Empty;
            cb_Estado.Text = String.Empty;

            chb_Chip.IsChecked = false;
            chb_esterilizado.IsChecked = false;
            chb_ppp.IsChecked = false;
            chb_vacunado.IsChecked = false;
            
        } 
        private void btn_Editar_Click(object sender, RoutedEventArgs e)
        {
            aux.ButtonSwitch(sender, e, btn_Editar, btn_Eliminar, btn_Añadir);
            if (comprobarAllControls() & comprobarInt())
            {
                actualizarPerro();
                btn_Limpiar_Click(sender, e);
                btn_add_imagenPrin.Visibility = Visibility.Visible;
                MessageBox.Show("Perro editado con exito");
            }
            else
                MessageBox.Show("No se rellenó alguno de los campos obligatorios o el formato es incorrecto");
        }



        private void btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            aux.ButtonSwitch(sender, e, btn_Eliminar, btn_Añadir, btn_Editar);
            XmlDocument doc = new XmlDocument();
            XmlDocument doc1 = new XmlDocument();
            doc.Load(rutaXmlPerros);
            XmlNode root = doc.SelectSingleNode("Perros");
            int id = listadoperros[lstbx_Perros.SelectedIndex].getsetIdPerro;
            doc1.Load(rutaXmlPadrinos);
            XmlNode root1 = doc1.SelectSingleNode("Padrinos");
            if (root1.HasChildNodes) 
            { 
                foreach (XmlNode node in root1.ChildNodes)
                {
                    if (node.HasChildNodes)
                    {
                        foreach(XmlNode subnode in node.ChildNodes)
                        {
                            if (subnode.HasChildNodes)
                            {
                                foreach(XmlNode subnode1 in subnode.ChildNodes)
                                {
                                    string identifier = subnode1.Attributes["IdPerro"].Value.ToString();
                                    if (identifier.Equals(id.ToString()))
                                    {
                                        subnode.RemoveChild(subnode1);
                                    }
                                }
                            }
                        }
                    }
                   
                }
            }
            doc1.Save(rutaXmlPadrinos);
            XmlNode target = root.SelectSingleNode("Perro [@IdPerro = "+id.ToString()+"]");
            root.RemoveChild(target);
            doc.Save(rutaXmlPerros);
            MessageBox.Show(target.Attributes["Nombre"].Value.ToString() + " Eliminado.");      
            listadoperros.RemoveAt(lstbx_Perros.SelectedIndex);
            btn_Limpiar_Click(sender, e);

        }

        private void btn_Añadir_Click(object sender, RoutedEventArgs e)
        {
            aux.ButtonSwitch(sender, e, btn_Añadir, btn_Editar, btn_Eliminar);
            if (comprobarAllControls() & comprobarInt())
            {   
                añadirPerros();
                btn_Limpiar_Click(sender, e);
                btn_add_imagenPrin.Visibility = Visibility.Visible;
                MessageBox.Show("Perro añadido con exito");

            }
            else
                MessageBox.Show("No se rellenó alguno de los campos obligatorios o el formato es incorrecto");

        }
        
    
      
        private void actualizarPerro()
        {            
            XmlDocument doc = new XmlDocument();
            doc.Load(rutaXmlPerros);
            XmlNode root = doc.SelectSingleNode("Perros");
            int id = listadoperros[lstbx_Perros.SelectedIndex].getsetIdPerro;
            XmlNode target = root.SelectSingleNode("Perro [@IdPerro = " + id.ToString() + "]");
            target.Attributes["Nombre"].Value = txt_Nombre.Text;
            target.Attributes["Sexo"].Value = cbGenero.Text;
            target.Attributes["Raza"].Value = txtbox_Raza.Text;
            target.Attributes["Peso"].Value = txtbox_Peso.Text;
            target.Attributes["Edad"].Value = txt_Edad.Text;
            target.Attributes["FechaEntrada"].Value = dp_Fecha.Text;
            target.Attributes["Chip"].Value = chb_Chip.IsChecked.ToString();
            target.Attributes["PPP"].Value = chb_ppp.IsChecked.ToString();
            target.Attributes["Vacunado"].Value = chb_vacunado.IsChecked.ToString();
            target.Attributes["Esterilizado"].Value = chb_esterilizado.IsChecked.ToString();
            target.Attributes["Apadrinado"].Value = chb_padrino.IsChecked.ToString();
            target.Attributes["Enfermedades"].Value = txt_Enfermedades.Text;
            target.Attributes["Tratamientos"].Value = txt_Tratamiento1.Text;
            target.Attributes["OtrosDatos"].Value = txt_OtrosDtos.Text;
            target.Attributes["Estado"].Value = cb_Estado.Text;
            

            doc.Save(rutaXmlPerros);

            XmlDocument doc1 = new XmlDocument();
            doc1.Load(rutaXmlPadrinos);
            XmlNode root1 = doc1.SelectSingleNode("Padrinos");
            if (root1.HasChildNodes)
            {
                foreach (XmlNode node in root1.ChildNodes)
                {
                    if (node.HasChildNodes)
                    {
                        foreach (XmlNode subnode in node.ChildNodes)
                        {
                            if (subnode.HasChildNodes)
                            {
                                foreach (XmlNode subnode1 in subnode.ChildNodes)
                                {
                                    string identifier = subnode1.Attributes["IdPerro"].Value.ToString();
                                    if (identifier.Equals(id.ToString()))
                                    {
                                        subnode1.Attributes["Nombre"].Value = target.Attributes["Nombre"].Value;
                                        subnode1.Attributes["Sexo"].Value = target.Attributes["Sexo"].Value;
                                        subnode1.Attributes["Raza"].Value = target.Attributes["Raza"].Value;
                                        subnode1.Attributes["Peso"].Value = target.Attributes["Peso"].Value;
                                        subnode1.Attributes["Edad"].Value = target.Attributes["Edad"].Value;
                                        subnode1.Attributes["FechaEntrada"].Value = target.Attributes["FechaEntrada"].Value;
                                        subnode1.Attributes["Chip"].Value = target.Attributes["Chip"].Value;
                                        subnode1.Attributes["PPP"].Value = target.Attributes["PPP"].Value;
                                        subnode1.Attributes["Vacunado"].Value = target.Attributes["Vacunado"].Value;
                                        subnode1.Attributes["Esterilizado"].Value = target.Attributes["Esterilizado"].Value;
                                        subnode1.Attributes["Apadrinado"].Value = target.Attributes["Apadrinado"].Value;
                                        subnode1.Attributes["Enfermedades"].Value = target.Attributes["Enfermedades"].Value;
                                        subnode1.Attributes["Tratamientos"].Value = target.Attributes["Tratamientos"].Value;
                                        subnode1.Attributes["OtrosDatos"].Value = target.Attributes["OtrosDatos"].Value;
                                        subnode1.Attributes["Estado"].Value = target.Attributes["Estado"].Value;
                                        subnode1.Attributes["Foto"].Value = target.Attributes["Foto"].Value;

                                    }
                                }
                            }
                        }
                    }

                }
            }
            doc1.Save(rutaXmlPadrinos);

        }

        private void bt_Atras_Click(object sender, RoutedEventArgs e)
        {
            win1 = new Window1(t);
            win1.Show();
            this.Close();
        }

        private void btn_add_imagenPrin_Click(object sender, RoutedEventArgs e)
        {
            if (lstbx_Perros.SelectedIndex >= 0)
            {

           
            BitmapImage b = aux.abrirImagen();
            img_Perro.Source = b;
            XmlDocument doc = new XmlDocument();
            doc.Load(rutaXmlPerros);
            XmlNode root = doc.SelectSingleNode("Perros");
            int id = listadoperros[lstbx_Perros.SelectedIndex].getsetIdPerro;
            String nombrefile = Path.GetFileNameWithoutExtension(img_Perro.Source.ToString());
            String extension = Path.GetExtension(img_Perro.Source.ToString());
            String.Concat(nombrefile, extension);
            XmlNode target = root.SelectSingleNode("Perro [@IdPerro = " + id.ToString() + "]");
            target.Attributes["Foto"].Value = "/src/Perros/"+ String.Concat(nombrefile, extension);
            doc.Save(rutaXmlPerros);
            btn_Editar_Click(sender, e);
        }
        }
    }
}
