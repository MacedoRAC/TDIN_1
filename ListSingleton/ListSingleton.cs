using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class ListSingleton : MarshalByRefObject, IListSingleton {
  List<Meal> itemsList;
  public event AlterDelegate alterEvent;
  int type = 2;

  public ListSingleton() {
    Console.WriteLine("Constructor called.");
    itemsList = new List<Meal>();
        itemsList.Add(new Meal());
  }

  public override object InitializeLifetimeService() {
    return null;
  }

  public List<Meal> GetList() {
    Console.WriteLine("GetList() called.");
    return itemsList;
  }

  public int GetNewType() {
    return type++;
  }

  public void AddItem(Meal item) {
    itemsList.Add(item);
    NotifyClients(Operation.New, item);
  }

  public void ChangeComment(int type, string comment) {
    Meal nitem = null;

    foreach (Meal it in itemsList) {
      if (it.Table == type) {
        nitem = it;
        break;
      }
    }
    NotifyClients(Operation.Change, nitem); 
  }

  void NotifyClients(Operation op, Meal item) {
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