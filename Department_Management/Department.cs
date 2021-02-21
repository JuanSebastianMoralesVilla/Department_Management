using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department_Management
{
    public class Department : IComparable<Department>
    {
        public List<Town> towns { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public int size { get; set; }
        public Department(int id, string name)
        {
            towns = new List<Town>();
            this.name = name;
            this.id = id;
            size = 0;
        }
        public void add(int idTown, string nameTown, string type)
        {
            Town town = new Town(nameTown, idTown, type);
            towns.Add(town);
            size++;
        }

        public int CompareTo(Department department)
        {
            return size - department.size;
        }
    }
}
