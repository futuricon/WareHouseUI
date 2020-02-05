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
    /// Логика взаимодействия для NewIncomeDialog.xaml
    /// </summary>
    public partial class NewIncomeDialog : UserControl
    {
        public NewIncomeDialog()
        {
            InitializeComponent();
            var orders = GetOrders();
            if (orders.Count > 0)
                listView.ItemsSource = orders;
        }

        private List<TestNewIncome> GetOrders()
        {
            return new List<TestNewIncome>()
            {
                new TestNewIncome(1, "Test Name", 5056451, 555, "TestName1" ),
                new TestNewIncome(1, "Test Name", 5056451, 555, "TestName1" ),
                new TestNewIncome(1, "Test Name", 5056451, 555, "TestName1" ),
                new TestNewIncome(1, "Test Name", 5056451, 555, "TestName1" ),
                new TestNewIncome(1, "Test Name", 5056451, 555, "TestName1" ),
                new TestNewIncome(1, "Test Name", 5056451, 555, "TestName1" ),
                new TestNewIncome(1, "Test Name", 5056451, 555, "TestName1" ),
                new TestNewIncome(1, "Test Name", 5056451, 555, "TestName1" ),
                new TestNewIncome(1, "Test Name", 5056451, 555, "TestName1" ),
                new TestNewIncome(1, "Test Name", 5056451, 555, "TestName1" ),
                new TestNewIncome(1, "Test Name", 5056451, 555, "TestName1" ),
                new TestNewIncome(1, "Test Name", 5056451, 555, "TestName1" ),
                new TestNewIncome(1, "Test Name", 5056451, 555, "TestName1" ),
                new TestNewIncome(1, "Test Name", 5056451, 555, "TestName1" ),
                new TestNewIncome(1, "Test Name", 5056451, 555, "TestName1" ),
                new TestNewIncome(1, "Test Name", 5056451, 555, "TestName1" ),
                new TestNewIncome(1, "Test Name", 5056451, 555, "TestName1" ),
                new TestNewIncome(1, "Test Name", 5056451, 555, "TestName1" ),
                new TestNewIncome(1, "Test Name", 5056451, 555, "TestName1" )
            };
        }
    }
}
