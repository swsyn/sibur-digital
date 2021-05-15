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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MESClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MESServiceClient client = new MESServiceClient("BasicHttpBinding_IMESService");
        public MainWindow()
        {
            InitializeComponent();
            AvailabilityDepartmentsGrid.ItemsSource = client.GetDepartments();
            TrafficDepartmentsGrid.ItemsSource = client.GetDepartments();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            client.Close();
        }

        private void AvailabilityDepartmentsGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "ExtensionData" || e.PropertyName == "Parent" || e.PropertyName == "Id" || e.PropertyName == "ProductAvailabilities")
            {
                e.Column = null;
            }
            if (e.PropertyName == "Name")
            {
                e.Column.Header = "Наименование подразделения";
            }
        }

        private void TrafficDepartmentsGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "ExtensionData" || e.PropertyName == "Parent" || e.PropertyName == "Id" || e.PropertyName == "ProductAvailabilities")
            {
                e.Column = null;
            }
            if (e.PropertyName == "Name")
            {
                e.Column.Header = "Наименование подразделения";
            }
        }

        private void PopulateAvailProductsGrid()
        {
            var productAvailabilities = client.GetDepartmentAvailability((Department)AvailabilityDepartmentsGrid.SelectedItem);
            List<ProductInstance> productInstances = new List<ProductInstance>();
            foreach (ProductAvailability pa in productAvailabilities)
            {
                productInstances.Add(new ProductInstance { Id = pa.Id, ProductName = pa.Product.Name, DepartmentName = pa.Department.Name });
            }
            AvailabilityProductsGrid.ItemsSource = productInstances;
        }

        private void PopulateInputMovement()
        {
            var inputMovements = client.GetInputMovements((Department)TrafficDepartmentsGrid.SelectedItem);
            List<ProductInputMovement> productInputMovements = new List<ProductInputMovement>();
            foreach (Movement p in inputMovements)
            {
                productInputMovements.Add(new ProductInputMovement
                {
                    Id = p.Id,
                    ProductName = p.Product.Name,
                    SourceName = p.Source.Name,
                    MovementDate = p.MovementDate,
                    TeamName = p.Team.Name
                });
            }
            InputTrafficGrid.ItemsSource = productInputMovements;
        }

        private void PopulateOutputMovement()
        {
            var outputMovements = client.GetOutputMovements((Department)TrafficDepartmentsGrid.SelectedItem);
            List<ProductOutputMovement> productOutputMovements = new List<ProductOutputMovement>();
            foreach (Movement p in outputMovements)
            {
                productOutputMovements.Add(new ProductOutputMovement
                {
                    Id = p.Id,
                    ProductName = p.Product.Name,
                    DestinationName = p.Destination.Name,
                    MovementDate = p.MovementDate,
                    TeamName = p.Team.Name
                });
            }
            OutputTrafficGrid.ItemsSource = productOutputMovements;
        }

        private void AvailabilityDepartmentsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateAvailProductsGrid();
        }

        private void TrafficDepartmentsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateInputMovement();
            PopulateOutputMovement();
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AvailabilityDepartmentsGrid.SelectedItem != null)
            {
                AddProductWindow addProductWindow = new AddProductWindow(client, ((Department)AvailabilityDepartmentsGrid.SelectedItem).Id);
                addProductWindow.ShowDialog();
                PopulateAvailProductsGrid();
            }
            else
            {
                MessageBox.Show("Выберите подразделение");
            }
        }

        private void DeleteProductBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AvailabilityProductsGrid.SelectedItems.Count > 0)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Удалить выбранные изделия?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    int[] productIds = new int[AvailabilityProductsGrid.SelectedItems.Count];
                    for (int i = 0; i < productIds.Length; i++)
                    {
                        productIds[i] = ((ProductInstance)AvailabilityProductsGrid.SelectedItems[i]).Id;
                    }
                    client.DeleteProducts(productIds);
                    PopulateAvailProductsGrid();
                }
            }
            else
            {
                MessageBox.Show("Выберите изделия");
            }
        }

        private void TakeProductBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AvailabilityProductsGrid.SelectedItems.Count > 0)
            {
                int[] productIds = new int[AvailabilityProductsGrid.SelectedItems.Count];
                for (int i = 0; i < productIds.Length; i++)
                {
                    productIds[i] = ((ProductInstance)AvailabilityProductsGrid.SelectedItems[i]).Id;
                }
                TakeProductWindow takeProductWindow = new TakeProductWindow(client, productIds);
                takeProductWindow.ShowDialog();
                PopulateAvailProductsGrid();
            }
            else
            {
                MessageBox.Show("Выберите изделия");
            }
        }

        private void GiveProductBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AvailabilityProductsGrid.SelectedItems.Count > 0)
            {
                int[] productIds = new int[AvailabilityProductsGrid.SelectedItems.Count];
                for (int i = 0; i < productIds.Length; i++)
                {
                    productIds[i] = ((ProductInstance)AvailabilityProductsGrid.SelectedItems[i]).Id;
                }
                GiveProductWindow giveProductWindow = new GiveProductWindow(client, productIds);
                giveProductWindow.ShowDialog();
                PopulateAvailProductsGrid();
            }
            else
            {
                MessageBox.Show("Выберите изделия");
            }
        }

        private void AvailabilityProductsGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "ExtensionData")
            {
                e.Column = null;
            }
            if (e.PropertyName == "ProductName")
            {
                e.Column.Header = "Изделие";
            }
            if (e.PropertyName == "DepartmentName")
            {
                e.Column.Header = "Участок";
            }
            if (e.PropertyName == "Id")
            {
                e.Column.Header = "#";
            }
        }

        private void InputTrafficGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "ExtensionData")
            {
                e.Column = null;
            }
            if (e.PropertyName == "Id")
            {
                e.Column.Header = "#";
            }
            if (e.PropertyName == "ProductName")
            {
                e.Column.Header = "Изделие";
            }
            if (e.PropertyName == "SourceName")
            {
                e.Column.Header = "Источник";
            }
            if (e.PropertyName == "MovementDate")
            {
                e.Column.Header = "Дата поступления";
            }
            if (e.PropertyName == "TeamName")
            {
                e.Column.Header = "Бригада";
            }
        }

        private void OutputTrafficGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "ExtensionData")
            {
                e.Column = null;
            }
            if (e.PropertyName == "Id")
            {
                e.Column.Header = "#";
            }
            if (e.PropertyName == "ProductName")
            {
                e.Column.Header = "Изделие";
            }
            if (e.PropertyName == "DestinationName")
            {
                e.Column.Header = "Приемник";
            }
            if (e.PropertyName == "MovementDate")
            {
                e.Column.Header = "Дата поступления";
            }
            if (e.PropertyName == "TeamName")
            {
                e.Column.Header = "Бригада";
            }
        }
    }
}
