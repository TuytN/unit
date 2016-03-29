using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KMS.UnitTestTraining.Entities;
using Moq;
using KMS.UnitTestTraining.Repositories;
using KMS.UnitTestTraining.Services;
using System.Collections;
using System.Collections.Generic;

namespace Tests.Unit.KMS.UnitTestTraining.Services
{
    [TestClass]
    public class ProductServiceTest
    {
        [TestMethod]
        public void GetProductById_Should_Work_Correctly()
        {
            //Arrange
            Product product = new Product("Product A", 10);
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(x => x.GetProductById(1)).Returns(product);

            //Act
            ProductService productService = new ProductService(mockProductRepository.Object);
            var resultProduct = productService.GetProductById(1);

            //Assert
            mockProductRepository.Verify(x => x.GetProductById(1), Times.Once);
            Assert.IsNotNull(resultProduct);
            Assert.AreEqual(product.Name, resultProduct.Name);
            Assert.AreEqual(product.Price, resultProduct.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetProductById_Should_Throw_Exception_When_Id_Is_Zero()
        {
            //Arrange
            Product product = new Product("Product A", 10);
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();

            //Act
            ProductService productService = new ProductService(mockProductRepository.Object);
            var resultProduct = productService.GetProductById(0);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertProduct_Should_Throw_ArgumentNullException_When_Name_Is_Empty()
        {
            //Arrange
            string name = string.Empty;
            decimal price = 10;
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();

            //Act
            IProductService service = new ProductService(mockProductRepository.Object);
            service.InsertProduct(name, price);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertProduct_Should_Throw_ArgumentException_When_Price_Is_Less_Than_Zero()
        {
            //Arrange
            string name = "Product A";
            decimal price = -10;
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();

            //Act
            IProductService service = new ProductService(mockProductRepository.Object);
            service.InsertProduct(name, price);

            //Assert
        }

        [TestMethod]
        public void InsertProduct_Should_Work_Correctly()
        {
            //Arrange
            string name = "Product A";
            decimal price = 10;
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            
            //Act
            IProductService service = new ProductService(mockProductRepository.Object);
            service.InsertProduct(name, price);

            //Assert
            mockProductRepository.Verify(x => x.Insert(It.Is<Product>(y => y.Name == name && y.Price == price)), Times.Once);
        }
    }
}
