using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class ListSingleton : MarshalByRefObject, IListSingleton
{
    List<Table> TablesList;
    public List<Table> PaymentList { get; set; }
    public event AlterDelegate AlterEvent;
    public event OrderDelegate OrderEvent;
    public event OrderDelegate KitchenEvent;
    public event OrderDelegate BarEvent;
    public event AlterDelegate PaymentEvent;
    public int Type = 2;

    public Dictionary<string, Product> menu;

    public ListSingleton()
    {
        Console.WriteLine("Constructor called.");
        TablesList = new List<Table>();
        PaymentList = new List<Table>();
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

    public void AddOrder(Order o)
    {
        Console.WriteLine("Adding Order to table {0}", o.TableId);
        foreach (Table t in TablesList)
            if (t.Equals(o.TableId))
                t.addOrder(o);
        NotifyClients(Operation.New, o, o.TableId);
    }

    public void AddOrder(int quantity, Product product, int tableID)
    {
        var order = new Order(quantity, product);
        order.TableId = tableID;

        AddOrder(order);
    }

    public int AttendOrder(int orderId)
    {
        foreach (Table t in TablesList)
        {
            foreach (Order o in t.orders)
            {
                if (o.Id == orderId)
                {
                    if (!o.State.Equals("In Queue"))
                        return -1;
                    o.attendOrder();
                    NotifyClients(Operation.Change, o, o.TableId);
                    return 0;
                }
            }
        }
        return -1;
    }


    public int FinishOrder(int orderId)
    {
        foreach (Table t in TablesList)
        {
            foreach (Order o in t.orders)
            {
                if (o.Id == orderId)
                {
                    if (!o.State.Equals("In Progress"))
                        return -1;
                    o.finishOrder();
                    NotifyClients(Operation.Ready, o, o.TableId);
                    return 0;
                }
            }
        }
        return -1;
    }

    void NotifyClients(Operation op, Order order, int tableId)
    {
        if (OrderEvent != null)
        {
            Delegate[] roomList = OrderEvent.GetInvocationList();
            Delegate[] prepList = new Delegate[0];
            Delegate[] invkList;

            if (order.Product.Bar && BarEvent != null && op != Operation.Ready)
            {
                prepList = BarEvent.GetInvocationList();
            }
            if (!order.Product.Bar && KitchenEvent != null && op != Operation.Ready)
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

    public void DeleteTable(Table table)
    {
        foreach (Table t in PaymentList)
        {
            if (t.ID == table.ID)
            {
                PaymentList.Remove(t);
                break;
            }
        }
        NotifyClients(Operation.Finish, table);
    }

    void NotifyClients(Operation op, Table item)
    {
        if (AlterEvent != null)
        {
            Delegate[] roomList = AlterEvent.GetInvocationList();
            Delegate[] paymentList = PaymentEvent.GetInvocationList();
            Delegate[] invkList;
            if (op == Operation.Close)
            {
                invkList = new Delegate[roomList.Length + paymentList.Length];
                roomList.CopyTo(invkList, 0);
                paymentList.CopyTo(invkList, roomList.Length);
            }
            else if (op == Operation.Finish)
                invkList = paymentList;
            else
                invkList = roomList;


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
        menu.Add("Água", new Product(0.5f, "Água"));
        menu.Add("Coca-cola", new Product(0.9f, "Coca-cola"));
        menu.Add("Super Bock", new Product(1f, "Super Bock"));
        menu.Add("Vinho Bramco da Casa", new Product(5f, "Vinho Branco da Casa"));
        menu.Add("Vinho Tinto da Casa", new Product(5f, "Vinho Tinto da Casa"));

        menu.Add("Bacalhau com Natas", new Product(8f, "Bacalhau com Natas", false, 13));
        menu.Add("Vitela Mendinha", new Product(13f, "Vitela Mendinha", false, 13));
        menu.Add("Francesinha Especial", new Product(6.99f, "Francesinha Especial", false, 13));
        menu.Add("Leitão no forno", new Product(12f, "Leitão no forno", false, 13));
        menu.Add("Sandes de Leitão", new Product(5f, "Sandes de Leitão", true,  13));

        menu.Add("Leite Creme", new Product(2.99f, "Leite Creme", true, 13));
        menu.Add("Bolo do Bolacha", new Product(2.5f, "Bolo de Bolacha", true, 13));
        menu.Add("Mousse de Manga", new Product(2.5f, "Mousse de Manga", true, 13));



    }

    public Dictionary<string, Product> GetMenu()
    {
        return menu;
    }

    public List<Table> GetPaymentList()
    {
        return PaymentList;
    }

    public int ToPayment(int id)
    {
        bool noTable = true;
        Table finished = new Table(id);
        foreach(Table t in TablesList)
        {
            if(t.ID == id)
            {
                finished = t;
                noTable = false;
                break;
            }
        }
        if (noTable)
            return -1;

        foreach(Order o in finished.orders)
        {
            if (!o.State.Equals("Done"))
                return -1;
        }
        if (TablesList.Remove(finished))
        {
            PaymentList.Add(finished);
            NotifyClients(Operation.Close, finished);
        }
        else
            return -1;

        return 0;
    }
}