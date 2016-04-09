﻿using System;
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
public class Meal {
    public Dictionary<string, Order> orders{ get; set; }
    public int State { get; set; }
    public int Table { get; set; }

    public Meal(){ orders = new Dictionary<string, Order>();    }

    public Meal(int num)
    {
        orders = new Dictionary<string, Order>();
        Table = num;
    }

    public void addOrder(string name, Order o)
    {
        orders.Add(name, o);
    }

    public int incrementOrder(string name)
    {
        Order o;
        if (orders.TryGetValue(name, out o))
        {
            o.Quantity = o.Quantity + 1;
            orders.Remove(name);
            orders.Add(name, o);
            return o.Quantity;
        }
        else
            throw new FieldAccessException();
    }

    public int Order(string name)
    {
        Order o;
        if (orders.TryGetValue(name, out o))
        {            
            o.Quantity = o.Quantity - 1;
            orders.Remove(name);
            if (o.Quantity > 0)
                orders.Add(name, o);
            return o.Quantity;
        }
        else
            throw new FieldAccessException();
    }

    public float totalPrice()
    {
        float price = 0f;
        foreach (KeyValuePair<string, Order> o in orders)
            price += o.Value.getTotalPrice();
        return price;
    }

}

public enum Operation { New, Change };

public delegate void AlterDelegate(Operation op, Meal item);

public interface IListSingleton {
  event AlterDelegate AlterEvent;

  List<Meal> GetList();
  int GetNewType();
  void AddItem(Meal item);
  void ChangeComment(int type, string comment);
}

public class AlterEventRepeater : MarshalByRefObject {
  public event AlterDelegate alterEvent;

  public override object InitializeLifetimeService() {
    return null;
  }

  public void Repeater(Operation op, Meal item) {
    if (alterEvent != null)
      alterEvent(op, item);
  }
}