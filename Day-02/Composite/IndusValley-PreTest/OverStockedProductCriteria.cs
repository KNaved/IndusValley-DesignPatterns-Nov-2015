namespace IndusValley_PreTest
{
    class OverStockedProductCriteria : IProductCriteria
    {
        public bool IsSatisfiedBy(Product product)
        {
            return product.Units > 50;
        }
    }
}