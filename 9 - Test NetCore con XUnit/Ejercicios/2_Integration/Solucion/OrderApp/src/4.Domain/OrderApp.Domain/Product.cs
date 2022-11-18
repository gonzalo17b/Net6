using OrderApp.Domain.Exceptions;

namespace OrderApp.Domain
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public int Price { get; private set; }
        public bool OutOfCatalog { get; private set; }
        public DateTime LastUpdate { get; private set; }

        public Product(int id, string name, string description, int price) 
        {
            this.Id = id;
            this.Update(name, description, price);
            this.OutOfCatalog = false;
        }
        
        public void Update(string name, string description, int price) 
        {
            if (string.IsNullOrEmpty(name) || name.Length < 12)
            {
                throw new ProductConfigurationException(nameof(name), name);
            }

            if (price < 0)
            {
                throw new ProductConfigurationException(nameof(price), price);
            }

            if (this.OutOfCatalog) 
            {
                throw new ProductConfigurationException(nameof(OutOfCatalog), true);
            }

            Name = name;
            Description = description;
            Price = price;
            LastUpdate = DateTime.UtcNow;
        }

        public void RemoveFromCatalog() 
        {
            this.OutOfCatalog = true;
        }
    }
}
