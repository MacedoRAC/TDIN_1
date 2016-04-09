using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class ListSingleton : MarshalByRefObject, IListSingleton
{
    List<Meal> ItemsList;
    public event AlterDelegate AlterEvent;
    public int Type = 2;

    public ListSingleton()
    {
        Console.WriteLine("Constructor called.");
        ItemsList = new List<Meal>();

    }

    public override object InitializeLifetimeService()
    {
        return null;
    }

    public List<Meal> GetList()
    {
        Console.WriteLine("GetList() called.");
        return ItemsList;
    }

    public int GetNewType()
    {
        return Type++;
    }

    public void AddItem(Meal item)
    {
        ItemsList.Add(item);
        NotifyClients(Operation.New, item);
    }

    public void ChangeComment(int type, string comment)
    {
        Meal nitem = null;

        foreach (Meal it in ItemsList)
        {
            if (it.Table == type)
            {
                nitem = it;
                break;
            }
        }
        NotifyClients(Operation.Change, nitem);
    }

    void NotifyClients(Operation op, Meal item)
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