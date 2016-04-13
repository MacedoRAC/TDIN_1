using System;
using System.Collections.Generic;

[Serializable]
public class Product
{
    public float UnitPrice { get; set; }
    public string Description { get; set; }
    public float IVA { get; set; } //percent value, like 23%
    public bool Bar { get; set; }

    public Product(float unit_price, string description, bool bar = true, float iva = 23)
    {
        UnitPrice = unit_price;
        Description = description;
        IVA = iva;
        Bar = bar;
    }

    public float GetPriceWithIva()
    {
        return UnitPrice * (100 + IVA) / 100;
    }

    public bool Equals(Product p)
    {
        // If parameter is null return false:
        if ((object)p == null)
        {
            return false;
        }

        // Return true if the fields match:
        return (UnitPrice == p.UnitPrice) && (Description == p.Description) && (IVA == p.IVA);
    }

}

[Serializable]
public class Order
{
    private static readonly object lockObject = new object();

    static int COUNTER = 0;
    public int Quantity { get; set; }
    public Product Product { get; set; }
    public string State { get; set; }
    public int TableId { get; set; }
    public int Id { get; set; }

    public Order (int quantity, Product product)
    {
        Quantity = quantity;
        Product = product;
        State = "In Queue";
        COUNTER = COUNTER+1;
        Id = COUNTER;
    }     

    public float getTotalPrice()
    {
        return Quantity * Product.GetPriceWithIva();
    }

    public void attendOrder()
    {
        State = "In Progress";
    }


    public void finishOrder()
    {
        State = "Done";
    }

    public bool Equals(Order o)
    {
        // If parameter is null return false:
        if ((object)o == null)
        {
            return false;
        }

        // Return true if the fields match:
        return (Quantity == o.Quantity) && (Product.Equals(o.Product));
    }

}


[Serializable]
public class Table {
    public List<Order> orders{ get; set; }
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

    public bool Equals(Table t)
    {
        // If parameter is null return false:
        if ((object)t == null)
        {
            return false;
        }

        // Return true if the fields match:
        return (ID == t.ID);
    }

    public bool Equals(int i)
    {

        // Return true if the fields match:
        return (ID == i);
    }

}

public enum Operation { New, Change, Ready, Close };

public delegate void AlterDelegate(Operation op, Table item);

public delegate void OrderDelegate(Operation op, Order item, int tableId);

public interface IListSingleton {
  event AlterDelegate AlterEvent;
  event OrderDelegate OrderEvent;
    event OrderDelegate KitchenEvent;
    event OrderDelegate BarEvent;

    List<Table> GetTablesList();
    List<Table> GetPaymentList();
  Dictionary<string, Product> GetMenu();
  int GetNewType();
  void AddTable(Table table);
  void AddOrder(Order o);
  void AddOrder(int quantity, Product product, int tableID);
  int AttendOrder(int orderId);
  int FinishOrder(int orderId);
  int ToPayment(Table finished);
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

public class OrderEventRepeater : MarshalByRefObject
{
    public event OrderDelegate alterEvent;

    public override object InitializeLifetimeService()
    {
        return null;
    }

    public void Repeater(Operation op, Order order, int tableId)
    {
        if (alterEvent != null)
            alterEvent(op, order, tableId);
    }
}