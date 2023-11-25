using samotoyalka.bd;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace samotoyalka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dgStudents.ItemsSource = studentsEntities.GetContext().Студенты.ToList();
            dgKursy.ItemsSource = studentsEntities.GetContext().Курсы.ToList();
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            AddStudent addStudent_win = new AddStudent(null);
            addStudent_win.Show();
            this.Close();
        }
        private void EditStudentButton_Click(object sender, RoutedEventArgs e)
        {
            AddStudent addStudent_win = new AddStudent((sender as Button).DataContext as Студенты);
            addStudent_win.Show();
            this.Close();
        }
        private void DeleteStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var сотрудникиForRemoving = dgStudents.SelectedItems.Cast<Студенты>().ToList();

            if (MessageBox.Show($"Вы точно хотите {сотрудникиForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    studentsEntities.GetContext().Студенты.RemoveRange(сотрудникиForRemoving);
                    studentsEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    MainWindow main_win = new MainWindow();
                    this.Close();
                    main_win.Show();

                }
                catch (Exception ex)
                {
                    this.Close();
                    MessageBox.Show(ex.Message.ToString());

                }
            }
        }

        private void EditKursButton_Click(object sender, RoutedEventArgs e)
        {
            AddKurs addKursy_win = new AddKurs((sender as Button).DataContext as Курсы);
            addKursy_win.Show();
            this.Close();
        }
        private void AddKursButton_Click(object sender, RoutedEventArgs e)
        {
            AddKurs addKursy_win = new AddKurs(null);
            addKursy_win.Show();
            this.Close();
        }
        private void DeleteKursButton_Click(object sender, RoutedEventArgs e)
        {
            var курсыForRemoving = dgKursy.SelectedItems.Cast<Курсы>().ToList();

            if (MessageBox.Show($"Вы точно хотите {курсыForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    studentsEntities.GetContext().Курсы.RemoveRange(курсыForRemoving);
                    studentsEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    MainWindow main_win = new MainWindow();
                    this.Close();
                    main_win.Show();

                }
                catch (Exception ex)
                {
                    this.Close();
                    MessageBox.Show(ex.Message.ToString());

                }
            }
        }
    }
}
