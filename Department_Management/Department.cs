﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department_Management
{
    public class Department
    {
        private List<Town> towns { get; set; }
        private string name { get; set; }
        private int id { get; set; }
        private int size { get; set; }
        public Department(int id, string name)
        {
            towns = new List<Town>();
            this.name = name;
            this.id = id;
            size = 0;
        }
        public void add(int idTown, string nameTown, string type)
        {

        }
    }
}