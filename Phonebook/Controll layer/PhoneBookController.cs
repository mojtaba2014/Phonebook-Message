using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class PhoneBookController
    {
        Proxy P = new Proxy();

       public void EditContact(string name, int workPhone, int privatePhone, string company )
        {
            Contact C = new Contact(name, workPhone, privatePhone , company);
            P.EditContactProxy(C);
        }

       public List<Contact> NewSearch(string name, string companyName)
       {
          List<Contact> CL = P.SearchingList(name, companyName);
          return CL;
       }
       public void AddNewContact(string name,string companyName,int workPhone,int privatePhone)
       {
           Contact C = new Contact(name, workPhone, privatePhone , companyName);
           P.AddNewContact(C);
       }
    }
}
