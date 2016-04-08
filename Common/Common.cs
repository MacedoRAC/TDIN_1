using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Order {
    public int Table { get; set; }
    public int State { get; set; }
    public int Id { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public float Price { get; set; }

    public Order(){    }

    public Order(int table)
    {
        Table = table;
    }

}

public enum Operation { New, Change };

public delegate void AlterDelegate(Operation op, Order item);

public interface IListSingleton {
  event AlterDelegate alterEvent;

  List<Order> GetList();
  int GetNewType();
  void AddItem(Order item);
  void ChangeComment(int type, string comment);
}

public class AlterEventRepeater : MarshalByRefObject {
  public event AlterDelegate alterEvent;

  public override object InitializeLifetimeService() {
    return null;
  }

  public void Repeater(Operation op, Order item) {
    if (alterEvent != null)
      alterEvent(op, item);
  }
}