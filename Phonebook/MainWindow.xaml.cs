﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Phonebook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PhoneBookController PBC;
        public MainWindow()
        {
            InitializeComponent();
            PBC = new PhoneBookController();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_GetList_Click(object sender, RoutedEventArgs e)
        {
            Edit_listbox.Items.Clear();
            Proxy P = new Proxy();
            List<Contact> CL = P.GetlistOfContacts();

            
            foreach(Contact C in CL)
            {
                Edit_listbox.Items.Add(C.name +" "+ C.companyName +" "+ C.workPhone + " " + C.privatePhone);  //+= C.name ;
            }
            
            Edit_listbox.SelectionMode = SelectionMode.Single;
        }
        private void Seach_Button_Click(object sender, RoutedEventArgs e)
        {
            
            PBC.NewSearch(Search_name.Text, Search_Company.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (Object obj in Edit_listbox.SelectedItems)
            {
               
                Edit_Window E = new Edit_Window(obj.ToString());
                E.Show();
                
                
            }
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            //PBC = new PhoneBookController();
            PBC.AddNewContact(Add_name.Text, Add_Company.Text, int.Parse(Add_workphone.Text), int.Parse(Add_privatePhone.Text));

            Add_name.Text = "";
            Add_Company.Text = "";
            Add_workphone.Text = "";
            Add_privatePhone.Text = "";
        }
    }
}
