﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department_Management
{
    public class Town
    {
        private string name { get; set; }
        private int id { get; set; }
        private string type { get; set; }
        public Town(string name, int id, string type)
        {
            this.name = name;
            this.id = id;
            this.type = type;
        }
    }
}