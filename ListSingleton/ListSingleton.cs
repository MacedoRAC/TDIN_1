using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class ListSingleton : MarshalByRefObject, IListSingleton
{
    List<Table> TablesList;
    public event AlterDelegate AlterEvent;
    public event OrderDelegate OrderEvent;
    public event OrderDelegate KitchenEvent;
    public event OrderDelegate BarEvent;
    public int Type = 2;

    public Dictionary<string, Product> menu;

    public ListSingleton()
    {
        Console.WriteLine("Constructor called.");
        TablesList = new List<Table>();
        initializeMenu();
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

    public void AddOrder(Order o, int tableID)
    {
        foreach (Table t in TablesList)
            if (t.Equals(tableID))
                t.addOrder(o);
        NotifyClients(Operation.New, o, tableID);
    }

    void NotifyClients(Operation op, Order order, int tableId)
    {
        if (OrderEvent != null)
        {
            Delegate[] roomList = OrderEvent.GetInvocationList();
            Delegate[] prepList = new Delegate[0];
            Delegate[] invkList;

            if (order.Product.Bar && BarEvent != null)
            {
                prepList = BarEvent.GetInvocationList();
            }
            if (!order.Product.Bar&& KitchenEvent != null)
            {
                prepList = KitchenEvent.GetInvocationList();
            }

            //Put Every Handler in a single Delegate[] to have only 1 cicle
            invkList = new Delegate[roomList.Length + prepList.Length];
            roomList.CopyTo(invkList, 0);
            prepList.CopyTo(invkList, roomList.Length);

            foreach (OrderDelegate handler in invkList)
            {
                new Thread(() =>
                {
                    try
                    {
                        handler(op, order, tableId);
                        Console.WriteLine("Invoking event handler");
                    }
                    catch (Exception)
                    {
                        OrderEvent -= handler;
                        Console.WriteLine("Exception: Removed an event handler");
                    }
                }).Start();
            }
        }
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


    private void initializeMenu()
    {
        menu = new Dictionary<string, Product>();
        menu.Add("Água", new Product(0.7f, "Água"));
        menu.Add("Coca-cola", new Product(1f, "Coca-cola"));
        menu.Add("Super Bock", new Product(0.7f, "Super Bock"));
        menu.Add("Vinho Bramco da Casa", new Product(0.7f, "Vinho Branco da Casa"));
        menu.Add("Vinho Tinto da Casa", new Product(0.7f, "Vinho Tinto da Casa"));

        menu.Add("Bacalhau com Natas", new Product(0.7f, "Bacalhau com Natas", false));
        menu.Add("Vitela Mendinha", new Product(0.7f, "Vitela Mendinha", false));
        menu.Add("Francesinha Especial", new Product(0.7f, "Francesinha Especial", false));
        menu.Add("Leitão no forno", new Product(0.7f, "Leitão no forno", false));
        menu.Add("Sandes de Leitão", new Product(0.7f, "Sandes de Leitão"));

        menu.Add("Leite Creme", new Product(0.7f, "Leite Creme"));
        menu.Add("Bolo do Bolacha", new Product(0.7f, "Bolo de Bolacha"));
        menu.Add("Mousse de Manga", new Product(0.7f, "Mousse de Manga"));



    }

    public Dictionary<string, Product> GetMenu()
    {
        return menu;
    }
}