using System;

public class Socio : Persona
{
    public string NumeroCuenta { get; set; }
    public double CuantiaAyuda { get; set; }
    public string FormaPago { get; set; }



    public Socio(int IdPersona, string Nombre, string Apellidos, string Telefono, string DNI, string Sexo, DateTime FechaNacimiento, string Domicilio, string NumeroCuenta, double CuantiaAyuda, string FormaPago)
        : base(IdPersona, Nombre, Apellidos, Telefono, DNI, Sexo, FechaNacimiento, Domicilio)
    {
        this.NumeroCuenta = NumeroCuenta;
        this.CuantiaAyuda = CuantiaAyuda;
        this.FormaPago = FormaPago;
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

    public double getsetCuantiaAyuda
    {
        get
        {
            return CuantiaAyuda;
        }
        set
        {
            CuantiaAyuda = value;
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
}
