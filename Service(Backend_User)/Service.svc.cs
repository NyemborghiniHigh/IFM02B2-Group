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
        public bool newUser(User user)
        {
            var newUser = new User();

            newUser.Email = user.Email;
            newUser.Name = user.Name;
            newUser.Password = user.Password;
            newUser.Phone = user.Phone;
            newUser.DOB = user.DOB;

            db.Users.InsertOnSubmit(newUser);
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

        public bool editUser(User edit)
        {
            var tempUser = (from u in db.Users
                            where edit.Id == u.Id
                            select u).FirstOrDefault();

            tempUser.Email = edit.Email;
            tempUser.Name = edit.Name;
            tempUser.Password = edit.Password;
            tempUser.Phone = edit.Phone;
            tempUser.DOB = edit.DOB;

            db.Users.InsertOnSubmit(tempUser);
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
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
    }
