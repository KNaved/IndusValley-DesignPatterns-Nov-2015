using System;

namespace IndusValley_PreTest
{
    public static class ProductFilters
    {
        /*public static FilterProductDelegate AffordableProducts = p => p.Cost < 40;
        public static FilterProductDelegate OverStockedProducts = p => p.Units > 50;*/

        /*public static FilterItemDelegate<Product> AffordableProducts = p => p.Cost < 40;
        public static FilterItemDelegate<Product> OverStockedProducts = p => p.Units > 50;*/

        /*public static Func<Product, bool> AffordableProducts = p => p.Cost < 40;
        public static Func<Product, bool> OverStockedProducts = p => p.Units > 50;*/

        public static Predicate<Product> AffordableProducts = p => p.Cost < 40;
        public static Predicate<Product> OverStockedProducts = p => p.Units > 50;
    }
}