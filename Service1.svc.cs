using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GroupProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public List<Product> getProducts()
        {
            dynamic prod = (from p in db.Products
                            select p);

            List<Product> products = new List<Product>();
            products = prod.ToList();

            return products;

        }

        public Product getProduct(int id)
        {
            var product = (from p in db.Products
                           where p.Id == id
                           select p).FirstOrDefault();

            if (product != null)
            {
                var prod = new Product
                {
                    Id = product.Id,
                    name = product.name,
                    image = product.image,
                    description = product.description,
                    price = product.price,
                    type = product.type,
                };
                return prod;
            }else
            {
                return null;
            }

            
        }

        public bool updateProduct(int id, Product product)
            {
            var prod = (from p in db.Products
                           where p.Id == id
                           select p).FirstOrDefault();

            if(prod != null)
            {
                var prod1 = new Product
                {
                    name = product.name,
                    description = product.description,
                    type = product.type,
                    price = product.price,
                };
                return true;
            }else
            {
                return false;
            }
        }
    }
}
