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
using System.Windows.Navigation;
using System.Windows.Shapes;
using POS2.ViewModel;

namespace POS2.View.Pages
{
    /// <summary>
    /// Interaction logic for UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            DataContext = new UsersPageVM();
            InitializeComponent();
        }

        private void Edit_btn(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("View/Pages/EditUser.xaml", UriKind.RelativeOrAbsolute));
           // Tag.Text = "Edit User";
        }

        private void Add_btn(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("View/Pages/UsersPage.xaml", UriKind.RelativeOrAbsolute));
            //Tag.Text = "Edit User";
        }


    }
}
