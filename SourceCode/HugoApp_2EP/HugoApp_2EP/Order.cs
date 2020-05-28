using System;

namespace HugoApp_2EP
{
    public class Order
    {
        public int idOrder { get; set; }
        public DateTime createOrder { get; set; }
        public int idProduct { get; set; }
        public int idAdress { get; set; }

        public Order()
        {
            idOrder = 0;
            createOrder = DateTime.Now;
            idProduct = 0;
            idAdress = 0;
        }
    }
}