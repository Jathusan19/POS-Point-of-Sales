using CommunityToolkit.Mvvm.ComponentModel;
using System;
using POS2.Model;
using POS2.View;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace POS2.ViewModel
{
    public partial class UsersPageVM : ObservableObject
    {
        [ObservableProperty]
        public int id;
        [ObservableProperty]
        public string username ;
        [ObservableProperty]
        public string password ;
        [ObservableProperty]
        public string firstname;
        [ObservableProperty]
        public string lastname;
        [ObservableProperty]
        public string contactNo;
        //private object IsAdmin;
        [ObservableProperty]
        public ObservableCollection<user> databaseUsers;

        
        public user _selectedUser;

        public UsersPageVM()
        {
            LoadUser();
        }        
        public user SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                SetProperty(ref _selectedUser, value);
                if (value != null)
                {
                    Id = value.Id;
                    Username = value.Username;
                    Firstname = value.Firstname;
                    Lastname = value.Lastname;
                    ContactNo = value.ContactNo;
                    //IsAdmin = value.IsAdmin;
                }
            }
        }

        public string AddString()
        {
            string Fullname = Firstname + Lastname;
            return Fullname;
        }

        public void LoadUser()
        {
            using (var db = new MyDbContext())
            {
                DatabaseUsers = new ObservableCollection<user>(db.users.ToList());
            }
        }

        [RelayCommand]
        public void CreateUser()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(ContactNo) || string.IsNullOrWhiteSpace(Firstname) || string.IsNullOrWhiteSpace(Lastname))
            {
                MessageBox.Show("Please fill in all the fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                var User = new user
                {
                    Username = Username,
                    Password = Password,
                    Firstname= Firstname,
                    Lastname= Lastname,
                    ContactNo = ContactNo,

                };

                using (var db = new MyDbContext())
                {
                    db.users.Add(User);
                    db.SaveChanges();
                }
                //Reset();
                LoadUser();
            }
        }

       

        //updatestaff metode
        [RelayCommand]
        public void EditUser()
        {
            if (SelectedUser.Username != Username || SelectedUser.ContactNo!= ContactNo || SelectedUser.Firstname != Firstname || SelectedUser.Lastname != Lastname)
            {
                using var db = new MyDbContext();
                var user = db.users.Find(id);
                user.Username = Username;
                user.ContactNo= ContactNo;
                //staff.IsAdmin = IsAdmin;    
                db.SaveChanges();

                LoadUser();
                SelectedUser= null;
                Reset();
            }
            else
            {
                MessageBox.Show("No changes made", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        [RelayCommand]
        public void DeleteUser()
        {
            if (SelectedUser == null)
            {
                return;
            }

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this person?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new MyDbContext())
                {
                    db.users.Remove(SelectedUser);
                    db.SaveChanges();
                }
                LoadUser();
            }
            SelectedUser = null;
            Reset();
        }

        

        [RelayCommand]
        public void Reset()
        {
            Id = 0;
            Username= "";
            ContactNo = "";
            Firstname = "";
            Lastname = "";
            //Phone = 0;
            //IsAdmin = false;
            LoadUser();
        }

        

    }
}
