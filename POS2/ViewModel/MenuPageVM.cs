using CommunityToolkit.Mvvm.ComponentModel;
using System;
using POS2.Model;
using POS2.View;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace POS2.ViewModel
{
    public partial class MenuPageVM : ObservableObject
    {
        [ObservableProperty]
        public int itemCode;
        [ObservableProperty]
        public string itemName;
        [ObservableProperty]
        public float unitPrice;
        [ObservableProperty] public int quantity;
        [ObservableProperty] public float subTotal=0;
        [ObservableProperty]
        public ObservableCollection<menuitem> databasemenuitems;
        [ObservableProperty]
        public ObservableCollection<menuitem> cart;


        
        public menuitem _selectedMenuItem;

        public MenuPageVM()
        {
            LoadMenuitem();
        }

        public menuitem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                SetProperty(ref _selectedMenuItem, value);
                if (value != null)
                {
                    ItemCode = value.ItemCode; 


                    ItemName = value.ItemName;
                }
            }

           
        }


        public void LoadMenuitem()
        {
            using (var db = new MyDbContext())
            {
                Databasemenuitems = new ObservableCollection<menuitem>(db.menuitems.ToList());
            }
        }

        [RelayCommand]
        public void CreateMenuItem()
        {
            if (string.IsNullOrWhiteSpace(ItemName))
            {
                MessageBox.Show("Please fill in all the fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                var Menuitem = new menuitem
                {
                    ItemCode = ItemCode,
                    ItemName = ItemName,
                    UnitPrice = UnitPrice,

                };

                using (var db = new MyDbContext())
                {
                    db.menuitems.Add(Menuitem);
                    db.SaveChanges();
                }
                //Reset();
                LoadMenuitem();
            }
        }

        [RelayCommand]
        public void EditMenuItem()
        {
            if (SelectedMenuItem.ItemCode != ItemCode || SelectedMenuItem.ItemName != ItemName || SelectedMenuItem.UnitPrice != UnitPrice )
            {
                using var db = new MyDbContext();
                var menuitem = db.menuitems.Find(ItemCode);
                menuitem.ItemName = ItemName;
                menuitem.UnitPrice = UnitPrice;
                menuitem.ItemCode = ItemCode;
                  
                db.SaveChanges();

                LoadMenuitem();
                SelectedMenuItem = null;
               
            }
            else
            {
                MessageBox.Show("No changes made", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        [RelayCommand]
        public void DeleteMenuItem()
        {
            if (SelectedMenuItem == null)
            {
                return;
            }

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this person?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new MyDbContext())
                {
                    db.menuitems.Remove(SelectedMenuItem);
                    db.SaveChanges();
                }
                LoadMenuitem();
            }
            SelectedMenuItem = null;
           
        }





    }
}
