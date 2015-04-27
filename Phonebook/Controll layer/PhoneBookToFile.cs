using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Phonebook
{
    [Serializable]
    class PhoneBookToFile
    {
       public void SaveContacts(List<Contact> Clist)
       {
           XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
           TextWriter textWriter = new StreamWriter(@"C:\Data\data.xml");
           serializer.Serialize(textWriter, Clist);
           textWriter.Close();
         
       }

    }
}
