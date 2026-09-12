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
        // Content Eksik kaldı içerik o

        IContactDal _contactdal;
        public ContactManager(IContactDal contactdal)
        {
            _contactdal = contactdal;
        }
        public void ContactAdd(Contact contact)
        {
            _contactdal.Insert(contact);
        }

        public Contact ContactGetByID(int id)
        {
            return _contactdal.Get(x=>x.ContactID == id);
        }

        public void ContactRemove(Contact contact)
        {
            _contactdal.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _contactdal.Update(contact);
        }

        public List<Contact> GetContactList()
        {
           return _contactdal.List();
        }
    }
}
