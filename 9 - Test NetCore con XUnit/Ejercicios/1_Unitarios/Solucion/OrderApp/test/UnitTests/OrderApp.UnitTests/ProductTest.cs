using FluentAssertions;
using OrderApp.Domain;
using OrderApp.Domain.Exceptions;
using System;
using Xunit;

namespace OrderApp.UnitTests
{
    public class ProductTest
    {
        [Fact]
        public void return_exception_when_has_a_product_without_name()
        {
            var id = 1;
            string name = null;
            var description = "";
            var price = 2;

            Action createCustomer = () => new Product(id, name, description, price);

            Assert.Throws<ProductConfigurationException>(createCustomer);
        }

        [Fact]
        public void create_product_when_has_a_product_without_description()
        {
            var id = 1;
            var name = "Product";
            string description = null;
            var price = 2;

            var product = new Product(id, name, description, price);

            product.Id.Should().Be(id);
            product.Name.Should().Be(name);
            product.Description.Should().BeNull();
            product.Price.Should().Be(price);
            product.OutOfCatalog.Should().Be(false);
        }

        [Fact]
        public void create_product_when_has_a_product_with_description_empty()
        {
            var id = 1;
            var name = "Product";
            string description = "";
            var price = 2;

            var product = new Product(id, name, description, price);

            product.Id.Should().Be(id);
            product.Name.Should().Be(name);
            product.Description.Should().BeEmpty();
            product.Price.Should().Be(price);
            product.OutOfCatalog.Should().Be(false);
        }

        [Fact]
        public void return_exception_when_has_a_product_with_price_minor_0()
        {
            var id = 1;
            string name = "Product";
            var description = "Description";
            var price = -2;

            Action createCustomer = () => new Product(id, name, description, price);

            Assert.Throws<ProductConfigurationException>(createCustomer);
        }

        [Fact]
        public void create_product_when_has_a_product_with_price_0()
        {
            var id = 1;
            string name = "Product";
            var description = "Description";
            var price = 0;

            var product = new Product(id, name, description, price);

            product.Id.Should().Be(id);
            product.Name.Should().Be(name);
            product.Description.Should().Be(description);
            product.Price.Should().Be(price);
            product.OutOfCatalog.Should().Be(false);
        }

        [Fact]
        public void create_product_when_has_a_product()
        {
            var id = 1;
            string name = "Product";
            var description = "Description";
            var price = 2;

            var product = new Product(id, name, description, price);

            product.Id.Should().Be(id);
            product.Name.Should().Be(name);
            product.Description.Should().Be(description);
            product.Price.Should().Be(price);
            product.OutOfCatalog.Should().Be(false);
        }

        [Fact]
        public void return_exception_when_update_a_product_without_name()
        {
            var product = new Product(1, "Product", "Description", 2);
            string newName = null;
            var newDescription = "DescriptionNew";
            var newPrice = 20;

            Action createCustomer = () => product.Update(newName, newDescription, newPrice);

            Assert.Throws<ProductConfigurationException>(createCustomer);
        }

        [Fact]
        public void return_exception_when_update_a_product_with_price_minor_0()
        {
            var product = new Product(1, "Product", "Description", 2);
            string newName = "NewName";
            var newDescription = "DescriptionNew";
            var newPrice = -20;

            Action createCustomer = () => product.Update(newName, newDescription, newPrice);

            Assert.Throws<ProductConfigurationException>(createCustomer);
        }

        [Fact]
        public void update_product_with_price_0()
        {
            var product = new Product(1, "Product", "Description", 2);
            var lastUpdateCreate = product.LastUpdate;
            string newName = "ProductNew";
            string newDescription = "DescriptionNew";
            var newPrice = 0;

            product.Update(newName, newDescription, newPrice);

            product.Id.Should().Be(1);
            product.Name.Should().Be(newName);
            product.Description.Should().Be(newDescription);
            product.Price.Should().Be(newPrice);
            product.LastUpdate.Ticks.Should().BeGreaterThan(lastUpdateCreate.Ticks);
            product.OutOfCatalog.Should().Be(false);
        }

        [Fact]
        public void update_product_without_description()
        {
            var product = new Product(1, "Product", "Description", 2);
            var lastUpdateCreate = product.LastUpdate;
            string newName = "ProductNew";
            string newDescription = null;
            var newPrice = 20;

            product.Update(newName, newDescription, newPrice);

            product.Id.Should().Be(1);
            product.Name.Should().Be(newName);
            product.Description.Should().Be(newDescription);
            product.Price.Should().Be(newPrice);
            product.LastUpdate.Ticks.Should().BeGreaterThan(lastUpdateCreate.Ticks);
            product.OutOfCatalog.Should().Be(false);
        }

        [Fact]
        public void update_product_with_description_empty()
        {
            var product = new Product(1, "Product", "Description", 2);
            var lastUpdateCreate = product.LastUpdate;
            string newName = "ProductNew";
            string newDescription = String.Empty;
            var newPrice = 20;

            product.Update(newName, newDescription, newPrice);

            product.Id.Should().Be(1);
            product.Name.Should().Be(newName);
            product.Description.Should().Be(newDescription);
            product.Price.Should().Be(newPrice);
            product.LastUpdate.Ticks.Should().BeGreaterThan(lastUpdateCreate.Ticks);
            product.OutOfCatalog.Should().Be(false);
        }

        [Fact]
        public void update_product_modify_last_update()
        {
            var product = new Product(1, "Product", "Description", 2);
            var lastUpdateCreate = product.LastUpdate;
            string newName = "ProductNew";
            var newDescription = "DescriptionNew";
            var newPrice = 20;

            product.Update(newName, newDescription, newPrice);

            product.Id.Should().Be(1);
            product.Name.Should().Be(newName);
            product.Description.Should().Be(newDescription);
            product.Price.Should().Be(newPrice);
            product.LastUpdate.Ticks.Should().BeGreaterThan(lastUpdateCreate.Ticks);
            product.OutOfCatalog.Should().Be(false);
        }

        [Fact]
        public void remove_from_catalog_modify_out_of_catalog_prop()
        {
            var product = new Product(1, "Product", "Description", 2);

            product.RemoveFromCatalog();

            product.OutOfCatalog.Should().Be(true);
        }

        [Fact]
        public void return_exception_when_update_a_product_out_of_catalog()
        {
            var product = new Product(1, "Product", "Description", 2);
            string newName = "ProductNew";
            var newDescription = "DescriptionNew";
            var newPrice = 20;
            product.RemoveFromCatalog();

            Action createCustomer = () => product.Update(newName, newDescription, newPrice);

            Assert.Throws<ProductConfigurationException>(createCustomer);
        }
    }
}
