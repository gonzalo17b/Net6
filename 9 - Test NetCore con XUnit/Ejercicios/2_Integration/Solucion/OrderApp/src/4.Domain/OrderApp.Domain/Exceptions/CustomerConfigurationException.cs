namespace OrderApp.Domain.Exceptions
{
    public class CustomerConfigurationException : Exception
    {
        public CustomerConfigurationException(string property, object value) 
            : base($"Value {value} in property {property} is wrong") 
        { }
    }
}
