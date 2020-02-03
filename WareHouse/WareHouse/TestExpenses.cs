using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse
{
    class TestExpenses
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Sum { get; set; }
        public string Description { get; set; }
        public bool Edit { get; set; }

        public TestExpenses(int id, DateTime date, decimal sum, string description, bool edit)
        {
            Id = id;
            Date = date;
            Sum = sum;
            Description = description;
            Edit = edit;
        }
    }
}
