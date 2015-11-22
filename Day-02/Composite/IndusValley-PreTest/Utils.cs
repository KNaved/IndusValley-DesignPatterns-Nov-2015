using System;
using System.Collections;

namespace IndusValley_PreTest
{
    class Utils
    {
        public static void Print(Product[] products)
        {
            for(var i=0; i<products.Length; i++)
                Console.WriteLine(products[i]);
        }
        public static void Sort(Product[] products, IProductComparer comparer)
        {
            for(var i=0; i<products.Length-1; i++)
                for (var j = i + 1; j < products.Length; j++)
                {
                    if (comparer.Compare(products[i], products[j]) > 0)
                    {
                        var temp = products[i];
                        products[i] = products[j];
                        products[j] = temp;
                    }
                }
        }

        /*public static Product[] FilterAffordableProducts(Product[] products)
        {
            var result = new ArrayList();
            foreach (var product in products)
            {
                if (product.Cost < 40)
                    result.Add(product);
            }
            return (Product[]) (result.ToArray(typeof (Product)));
        }
        public static Product[] FilterOverStockedProducts(Product[] products)
        {
            var result = new ArrayList();
            foreach (var product in products)
            {
                if (product.Units > 50)
                    result.Add(product);
            }
            return (Product[])(result.ToArray(typeof(Product)));
        }*/

        public static Product[] Filter(Product[] products, IProductCriteria productCriteria)
        {
            var result = new ArrayList();
            foreach (var product in products)
            {
                if (productCriteria.IsSatisfiedBy(product))
                    result.Add(product);
            }
            return (Product[])(result.ToArray(typeof(Product)));
        }

        /*public static Product[] Filter(Product[] products, FilterItemDelegate<Product> filterCriteria)
        {
            var result = new ArrayList();
            foreach (var product in products)
            {
                if (filterCriteria(product))
                    result.Add(product);
            }
            return (Product[])(result.ToArray(typeof(Product)));
        }*/

        /* public static Product[] Filter(Product[] products, Func<Product, bool> filterCriteria)
        {
            var result = new ArrayList();
            foreach (var product in products)
            {
                if (filterCriteria(product))
                    result.Add(product);
            }
            return (Product[])(result.ToArray(typeof(Product)));
        }*/

        public static Product[] Filter(Product[] products, Predicate<Product> filterCriteria)
        {
            var result = new ArrayList();
            foreach (var product in products)
            {
                if (filterCriteria(product))
                    result.Add(product);
            }
            return (Product[])(result.ToArray(typeof(Product)));
        }
    }
}