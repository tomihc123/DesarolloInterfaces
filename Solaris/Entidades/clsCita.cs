using System;

namespace Entidades
{
    public class clsCita
    {
        #region Properties 
        public string diaSemana { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string calle { get; set; }
        public int codigoPostal { get; set; }
        public string ciudad { get; set; }
        public double longitud { get; set; }
        public double latitud { get; set; }
        #endregion


        #region Constructors 
        //Constructor por defecto
        public clsCita()
        {
            diaSemana = "Lunes";
            fecha = "28/10";
            hora = "9:00";
            calle = "c/Urbano";
            codigoPostal = 41400;
            ciudad = "Sevilla";
        }


        //Constructor con parametros
        public clsCita(string diaSemana, string fecha, string hora, string calle, int codigoPostal, string ciudad, double longitud, double latitud)
        {
            this.diaSemana = diaSemana;
            this.fecha = fecha;
            this.hora = hora;
            this.calle = calle;
            this.codigoPostal = codigoPostal;
            this.ciudad = ciudad;
            this.longitud = longitud;
            this.latitud = latitud;
        }
        #endregion


    }

}