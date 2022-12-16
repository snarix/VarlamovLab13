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
using System.IO;

namespace VarlamovLab13
{
    /// <summary>
    /// Логика взаимодействия для Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {
        public Setting()
        {
            InitializeComponent();
            this.Height += 25;
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            try
            {
                int rowCount = Int32.Parse(KolRow.Text);
                int columnCount = Int32.Parse(KolColumns.Text);

                StreamWriter streamWriter = new("config1.ini");
                using (streamWriter)
                {
                    streamWriter.WriteLine(rowCount);
                    streamWriter.WriteLine(columnCount);
                    Close();
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Данные введены неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
