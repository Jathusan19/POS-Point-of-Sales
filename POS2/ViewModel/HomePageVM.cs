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
    public partial class HomePageVM : ObservableObject
    {
        [ObservableProperty]
        public int itemCode;
        [ObservableProperty]
        public string itemName;
        [ObservableProperty]
        public float unitPrice;
        [ObservableProperty] public int quantity;
        [ObservableProperty] public float subTotal = 0;
        [ObservableProperty] public float total=0;
        [ObservableProperty]
        public ObservableCollection<menuitem> databasemenuitems;
        [ObservableProperty]
        public ObservableCollection<menuitem> cart;



        [ObservableProperty]
        public menuitem selectedMenuItem;
        [ObservableProperty]
        public menuitem selectedCartItem;

        public HomePageVM()
        {
            Cart = new ObservableCollection<menuitem>();
            LoadMenuitem();
        }

       


        public void LoadMenuitem()
        {
            using (var db = new MyDbContext())
            {
                Databasemenuitems = new ObservableCollection<menuitem>(db.menuitems.ToList());

            }
        }

       



        //Add to cart

        [RelayCommand]
        public void AddToCart()
        {
            Cart.Add(SelectedMenuItem);
            SubTotal *= SelectedMenuItem.UnitPrice * SelectedMenuItem.Quantity;
            Total = Cart.Sum(x => x.UnitPrice * x.Quantity);
            Quantity = 0;
        }

        [RelayCommand]
        public void DeleteCart()
        {
            Cart.Remove(SelectedCartItem);

        }



    }
}
