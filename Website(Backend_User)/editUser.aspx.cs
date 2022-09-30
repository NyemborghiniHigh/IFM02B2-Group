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

//im just adding this check if you agree with it it checks if the email is registered your way looks much better but we should change it to a User abjoct

protected void editRes_Click(object sender, EventArgs e)
        {
            dynamic em = service.getAllEmails();
            Reservation editReservation = new Reservation
            {
                Name = m_fname.Value,
                LName = m_lname.Value,
                Email = m_email.Value,
                Persons = Convert.ToInt32(m_people.Value),
                Phone = m_phone.Value,
                Date = Convert.ToDateTime(m_date.Value),
                Time = m_time.Value,
                Note = m_message.Value
            };
            foreach (Reservation r in em)
            {
                if (r.Email.Equals(email_Edit))
                {
                    service.EditReservation(editReservation);
                }
            }
        }
