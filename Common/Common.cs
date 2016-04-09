using System;
using System.Collections;
using System.Collections.Generic;


[Serializable]
public class Product
{
    public float UnitPrice { get; set; }
    public string Description { get; set; }
    public float IVA { get; set; } //percent value, like 23%

    public Product(float unit_price, string description, float iva = 23)
    {
        UnitPrice = unit_price;
        Description = description;
        IVA = iva;
    }

    public float GetPriceWithIva()
    {
        return UnitPrice * (100 + IVA) / 100;
    }
}

[Serializable]
public class Order
{
    public int Quantity { get; set; }
    public Product Product { get; set; }
    
    public Order (int quantity, Product product)
    {
        Quantity = quantity;
        Product = product;
    }     

    public float getTotalPrice()
    {
        return Quantity * Product.GetPriceWithIva();
    }

}


[Serializable]
public class Table {
    public List<Order> orders{ get; set; }
    public int State { get; set; }
    public bool Free { get; set; }
    public int ID { get; set; }

    public Dictionary<string, Product> menu { get; }

    public Table(int id)
    {
        ID = id;
        orders = new List<Order>();
        Free = false;
    }

    public void addOrder(Order o)
    {
        orders.Add(o);
    }
    
    public float totalPrice()
    {
        float price = 0f;
        foreach (Order o in orders)
            price += o.getTotalPrice();
        return price;
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

public enum Operation { New, Change };

public delegate void AlterDelegate(Operation op, Table item);

public interface IListSingleton {
  event AlterDelegate AlterEvent;

  List<Table> GetTablesList();
  int GetNewType();
  void AddTable(Table table);
}

public class AlterEventRepeater : MarshalByRefObject {
  public event AlterDelegate alterEvent;

  public override object InitializeLifetimeService() {
    return null;
  }

  public void Repeater(Operation op, Table item) {
    if (alterEvent != null)
      alterEvent(op, item);
  }
}