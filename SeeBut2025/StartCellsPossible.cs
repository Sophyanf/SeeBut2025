using SeeBat2025;
using SeeBat2025.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SeeBat2025
{
    internal class StartCellsPossible
    {
        public List<Cell> CellsStartHorizontal4 = new List<Cell>();
        public List<Cell> CellsStartVertical4 = new List<Cell>();
        public List<Cell> CellsStartHorizontal3 = new List<Cell>();
        public List<Cell> CellsStartVertical3 = new List<Cell>();
        public List<Cell> CellsStartHorizontal2 = new List<Cell>();
        public List<Cell> CellsStartVertical2 = new List<Cell>();
        public List<Cell> CellsStart1 = new List<Cell>();
        public struct CoordsForRemove
        {
            public int checkStartX;
            public int checkEndX;
            public int checkStartY;
            public int checkEndY;
        }
        CoordsForRemove coordsForRemove = new CoordsForRemove();

        public StartCellsPossible()    //конструктор
        {
            fillList("horizontal", 4);
            fillList("vertical", 4);
            fillList("horizontal", 3);
            fillList("vertical", 3);
            fillList("horizontal", 2);
            fillList("vertical", 2);
            fillList(" ", 1);
        }  


        private void fillList(string type, int countCells)
        {
            var workList = new List<Cell>();
            switch (type)
            {

                case "horizontal":
                    workList = ChangeList(type, countCells);
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10 - countCells + 1; j++)
                        {
                            workList.Add(new Cell(j, i));
                        }
                    }
                    break;
                case "vertical":
                    for (int i = 0; i < 10 - countCells + 1; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            ChangeList(type, countCells).Add(new Cell(j, i));
                        }
                    }
                    break;

                case " ":
                    for (int i = 0; i < 10 - countCells + 1; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            ChangeList(type, countCells).Add(new Cell(j, i));
                        }
                    }
                    break;

                default:
                    break;
            }
        }
        #region ChangedLists
        public List<Cell> ChangeList(string type, int countCells)
        {
            List<Cell> changeList = new List<Cell>();

            switch (countCells)
            {
                case 4:
                    changeList = ChangeList4(type);
                    break;
                case 3:
                    changeList = ChangeList3(type);
                    break;
                case 2:
                    changeList = ChangeList2(type);
                    break;
                case 1:
                    changeList = ChangeList1();
                    break;

                default:
                    break;
            }
            return changeList;
        }
       
        private List<Cell> ChangeList4(string type)
        {
            List<Cell> changeList = new List<Cell>();
            
            switch (type)
            {
                case "horizontal":
                    changeList = CellsStartHorizontal4;
                    break;
                case "vertical":

                    changeList = CellsStartVertical4;
                    break;

                default:
                    break;
            }
           return changeList;
        }

       
        private List<Cell> ChangeList3(string type)
    {
        List<Cell> changeList = new List<Cell>();

        switch (type)
        {
            case "horizontal":
                changeList = CellsStartHorizontal3;
                break;
            case "vertical":

                changeList = CellsStartVertical3;
                break;

            default:
                break;
        }
        return changeList;
    }

        private List<Cell> ChangeList2(string type)
        {
            List<Cell> changeList = new List<Cell>();

            switch (type)
            {
                case "horizontal":
                    changeList = CellsStartHorizontal2;
                    break;
                case "vertical":

                    changeList = CellsStartVertical2;
                    break;

                default:
                    break;
            }
            return changeList;
        }

        private List<Cell> ChangeList1()
        {
            return CellsStart1;
        }

        #endregion

        public void RemoveStartCells(Ship ship, int countCells)
        {
            if (ship.ShipPozV_G == "vertical")
            {
                RemoveStartCellsVertShip(ship, countCells);
            }
            else
            {
                RemoveStartCellsHorizShip(ship, countCells);
            }
        }
        private void RemoveStartCellsVertShip(Ship ship, int countCells)
        {
            var workList = ChangeList("vertical", countCells);
            coordsForRemove.checkStartX = ship.StartCell.X - 1;
            coordsForRemove.checkEndX = ship.StartCell.X + 1;
            coordsForRemove.checkStartY = ship.StartCell.Y - countCells;
            coordsForRemove.checkEndY = ship.StartCell.Y + ship.SizeShip;
            for (int i = workList.Count - 1; i >= 0; i--)
            {
                Cell cell = workList[i];
                if (removeAround(coordsForRemove, cell))
                    workList.Remove(cell);
            }

            workList = ChangeList("horizontal", countCells);
            coordsForRemove.checkStartX = ship.StartCell.X - countCells;
            coordsForRemove.checkEndY = ship.StartCell.Y + ship.SizeShip;
            for (int i = workList.Count - 1; i >= 0; i--)
            {
                Cell cell = workList[i];
                if (removeAround(coordsForRemove, cell))
                    workList.Remove(cell);
            }
        }

        private void RemoveStartCellsHorizShip(Ship ship, int countCells)
        {
            var workList = ChangeList("horizontal", countCells);
            coordsForRemove.checkStartX = ship.StartCell.X - countCells;
            coordsForRemove.checkEndX = ship.StartCell.X + ship.SizeShip;
            coordsForRemove.checkStartY = ship.StartCell.Y - 1;
            coordsForRemove.checkEndY = ship.StartCell.Y + 1;
            for (int i = workList.Count - 1; i >= 0; i--)
            {
                Cell cell = workList[i];
                if (removeAround(coordsForRemove, cell))
                    workList.Remove(cell);
            }

            workList = ChangeList("vertical", countCells);
            //coordsForRemove.checkStartX = ship.StartCell.X - 1;
            coordsForRemove.checkEndX = ship.StartCell.X + ship.SizeShip;
            coordsForRemove.checkStartY = ship.StartCell.Y - countCells;
            //coordsForRemove.checkEndY = ship.StartCell.Y + 1;
            for (int i = workList.Count - 1; i >= 0; i--)
                {
                    Cell cell = workList[i];
                if (removeAround(coordsForRemove, cell))
                    workList.Remove(cell);
            }
        }

        private bool removeAround (CoordsForRemove coordsForRemove, Cell cell)
        {
            return cell.Y >= coordsForRemove.checkStartY && cell.Y <= coordsForRemove.checkEndY
                    && cell.X >= coordsForRemove.checkStartX
                    && cell.X <= coordsForRemove.checkEndX;
        }
    }
}