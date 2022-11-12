using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Back_End_BD.Models
{
    public class Alumnos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
    }
}