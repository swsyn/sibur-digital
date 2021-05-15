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
    /// Логика взаимодействия для GiveProductWindow.xaml
    /// </summary>
    public partial class GiveProductWindow : Window
    {
        private MESServiceClient client;
        private int[] productIds;
        public GiveProductWindow()
        {
            InitializeComponent();
        }

        public GiveProductWindow(MESServiceClient client, int[] productIds)
        {
            InitializeComponent();
            this.client = client;
            this.productIds = productIds;
            TeamsComboBox.ItemsSource = client.GetTeams();
            TeamsComboBox.DisplayMemberPath = "Name";
            TeamsComboBox.SelectedValuePath = "Id";
            TeamsComboBox.SelectedIndex = 0;
            ProductsComboBox.ItemsSource = client.GetProducts();
            ProductsComboBox.DisplayMemberPath = "Name";
            ProductsComboBox.SelectedValuePath = "Id";
            ProductsComboBox.SelectedIndex = 0;
        }

        private void GiveProductBtn_Click(object sender, RoutedEventArgs e)
        {
            client.GiveProduct(productIds, (int)TeamsComboBox.SelectedValue, (int)ProductsComboBox.SelectedValue);
            this.Close();
        }
    }
}
