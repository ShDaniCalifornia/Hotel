using Hotel.AppData;
using Hotel.Model;
using System;
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
        List<Category> categories = App.context.Category.ToList();

        public RoomsPage()
        {
            InitializeComponent();

            RoomsLB.ItemsSource = App.context.Room.ToList();
            categories.Insert(0, new Category { Name = "Все категории" });
            FilterCMB.ItemsSource = categories;
            FilterCMB.DisplayMemberPath = "Name";
            FilterCMB.SelectedValuePath = "Id";
            FilterCMB.SelectedIndex = 0;
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchTB.Text))
            {
                try
                {
                    int roomNumber = Convert.ToInt32(SearchTB.Text);
                    RoomsLB.ItemsSource = App.context.Room.Where(room => room.Number == roomNumber).ToList();
                }
                catch (FormatException exception)
                {
                    FeedBack.Error($"{exception.Message} Используйте числовые символы для поиска.");
                }
                catch (Exception exception)
                {
                    FeedBack.Error(exception.Message);
                }
            }
            else
            {
                RoomsLB.ItemsSource = App.context.Room.ToList();
            }
        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterCMB.SelectedIndex != 0)
            {
                RoomsLB.ItemsSource = App.context.Room.Where(room => room.CategoryId == FilterCMB.SelectedIndex).ToList();
            }
            else
            {
                RoomsLB.ItemsSource = App.context.Room.ToList();
            }

            CountRoomsByStatusTBL.Text = CountRoomsByStatus();
        }

        public string CountRoomsByStatus()
        {


            return $"";
        }

        private void RoomsLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BoolingBTN_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
