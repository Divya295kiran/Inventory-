using Inventory.Models;
using Inventory;
using System;

namespace InventoryTest
{
    public class ProductInventoryTest
    {
        private ProductInventoryTest productInventoryTest { get; set; } = null;
        private ProductService productService { get; set; } = null;

        [SetUp]
        public void Setup()
        {
            productInventoryTest = new ProductInventoryTest();
            productService = new ProductService();
        }

        [Test]
        public void RemoveProduct()
        {


            var product = new Product { ProductName = "Product 4", ProductDescription = "Red", Quantity = 10, Price = 100, ProductType = "Product", ShipmentStatus = "New" };
            productService.Save(product);
            int count = productService.Remove(5);
            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public void SaveProduct()
        {

            var product = new Product { ProductName = "Product 1", ProductDescription = "Red", Quantity = 10, Price = 100, ProductType = "Product", ShipmentStatus = "New" };
            int count = productService.Save(product);
            Assert.That(count, Is.EqualTo(1));


        }

        [Test]
        public void UpdateProduct()
        {
            var product = new Product { ProductName = "Product 1", ProductDescription = "Red", Quantity = 10, Price = 100, ProductType = "Product", ShipmentStatus = "New" };
            productService.Save(product);
            var updateProduct = new Product { Id = 4, ProductName = "Update Product4", ProductDescription = "Red", Quantity = 100, Price = 1000, ProductType = "Product8", ShipmentStatus = "Hold" };
            int count = productService.Update(updateProduct);
            Assert.That(count, Is.EqualTo(1));

        }

        [Test]
        public void UpdateProduct_ShouldThrowArgumentException_WhenProductNotFound()
        {
            var updatedProduct = new Product { Id = 3, ProductName = "Updated Product9", ProductDescription = "Blue", Quantity = 20, Price = 150, ProductType = "Product", ShipmentStatus = "Hold" };
            Assert.Throws<ArgumentException>(() => productService.Update(updatedProduct));

        }

        [Test]
        public void RemoveProduct_ShouldThrowArgumentException_WhenProductNotFound()
        {
            Assert.Throws<ArgumentException>(() => productService.Remove(7));
        }

    }
}
