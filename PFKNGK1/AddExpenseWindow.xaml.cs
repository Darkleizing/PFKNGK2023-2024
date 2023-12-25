using PFKNGK1.AppData;
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

namespace PFKNGK1
{
    /// <summary>
    /// Логика взаимодействия для AddExpenseWindow.xaml
    /// </summary>
    public partial class AddExpenseWindow : Window
    {
        private readonly PFKNGK1Entities _dbContext = new PFKNGK1Entities();

        public AddExpenseWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Создание новой категории расходов на основе введенных данных
            var newExpenseCategory = new Виды_расходов
            {
                Название_категории = NameTextBox.Text,
                Описание = DescriptionTextBox.Text,
                Предельная_сумма = Convert.ToDecimal(LimitTextBox.Text)
            };

            _dbContext.Виды_расходов.Add(newExpenseCategory); // Добавление новой категории расходов в базу данных
            _dbContext.SaveChanges(); // Сохранение изменений
            this.Close(); // Закрытие окна после добавления
        }
    }
}
