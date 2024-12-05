using Hotel.AppData;
using Hotel.Model;
using Hotel.Views.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Hotel.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        // 2-ой вариант именования: UserRoleId  Можно скопировать
        const int USER_ROLE_ID = 2; // Можно скопировать
        public UsersPage()
        {
            InitializeComponent();

            //Логика пользователей в список при открытии страницы // Можно скопировать
            UserLv.ItemsSource = App.context.User.Where(u => u.RoleId == 2).ToList(); //Можно скопировать
        }

        private void SaveChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            FeedBack.Information("Иноформация успешно изменена!");
            App.context.SaveChanges();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            if (addUserWindow.ShowDialog() == true)
            {
                UserLv.ItemsSource = App.context.User.ToList();
            }
        }

        private void UserLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserDetailsGrid.DataContext = UserLv.SelectedItem as User;
        }

    }
}
