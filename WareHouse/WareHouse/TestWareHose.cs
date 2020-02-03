using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse
{
    class TestWareHose
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public bool Edit { get; set; }

        public TestWareHose(int id, string name, int amount, bool edit)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Edit = edit;
        }
    }
}
