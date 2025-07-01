using SeeBat2025;
using SeeBat2025.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SeeBut2025
{ 
    public class Battle : Field
    {
        public void checkCell(String cell)
        {
            for (int i = ShipsList.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < ShipsList[i].ShipCells.Count; j++)
                {
                    if (ShipsList[i].ShipCells[j] == cell)
                    {
                        //MessageBox.Show(ShipsList[i].ShipCells.Count.ToString());
                        ShipsList[i].ShipCells.RemoveAt(j);
                        if (ShipsList[i].ShipCells.Count == 0) { PoinAround(ShipsList[i]); }

                    }
                }
            }
            for (int i = 0; i < GameField.Count; i++)
            {
                if (GameField[i].ToString() ==  cell) {
                    MessageBox.Show("OK");
                    GameField[i].Value = "!"; }
                    
            }
        }

            private void PoinAround (Ship ship)
        {
                int startX = ship.StartCell.X - 1;
                int endX = ship.StartCell.X + 1;
                int startY = ship.StartCell.Y - 1;
                int endY = ship.StartCell.Y + ship.SizeShip;
            
            if (ship.ShipPozV_G == "vertical")
            {
                for (int i = 0; i< GameField.Count; i++)
                {
                    if (GameField[i].X >= startX && GameField[i].X <= endX &&
                            GameField[i].Y == startY && GameField[i].Y == endY)
                        GameField[i].Value = "*";
                }
            }
            else
            {
                endX = ship.StartCell.X + ship.SizeShip;
                endY = ship.StartCell.Y + 1;

            }
        }
    }
    
}
