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
    /// Логика взаимодействия для WareHouseView.xaml
    /// </summary>
    public partial class WareHouseView : UserControl
    {
        public WareHouseView()
        {
            InitializeComponent();
            var orders = GetOrders();
            if (orders.Count > 0)
                listView.ItemsSource = orders;
        }


        private List<TestWareHose> GetOrders()
        {
            return new List<TestWareHose>()
            {
                new TestWareHose(1,  "TestName1" , 12, true),
                new TestWareHose(2,  "TestName2" , 13, false),
                new TestWareHose(3,  "TestName3" , 14, true),
                new TestWareHose(4,  "TestName4" , 15, false),
                new TestWareHose(5,  "TestName5" , 16, true),
                new TestWareHose(6,  "TestName6" , 17, false),
                new TestWareHose(7,  "TestName7" , 18, true),
                new TestWareHose(8,  "TestName8" , 19, false),
                new TestWareHose(9,  "TestName9" , 20, true),
                new TestWareHose(10, "TestName10", 21, false),
                new TestWareHose(11, "TestName12", 22, true),
                new TestWareHose(12, "TestName13", 23, false),
                new TestWareHose(13, "TestName14", 24, true),
                new TestWareHose(13, "TestName15", 25, false),
                new TestWareHose(13, "TestName16", 26, true),
                new TestWareHose(13, "TestName17", 27, false),
                new TestWareHose(13, "TestName18", 28, true),
                new TestWareHose(13, "TestName19", 29, false),
                new TestWareHose(13, "TestName20", 30, true),
                new TestWareHose(14, "TestName21", 31, false)
            };
        }
    }
}
