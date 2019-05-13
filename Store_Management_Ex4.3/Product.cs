using System;
using System.Collections.Generic;
using System.Text;

namespace Store_Management_Ex4._3
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double PriceWhenBuy { get; set; }
        public double PriceWhenSell { get; set; }


        public Product()
        {

        }

        public Product(int id, string name, double priceWhenBuy, double priceWhenSell)
        {
            this.Id = id;
            this.Name = name;
            this.PriceWhenBuy = priceWhenBuy;
            this.PriceWhenSell = priceWhenSell;
        }

        public override string ToString()
        {
            return $"ID = {Id} Name = {Name} Price when buy = {PriceWhenBuy} Price when sell = {PriceWhenSell}" ;
        }


    }



   

}
