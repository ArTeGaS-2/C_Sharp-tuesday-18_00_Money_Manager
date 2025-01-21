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
using System.IO;
using System.Diagnostics;

namespace ВТ_18_00_Money_Manager
{
    public partial class MainWindow : Window
    {
        // ObservableCollection для зберігання транзакцій,
        // автоматично оновлює UI при додаванні/видаленні елементів
        private ObservableCollection<Transaction> Transactions_;
        // Змінна для зберігання поточного балансу
        private decimal Balance;
        public MainWindow()
        {
            InitializeComponent();
            // Ініціалізація колекції транзакцій
            Transactions_ = new ObservableCollection<Transaction>();
            // Прив'язка ListView до колекції Transactions
            TransactionHistoryListView.ItemsSource = Transactions_;
            // Ініціалізація балансу як нуль
            Balance = 0;

        }
        private void AddTransaction_Click(object sender, RoutedEventArgs e)
        {
            // Отримання вибраного типу транзакції з ComboBox
            string type = ((ComboBoxItem)TransactionTypeCombobox.SelectedItem
                )?.Content.ToString();
            // Отримання вибраної категорії з ComboBox
            string category = ((ComboBoxItem)CategoryComboBox.SelectedItem
                )?.Content.ToString();
            // Отримання введеної користувачем суми
            string amountText = AmountTextBox.Text;
            // Отримання вибраної дати з DataPicker
            DateTime? date = TransactionDatePicker.SelectedDate;

            // Перевірка що всі поля заповнені
            if (string.IsNullOrEmpty(type) ||
                string.IsNullOrEmpty(category) ||
                string.IsNullOrEmpty(amountText) ||
                !date.HasValue)
            {
                MessageBox.Show("Введіть корректну суму.", "Помилка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // Спроба перетворити введену суму на значення типу decimal
            if (!decimal.TryParse(amountText, out decimal amount))
            {
                MessageBox.Show("Введіть коректну суму", "Помилка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (type == "Витрати")
            {
                amount = -amount;
            }
            // Створення нового об'єкта Transaction з наданими даними
            Transaction transaction = new Transaction
            {
                Date = date.Value.ToString("dd.MM.yyyy"),
                Type = type,
                Category = category,
                Amount = amount,
            };
            // Додавання транзакції до колекції
            Transactions_.Add(transaction);
            // Оновлення балансу з урахуванням нової транзакції
            Balance += amount;
            // Оновлення BalabceTextBlock для відображуння нового балансу
            BalanceTextBlock.Text = Balance.ToString("0.00 грн");
            // Очищення полів введення для наступного запису
            AmountTextBox.Clear();
            TransactionDatePicker.SelectedDate = null;
        }
        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            // Закриття застосунку
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process unityGame = new Process();
            unityGame.StartInfo.FileName = @"..\..\Clicker\ВТ-18-00-C#.exe";
            unityGame.StartInfo.UseShellExecute = false;
            unityGame.Start();
        }
    }
    // Клас для представлення фінансової транзакції
    public class Transaction
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
