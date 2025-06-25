using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeBat2025.Resources
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Value { get; set; }
        public Cell() { }
        public Cell(int x, int y) { X = x; Y = y;}
        public override string ToString()
        {
            return "arr";
        }
    }


}
