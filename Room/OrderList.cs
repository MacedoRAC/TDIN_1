using System;
using System.Collections.Generic;
namespace Room
{
    internal class OrderList: MarshalByRefObject, IListSingleton
    {
        public OrderList()
        {
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
            // throw new NotImplementedException();
            return new List<Order>();
        }

        int IListSingleton.GetNewType()
        {
            throw new NotImplementedException();
        }
    }
}