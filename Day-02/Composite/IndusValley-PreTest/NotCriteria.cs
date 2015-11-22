namespace IndusValley_PreTest
{
    public class NotCriteria : IProductCriteria
    {
        private readonly IProductCriteria _criteria;

        public NotCriteria(IProductCriteria criteria)
        {
            _criteria = criteria;
        }

        public bool IsSatisfiedBy(Product product)
        {
            return !_criteria.IsSatisfiedBy(product);
        }
    }
}