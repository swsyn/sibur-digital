using MESClient.MESServiceReference;
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

namespace MESClient
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private MESServiceClient client;
        private int departmentId;
        public AddProductWindow()
        {
            InitializeComponent();
        }

        public AddProductWindow(MESServiceClient client, int departmentId)
        {
            InitializeComponent();
            this.client = client;
            this.departmentId = departmentId;
            ProductsComboBox.ItemsSource = client.GetProducts();
            ProductsComboBox.DisplayMemberPath = "Name";
            ProductsComboBox.SelectedValuePath = "Id";
            ProductsComboBox.SelectedIndex = 0;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            client.AddProduct((int)ProductsComboBox.SelectedValue, departmentId);
            this.Close();
        }
    }
}
