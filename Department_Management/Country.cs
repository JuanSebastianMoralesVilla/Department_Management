using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department_Management
{

   public  class Country{
        public List<Department> departments{get;set;}
        public int size{get;set;}

        public Country (){
            departments = new List<Department>();
            size = 0;
        }

        public void add(int idDepartment,int idTown,string nameDepartmen,string nameTown,string type){
            Department depart = null;
            for(int i = 0; i < size; i++)
            {
                if (departments.ElementAt(i).id == idDepartment)
                {
                    depart = departments.ElementAt(i);
                    break;
                }
            }
            
            if(depart==null){
                depart = new Department(idDepartment,nameDepartmen);
                departments.Add(depart);
                size++;
            }
            
            depart.add(idTown, nameTown, type);
        }

        public String[] getDepartments()
        {
            departments.Sort();
            string[] names = new string[size];
            for(int i = 0; i < size; i++)
            {
                names[i] = departments.ElementAt(i).name;
            }
            return names;
        }

        public int[] getAmmount()
        {
            
            int[] ammount = new int[size];
            for (int i = 0; i < size; i++)
            {
                ammount[i] = departments.ElementAt(i).size;
            }
            return ammount;
        }
    }
}
