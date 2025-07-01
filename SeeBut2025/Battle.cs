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
                        //MessageBox.Show(ShipsList[i].ShipCells.Count.ToString());
                       if (ShipsList[i].ShipCells.Count == 0) { 
                            PoinAround(ShipsList[i]); 
                            ShipsList.RemoveAt(i);
                            if (ShipsList.Count == 0) { MessageBox.Show("WIN!!!!!"); }
                            break;
                        }
                    }
                }
            }
        }

            private void PoinAround (Ship ship)
        {
                int startX = ship.StartCell.X - 1;
                int endX = ship.StartCell.X + 1;
                int startY = ship.StartCell.Y - 1;
                int endY = ship.StartCell.Y + ship.SizeShip;
            
                for (int i = 0; i < GameField.Count; i++)
                {
                if (ship.ShipPozV_G != "vertical")
                {
                    endX = ship.StartCell.X + ship.SizeShip;
                    endY = ship.StartCell.Y + 1;
                    if (GameField[i].X >= ship.StartCell.X && GameField[i].X <= ship.StartCell.X + ship.SizeShip - 1 &&
                        GameField[i].Y == ship.StartCell.Y) { continue; }
                    else if (GameField[i].X >= startX && GameField[i].X <= endX &&
                            GameField[i].Y >= startY && GameField[i].Y <= endY) GameField[i].Value = "*";
                }
                    else
                    {
                        if (GameField[i].X == ship.StartCell.X  && 
                        GameField[i].Y >= ship.StartCell.Y && GameField[i].Y <= ship.StartCell.Y + ship.SizeShip - 1) { continue; }
                        else if (GameField[i].X >= startX && GameField[i].X <= endX &&
                                GameField[i].Y >= startY && GameField[i].Y <= endY)
                            GameField[i].Value = "*";
                    }
                }
            }
        }
    }

