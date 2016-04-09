using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class ListSingleton : MarshalByRefObject, IListSingleton
{
    List<Table> TablesList;
    public event AlterDelegate AlterEvent;
    public int Type = 2;
    Dictionary<string, Product> menu;

    public Dictionary<string, Product> menu{  get; }

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

    public Dictionary<string, Product> GetMenu()
    {
        Console.WriteLine("GetMenu() called.");
        return menu;
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


    private void initializeMenu()
    {
        menu.Add("Água", new Product(0.7f, "Água"));
        menu.Add("Coca-cola", new Product(1f, "Coca-cola"));
        menu.Add("Super Bock", new Product(0.7f, "Super Bock"));
        menu.Add("Vinho Bramco da Casa", new Product(0.7f, "Vinho Branco da Casa"));
        menu.Add("Vinho Tinto da Casa", new Product(0.7f, "Vinho Tinto da Casa"));

        menu.Add("Bacalhau com Natas", new Product(0.7f, "Bacalhau com Natas"));
        menu.Add("Vitela Mendinha", new Product(0.7f, "Vitela Mendinha"));
        menu.Add("Francesinha Especial", new Product(0.7f, "Francesinha Especial"));
        menu.Add("Leitão no forno", new Product(0.7f, "Leitão no forno"));
        menu.Add("Sandes de Leitão", new Product(0.7f, "Sandes de Leitão"));

        menu.Add("Leite Creme", new Product(0.7f, "Leite Creme"));
        menu.Add("Bolo do Bolacha", new Product(0.7f, "Bolo de Bolacha"));
        menu.Add("Mousse de Manga", new Product(0.7f, "Mousse de Manga"));



    }
}