namespace IndusValley_PreTest
{
    public class OrCriteria : IProductCriteria
    {
        private readonly IProductCriteria _criteria1;
        private readonly IProductCriteria _criteria2;

        public OrCriteria(IProductCriteria criteria1, IProductCriteria criteria2)
        {
            _criteria1 = criteria1;
            _criteria2 = criteria2;
        }

        public bool IsSatisfiedBy(Product product)
        {
            return _criteria1.IsSatisfiedBy(product) || _criteria2.IsSatisfiedBy(product);
        }
    }
}