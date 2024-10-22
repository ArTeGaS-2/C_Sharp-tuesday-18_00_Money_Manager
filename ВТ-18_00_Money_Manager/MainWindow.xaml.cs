using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Util;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ВТ_18_00_Money_Manager
{
    public partial class MainWindow : Window
    {
        // ObservableCollection для зберігання транзакцій,
        // автоматично оновлює UI при додаванні/видаленні елементів
        private ObservableCollection<Transactions> Transactions_;
        // Змінна для зберігання поточного балансу
        private decimal Balance;
        public MainWindow()
        {
            InitializeComponent();
            // Ініціалізація колекції транзакцій
            Transactions_ = new ObservableCollection<Transactions>();
            // Прив'язка ListView до колекції Transactions
            TransactionHistoryListView.ItemsSource = Transactions_;
            // Ініціалізація балансу як нуль
            Balance = 0;

        }
        private void AddTransaction_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
    // Клас для представлення фінансової транзакції
    public class Transtaction
    {
        // Дата транзакції
        public string Date { get; set; }
        // Тип транзакції (Дохід або Витрата)
        public string Type { get; set; }
        // Категорія транзакції
        public string Category {  get; set; }
        // Сума транзакції
        public decimal Amount { get; set; }
    }
}
