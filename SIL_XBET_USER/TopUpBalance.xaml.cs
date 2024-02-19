using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SIL_XBET_BANK;
using SIL_XBET_USER;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows;

namespace SIL_XBET_USER
{
    
    public partial class TopUpBalance : Window
    {
        public TopUpBalance()
        {
            InitializeComponent();
        }

        private void TopUpBalance_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что поле ввода не пустое
            if (string.IsNullOrWhiteSpace(amountTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите сумму для пополнения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Пытаемся преобразовать введенное значение в десятичное число
            if (!decimal.TryParse(amountTextBox.Text, out decimal amount))
            {
                MessageBox.Show("Некорректная сумма. Пожалуйста, введите число.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Проверяем, что сумма для пополнения больше нуля
            if (amount <= 0)
            {
                MessageBox.Show("Сумма для пополнения должна быть больше нуля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Ваша логика для пополнения баланса
            // Например:
            // authUser.Balance += amount;
            // Сохранение изменений в базе данных

            MessageBox.Show($"Баланс успешно пополнен на {amount}.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}


