using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Security;
namespace BusinessLayer.Concrete
{
    public class LoginManager : ILoginService
    {
        public void Login(Admin admin)
        {
            Loggin(admin);
        }


        private void Loggin(Admin admin)
        {
            Context context = new Context();
            var adminUserInfo = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
           
            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
          //      Session["AdminUserName"] = adminUserInfo.AdminUserName;//Oturum yönetimi 
              //  return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
             //   return RedirectToAction("Index");
            }
        }
    }
}
