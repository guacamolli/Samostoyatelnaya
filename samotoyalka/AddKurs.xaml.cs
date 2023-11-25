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

namespace samotoyalka.bd
{
    /// <summary>
    /// Логика взаимодействия для AddKurs.xaml
    /// </summary>
    public partial class AddKurs : Window
    {
        private Курсы _currentКурс = new Курсы();
        public AddKurs(Курсы selectedКурсы)
        {
            InitializeComponent();

            if (selectedКурсы != null)
                _currentКурс = selectedКурсы;

            DataContext = _currentКурс;
        }

        private void saveStudentButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentКурс.Название))
                errors.AppendLine("Укажите название");
            if (string.IsNullOrWhiteSpace(_currentКурс.Расшифровка))
                errors.AppendLine("Укажите расшифровку");
            if (string.IsNullOrWhiteSpace(_currentКурс.Длительность))
                errors.AppendLine("Укажите длительность");
            if (_currentКурс.Код == 0)
                errors.AppendLine("Укажите код курса");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            studentsEntities.GetContext().Курсы.Add(_currentКурс);

            try
            {
                studentsEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена.");
                MainWindow main_win = new MainWindow();
                main_win.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void backStudentButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main_win = new MainWindow();
            main_win.Show();
            this.Close();
        }
    }
}
