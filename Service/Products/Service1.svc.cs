using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IFM02B2_Project_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public List<Product> getAllProducts()
        {
            dynamic prod = (from p in db.Products
                            where p.Active.Equals(1)
                            select p);

            List<Product> products = new List<Product>();
            foreach (Product p in prod)
            {
                Product temp = new Product
                {
                    Prod_ID = p.Prod_ID,
                    Prod_Name = p.Prod_Name,
                    Brand_Name = p.Brand_Name,
                    Price = p.Price,
                    Type_ID = p.Type_ID,
                    Prod_Image = p.Prod_Image,
                };
                products.Add(temp);
            }

            return products;

        }

        public Product getProduct(int id)
        {
            var product = (from p in db.Products
                           where p.Prod_ID == id && p.Active.Equals(1)
                           select p).FirstOrDefault();

            if (product != null)
            {
                var prod = new Product
                {
                    Prod_ID = product.Prod_ID,
                    Brand_Name = product.Brand_Name,
                    Prod_Name = product.Prod_Name,
                    Description = product.Description,
                    Type_ID = product.Type_ID,
                    Active = product.Active,
                    Prod_Image = product.Prod_Image,
                    Price = product.Price,
                    created_at = product.created_at,
                    Quantity = product.Quantity,
                    
                };
                return prod;
            }
            else
            {
                return null;
            }


        }

        
    }
}
