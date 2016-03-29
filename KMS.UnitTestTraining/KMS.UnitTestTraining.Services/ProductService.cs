using KMS.UnitTestTraining.Entities;
using KMS.UnitTestTraining.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.UnitTestTraining.Services
{
    public class ProductService : IProductService
    {
        IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product GetProductById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("id");
            }
            return productRepository.GetProductById(id);
        }

        public void InsertProduct(string name, decimal price)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }
            if(price < 0)
            {
                throw new ArgumentException("price");
            }
            Product product = new Product(name, price);
            productRepository.Insert(product);
        }
    }
}
