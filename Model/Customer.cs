using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpgSqlConnections.Model
{
    internal class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Product product_id { get; set; }
    }
}
