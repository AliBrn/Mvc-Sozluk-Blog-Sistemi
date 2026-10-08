using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactdal;

        public ContactManager(IContactDal contactdal)
        {
            _contactdal = contactdal;
        }

        // Yeni iletişim mesajı ekler
        public void ContactAdd(Contact contact)
        {
            _contactdal.Insert(contact);
        }

        // ID'ye göre tekil iletişim mesajını getirir
        public Contact ContactGetByID(int id)
        {
            return _contactdal.Get(x => x.ContactID == id);
        }

        // İletişim mesajını siler
        public void ContactRemove(Contact contact)
        {
            _contactdal.Delete(contact);
        }

        // İletişim mesajını günceller
        public void ContactUpdate(Contact contact)
        {
            _contactdal.Update(contact);
        }

        // Tüm iletişim mesajlarını listeler
        public List<Contact> GetContactList()
        {
            return _contactdal.List();
        }
    }
}
