using NpgSqlConnections.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpgSqlConnections.Services.Intefaces
{
    internal interface ICRUDBase
    {
        public void create(string table, string columns);
        public IEnumerable<T> getTable<T>(string table);
        public void update(string table, string column,string newInfo,string condition);
        public void delete(string table,string condition);
        public void insert(string table, string columns_forInsert,string info);

    }
}
