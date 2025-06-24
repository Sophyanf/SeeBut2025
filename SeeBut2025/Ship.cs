using SeeBat2025.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeBat2025
{
    internal class Ship
    {
        public Cell StartCell { get; set; }
        public string ShipPozV_G { get; set; }
        public int SizeShip { get; set; }
        public List<Cell> ShipCells { get; set; } = new List<Cell>();

        public void FillShipCells ()
        {

            for (int i = 0; i < this.SizeShip; i++)
            {
                Cell cell = new Cell();
                switch (this.ShipPozV_G)
                {
                    case "horizontal":
                        cell.X = this.StartCell.X;
                        cell.Y = this.StartCell.Y + i;
                        break;
                    case "vertical":
                        cell.X = this.StartCell.X + i;
                        cell.Y = this.StartCell.Y;
                        break;
                    
                    default:
                        break;
                }
            }
        }
    }
}
