using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Back_End_BD.Models
{
    public class AlumnoDbContext:DbContext
    {
        private static string connection1 = "DefaultConnection";
        public AlumnoDbContext():base(connection1)
        {

        }
        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<Maestros> Maestros { get; set; }
    }
}