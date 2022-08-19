using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool register(string firstname, string surname, string username, string email, string user_type,string password);

        [OperationContract]
        SysUser Login(string email, string password);

        [OperationContract]
        SysUser getUser(int ID);

        [OperationContract]
        bool EditUser(SysUser user);
    }
}
