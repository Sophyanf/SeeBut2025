using SeeBat2025.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeeBut2025.CompBattle;

namespace SeeBut2025
{
    internal class CompBattle : Battle
    {

        private bool isInjured = true;
        public bool ComputerBattle(Cell cell)
        {
            bool flag = true;
            if (isInjured)
            {
                flag = true;
              //  ComputerLogic(cell);
            }
            else flag = false;
            return flag;
        }
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
            /*
            injured.countInjuredCells++;
            injured.possibleCells = new List<Cell>();
            injured.possibleCells.Clear();
            if (!CheckCell(cell.ToString(), "comp"))
            {
                if (injured.cellFirst == null)
                {
                    injured.cellFirst = cell;
                    foreach (var gameCell in playerField.GameField)
                    {
                        if ((gameCell.Y == cell.Y && (gameCell.X == cell.X - 1 || gameCell.X == cell.X + 1)) ||
                            (gameCell.X == cell.X && (gameCell.Y == cell.Y - 1 || gameCell.Y == cell.Y + 1)))
                        {
                            if (gameCell.Value != "*") injured.possibleCells.Add(gameCell);
                        }
                    }
                }
                else
                {
                    if (injured.cellLastInjured == null)
                    {

                        injured.cellLastInjured = cell;
                        if (injured.cellFirst.X == injured.cellLastInjured.X)
                        {

                            injured.injuredPozV_G = "Vertical";
                            foreach (var gameCell in playerField.GameField)
                            {
                                if (gameCell.X == cell.X &&
                                    ((gameCell.Y > injured.cellLastInjured.Y - maxSizeShip && gameCell.Y < injured.cellFirst.Y) ||
                                    (gameCell.Y > injured.cellLastInjured.Y && gameCell.Y < injured.cellFirst.Y + maxSizeShip)))
                                {
                                    if (gameCell.Value != "*") injured.possibleCells.Add(gameCell);
                                }
                            }
                        }
                        else injured.injuredPozV_G = "Horizontal";

                    }
                }
            }
            */
        }
    }
}
