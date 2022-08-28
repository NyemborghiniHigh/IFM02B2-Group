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
        //Registration button//
         protected void Register_Click_Button(object sender, EventArgs e)  
        {  
            message.Text      = "Hello " + username.Text + " ! ";  
            message.Text      = message.Text + " <br/> You have successfuly Registered with the following details.";  
            ShowUserName.Text = username.Text;  
            ShowEmail.Text    = EmailID.Text;  
            if (RadioButton1.Checked)  
            {  
                ShowGender.Text = RadioButton1.Text;  
            }  
            else ShowGender.Text = RadioButton2.Text;  
        var courses = "";  
            if (CheckBox1.Checked)  
            {  
                courses = CheckBox1.Text + " ";  
            }  
            if (CheckBox2.Checked)  
            {  
                courses += CheckBox2.Text + " ";  
            }     
            if (CheckBox3.Checked)  
            {  
                courses += CheckBox3.Text;  
            }  
            ShowCourses.Text = courses;  
            ShowUserNameLabel.Text = "User Name";  
            ShowEmailIDLabel.Text = "Email ID";  
            ShowGenderLabel.Text = "Gender";  
            ShowCourseLabel.Text = "Courses";  
            username.Text = "";  
            EmailID.Text = "";  
            RadioButton1.Checked = false;  
            RadioButton2.Checked = false;  
            CheckBox1.Checked = false;  
            CheckBox2.Checked = false;  
            CheckBox3.Checked = false;  
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
