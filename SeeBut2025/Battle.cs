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
    public class Battle : Field
    {
        int maxSizeShip = 4;
        public struct Injured
        {
            public int countInjuredCells;
            public string startCellShipInjured;
            public string injuredPozV_G;
            public List<Cell> possibleCells;
            public Cell cellFirst;
            public Cell cellLastInjured;
        }
        Injured injured = new Injured();

        public void ComputerLogic(Cell cell)
        {
            injured.countInjuredCells++;
            injured.possibleCells = new List<Cell>();
            injured.possibleCells.Clear();
            if (!checkCell(cell.ToString())) {
                if (injured.cellFirst == null) {
                    injured.cellFirst = cell;
                    foreach (var gameCell in GameField)
                    {
                        if ((gameCell.Y == cell.Y && (gameCell.X == cell.X-1 || gameCell.X == cell.X - 1)) || 
                            (gameCell.X == cell.X && (gameCell.Y == cell.Y-1 || gameCell.Y == cell.Y + 1))) {
                            if (gameCell.Value != "*") injured.possibleCells.Add(gameCell);
                        }
                    }
                }
                else
                {
                    if (injured.cellLastInjured == null)
                    {
                   
                        injured.cellLastInjured = cell;
                        if (injured.cellFirst.X == injured.cellLastInjured.X) { 

                            injured.injuredPozV_G = "Vertical";
                            foreach (var gameCell in GameField)
                            {
                                if ((gameCell.X == cell.X && 
                                    (gameCell.Y > injured.cellLastInjured.Y-maxSizeShip && gameCell.Y < injured.cellFirst.Y) ||
                                    (gameCell.Y > injured.cellLastInjured.Y  && gameCell.Y < injured.cellFirst.Y + maxSizeShip)))
                                {
                                    if (gameCell.Value != "*") injured.possibleCells.Add(gameCell);
                                }
                            }
                        }
                        else injured.injuredPozV_G = "Horizontal";

                        }
                    }
                }
                        for (int i = 0; i < GameField.Count; i++)
                        {
                            for (int j = 0; j < injured.possibleCells.Count; j++) {
                                if (GameField[i].ToString() == injured.possibleCells[j].ToString()) GameField[i].Value = "!";
                                    
                                        }
             }
        }
        public bool checkCell(String cell)
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
                            PoinAround(ShipsList[i]); 
                            ShipsList.RemoveAt(i);
                            if (ShipsList.Count == 0) { MessageBox.Show("WIN!!!!!"); }
                            win = true;
                        }
                    }
                }
            }
            return win;
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

