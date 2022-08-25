using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IFM02B2_Project.ServiceReference1;

namespace IFM02B2_Project
{
    public partial class SingleProduct : System.Web.UI.Page
    {
        Service1Client sr = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect("shop.aspx");
            }
            else
            {
                initSingleProduct();
                
            }

            
        }
        protected void initSingleProduct()
        {
            int id = Convert.ToInt32(Request.QueryString["ID"].ToString());

            var prod = sr.getProduct(id);

            string display = "";
            


            display += "<div class='col-md-6'><img class='card-img-top mb-5 mb-md-0' src='" + prod.Prod_Image + "' alt='...'/></div>";
            display += "<div class='col-md-6''><div class='small mb-1'>" + prod.Category + "</div>";
            display += "<h1 class='display-5 fw-bolder'>" + prod.Brand_Name + "</h1>";
            display += "<h1>" + prod.Prod_Name + "</h1>";
            display += "<div class='fs-5 mb-5'><span>" + prod.Price + "</span></div>";
            display += "<p class'lead'>" + prod.Description + "</p>";
            display += "<div class='d-flex'><input class='form-control text-center me-3' id='inputQuantity' type='num' value='1' style='max-width: 3rem'/>";
            display += "<button class='btn btn-outline-orange flex-shrink-0' type='button'>";
            display += "<i class='bi-cart-fill me-1'></i>";
            display += "Add To Cart</button></div></div>";

            string displayRelated = "";

            dynamic pro = sr.getAllProducts();

            foreach (Product product in pro)
            {
                if (product.Category.Equals(prod.Category))
                {
                    displayRelated += "<div class='col mb-5'>";
                    displayRelated += "<div class='card h-100'>";
                    displayRelated += "<img class='card-img-top' src='" + product.Prod_Image + "' alt='...'/>";
                    displayRelated += "<div class='card-body p-4'>";
                    displayRelated += "<div class='text-center'>";
                    displayRelated += "<h1 class='fw-bolder'>" + product.Brand_Name + "</h1>";
                    displayRelated += "<h5 class='fw-bolder'>" + product.Prod_Name + "</h5>";
                    displayRelated += "" + product.Price + "</div></div>";
                    displayRelated += "<div class='card-footer p-4 pt-0 border-top-0 bg-transparent'>";
                    displayRelated += "<div class='text-center'><a class='btn btn-outline-orange mt-auto' href='SingleProduct.aspx?ID=" + product.Prod_ID + "'>View Product</a></div>";
                    displayRelated += "</div></div></div>";
                }
                

            }
            
            singleDiv.InnerHtml = display;
            relatedDiv.InnerHtml = displayRelated;
        }

        
    }
}
