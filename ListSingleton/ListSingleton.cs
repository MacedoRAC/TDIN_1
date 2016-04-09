using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class ListSingleton : MarshalByRefObject, IListSingleton
{
    List<Table> TablesList;
    public event AlterDelegate AlterEvent;
    public int Type = 2;

    public ListSingleton()
    {
        Console.WriteLine("Constructor called.");
        TablesList = new List<Table>();
    }

    public override object InitializeLifetimeService()
    {
        return null;
    }

    public List<Table> GetTablesList()
    {
        Console.WriteLine("GetList() called.");
        return TablesList;
    }

    public int GetNewType()
    {
        return Type++;
    }

    public void AddTable(Table table)
    {
        TablesList.Add(table);
        NotifyClients(Operation.New, table);
    }

    void NotifyClients(Operation op, Table item)
    {
        if (AlterEvent != null)
        {
            Delegate[] invkList = AlterEvent.GetInvocationList();

            foreach (AlterDelegate handler in invkList)
            {
                new Thread(() =>
                {
                    try
                    {
                        handler(op, item);
                        Console.WriteLine("Invoking event handler");
                    }
                    catch (Exception)
                    {
                        AlterEvent -= handler;
                        Console.WriteLine("Exception: Removed an event handler");
                    }
                }).Start();
            }
        }
    }
}