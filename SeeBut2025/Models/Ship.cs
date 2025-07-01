using SeeBat2025.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeBat2025
{
    public class Ship
    {
        public Cell StartCell { get; set; }
        public string ShipPozV_G { get; set; }
        public int SizeShip { get; set; }
        public int ShipLifes { get; set; } 
        public List<string> ShipCells { get; set; } = new List<string>();
        public Ship(Cell cell, string shipPoz, int size) {
            StartCell = cell;
            ShipPozV_G = shipPoz;
            SizeShip = size;
            ShipLifes = size;
            AddShipsList(); 
        }
        public override string ToString()
        {
            return StartCell.X.ToString() + " " + StartCell.Y.ToString();
        }

        public void AddShipsList ()
        {
            for (int i = 0; i < SizeShip; i++)
            {
                string cellShip = "";
                if (ShipPozV_G == "vertical") { 
                cellShip = StartCell.X.ToString() + " " + (StartCell.Y + i).ToString();
                    
                }
                else { cellShip = (StartCell.X + i).ToString() + " " + StartCell.Y.ToString(); }
                ShipCells.Add(cellShip);
            }
        }
    }
}
