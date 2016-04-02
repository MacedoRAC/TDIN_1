using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment
{
    class Order
    {
        public int Table { get; set; }
        public int State { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }


    }
}