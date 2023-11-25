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
using System.Windows.Shapes;

namespace samotoyalka
{
    /// <summary>
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        private Студенты _currentStudent = new Студенты();
        public AddStudent(Студенты selectedСтуденты)
        {
            InitializeComponent();

            if (selectedСтуденты != null)
                _currentStudent = selectedСтуденты;

            DataContext = _currentStudent;
        }

        private void saveStudentButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentStudent.ФИО))
                errors.AppendLine("Укажите ФИО");
            if (string.IsNullOrWhiteSpace(_currentStudent.Почта))
                errors.AppendLine("Укажите почту");
            if (_currentStudent.Курс == 0)
                errors.AppendLine("Укажите код курса");
            if (_currentStudent.Код == 0)
                errors.AppendLine("Укажите код студента");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            studentsEntities.GetContext().Студенты.Add(_currentStudent);

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
