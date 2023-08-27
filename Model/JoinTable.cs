using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpgSqlConnections.Model
{
    internal class JoinTable<T1,T2>
    {
        public T1 first { get; set; }
        public (T1,T2) _joins { get; set; }
        public T2 second { get; set; }
    }
}
