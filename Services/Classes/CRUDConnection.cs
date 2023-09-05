using Dapper;
using Npgsql;
using NpgSqlConnections.Model;
using NpgSqlConnections.Services.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;

namespace NpgSqlConnections.Services.Classes
{
    internal class CRUDConnection:ICRUDConnection
    {
        private string _connectionString = "Host=localhost; Port=5432; Database=visualstudio; User Id=javlon; Password=123;";

        public void create(string table, string columns)
        {
            string insertingCommand = $"create table IF NOT EXISTS {table}({columns});";
            Connectionmethod(insertingCommand);
        }
        public void update(string table, string column, string newInfo, string condition)
        {
            condition = condition != "where " ? condition : "";
            string insertingCommand = $"update {table} set {column}={newInfo} {condition}";
            Connectionmethod(insertingCommand);
        }
        public void delete(string table,string condition="")
        {
            condition = condition != "where " ? condition : "";
            string insertingCommand = $"delete from {table} {condition}";
            Connectionmethod(insertingCommand);
        }

        public void insert(string table, string columns_forInsert, string info)
        {
            string insertingCommand = $"insert into {table}({columns_forInsert}) values{info}";
            Connectionmethod(insertingCommand);
        }
        
        public async Task<IEnumerable<object>> getJoinTable<T1,T2>(string table1, string table2)
        {
            string insertingCommand = $"select * from {table1}";
            var res1 = ConnectionReadMethod<T1>(insertingCommand);
            insertingCommand = $"select * from {table2}";
            var res2 = ConnectionReadMethod<T2>(insertingCommand);
            var res = res1.Cast<object>().Union(res2.Cast<object>());

            return res;
        }
        public IEnumerable<T> getTable<T>(string table)
        {
            string insertingCommand = $"select * from {table}";
            var res = ConnectionReadMethod<T>(insertingCommand);
            return res;
        }
        public IEnumerable<T> ConnectionReadMethod<T>(string insertingCommand)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            //NpgsqlCommand command = new NpgsqlCommand(insertingCommand, connection);
            //NpgsqlDataReader reader = command.ExecuteReader();
            
            //var ourData = readData<T>(reader);

            //reader.Close();
            var ourData = connection.Query<T>(insertingCommand).ToList();
            connection.Close();

            return ourData;
        }
        public IEnumerable<T> readData<T>(NpgsqlDataReader reader)
        {
            ICollection<T> list = new List<T>();
            
            while (reader.Read())
            {
                var type = typeof(T);
                T obj = (T)Activator.CreateInstance(type);
                foreach (var prop in type.GetProperties())
                {
                    var propType = prop.PropertyType;
                    prop.SetValue(obj, Convert.ChangeType(reader[prop.Name].ToString(), propType));
                }
                list.Add(obj);
            }
           return list;
        }
        private void Connectionmethod(string insertingCommand)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(insertingCommand, connection);

            var effectedRows = command.ExecuteNonQuery();
            Console.WriteLine(effectedRows);
            if (effectedRows > 0 || effectedRows==-1)
            {
                Console.WriteLine("Succes do");
            }
            else
            {
                Console.WriteLine("no Succes command");
            }
            connection.Close();
        }

        
    }
}
