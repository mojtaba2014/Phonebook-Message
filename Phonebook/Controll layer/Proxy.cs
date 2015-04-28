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
        public List<Contact> listOfContacts;
        DBConection DB = new DBConection();
        PhoneBookToFile PBTF = new PhoneBookToFile(); //wait with using this--Johann

        public Proxy()
        {
            listOfContacts = DB.GetPhonebook(); //this is only from DB need to compare to File
        }

        public void EditContactProxy(Contact C)
        {
            //DB.EditContactDB(C);
            //foreach (Contact old in listOfContacts)
            //{
            //    if (old.name.Equals(C.name))
            //    {
            //        listOfContacts.Remove(old);
            //        listOfContacts.Add(C);
            //    }
            //}
            Task t = new Task(SavetoText);
            t.Start();
            
        }

        public bool AddNewContact(Contact C)
        {
            bool bo = true; 
            DB.AddNewContactDB(C);
            
            foreach (Contact x in listOfContacts)
            {
                if (x.name.Equals(C.name)) 
                {
                   bo = false;
                }
                else
                {
                    listOfContacts.Add(C);
                    bo=true;
                }
            }
            return bo;
            
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
