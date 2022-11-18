using OrderApp.Domain.Exceptions;

namespace OrderApp.Domain
{
    public class Customer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public bool Active { get; private set; }

        public Customer(int id, string name, string surname, int age, string email)
        {
            this.Id = id;
            this.Update(name, surname, age, email);
            this.Active = true;
        }

        public void Update(string name, string surname, int age, string email)
        {
            if (string.IsNullOrEmpty(name)) 
            {
                throw new CustomerConfigurationException(nameof(name), name);
            }

            if (string.IsNullOrEmpty(surname))
            {
                throw new CustomerConfigurationException(nameof(surname), surname);
            }

            if (age < 18) 
            {
                throw new CustomerConfigurationException(nameof(age), age);
            }

            if (string.IsNullOrEmpty(email) || !email.Contains('@'))
            {
                throw new CustomerConfigurationException(nameof(email), email);
            }

            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            LastUpdate = DateTime.UtcNow;
        }

        public void Reactive()
        {
            this.Active = true;
        }

        public void Desactive() 
        {
            this.Active = false;
        }
    }
}
