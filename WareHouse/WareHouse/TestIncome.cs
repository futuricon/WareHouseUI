using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse
{
    class TestIncome
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Sum { get; set; }
        public string Deliver { get; set; }
        public bool Edit { get; set; }

        public TestIncome(int id, DateTime date, int quantity, decimal sum, string deliver, bool edit)
        {
            Id = id;
            Deliver = deliver;
            Date = date;
            Quantity = quantity;
            Sum = sum;
            Edit = edit;
        }
    }
}
