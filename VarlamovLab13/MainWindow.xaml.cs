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
using Library1;
using Microsoft.Win32;

namespace VarlamovLab13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Height += 25;
        }
        Matrix<int> matrix = new(0, 0);
        private void Create(object sender, RoutedEventArgs e)
        {
            try
            {
                matrix = new Matrix<int>(Int32.Parse(Row.Text), Int32.Parse(Column.Text));
                matrix.CreateArray();
                MatrixGrid.ItemsSource = matrix.ToDataTable().DefaultView;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Данные введены неверно","Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            rez.Text = matrix.FindNumberMaxIdentity().ToString();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new();
                saveFileDialog.DefaultExt = matrix.Extension;
                if (saveFileDialog.ShowDialog() == true)
                {
                    matrix.Save(saveFileDialog.FileName);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Выбран неверный файл", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Load(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.DefaultExt = matrix.Extension;
            openFileDialog.Filter = "Матрица| *.matrix";
            if (openFileDialog.ShowDialog() == true)
            {
                matrix.Load(openFileDialog.FileName);
                MatrixGrid.ItemsSource = matrix.ToDataTable().DefaultView;
            }
        }

        private void Row_TextChanged(object sender, TextChangedEventArgs e)
        {
            rez.Text = null;
        }

        private void Column_TextChanged(object sender, TextChangedEventArgs e)
        {
            rez.Text = null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Window1 password = new();
            password.Owner = this;
            password.ShowDialog();
        }

        private void Setting(object sender, RoutedEventArgs e)
        {
            Setting setting = new();
            setting.Owner = this;
            setting.ShowDialog();
        }

        private void AboutProgramm(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дана целочисленная матрица размера M * N." +
                "\r\nНайти номер последней из ее строк,содержащих максимальное количество одинаковых элементов.");
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы действительно хотите закончить работу с программой?", "Выход");
            Close();
        }
    }
}
