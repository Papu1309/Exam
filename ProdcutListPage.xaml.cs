using Exam.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Exam
{
    /// <summary>
    /// Логика взаимодействия для ProdcutListPage.xaml
    /// </summary>
    public partial class ProdcutListPage : Page
    {
        public ProdcutListPage()
        {
            InitializeComponent();
            //Инициализация таблицы продукт внутри листа
            ProductLV.ItemsSource = Connections.Conn.almazEntities.Products.ToList();
            
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedproduct = ProductLV.SelectedItem as Products;
            if (selectedproduct != null)
            {
                NavigationService.Navigate(new AddEditPage(selectedproduct));
            }
            else 
            {
                MessageBox.Show("Выберите продукт");
            }

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditPage(new Products()));

        }
    }
}
