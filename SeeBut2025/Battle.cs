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
        


        public Ship KilledShip(Cell cell, FieldCreat fieldCreat)  // "String player" для выбора ShipsList
        {
            
            Ship ship = null;
            for (int i = fieldCreat.ShipsList.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < fieldCreat.ShipsList[i].ShipCells.Count; j++)
                {
                    if (fieldCreat.ShipsList[i].ShipCells[j] == cell.ToString())
                    {
                        if (fieldCreat.ShipsList[i].ShipCells.Count == 1)
                        {
                            MessageBox.Show(fieldCreat.ShipsList[i].ToString());
                            ship = fieldCreat.ShipsList[i];
                            fieldCreat.ShipsList.RemoveAt(i);
                        }
                        else
                            fieldCreat.ShipsList[i].ShipCells.RemoveAt(j);
                        //MessageBox.Show(fieldCreat.ShipsList[i].ShipCells.ToString());
                    }
                }
            }
            return ship;
        }
        public void shipsCoord()
        {
            //string string1 = "";
            //foreach (var ship in fieldCreatShipsList)
            //    string1 += ship.StartCell.X.ToString() + " " + ship.StartCell.Y.ToString() + "\n";


            //MessageBox.Show(string1);
        }
    }
}

