using POS2.ViewModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;


namespace POS2.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            DataContext = new LoginVM();
            InitializeComponent();
        }

        //private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (e.ChangedButton == MouseButton.Left)
        //    {
        //        this.DragMove();
        //    }
        //}

        

    }
}
