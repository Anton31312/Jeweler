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
using Jeweler.ClassHelper;
using Jeweler.EF;

namespace Jeweler.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientAndManagerWindow.xaml
    /// </summary>
    public partial class ClientAndManagerWindow : Window
    {
        private List<string> listSort = new List<string>()
        {
            "Стоимость (по возрастанию)",
            "Стоимость (по убыванию)"
        };

        List<ProductManufature> manufature = new List<ProductManufature>();

        List<Product> listProduct = new List<Product>();

        private void Filter() // Поиск, фильтрация, сортировка
        {
            listProduct = AppData.Context.Product.ToList();

            // Поиск
            listProduct = listProduct.
            Where(i => i.ProductName.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.ProductManufature.NameManufacture.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.ProductSupplier.NameSupplier.ToLower().Contains(txtSearch.Text.ToLower())).
            ToList();

            // Сортировка
            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    listProduct = listProduct.OrderBy(i => i.ProductCost).ToList(); // сортировка по возрастанию
                    break;

                case 1:
                    listProduct = listProduct.OrderByDescending(i => i.ProductCost).ToList(); // сортировка по убыванию
                    break;

                default:
                    listProduct = listProduct.OrderBy(i => i.ProductCost).ToList();
                    break;
            }


            // Фильтрация
            if (cmbFilter.SelectedIndex != 0)
            {
                listProduct = listProduct.Where(i => i.IDProductManufacturer == cmbFilter.SelectedIndex).ToList();
            }
        }

        public ClientAndManagerWindow()
        {
            InitializeComponent();
            try
            {
                cmbSort.ItemsSource = listSort;
                cmbSort.SelectedIndex = 0;

                manufature = AppData.Context.ProductManufature.ToList();

                manufature.Insert(0, new ProductManufature { NameManufacture = "Все производители" }); // добавление в список элемента "Все производители"
                cmbFilter.ItemsSource = manufature; // заполнеие ComboBox для фильтрации
                cmbFilter.DisplayMemberPath = "NameManufacture";
                cmbFilter.SelectedIndex = 0;

                Filter();
            }
            catch
            {
                MessageBox.Show("Warning x0\nПроизошла непредвиденная ошибка\nПотеряно соединение с базой данных");
            }
        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}
