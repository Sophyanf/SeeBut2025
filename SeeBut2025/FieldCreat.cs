using SeeBat2025.Resources;
using SeeBat2025;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SeeBut2025
{
    public class FieldCreat
    {
        public List<Cell> FieldGame = new List<Cell>();
        private StartCellsPossible startCellsPossible { get; set; } = new StartCellsPossible();
        public List<Ship> ShipsList { get; set; } = new List<Ship>();
        int count = 0;

        public FieldCreat()
        {
            fillList();
            fillShips();
            String str = "";
            foreach (Ship ship in ShipsList) {
                
                    str += ship.StartCell.NumCell.ToString(); 
            }
               MessageBox.Show(str);
        }

     

        private void fillList()
        {
            int count = 0;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    Cell cell = new Cell { NumCell = count, X = j, Y = i, Value = "." };
                    FieldGame.Add(cell);
                    count++;
                }
        }


        private void shipCreat(int sizeShip)
        {
            count++;
            string typeShip = shipType();
            List<Cell> workList = startCellsPossible.СhoiceList(typeShip, sizeShip);
            int startCellNum = new Random().Next(0, workList.Count);
            Cell startCell = workList.ElementAtOrDefault(startCellNum);
            
            Ship ship = new Ship(startCell, typeShip, sizeShip);
            addShip(ship);
        }

        private void addShip(Ship ship)
        {
            
            if (ship.ShipPozV_G == "vertical")
            {
                foreach (Cell cell in FieldGame)
                {
                    if (cell.X == ship.StartCell.X && cell.Y >= ship.StartCell.Y && cell.Y < ship.StartCell.Y + ship.SizeShip) cell.Value = count.ToString();
                }
            }
            else
            {
                foreach (Cell cell in FieldGame)
                {
                    if (cell.Y == ship.StartCell.Y && cell.X >= ship.StartCell.X && cell.X < ship.StartCell.X + ship.SizeShip) cell.Value = count.ToString();
                }
            }
            ShipsList.Add(ship);
            //MessageBox.Show(ShipsList.Count.ToString() + " : " + ship.StartCell.X.ToString() + " " + ship.StartCell.Y.ToString());
            fillingListCells(ship);
            startCellsPossible.RemoveStartCells(ship, 3);
            startCellsPossible.RemoveStartCells(ship, 2);
            startCellsPossible.RemoveStartCells(ship, 1);
        }

        private void fillingListCells(Ship ship)
        {
            for (int i = 0; i < ship.SizeShip; i++)
            {
                Cell cell = new Cell();
                if (ship.ShipPozV_G == "vertical")
                {
                    cell.X = ship.StartCell.X;
                    cell.Y = ship.StartCell.Y + i;
                }
                else
                {
                    cell.X = ship.StartCell.X + i;
                    cell.Y = ship.StartCell.Y;
                }
            }
        }
        private string shipType()
        {
            string typeShip = "";
            Random rnd = new Random();
            int type = rnd.Next(0, 2);
            switch (type)
            {
                case 0:
                    typeShip = "horizontal";
                    break;
                case 1:
                    typeShip = "vertical";
                    break;
                default: break;
            }
            return typeShip;
        }

        void fillShips()
        {
            shipCreat(4);
            Thread.Sleep(1);
            for (int i = 0; i < 2; i++)
            {
                shipCreat(3);
                Thread.Sleep(1);
            }
            for (int i = 0; i < 3; i++)
            {
                shipCreat(2);
                Thread.Sleep(1);
            }

            for (int i = 0; i < 4; i++)
            {
                shipCreat(1);
                Thread.Sleep(1);
            }
        }

        public void PoinAround(Ship ship)
        {
            int startX = ship.StartCell.X - 1;
            int endX = ship.StartCell.X + 1;
            int startY = ship.StartCell.Y - 1;
            int endY = ship.StartCell.Y + ship.SizeShip;

            for (int i = 0; i < FieldGame.Count; i++)
            {
                if (ship.ShipPozV_G != "vertical")
                {
                    endX = ship.StartCell.X + ship.SizeShip;
                    endY = ship.StartCell.Y + 1;
                    if (FieldGame[i].X >= ship.StartCell.X && FieldGame[i].X <= ship.StartCell.X + ship.SizeShip - 1 &&
                        FieldGame[i].Y == ship.StartCell.Y) { continue; }
                    else if (FieldGame[i].X >= startX && FieldGame[i].X <= endX &&
                            FieldGame[i].Y >= startY && FieldGame[i].Y <= endY) FieldGame[i].Value = "*";
                }
                else
                {
                    if (FieldGame[i].X == ship.StartCell.X &&
                    FieldGame[i].Y >= ship.StartCell.Y && FieldGame[i].Y <= ship.StartCell.Y + ship.SizeShip - 1) { continue; }
                    else if (FieldGame[i].X >= startX && FieldGame[i].X <= endX &&
                            FieldGame[i].Y >= startY && FieldGame[i].Y <= endY)
                        FieldGame[i].Value = "*";
                }
            }
        }
    }
}
