using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.ServiceReference1;
using HashPass;

namespace WebApplication1
{
    public partial class login : System.Web.UI.Page
    {
        Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginSubmit_Click(object sender, EventArgs e)
        {
            var user = client.Login(your_username.Value, your_pass.Value);
            if (user != null)
            {
                Session["UserID"] = user.UserID;
                Session["User_Type"] = user.User_Type;
                Session["Username"] = user.Username;
            
                Response.Redirect("index.aspx");
            }
            else
            {
                notFound.Visible = true;
            }
        }
    }
}
