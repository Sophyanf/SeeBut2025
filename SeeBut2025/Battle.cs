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
        


        public Ship KilledShip(Cell cell, FieldForGame fieldForGame)  // "String player" для выбора ShipsList
        {
            
            Ship ship = null;
            for (int i = fieldForGame.ShipsList.Count - 1; i >= 0; i--)
            {
                //MessageBox.Show(fieldForGame.ShipsList[i].ShipCells.Count.ToString());
                for (int j = 0; j < fieldForGame.ShipsList[i].ShipCells.Count; j++)
                {
                    if (fieldForGame.ShipsList[i].ShipCells[j] == cell.ToString())
                    {
                        if (fieldForGame.ShipsList[i].ShipCells.Count == 1)
                        {
                            ship = fieldForGame.ShipsList[i];
                            fieldForGame.ShipsList.RemoveAt(i);
                        }
                        else
                            fieldForGame.ShipsList[i].ShipCells.RemoveAt(j);
                            break;
                    }
                }
            }
            return ship;
        }

        public void shipsCoord()
        {
            //string string1 = "";
            //foreach (var ship in fieldForGameShipsList)
            //    string1 += ship.StartCell.X.ToString() + " " + ship.StartCell.Y.ToString() + "\n";


            //MessageBox.Show(string1);
        }
    }
}

