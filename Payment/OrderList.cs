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

        event AlterDelegate IListSingleton.alterEvent
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public void AddOrder(Order o)
        {
            list.Add(o);
        }

        public List<Order> GetList()
        {
            Console.WriteLine("cenas\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
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

        void IListSingleton.AddItem(Order item)
        {
            throw new NotImplementedException();
        }

        void IListSingleton.ChangeComment(int type, string comment)
        {
            throw new NotImplementedException();
        }

        List<Order> IListSingleton.GetList()
        {
            throw new NotImplementedException();
        }

        int IListSingleton.GetNewType()
        {
            throw new NotImplementedException();
        }
    }
}