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