using Npgsql;
using NpgSqlConnections.Manager;
using NpgSqlConnections.Services.Classes;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;

namespace NpgSqlConnections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ManagerConnection managerConnection = new ManagerConnection();
                managerConnection.Start();
            }   
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }


            #region ss  
            //string _connectionString = "Host=localhost; Port=5432; Database=visualstudio; User Id=javlon; Password=123;";
            //string insertingCommand = $"insert into persons(name,money) values('javlon',1000.0)";
            //using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
            //connection.Open();
            //NpgsqlCommand command = new NpgsqlCommand(insertingCommand, connection);
            //var effectedRows = command.ExecuteNonQuery();
            //Console.WriteLine(effectedRows);
            //if (effectedRows >0)
            //{
            //    Console.WriteLine("Succes do");
            //}
            //else
            //{
            //    Console.WriteLine("no Succes command");
            //}
            //connection.Close();
            #endregion
        }
    }
}