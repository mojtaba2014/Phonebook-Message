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
           string dir = @"C:\Data";
           string serializationFile = Path.Combine(dir, "Contact.bin");

           //serialize
           using (Stream stream = File.Open(serializationFile, FileMode.CreateNew))
           {
               var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

               bformatter.Serialize(stream, Clist);
           }
                  
       }
        public List<Contact> GetContactFromFile()
       {
            List<Contact> CList;

            string dir = @"C:\Data";
            string serializationFile = Path.Combine(dir, "Contact.bin");


           using (Stream stream = File.Open(serializationFile, FileMode.Open))
           {
               var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                CList = (List<Contact>)bformatter.Deserialize(stream);
           }
           return CList;
       }

    }
}
