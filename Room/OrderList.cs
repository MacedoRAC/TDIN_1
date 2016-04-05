using System;
using System.Collections.Generic;
using Common;

namespace Room
{
    internal class OrderList: MarshalByRefObject, IListSingleton
    {
        public OrderList()
        {
        }

        void IListSingleton.AddOrder(Order o)
        {
          //  throw new NotImplementedException();
        }

        List<Order> IListSingleton.GetList()
        {
            // throw new NotImplementedException();
            return new List<Order>();
        }

        List<Order> IListSingleton.GetTableOrders(int table)
        {
            // throw new NotImplementedException();
            return new List<Order>();
        }

        float IListSingleton.GetTablePrice(int table)
        {
            // throw new NotImplementedException();
            return 1f;
        }
    }
}