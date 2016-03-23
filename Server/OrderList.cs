using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
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

        public float getTablePrice(int table)
        {
            float total = 0f;

            foreach(Order o in list)
            {
                
            }


            return total;
        }

    }
}
