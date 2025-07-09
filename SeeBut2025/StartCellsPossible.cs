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
                    workList = СhoiceList(type, countCells);
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
                            СhoiceList(type, countCells).Add(new Cell(j, i));
                        }
                    }
                    break;

                case " ":
                    for (int i = 0; i < 10 - countCells + 1; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            СhoiceList(type, countCells).Add(new Cell(j, i));
                        }
                    }
                    break;

                default:
                    break;
            }
        }
        #region СhoicedLists
        public List<Cell> СhoiceList(string type, int countCells)
        {
            List<Cell> СhoiceList = new List<Cell>();

            switch (countCells)
            {
                case 4:
                    СhoiceList = СhoiceList4(type);
                    break;
                case 3:
                    СhoiceList = СhoiceList3(type);
                    break;
                case 2:
                    СhoiceList = СhoiceList2(type);
                    break;
                case 1:
                    СhoiceList = СhoiceList1();
                    break;

                default:
                    break;
            }
            return СhoiceList;
        }
       
        private List<Cell> СhoiceList4(string type)
        {
            List<Cell> СhoiceList = new List<Cell>();
            
            switch (type)
            {
                case "horizontal":
                    СhoiceList = CellsStartHorizontal4;
                    break;
                case "vertical":

                    СhoiceList = CellsStartVertical4;
                    break;

                default:
                    break;
            }
           return СhoiceList;
        }

       
        private List<Cell> СhoiceList3(string type)
    {
        List<Cell> СhoiceList = new List<Cell>();

        switch (type)
        {
            case "horizontal":
                СhoiceList = CellsStartHorizontal3;
                break;
            case "vertical":

                СhoiceList = CellsStartVertical3;
                break;

            default:
                break;
        }
        return СhoiceList;
    }

        private List<Cell> СhoiceList2(string type)
        {
            List<Cell> СhoiceList = new List<Cell>();

            switch (type)
            {
                case "horizontal":
                    СhoiceList = CellsStartHorizontal2;
                    break;
                case "vertical":

                    СhoiceList = CellsStartVertical2;
                    break;

                default:
                    break;
            }
            return СhoiceList;
        }

        private List<Cell> СhoiceList1()
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
            var workList = СhoiceList("vertical", countCells);
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

            workList = СhoiceList("horizontal", countCells);
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
            var workList = СhoiceList("horizontal", countCells);
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

            workList = СhoiceList("vertical", countCells);
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