using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
namespace BusinessLayer.Concrete
{
    public class LoginManager : ILoginService
    {
       

        public void Login(Admin admin)
        {
            Context context = new Context();
            var adminUserInfo = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            if(adminUserInfo!=null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                var sessionValue = HttpContext.Current.Session["AdminUserName"];
                sessionValue = adminUserInfo.AdminUserName;//Oturum yönetimi
            }
            else
            {
                throw new Exception();
            }
         
           
        }


       
    }
}
