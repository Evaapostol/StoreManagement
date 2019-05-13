using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;





namespace Store_Management_Ex4._3
{

    public interface IStore
    {
        double Buy(Product product);
        double Sell(Product product);
        double GetRevenue();


    }
    

    public class SimpleRetailStore : IStore
    {
        public Product Id { get; set; }
        public string Name { get; set; }
        public Product PriceWhenBuy { get; set; }
        public Product PriceWhenSell { get; set; }
        public double totalBuyBalance;
        public double totalSellBalance;
        private double _balance;

        public SimpleRetailStore()
        {

        }

        public SimpleRetailStore(Product id, Product priceWhenBuy, Product priceWhenSell, double totalBuyBalance, double totalSellBalance, double balance)
        {
            this.Id = id;
            this.PriceWhenBuy = priceWhenBuy;
            this.PriceWhenSell = priceWhenSell;
            this.totalBuyBalance = totalBuyBalance;
            this.totalSellBalance = totalSellBalance;
            _balance = 0;
        }

        public double Buy(Product product)
        {

            totalBuyBalance += product.PriceWhenBuy;
            return totalBuyBalance;

        }

        public double Sell(Product product)
        {

            totalSellBalance += product.PriceWhenSell;
            return totalSellBalance;
        }

        public double GetRevenue()
        {

            _balance += totalSellBalance;
            _balance -= totalBuyBalance;
            return _balance;
        }
    }

    public class InventoryRetailStore : IStore
    {

        private readonly List<Product> products = new List<Product>();
        private const string storemanag = @"c:\mydata\academy\products.json";
        public Product Id { get; set; }
        public Product PriceWhenBuy { get; set; }
        public Product PriceWhenSell { get; set; }
        public double totalBuyBalance;
        public double totalSellBalance;
        public bool z;
        public bool k;
        public double _balance;

        public InventoryRetailStore()
        {

        }

       

        public double Buy(Product product)
        {
            products.Add(new Product(product.Id,
                product.Name, product.PriceWhenBuy, product.PriceWhenSell));
            totalBuyBalance += product.PriceWhenBuy;
            z = true;
            return totalBuyBalance;
        }


        public double Sell(Product product)
        {
            products.Remove(product);
            totalSellBalance += product.PriceWhenSell;
            k = true;
            return totalSellBalance;
        }

        public double GetRevenue()
        {
            if (z == true)
            {
                _balance -= totalBuyBalance;
            }
            if (k == true)
            {
                _balance += totalSellBalance;
            }

            return _balance;
        }

        public void GetInventory()
        {
            foreach (Product p in products)
            {
                Console.WriteLine(p);
            }
        }

        public void Reset()
        {
            foreach (Product p in products)
            {
                products.Remove(p);
            }
        }

        public void SaveToFile(string storemanag)
        {
            using (StreamWriter file =
                new StreamWriter(storemanag))
            {
                foreach (Product p in products)
                {
                    {
                        file.WriteLine(p);
                    }
                }
            }
        }

        public void SaveToJson()            
        {
            string json1 = JsonConvert.SerializeObject(products.ToArray());

            File.WriteAllText(storemanag, json1); 
        }

        
        public void LoadJson()
        {

            string data = File.ReadAllText(storemanag);   
            var tempProducts = JsonConvert.DeserializeObject<List<Product>>(data);  
            foreach (Product p in tempProducts)
            {
                products.Add(p);
            }
            
        }



    }
}
