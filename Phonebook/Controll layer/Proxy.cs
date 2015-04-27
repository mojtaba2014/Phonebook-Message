using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Phonebook
{
    class Proxy
    {
        public List<Contact> listOfContacts;
        DBConection DB = new DBConection();
        PhoneBookToFile PBTF = new PhoneBookToFile(); //wait with using this--Johann

        public Proxy()
        {
            listOfContacts = DB.GetPhonebook(); // this is only from DB need to compare to File
        }
        public void EditContactProxy(Contact C)
        {
            DB.EditContactDB(C);
            foreach (Contact old in listOfContacts)
            {
                if (old.name.Equals(C.name))
                {
                    listOfContacts.Remove(old);
                    listOfContacts.Add(C);
                }
            }
        }
        public void AddNewContact(Contact C)
        {

        }
        public List<Contact> SearchingList(string name, string companyName)
        {

            List<Contact> SearchingList = new List<Contact>();
            foreach (Contact c in listOfContacts)
            {
                if (c.name.Equals(name) || c.companyName.Equals(companyName))
                {
                    SearchingList.Add(c);
                }
            }
            return SearchingList;            
        }
    }
}
