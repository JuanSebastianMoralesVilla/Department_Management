using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department_Management
{
    public class Town
    {
        public string name { get; set; }
        public int id { get; set; }
        public string type { get; set; }
        public const string MUNICIPIO = "Municipio";
        public const string ISLA = "Isla";
        public const string NO_MUNICIPALIZADA = "Área no municipalizada";
        public Town(string name, int id, string type)
        {
            this.name = name;
            this.id = id;
            this.type = type;
        }
    }
}
