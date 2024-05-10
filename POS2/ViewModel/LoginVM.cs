using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using POS2.Model;
using POS2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace POS2.ViewModel
{
    public partial class LoginVM : ObservableObject
    {
        [ObservableProperty]
        public string username;

        
        [ObservableProperty]
        public string password;

        [RelayCommand]
        public void Login()
        {
            using (MyDbContext context = new MyDbContext())
            {
                var user = context.users.FirstOrDefault(x=> x.Username==Username);
                bool userfound = context.users.Any(user => user.Username == Username && user.Password == Password);

                if (userfound)
                {
                    if (user.IsAdmin) {
                        Grantaccess();
                    
                    Application.Current.MainWindow.Close();
                    }
                    else
                    {
                        MessageBox.Show("staff");
                    }
                    

                }
                else
                {
                    MessageBox.Show("user not found");
                }
            }
        }



        public void Grantaccess()
        {
            DashboardView main = new DashboardView();
            main.Show();

        }
        [RelayCommand]
        public void Close()
        {
            Application.Current.Shutdown();
        }



    

}
}
