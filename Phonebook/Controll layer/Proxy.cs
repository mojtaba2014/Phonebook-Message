using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Phonebook
{
    class Proxy
    {
        internal List<Contact> listOfContacts;

        DBConection DB = new DBConection();
        PhoneBookToFile PBTF = new PhoneBookToFile(); 

        public Proxy()
        {
            LoadContactsFromText();
           // listOfContacts = DB.GetPhonebook(); //this is only from DB need to compare to File
        }

        public void EditContactProxy(Contact C)
        {
            //DB.EditContactDB(C);
            foreach (Contact old in listOfContacts)
            {
                if (old.name.Equals(C.name))
                {
                    listOfContacts.Remove(old);
                    listOfContacts.Add(C);
                    break;
                }
            }
            Task t = new Task(SavetoText);
            t.Start();            
        }

        public void AddNewContact(Contact C)
        {
            DB.AddNewContactDB(C);            
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
        private void SavetoText()
        {
            PBTF.SaveContacts(listOfContacts);           
        }
        private void LoadContactsFromText()
        {
            listOfContacts = PBTF.GetContactFromFile();
        }
        public List<Contact> GetlistOfContacts()
        {
            var sortedlist = listOfContacts.OrderBy(x => x.name).ToList();
            return sortedlist;
        }
    }
}
