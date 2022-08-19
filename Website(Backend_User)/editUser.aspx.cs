using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.ServiceReference1;

namespace WebApplication1
{
    public partial class editUser : System.Web.UI.Page
    {
        Service1Client sr = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("index.aspx");
                }
                else
                {
                    int id = Convert.ToInt32(Session["UserID"]);
                    var user = sr.getUser(id);

                    firstname.Value = user.First_Name;
                    surname.Value = user.Surname;
                    username.Value = user.Username;
                    editEmail.Value = user.Email;
                }
            }
            Validate();
        }

        protected void updateUser_Click(object sender, EventArgs e)
        {
            var user = sr.getUser(Convert.ToInt32(Session["UserID"]));
            
            user.Username = username.Value;
            user.Email = editEmail.Value;
            user.Surname = surname.Value;

            bool updatedUser = sr.EditUser(user);
            if (updatedUser == true)
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}
