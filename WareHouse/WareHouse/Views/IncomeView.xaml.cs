using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WareHouse.Views
{
    /// <summary>
    /// Логика взаимодействия для IncomeView.xaml
    /// </summary>
    public partial class IncomeView : UserControl
    {
        public IncomeView()
        {
            InitializeComponent();
            var orders = GetOrders();
            if (orders.Count > 0)
                listView.ItemsSource = orders;
        }

        private List<TestIncome> GetOrders()
        {
            return new List<TestIncome>()
            {
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
                new TestIncome(1, DateTime.Now, 50, 556565656, "TestName1" , true),
            };
        }
    }
}
