using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department_Management
{
    public class AllTowns
    {
        private int idDepartment { get; set; }
        private int idTown { get; set; }
        private string nameDepartment { get; set;}
        private string nameTown { get; set; }
        private string type { get; set; }

        public AllTowns(int idDepartment,int idTown,string nameDepartment,string nameTown, string type)
        {
            this.idDepartment = idDepartment;
            this.idTown = idTown;
            this.nameDepartment = nameDepartment;
            this.nameTown = nameTown;
            this.type = type;
        }

        override
            public String ToString()
        {
            return idDepartment + " " + idTown + " " + nameDepartment + " " + nameTown + " " + type;
        }
    }
}
