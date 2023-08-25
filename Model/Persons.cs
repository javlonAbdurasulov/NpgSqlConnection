using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpgSqlConnections.Model
{
    internal class Persons
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public float Money { get; set; }
        public override string ToString()
        {
            return $"{Id},{Name},{Money}";

        }
    }
}
