namespace OrderApp.Domain.Exceptions
{
    public class ProductConfigurationException : Exception
    {
        public ProductConfigurationException(string property, object value)
            : base($"Value {value} in property {property} is wrong")
        { }
    }
}
