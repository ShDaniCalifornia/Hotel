using Hotel.AppData;
using Hotel.Model;
using System;
using System.Data.Entity.Infrastructure;
using System.Windows;

namespace Hotel.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUser();
        }

        public void AddUser()
        {
            try
            {
                if (string.IsNullOrEmpty(FullnameTb.Text) ||
                    string.IsNullOrEmpty(LoginTb.Text) ||
                    string.IsNullOrEmpty(PasswordPb.Password))
                {
                    FeedBack.Warning("Все поля обязательны для заполнения! Заполните каждое поле!");
                }
                else
                {
                    User newUser = new User()
                    {
                        Fullname = FullnameTb.Text,
                        Login = LoginTb.Text,
                        Password = PasswordPb.Password,
                        RegistrationDate = DateTime.Now.Date,
                        IsActivated = false,
                        IsBlocked = false,
                        RoleId = 2,
                    };

                    App.context.User.Add(newUser);
                    App.context.SaveChanges();

                    FeedBack.Information("Пользователь успешно добавлен!");

                    DialogResult = true;
                }
            }
            catch (DbUpdateException dbUpdateException)
            {
                FeedBack.Error($"Пользователь с таким логином уже существует. Придумайте новый. {dbUpdateException.Message}");
            }
            catch (Exception exeption)
            {
                FeedBack.Error($"Ошибка при добавлении пользователя. {exeption.Message}");
            }
        }
    }
}
