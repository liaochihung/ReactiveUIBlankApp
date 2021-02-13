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
using LoginModule.ViewModels;

namespace ReactiveUIBlankApp
{
    /// <summary>
    /// LoginView.xaml 的互動邏輯
    /// </summary>
    public partial class LoginView : Window
    {
        public static string WindowTitle = "Login";

        public LoginView()
        {
            InitializeComponent();

            DataContext = new LoginViewModel();
        }

        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
