using Hotel.Views.Pages;
using System.Windows;

namespace Hotel.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        public AdministratorWindow()
        {
            InitializeComponent();

            // Открытие страницы пользователей по умолчанию
            MainFrame.Navigate(new UsersPage());
        }

        private void Rooms_Click(object sender, RoutedEventArgs e)
        {
            // Открытие страницы комнат
            MainFrame.Navigate(new RoomsPage());
        }

        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {
            // Отк
            MainFrame.Navigate(new UsersPage());
        }
    }
}
