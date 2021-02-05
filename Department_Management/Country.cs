using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department_Management
{

   public  class Country{
        private List<Department> departments{get;set;}
        private int last {get;set;}
        private int size{get;set;}

        public Country (){
            departments = new List<Department>();
            last = -1;
            size = 0;
        }

        public void add(int idDepartment,string idTown,string nameDepartmen,string nameTown,string type){
            Department depart = null;
            if(last!=idDepartment){
                last = idDepartment;
                depart = new Department(idDepartment,nameDepartmen);
                departments.Add(depart);
                size++;
            }else{
                //depart = departments.IndexOf();
            }
        }
    }
}
