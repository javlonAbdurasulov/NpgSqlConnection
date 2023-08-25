﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpgSqlConnections.Model
{
    internal class Cars
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public override string ToString()
        {
            return $"{Id},{Name},{Price}";
        }
    }
}
