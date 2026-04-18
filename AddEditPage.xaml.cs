using Exam.Connections;
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

namespace Exam
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        Products products;
        bool isAdd = false;
        public AddEditPage(Products _products)
        {
            InitializeComponent();
            products = _products;
            this.DataContext = products;
            ProductTypeCmb.ItemsSource = Conn.almazEntities.ProductType.ToList();
            // Выводим именно название типа продукта а не айди
            ProductTypeCmb.DisplayMemberPath = "Name";
            if (products.Articule == null || products.Articule.ToString() == "")
            {
                isAdd = true;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                products.IdProductType = (ProductTypeCmb.SelectedItem as ProductType).Id;
                if (isAdd)
                {
                    Conn.almazEntities.Products.Add(products);
                }
                Conn.almazEntities.SaveChanges();
                MessageBox.Show("Операция выполнена");
                NavigationService.Navigate(new ProdcutListPage());
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CanselBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProdcutListPage());
        }

    }
}
