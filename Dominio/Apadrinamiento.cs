using System;

public class Apadrinamiento
{
    private int IdApadrinamiento { get; set; }
    private int IdPadrino { get; set; }
    private int IdPerro { get; set; }
    private DateTime FechaComienzoApadrinamiento { get; set; }


  

    public Apadrinamiento(int IdApadrinamiento, int IdPadrino, int IdPerro, DateTime FechaComienzoApadrinamiento)
    {
        this.IdApadrinamiento = IdApadrinamiento;
        this.IdPadrino = IdPadrino;
        this.IdPerro = IdPerro;
        this.FechaComienzoApadrinamiento = FechaComienzoApadrinamiento;
    }
   

    public int getsetIdApadrinamiento
    {
        get
        {
            return IdApadrinamiento;
        }
        set
        {
            IdApadrinamiento = value;
        }
    }

    public int getsetIdPadrino
    {
        get
        {
            return IdPadrino;
        }
        set
        {
            IdPadrino = value;
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

    public DateTime getsetFechaComienzoApadrinamiento
    {
        get
        {
            return FechaComienzoApadrinamiento;
        }
        set
        {
            FechaComienzoApadrinamiento = value;
        }
    }
}

