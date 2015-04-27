using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Proxy
    {
        public List<Contact> listOfContacts;
        DBConection DB = new DBConection();
        PhoneBookToFile PBTF = new PhoneBookToFile(); //wait with using this--Johann

        public Proxy()
        {
            listOfContacts = DB.GetPhonebook();
        }
        public void EditContactProxy(Contact C)
        {
            
        }
        public void AddNewContact(Contact C)
        {

        }
        public List<Contact> SearchingList(string name, string companyName)
        {

            List<Contact> SearchingList = new List<Contact>();
            foreach (Contact c in listOfContacts)
            {
                if (c.Equals(name) || c.Equals(companyName))
                {
                    SearchingList.Add(c);
                }



            }
            return SearchingList;
            
        }
    }
}
