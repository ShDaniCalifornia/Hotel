using Hotel.AppData;
using System.Windows;

namespace Hotel.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        void ChangePassword()
        {
            if (string.IsNullOrEmpty(OldPasswordPb.Password) ||
               string.IsNullOrEmpty(NewPasswordPb.Password) ||
               string.IsNullOrEmpty(AcceptNewPasswordPb.Password))

            {
                FeedBack.Warning("Все поля обязательны для заполнения! Заполните каждое поле!");
            }
            else if (OldPasswordPb.Password != App.currentUser.Password)
            {
                FeedBack.Error("Неверно введен текущий пароль! Попробуйте снова.");
            }
            else if (NewPasswordPb.Password != AcceptNewPasswordPb.Password)
            {
                FeedBack.Error("Новые пароли не совпадают! Попробуйте снова.");
            }
            else if (OldPasswordPb.Password == NewPasswordPb.Password)
            {
                FeedBack.Error("Старый и новый пароль совпадают! Придумайте новый пароль.");
            }
            else
            {
                App.currentUser.Password = NewPasswordPb.Password;
                App.currentUser.IsActivated = true;
                App.context.SaveChanges();

                FeedBack.Information("Пароль успешно изменен!");
                Close();
            }
        }

        private void ChangePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword();
        }
    }
}
