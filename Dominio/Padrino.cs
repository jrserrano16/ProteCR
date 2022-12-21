using System;
using System.Collections.Generic;

public class Padrino : Persona
{
    public double AportacionMensual { get; set; }
    public string FormaPago { get; set; }
    public string NumeroCuenta { get; set; }
    public List<Perro> ListadoPerros = new List<Perro>();



    public Padrino(int IdPersona, string Nombre, string Apellidos, string Telefono, string DNI, string Sexo, DateTime FechaNacimiento, string Domicilio, double AportacionMensual, string FormaPago, string NumeroCuenta)
        : base(IdPersona, Nombre, Apellidos, Telefono, DNI, Sexo, FechaNacimiento, Domicilio)
    {
        this.AportacionMensual = AportacionMensual;
        this.FormaPago = FormaPago;
        this.NumeroCuenta = NumeroCuenta;
    }

    

    public double getsetAportacionMensual
    {
        get
        {
            return AportacionMensual;
        }
        set
        {
            AportacionMensual = value;
        }
    }

    public string getsetFormaPago
    {
        get
        {
            return FormaPago;
        }
        set
        {
            FormaPago = value;
        }
    }

    public string getsetNumeroCuenta
    {
        get
        {
            return NumeroCuenta;
        }
        set
        {
            NumeroCuenta = value;
        }
    }

    public List<Perro> getsetListadoPerros
    {
        get
        {
            return ListadoPerros;
        }
        set
        {
            ListadoPerros = value;
        }
    }
}
