using System;
using System.Collections;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class Order
    {
        public int Table { get; set; }
        public int State { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }


    }

    public enum Operation { New, Change };

    public delegate void AlterDelegate(Operation op, Order item);

    public interface IListSingleton
    {
       // event AlterDelegate alterEvent;

        //int GetNewType();

        void AddOrder(Order o);
        List<Order> GetList();
        List<Order> GetTableOrders(int table);
        float GetTablePrice(int table);
    }
}