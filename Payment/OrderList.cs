using Common;
using System;
using System.Collections.Generic;



namespace Payment
{
    class OrderList : MarshalByRefObject, IListSingleton
    {
        private List<Order> list;

        OrderList()
        {
            list = new List<Order>();
        }

        public void AddOrder(Order o)
        {
            list.Add(o);
        }

        public List<Order> GetList()
        {
            return list;
        }


        public List<Order> GetTableOrders(int table)
        {
            List<Order> tables = new List<Order>();

            foreach (Order o in list)
            {
                if (o.Table == table)
                    tables.Add(o);
            }

            return tables;

        }

        public float GetTablePrice(int table)
        {
            float total = 0f;

            foreach (Order o in list)
            {
                total += o.Price;
            }


            return total;
        }

    }
}