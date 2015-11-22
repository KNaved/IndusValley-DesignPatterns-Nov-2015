namespace IndusValley_PreTest
{
    class AffordableProductCriteria : IProductCriteria
    {
        public bool IsSatisfiedBy(Product product)
        {
            return product.Cost < 40;
        }
    }
}