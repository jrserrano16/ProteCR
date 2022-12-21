using System;

public class Voluntario : Persona
{
    public string Email { get; set; }
    public string HorarioDisponibilidad { get; set; }
    public string ZonaDisponibilidad { get; set; }
    public bool ConocimientosVeterinarios { get; set; }


    public Voluntario(int IdPersona, string Nombre, string Apellidos, string Telefono, string DNI, string Sexo, DateTime FechaNacimiento, string Domicilio, string Email, string HorarioDisponibilidad, string ZonaDisponibilidad, bool ConocimientosVeterinarios)
    : base(IdPersona, Nombre, Apellidos, Telefono, DNI, Sexo, FechaNacimiento, Domicilio)
    {
        this.Email = Email;
        this.HorarioDisponibilidad = HorarioDisponibilidad;
        this.ZonaDisponibilidad = ZonaDisponibilidad;
        this.ConocimientosVeterinarios = ConocimientosVeterinarios;
    }

    public string getsetEmail
    {
        get
        {
            return Email;
        }
        set
        {
            Email = value;
        }
    }


    public string getsetHorarioDisponibilidad
    {
        get
        {
            return HorarioDisponibilidad;
        }
        set
        {
            HorarioDisponibilidad = value;
        }
    }

    public string getsetZonaDisponibilidad
    {
        get
        {
            return ZonaDisponibilidad;
        }
        set
        {
            ZonaDisponibilidad = value;
        }
    }

    public bool getsetConocimientosVeterinarios
    {
        get
        {
            return ConocimientosVeterinarios;
        }
        set
        {
            ConocimientosVeterinarios = value;
        }
    }
}