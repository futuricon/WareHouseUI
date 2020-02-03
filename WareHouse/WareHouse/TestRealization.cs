using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse
{
    class TestRealization
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Sum { get; set; }
        public bool Edit { get; set; }

        public TestRealization(int id, string client, DateTime date, int quantity, decimal sum, bool edit)
        {
            Id = id;
            Client = client;
            Date = date;
            Quantity = quantity;
            Sum = sum;
            Edit = edit;
        }

    }
}
