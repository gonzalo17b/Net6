using FluentAssertions;
using OrderApp.Domain;
using OrderApp.Domain.Exceptions;
using System;
using Xunit;

namespace OrderApp.UnitTests
{
    public class CustomerTests
    {
        [Fact]
        public void return_exception_when_create_customer_without_name()
        {
            var id = 1;
            string name = null;
            var surname = "Lopez";
            var age = 23;
            var email = "email@email.com";

            Action createCustomer = () => new Customer(id, name, surname, age, email);

            Assert.Throws<CustomerConfigurationException>(createCustomer);
        }

        [Fact]
        public void return_exception_when_create_customer_without_surname()
        {
            var id = 1;
            var name = "Pepe";
            string surname = null;
            var age = 23;
            var email = "email@email.com";

            Action createCustomer = () => new Customer(id, name, surname, age, email);

            Assert.Throws<CustomerConfigurationException>(createCustomer);
        }

        [Fact]
        public void return_exception_when_create_customer_with_age_minor_18()
        {
            var id = 1;
            var name = "Pepe";
            string surname = "Lopez";
            var age = 5;
            var email = "email@email.com";

            Action createCustomer = () => new Customer(id, name, surname, age, email);

            Assert.Throws<CustomerConfigurationException>(createCustomer);
        }

        [Fact]
        public void return_exception_when_create_customer_with_email_without_arroba()
        {
            var id = 1;
            var name = "Pepe";
            string surname = "Lopez";
            var age = 23;
            var email = "email";

            Action createCustomer = () => new Customer(id, name, surname, age, email);

            Assert.Throws<CustomerConfigurationException>(createCustomer);
        }

        [Fact]
        public void create_customer_when_data_is_ok()
        {
            // Arrange
            var id = 1;
            var name = "Pepe";
            string surname = "Lopez";
            var age = 23;
            var email = "email@email.com";

            // Act
            var customer = new Customer(id, name, surname, age, email);

            // Assert
            customer.Id.Should().Be(id);
            customer.Name.Should().Be(name);
            customer.Surname.Should().Be(surname);
            customer.Age.Should().Be(age);
            customer.Email.Should().Be(email);
            customer.Active.Should().Be(true);
        }

        [Fact]
        public void update_customer_throw_exception_when_name_is_null()
        {
            var customer = new Customer(1, "Pepe", "Lopez", 23, "email@email.com");
            string name = null;
            var surname = "Lopez";
            var age = 35;
            var email = "newemail@email.com";

            Action updateCustomer = () => customer.Update(name, surname, age, email);

            Assert.Throws<CustomerConfigurationException>(updateCustomer);
        }

        [Fact]
        public void update_customer_throw_exception_when_surname_is_null()
        {
            var customer = new Customer(1, "Pepe", "Lopez", 23, "email@email.com");
            var name = "Juan";
            string surname = null;
            var age = 35;
            var email = "newemail@email.com";

            Action updateCustomer = () => customer.Update(name, surname, age, email);

            Assert.Throws<CustomerConfigurationException>(updateCustomer);
        }

        [Fact]
        public void update_customer_throw_exception_when_age_is_minor_18()
        {
            var customer = new Customer(1, "Pepe", "Lopez", 23, "email@email.com");
            var name = "Juan";
            var surname = "Lopez";
            var age = 6;
            var email = "newemail@email.com";

            Action updateCustomer = () => customer.Update(name, surname, age, email);

            Assert.Throws<CustomerConfigurationException>(updateCustomer);
        }

        [Fact]
        public void update_customer_throw_exception_when_email_has_no_arroba()
        {
            var customer = new Customer(1, "Pepe", "Lopez", 23, "email@email.com");
            var name = "Juan";
            var surname = "Lopez";
            var age = 6;
            var email = "newemail";

            Action updateCustomer = () => customer.Update(name, surname, age, email);

            Assert.Throws<CustomerConfigurationException>(updateCustomer);
        }


        [Fact]
        public void update_customer_when_data_is_ok()
        {
            var customer = new Customer(1, "Pepe", "Lopez", 23, "email@email.com");
            var name = "Juan";
            string surname = "Lopez";
            var age = 35;
            var email = "newemail@email.com";

            customer.Update(name, surname, age, email);

            customer.Id.Should().Be(1);
            customer.Name.Should().Be(name);
            customer.Surname.Should().Be(surname);
            customer.Age.Should().Be(age);
            customer.Email.Should().Be(email);
            customer.Active.Should().Be(true);
        }

        [Fact]
        public void desactive_customer_when_call_desactive()
        {
            var customer = new Customer(1, "Pepe", "Lopez", 23, "email@email.com");

            customer.Desactive();

            customer.Active.Should().Be(false);
        }
    }
}