using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Phonebook
{
    class DBConection
    {
        SqlConnection Conn = new SqlConnection("Server=ealdb1.eal.local;" +
                                                     "Database=EJL87_DB;" +
                                                     "User ID=ejl87_usr;" +
                                                    "Password=Baz1nga87;");
       public void EditContactDB(Contact C)
       {
           try
           {
               Conn.Open();
               SqlCommand cmd = new SqlCommand("EditContact", Conn);
               cmd.CommandType = CommandType.StoredProcedure;


           }
           catch (SqlException e)
           {
               
           }
           finally
           {
               Conn.Close();
               Conn.Dispose();
           }
       }
       public void AddNewContactDB(Contact C)
       {
           try
           {
               Conn.Open();
               SqlCommand cmd = new SqlCommand("AddNewContact", Conn);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.Add(new SqlParameter("@Name", C.name.ToString()));
               cmd.Parameters.Add(new SqlParameter("@CompanyName", C.companyName.ToString()));
               cmd.Parameters.Add(new SqlParameter("@WorkPhone", C.workPhone));
               cmd.Parameters.Add(new SqlParameter("@PrivatePhone",C.privatePhone));

               cmd.ExecuteNonQuery();

           }
           catch (SqlException e)
           {
               Console.WriteLine("SQL conection error " + e.Message);
           }
           finally
           {
               Conn.Close();
               Conn.Dispose();
           }
       }
       public List<Contact> GetPhonebook()
       {
           List<Contact> Clist = new List<Contact>();
           try
           {
               Conn.Open();
               SqlCommand cmd = new SqlCommand("GetAllContacts", Conn);
               cmd.CommandType = CommandType.StoredProcedure;

               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.HasRows && rdr.Read())
               {

                   Contact C = new Contact(rdr["C_Name"].ToString(), int.Parse(rdr["C_WorkPhone"].ToString()), int.Parse(rdr["C_PrivatePhone"].ToString()), rdr["C_CompanyName"].ToString());
                   Clist.Add(C);
               }

           }
           catch (SqlException e)
           {

           }
           finally
           {
               Conn.Close();
               Conn.Dispose();
           }
           return Clist;      
         }
       
    }
}
