using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2TAREA12.Models
{
    public class Empleado
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        [MaxLength(100)]
        public string nombres { get; set; }
        [MaxLength(100)]
        public string apellidos { get; set; }

        public int edad { get; set; }

        public string correo { get; set; }

        public string direccion { get; set; }


    }
}
