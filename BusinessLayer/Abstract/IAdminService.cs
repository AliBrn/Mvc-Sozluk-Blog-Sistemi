using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
       // Bu iş Admin'e özel olduğu için:
       //IAdminService + AdminManager tarafına eklenir.
        void AddAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
        void DeleteAdmin(int adminId);
        Admin GetAdminById(int adminId);
        List<Admin> GetAllAdmins();
        Admin GetAdminByUserNamePassword(string username, string password);
        Admin GetAdminByUserName(string username);
    }
}
