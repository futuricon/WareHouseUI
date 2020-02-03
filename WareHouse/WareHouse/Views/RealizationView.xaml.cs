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
    /// Логика взаимодействия для RealizationView.xaml
    /// </summary>
    public partial class RealizationView : UserControl
    {
        public RealizationView()
        {
            InitializeComponent();
            var orders = GetOrders();
            if (orders.Count > 0)
                listView.ItemsSource = orders;
        }

        private List<TestRealization> GetOrders()
        {
            return new List<TestRealization>()
            {
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
                new TestRealization(1, "TestName1", DateTime.Now, 50, 556565656, true),
            };
        }
    }
}
