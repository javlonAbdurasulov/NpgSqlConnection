﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpgSqlConnections.Services.Intefaces
{
    internal interface ICRUDConnection:ICRUDBase
    {
        public IEnumerable<T> ConnectionReadMethod<T>(string insertingCommand);
        public IEnumerable<T> readData<T>(NpgsqlDataReader reader);
        public Task<IEnumerable<object>> getJoinTable<T1,T2>(string table1, string table2);
    }
}
