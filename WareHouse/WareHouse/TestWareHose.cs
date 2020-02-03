using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse
{
    class TestWareHose
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Remainder { get; set; }
        public bool Edit { get; set; }

        public TestWareHose(int id, string name, decimal remainder, bool edit)
        {
            Id = id;
            Name = name;
            Remainder = remainder;
            Edit = edit;
        }
    }
}
