using System;

namespace Store_Management_Ex4._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Product x1 = new Product(1, "Painting Picasso. Guernica", 100, 1000);
            Console.WriteLine(x1);
            Product x2 = new Product(2, "Painting Tsarouxis. Naftis A", 200, 2000);
            Console.WriteLine(x2);
            Product x3 = new Product(3, "Chair. Luis XV", 100, 1000);
            Console.WriteLine(x3);
            Product x4 = new Product(4, "Vase. Cubic", 500, 5000);
            Console.WriteLine(x4);
            var simple = new SimpleRetailStore();
            simple.Buy(x1);
            simple.Buy(x3);
            simple.Sell(x1);
            simple.GetRevenue();
            var invStore = new InventoryRetailStore();
            invStore.Buy(x1);
            invStore.Buy(x3);
            invStore.Sell(x1);
            invStore.GetRevenue();
            invStore.Sell(x2);
            invStore.GetInventory();
        }
    }
}
