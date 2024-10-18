using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiApp1.Models
{

    [Table("Autores")]

    public class Autores
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nombres { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Pais { get; set; } = string.Empty;

        public string DisplayInfo => $"{Id}. {Nombres} ({Pais})";

    }
}
