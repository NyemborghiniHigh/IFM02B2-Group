using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IFM02B2_Project.ServiceReference1;

namespace IFM02B2_Project
{
    public partial class shop : System.Web.UI.Page
    {
        Service1Client sr = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            string display =  "";

            
            dynamic prod = sr.getAllProducts();

            foreach (Product product in prod)
            {
                display += "<div class='col mb-5'>";
                display += "<div class='card h-100'>";
                display += "<img class='card-img-top' src='" + product.Prod_Image + "' alt='...'/>";
                display += "<div class='card-body p-4'>";
                display += "<div class='text-center'>";
                display += "<h1 class='fw-bolder'>" + product.Brand_Name + "</h1>";
                display += "<h5 class='fw-bolder'>" + product.Prod_Name + "</h5>";
                display += "" + product.Price + "</div></div>";
                display += "<div class='card-footer p-4 pt-0 border-top-0 bg-transparent'>";
                display += "<div class='text-center'><a class='btn btn-outline-orange mt-auto' href='SingleProduct.aspx?ID=" + product.Prod_ID + "'>View Product</a></div>";
                display += "</div></div></div>";
                
            }
            shopDiv.InnerHtml = display;
            
        }
    }
}