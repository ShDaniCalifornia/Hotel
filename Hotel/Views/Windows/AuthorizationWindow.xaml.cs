using Hotel.AppData;
using System;
using System.Linq;
using System.Windows;

namespace Hotel.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>

    public partial class AuthorizationWindow : Window
    {
        /// <summary>
        /// Представляет поле для хранения количества попыток входа.
        /// </summary>

        int loginAttemptCount = 0;


        public AuthorizationWindow()
        {
            InitializeComponent();

            BlockingUserByDate();
        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validation() == true)
            {
                Authentication();

            }
        }

        public bool Validation()
        {
            if (string.IsNullOrEmpty(LoginTb.Text) && string.IsNullOrEmpty(PasswordPb.Password))
            {
                FeedBack.Warning("Поля для ввода не должны быть пустыми. Введите логин и пароль!");
                return false;
            }
            else if (string.IsNullOrEmpty(LoginTb.Text))
            {
                FeedBack.Warning("Поле для ввода логина не должно быть пустым. Введите логин!");
                return false;
            }
            else if (string.IsNullOrEmpty(PasswordPb.Password))
            {
                FeedBack.Warning("Поле для ввода пароля не должно быть пустым. Введите пароль!");
                return false;
            }

            return true;
        }

        public void Authentication()
        {
            // Проверка данных
            App.currentUser = App.context.User.FirstOrDefault(user => user.Login == LoginTb.Text && user.Password == PasswordPb.Password);
            if (App.currentUser == null)
            {
                loginAttemptCount++;

                FeedBack.Error($"Вы ввели неверный логин или пароль. Пожалуйста, проверьте еще раз введенные данные. Попытка: {loginAttemptCount} из 3");

                if (loginAttemptCount == 3)
                {
                    // App.currentUser.IsBlocked = true;
                    loginAttemptCount = 0;
                    FeedBack.Error("Вы заблокированы. Обратитесь к администратору!");
                    Close();
                }
            }
            else if (App.currentUser.IsBlocked == true)
            {
                FeedBack.Error("Вы заблокированы. Обратитесь к администратору!");
            }
            else if (App.currentUser.IsActivated == false)
            {
                ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow();
                changePasswordWindow.ShowDialog();
            }
            else
            {
                FeedBack.Information("Вы успешно авторизовались!");
                Authorization();
            }
        }

        public void Authorization()
        {
            switch (App.currentUser.RoleId)
            {
                case 1:
                    AdministratorWindow administrationWindow = new AdministratorWindow();
                    administrationWindow.Show();
                    break;
                case 2:
                    UserWindow userWindow = new UserWindow();
                    userWindow.Show();
                    break;
                default:
                    FeedBack.Error("Роль пользователя не найдена! Доступ запрещен");
                    break;
            }
            Close();
        }

        private void BlockingUserByDate()
        {
            foreach (var user in App.context.User.Where(u => u.RoleId == 2))
            {
                if (user.RegistrationDate.AddMonths(1) < DateTime.Now.Date && user.IsActivated == false)
                {
                    user.IsBlocked = true;
                }
            }
            App.context.SaveChanges();
        }
    }
}
