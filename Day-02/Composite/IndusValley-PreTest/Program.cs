using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndusValley_PreTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var products = new[]
            {
                new Product {Id = 2, Name = "Pen", Units = 40, Cost = 20},
                new Product {Id = 6, Name = "Hen", Units = 80, Cost = 50},
                new Product {Id = 9, Name = "Den", Units = 30, Cost = 40},
                new Product {Id = 3, Name = "Zen", Units = 50, Cost = 80},
                new Product {Id = 5, Name = "Ken", Units = 90, Cost = 10},
            };

            var books = new[]
            {
                new Book {Id = 4, Title = "Art of Coding", Cost = 80, PubDate = new DateTime(2015, 4, 10)},
                new Book {Id = 7, Title = "Design Patterns", Cost = 40, PubDate = new DateTime(2015, 2, 10)},
                new Book {Id = 2, Title = "Beautiful Code", Cost = 90, PubDate = new DateTime(2015, 1, 10)},
            };

            Console.WriteLine("Initial List - Products");
            Utils.Print(products);

            Console.WriteLine();
            Console.WriteLine("After sorting [default]");
            Utils.Sort(products, new ProductComparerById());
            Utils.Print(products);

            /* 
             * Assignment
             * ==========
             * 1. Modify the Utils.Sort() method so that the same function can be used to sort products by any attribute (id or name or units or cost)
             */

            Console.WriteLine();
            Console.WriteLine("After sorting products by [Cost]");
            Utils.Sort(products, new ProductComparerByCost());
            Utils.Print(products);

            Console.WriteLine();
            Console.WriteLine("After sorting products by [Units]");
            //Sort(....);
            Utils.Print(products);

            /* 
             * Assignment
             * ==========
             * 2. Modify the Utils.Print() such that it can be used to print ANY array of entities (in this case Product or Book)
             */
            

            Console.WriteLine("Initial List - Books");
            //Utils.Print(.....); (should print the list of books)

            /* 
             * Assignment
             * ==========
             * 1. Modify the Utils.Sort() method so that the same function can be used to sort books by any attribute.
             * NOTE that the after modifcation the function should still be used with 'Products' as well.
             */
            
            Console.WriteLine();
            Console.WriteLine("After sorting [Books by Id]");
            //Utils.Sort(....); (should sort the books by Id)
            //Utils.Print(products);

            Console.WriteLine();
            Console.WriteLine("After sorting [Books by Cost]");
            //Utils.Sort(....); (should sort the books by Cost)
            //Utils.Print(products);

            Console.WriteLine();
            Console.WriteLine("Affordable products");
            //var affordableProducts = Utils.FilterAffordableProducts(products);

            //Using Interface
            //var affordableProducts = Utils.Filter(products, new AffordableProductCriteria());

            //Using Delegate
            //var affordableProducts = Utils.Filter(products, Program.AffordableProductCriteria);
            /*var affordableProducts = Utils.Filter(products, delegate(Product product)
            {
                return product.Cost < 40;
            });*/
            /*var affordableProducts = Utils.Filter(products, (p) =>
            {
                return p.Cost < 40;
            });*/
            //var affordableProducts = Utils.Filter(products, p => p.Cost < 40);
            var affordableProducts = Utils.Filter(products, ProductFilters.AffordableProducts);
            Utils.Print(affordableProducts);

            Console.WriteLine();
            Console.WriteLine("Ovar stocked products");
            //var overStockedProducts = Utils.FilterOverStockedProducts(products);
            var overStockedProducts = Utils.Filter(products, new OverStockedProductCriteria());
            Utils.Print(overStockedProducts);
            Console.ReadLine();
        }

        public static bool AffordableProductCriteria(Product product)
        {
            return product.Cost < 40;
        }
    }

    /*public delegate  bool FilterItemDelegate<T>(T item);*/
}
