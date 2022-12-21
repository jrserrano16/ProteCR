using System;

public class Persona
{
    public int IdPersona { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Telefono { get; set; }
    public string DNI { get; set; }
    public string Sexo { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Domicilio { get; set; }

   

    public Persona(int IdPersona, string Nombre, string Apellidos, string Telefono, string DNI, string Sexo, DateTime FechaNacimiento, string Domicilio)
    {
        this.IdPersona = IdPersona;
        this.Nombre = Nombre;
        this.Apellidos = Apellidos;
        this.Telefono = Telefono;
        this.DNI = DNI;
        this.Sexo = Sexo;
        this.FechaNacimiento = FechaNacimiento;
        this.Domicilio = Domicilio;
    }



    public int getsetIdPersona
    {
        get
        {
            return IdPersona;
        }
        set
        {
            IdPersona = value;
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

    public string getsetApellidos
    {
        get
        {
            return Apellidos;
        }
        set
        {
            Apellidos = value;
        }
    }

    public string getsetTelefono
    {
        get
        {
            return Telefono;
        }
        set
        {
            Telefono = value;
        }
    }

    public string getsetDNI
    {
        get
        {
            return DNI;
        }
        set
        {
            DNI = value;
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

    public DateTime getsetFechaNacimiento
    {
        get
        {
            return FechaNacimiento;
        }
        set
        {
            FechaNacimiento = value;
        }
    }

    public string getsetDomicilio
    {
        get
        {
            return Domicilio;
        }
        set
        {
            Domicilio = value;
        }
    }
}
