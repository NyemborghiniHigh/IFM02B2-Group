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
                int id = Convert.ToInt32(Request.QueryString["ID"].ToString());
                
                var prod = sr.getProduct(id);

                productName.Text = prod.Prod_Name;
                prodBrand.Text = prod.Brand_Name;
                description.Text = prod.Description;
                category.Text = prod.Type_ID.ToString();
                prodImage.ImageUrl = prod.Prod_Image;
            }
        }
    }
}