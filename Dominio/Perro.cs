using System;
//nodo.Attributes["Id"].Value = "Nuevo Valor";
public class Perro
{
    public int IdPerro { get; set; }
    public string Nombre { get; set; }
    public string Sexo { get; set; }
    public string Raza { get; set; }
    public double Peso { get; set; }
    public int Edad { get; set; }
    public DateTime FechaEntrada { get; set; }
    public bool Chip { get; set; }
    public bool PPP { get; set; }
    public bool Vacunado { get; set; }
    public bool Esterilizado { get; set; }
    public bool Apadrinado { get; set; }
    public string Enfermedades { get; set; }
    public string Tratamientos { get; set; }
    public string DatosInteres { get; set; }
    public string Estado { get; set; }
    public Uri Foto { get; set; }





    public Perro(int IdPerro, string Nombre, String Sexo,String Raza, double Peso, int Edad, DateTime FechaEntrada, bool Chip, bool PPP, bool Vacunado, bool Esterilizado, bool Apadrinado,string Enfermedades, string Tratamientos,  string DatosInteres, string Estado, Uri Foto)
    {
        this.IdPerro = IdPerro;
        this.Nombre = Nombre;
        this.Sexo = Sexo;
        this.Raza = Raza;
        this.Peso = Peso;
        this.Edad = Edad;
        this.FechaEntrada = FechaEntrada;
        this.Chip = Chip;
        this.PPP = PPP;
        this.Vacunado = Vacunado;
        this.Esterilizado = Esterilizado;
        this.Apadrinado = Apadrinado;
        this.Enfermedades = Enfermedades;
        this.Tratamientos = Tratamientos;
        this.DatosInteres = DatosInteres;
        this.Estado = Estado;
        this.Foto = Foto;



 
    }

    public Perro()
    {
    }
    public bool getsetApadrinado
    {
        get
        {
            return Apadrinado;
        }
        set
        {
            Apadrinado = value;
        }
    }
    public int getsetIdPerro
    {
        get
        {
            return IdPerro;
        }
        set
        {
            IdPerro = value;
        }
    }

    public string getsetNombre
    {
        get
        {
            return Nombre;
        }
        set
        {
            Nombre = value;
        }
    }
    public Uri getsetFoto
    {
        get
        {
            return Foto;
        }
        set
        {
            Foto = value;
        }
    }

    public string getsetSexo
    {
        get
        {
            return Sexo;
        }
        set
        {
            Sexo = value;
        }
    }
    public string getsetRaza
    {
        get
        {
            return Raza;
        }
        set
        {
            Raza = value;
        }
    }

    public double getsetPeso
    {
        get
        {
            return Peso;
        }
        set
        {
            Peso = value;
        }
    }

    public int getsetEdad
    {
        get
        {
            return Edad;
        }
        set
        {
            Edad = value;
        }
    }
    public DateTime getsetFechaEntrada
    {
        get
        {
            return FechaEntrada;
        }
        set
        {
            FechaEntrada = value;
        }
    }

    public bool getsetChip
    {
        get
        {
            return Chip;
        }
        set
        {
            Chip = value;
        }
    }

   
    public bool getsetPPP
    {
        get
        {
            return PPP;
        }
        set
        {
            PPP = value;
        }
    }

    public bool getsetVacunado
    {
        get
        {
            return Vacunado;
        }
        set
        {
            Vacunado = value;
        }
    }

    public bool getsetEsterilizado
    {
        get
        {
            return Esterilizado;
        }
        set
        {
            Esterilizado = value;
        }
    }
    public string getsetEnfermedades
    {
        get
        {
            return Enfermedades;
        }
        set
        {
            Enfermedades = value;
        }
    }

    public string getsetTratamientos
    {
        get
        {
            return Tratamientos;
        }
        set
        {
            Tratamientos = value;
        }
    }
    public string getsetDatosInteres
    {
        get
        {
            return DatosInteres;
        }
        set
        {
            DatosInteres = value;
        }
    }

    public string getsetEstado
    {
        get
        {
            return Estado;
        }
        set
        {
            Estado = value;
        }
    }

    
}
