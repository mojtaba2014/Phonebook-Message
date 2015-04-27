using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Contact
    {
        string name { get; set; }
        int workPhone { get; set; }
        int privatePhone { get; set; }
        string company { get; set; }

        public Contact(string Name, int WorkPhone, int PrivatePhone, string Company)
        {
            this.name = Name;
            this.workPhone = WorkPhone;
            this.privatePhone = PrivatePhone;
            this.company = Company;
        }
    }
}
