using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Models.Repositories;
using Models.Entities;

using Assert = NUnit.Framework.Assert;
using CollectionAssert = NUnit.Framework.CollectionAssert;
using Web.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Tests.Service
{
    [TestClass]
    public class ProductServiceTest
    {
        private Mock<IProductRepository> productRepository;
        private Product p1;
        private Product p2;
        private Product p3;
        [SetUp]
        public void setupmock()
        {
            p1 = new Product { Id = 222, Name = "kris", RetailPrice = 22.3, WholesalePrice = 22, Image = "http://i1379.photobucket.com/albums/ah152/krisferrari/WatPhaSom/-2-500x600_zpsfvtbxmal.jpg", Description = "Rice" };
            p2 = new Product { Id = 333, Name = "Umy", RetailPrice = 55.4, WholesalePrice = 33, Image = "http://i1379.photobucket.com/albums/ah152/krisferrari/WatPhaSom/4_zpsbbthnyjh.png", Description = "Shampoo" };
            p3 = new Product { Id = 444, Name = "Nong", RetailPrice = 134.5, WholesalePrice = 44, Image = "http://i1379.photobucket.com/albums/ah152/krisferrari/WatPhaSom/-use_zpsub4e7zog.jpg", Description = "Banana" };
            productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repository => repository.GetAll()).Returns(new List<Product> { p1,p2,p3 });

        }

        [Test]
        public void Test_GetAllProductShouldPass()
        {
            var service = new ProductService(productRepository.Object);
            service.GetAll();
            productRepository.Verify(p => p.GetAll());
        }

        [Test]
        public void Test_GetProductByIDShouldPass()
        {
            var service = new ProductService(productRepository.Object);
            service.GetById(222);
            Assert.AreEqual(p1.Id, 222);
            
        }

        [Test]
        public void DeleteProduct()
        {
            var service = new ProductService(productRepository.Object);
            service.Delete(333);
            productRepository.Verify(p => p.Delete(333));
        }

        [Test]
        public void EditProductShouldPass()
        {
            var service = new ProductService(productRepository.Object);
            p3 = new Product
            {
                Name = "Garlic",
                RetailPrice = 700.00,
                Description = "eieieieiei",
                WholesalePrice = 66,
                
            };
            service.Edit(p3);
            productRepository.Verify(p => p.Edit(p3));
        }

        [Test]
        public void AddProductShouldPass()
        {
            var service = new ProductService(productRepository.Object);
            Product p4 = new Product
            {
                Name = "Wow",
                RetailPrice = 888,
                Description = "kikikikiki",
                WholesalePrice = 99,
            };
            service.Add(p4);
            productRepository.Verify(p => p.Add(p4));
        }
    }
}
