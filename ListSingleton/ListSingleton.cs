using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class ListSingleton : MarshalByRefObject, IListSingleton {
  List<Order> itemsList;
  public event AlterDelegate alterEvent;
  int type = 2;

  public ListSingleton() {
    Console.WriteLine("Constructor called.");
    itemsList = new List<Order>();
    Order item = new Order();
    itemsList.Add(item);
  }

  public override object InitializeLifetimeService() {
    return null;
  }

  public List<Order> GetList() {
    Console.WriteLine("GetList() called.");
    return itemsList;
  }

  public int GetNewType() {
    return type++;
  }

  public void AddItem(Order item) {
    itemsList.Add(item);
    NotifyClients(Operation.New, item);
  }

  public void ChangeComment(int type, string comment) {
    Order nitem = null;

    foreach (Order it in itemsList) {
      if (it.Table == type) {
        it.Description = comment;
        nitem = it;
        break;
      }
    }
    NotifyClients(Operation.Change, nitem); 
  }

  void NotifyClients(Operation op, Order item) {
    if (alterEvent != null) {
      Delegate[] invkList = alterEvent.GetInvocationList();

      foreach (AlterDelegate handler in invkList) {
        new Thread(() => {
          try {
            handler(op, item);
            Console.WriteLine("Invoking event handler");
          }
          catch (Exception) {
            alterEvent -= handler;
            Console.WriteLine("Exception: Removed an event handler");
          }
        }).Start();
      }
    }
  }
}