using BusinessLayer.Abstract;
using BusinessLayer.Helpers;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _admindal;
        public AdminManager(IAdminDal admindal)
        {
            _admindal = admindal;

        }
        public void AddAdmin(Admin admin)
        {
            admin.AdminPassword = PasswordHasher.HashPassword(admin.AdminPassword);
            _admindal.Insert(admin);
        }
        public void UpdateAdmin(Admin admin)
        {
            _admindal.Update(admin);
        }
        public void DeleteAdmin(int adminId)
        {
            var admin = _admindal.Get(x => x.AdminID == adminId);
            // Kurucu Admin (C) yanlışlıkla pasif yapılamasın diye koruma koyuyoruz (büyük/küçük harf ve boşluktan etkilenmez):
            if (admin != null && (string.IsNullOrWhiteSpace(admin.AdminRole) || admin.AdminRole.Trim().ToUpper() != "C"))
            {
                admin.AdminStatus = !admin.AdminStatus; // Aktifse pasif, pasifse aktif yapar
                _admindal.Update(admin);
            }
        }
        // AdminID'ye göre admini getirme metodu bunun şartlı hali özel parametre koşuluna göre aşağıda yaptık.
        public Admin GetAdminById(int adminId)
        {
            return _admindal.Get(x => x.AdminID == adminId);
        }
        public List<Admin> GetAllAdmins()
        {
            return _admindal.List();
        }
        public Admin GetAdminByUserNamePassword(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            username = username.Trim();

            // 1. Önce doğrudan girilen kullanıcı adına göre ara
            var admin = _admindal.Get(x => x.AdminUserName == username);

            // 2. Bulunamadıysa ve @ yoksa (örn: "admin21"), "@gmail.com" ekleyerek de ara
            if (admin == null && !username.Contains("@"))
            {
                admin = _admindal.Get(x => x.AdminUserName == username + "@gmail.com");
            }

            // 3. Bulunamadıysa ve @ varsa, ön ek ile (örn: "admin21@gmail.com" -> "admin21") de ara
            if (admin == null && username.Contains("@"))
            {
                var shortName = username.Split('@')[0];
                admin = _admindal.Get(x => x.AdminUserName == shortName);
            }

            // Admin hiç bulunamadıysa giriş başarısız
            if (admin == null)
            {
                return null;
            }

            // 4. Pasif yapılmış admin (AdminStatus == false) sisteme giriş yapamaz:
            if (!admin.AdminStatus)
            {
                return null;
            }

            // 5. Şifre doğrulaması (Hem PBKDF2 hashli hem de eski düz şifreleri destekler)
            bool passwordCorrect = PasswordHasher.VerifyPassword(password.Trim(), admin.AdminPassword);

            if (!passwordCorrect)
            {
                return null;
            }

            return admin;
        }

        public Admin GetAdminByUserName(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return null;
            }

            username = username.Trim();

            // 1. Önce doğrudan girilen kullanıcı adına göre ara
            var admin = _admindal.Get(x => x.AdminUserName == username);

            // 2. Bulunamadıysa ve @ yoksa, "@gmail.com" ekleyerek de ara
            if (admin == null && !username.Contains("@"))
            {
                admin = _admindal.Get(x => x.AdminUserName == username + "@gmail.com");
            }

            // 3. Bulunamadıysa ve @ varsa, ön ek ile de ara
            if (admin == null && username.Contains("@"))
            {
                var shortName = username.Split('@')[0];
                admin = _admindal.Get(x => x.AdminUserName == shortName);
            }

            return admin;
        }
    }
}

