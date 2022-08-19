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
    public partial class register : System.Web.UI.Page
    {
        Service1Client user = new Service1Client();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerSubmit_Click(object sender, EventArgs e)
        {
            if (Session["User_Type"] != null)
            {
                if (user.register(firstname.Value, surname.Value, username.Value, email.Value, "manager", pass.Value) != false)
                {
                    success.Visible = true;
                    Response.Redirect("index.aspx");
                }
                else
                {
                    failed.Visible = true;
                }
            }
            else
            {
                if (user.register(firstname.Value, surname.Value, username.Value, email.Value, "client", pass.Value) != false)
                {
                    success.Visible = true;
                    Response.Redirect("login.aspx");
                }
                else
                {
                    failed.Visible = true;
                }
            }
        }   
    }
}
