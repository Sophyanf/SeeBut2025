using SeeBat2025;
using SeeBat2025.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static SeeBut2025.Battle;

namespace SeeBut2025
{ 

    public class Battle {

        protected int maxSizeShip = 4;
        public List<Ship> ShipsList { get; set; }


        public bool CheckCell(String cell, String player)
        {
            bool win  = false;
            for (int i = ShipsList.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < ShipsList[i].ShipCells.Count; j++)
                {
                    if (ShipsList[i].ShipCells[j] == cell)
                    {
                        ShipsList[i].ShipCells.RemoveAt(j);
                       if (ShipsList[i].ShipCells.Count == 0) { 
                            //choiceField(player).PoinAround(ShipsList[i]); 
                            ShipsList.RemoveAt(i);
                            if (ShipsList.Count == 0) { MessageBox.Show("WIN!!!!!"); }
                            win = true;
                        }
                    }
                }
            }
            return win;
        }
        public void shipsCoord()
        {
            string string1 = "";
            foreach (var ship in ShipsList)
                string1 += ship.StartCell.X.ToString() + " " + ship.StartCell.Y.ToString() + "\n";


            MessageBox.Show(string1);
        }
    }
}

