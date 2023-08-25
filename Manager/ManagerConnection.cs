using NpgSqlConnections.Model;
using NpgSqlConnections.Services.Classes;
using NpgSqlConnections.Services.Intefaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpgSqlConnections.Manager
{
    internal class ManagerConnection
    {
        private readonly ICRUDConnection _crud;
        public ManagerConnection() {
            _crud = new CRUDConnection();
        }
        public async Task Start()
        {
            bool repeat = true;
            while (repeat)
            {
            string table = "";
            string column = "";
            string info = "";
            string condition = "where ";
            Console.WriteLine("menu:\n1-create\n2-update\n3-delete\n4-insert\n5-select\n0-exit");
            int choose=int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    Console.Write("Table: ");
                    table = Console.ReadLine();
                    Console.Write("Columns - type: exemple: id integer,name varchar \n");
                    column = Console.ReadLine();
                    _crud.create(table, column);
                    break;
                case 2:
                    Console.Write("Table: ");
                    table = Console.ReadLine();
                    Console.Write("Column: ");
                    column = Console.ReadLine();
                    Console.WriteLine("new Info: ");
                    info = Console.ReadLine();
                    Console.WriteLine("Condition: \nexemple:  id=1");
                    condition+= Console.ReadLine();
                    _crud.update(table,column,info,condition);
                    break;
                case 3:
                    Console.Write("Table: ");
                    table = Console.ReadLine();
                    Console.WriteLine("Condition: \nexemple:  id=1 or nothing");
                    condition += Console.ReadLine();
                    _crud.delete(table,condition);
                    break;
                case 4:
                    Console.Write("Table: ");
                    table = Console.ReadLine();
                    Console.Write("Columns: ");
                    column= Console.ReadLine();
                    Console.WriteLine("info: \nexemple: if table(id,name)  => (1,'javlon') and other");
                    info = Console.ReadLine();
                    _crud.insert(table, column, info);
                    break;
                case 5:
                        //string text = "tab;";
                        //var res = _crud.ConnectionReadMethod<Tab>(text);
                        //await Print(_crud.getTable<Tab>("tab"));
                        Console.WriteLine("table: ");
                        table = Console.ReadLine();
                        switch (table)
                        {
                            case "persons":
                                await Print(_crud.getTable<Persons>(table));
                                break;
                            case "cars":
                                await Print(_crud.getTable<Cars>(table));
                                break;

                        }
                        break;
                case 0: 
                    repeat=false;
                    break;
            }
            }
        }
        public async Task Print<T>(IEnumerable<T> persons)
        {
            foreach (var item in persons)
            {
                Console.WriteLine(item.ToString());
            }
            
        }
    }
}
