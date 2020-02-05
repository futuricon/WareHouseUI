using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse
{
    class TestNewIncome
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string Storage { get; set; }

        public TestNewIncome(int id, string name, decimal price, int amount, string storage)
        {
            Id = id;
            Name = name;
            Price = price;
            Amount = amount;
            Storage = storage;
        }
    }
}
