using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Phonebook
{
    /// <summary>
    /// Interaction logic for Edit_Window.xaml
    /// </summary>
    public partial class Edit_Window : Window
    {
        PhoneBookController PBC = new PhoneBookController();
        public Edit_Window(string S)
        {
            InitializeComponent();
            string[] words = S.Split(' ');

            Name.Text = words[0];
            Company.Text = words[1];
            Workphone.Text = words[2];
            PrivatePhone.Text = words[3];           
        }

        private void Comfirm_button_Click(object sender, RoutedEventArgs e)
        {
            PBC.EditContact(Name.Text, int.Parse(Workphone.Text), int.Parse(PrivatePhone.Text), Company.Text);
            this.Close();
        }
    }
}
