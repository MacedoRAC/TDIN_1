using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment
{
    class OrderList : MarshalByRefObject
    {
        private List<Order> list;

        OrderList()
        {
            list = new List<Order>();
        }

        public void addOrder(Order o)
        {
            list.Add(o);
        }

        public List<Order> getList()
        {
            return list;
        }


        public List<Order> getTableOrders(int table)
        {
            List<Order> tables = new List<Order>();

            foreach (Order o in list)
            {
                if (o.Table == table)
                    tables.Add(o);
            }

            return tables;

        }

        public float getTablePrice(int table)
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