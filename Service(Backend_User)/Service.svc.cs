using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HashPass;

namespace WCFService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public bool register(string firstname, string surname, string username, string email, string user_type, string password)
        {
            var newUser = new SysUser();
   
            newUser.First_Name = firstname;
            newUser.Surname = surname;
            newUser.Username = username;
            newUser.Email = email;
            newUser.User_Type = user_type;
            newUser.Password = Secrecy.HashPassword(password);


            db.SysUsers.InsertOnSubmit(newUser);
            try
            {
                db.SubmitChanges();
                return true;
            }catch(Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

        public SysUser Login(string username, string password)
        {
            var pass = Secrecy.HashPassword(password);
            var user = (from u in db.SysUsers
                        where u.Username.Equals(username) && u.Password.Equals(pass)
                        select u).FirstOrDefault();
            return user;
        }
        
        public SysUser getUser(int ID)
        {
            var user = (from u in db.SysUsers
                        where u.UserID.Equals(ID) && u.UserID == ID
                        select u).FirstOrDefault();

            if(user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public bool EditUser(SysUser user)
        {
            var tempUser = (from u in db.SysUsers
                        where user.UserID == u.UserID
                            select u).FirstOrDefault();

            //tempUser.UserID = user.UserID;
            tempUser.First_Name = user.First_Name;
            tempUser.Surname = user.Surname;
            tempUser.Username = user.Username;
            tempUser.Email = user.Email;

            try
            {
                db.SubmitChanges();
                return true;
            }catch(Exception e)
            {
                e.GetBaseException();
                return false;
            }
        }
    }
