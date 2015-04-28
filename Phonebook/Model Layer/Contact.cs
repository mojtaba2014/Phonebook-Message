using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Phonebook
{
    [Serializable]
    class Contact 
    {
        public string name { get; private set; }
        public int workPhone { get; private set; }
        public int privatePhone { get; private set; }
        public string companyName { get; private set; }

        public Contact(string Name, int WorkPhone, int PrivatePhone, string Company)
        {
            this.name = Name;
            this.workPhone = WorkPhone;
            this.privatePhone = PrivatePhone;
            this.companyName = Company;
        }

    }
}
