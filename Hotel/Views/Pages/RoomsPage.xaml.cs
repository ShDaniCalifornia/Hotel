using Hotel.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Hotel.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для RoomsPage.xaml
    /// </summary>
    public partial class RoomsPage : Page
    {
        List<Status> statuses = App.context.Status.ToList();

        public RoomsPage()
        {
            InitializeComponent();

            RoomsLb.ItemsSource = App.context.Room.ToList();

            statuses.Insert(0, new Status { Name = "Все статусы" });
            FilterCmb.ItemsSource = statuses;
            FilterCmb.DisplayMemberPath = "Name";
            FilterCmb.SelectedValue = "Id";
            FilterCmb.SelectedIndex = 0;
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RoomsLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
