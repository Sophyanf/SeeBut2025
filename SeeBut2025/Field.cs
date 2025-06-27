using SeeBat2025.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SeeBat2025
{
    public class Field
    {
        public List<Cell> GameField { get; set; }
        public List<Cell> FillCells { get; set; }
        public List<Ship> ShipsList { get; set; }
        //private StartCellsPossible startCellsPossible { get; set; } = new StartCellsPossible();

        int count = 0;

        public Field()
        {
            GameField = new List<Cell>();
            FillCells = new List<Cell>();
            ShipsList = new List<Ship>();
            //fillList();
           // fillShips();
            //fieldGame = GameField;
            MessageBox.Show("jjj");
            }
        /*
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        protected virtual void UpdateValue<T>(ref T field, T value, [CallerMemberName] string property = "")
        {
            field = value;
            OnPropertyChanged(property);
        }
        #endregion
        
        private List<Cell> fieldGame; 
        public List<Cell> FieldGame

        {
            get { return fieldGame; }
            set
            {
                fieldGame = value;
                OnPropertyChanged();
            }
        }

        private void fillList()
        {
            int count = 0;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    Cell cell = new Cell { X = j, Y = i, Value = "." };
                    GameField.Add(cell);
                    count++;
                }
        }
      

        private void shipCreat (int sizeShip)
        {
            count++;
            string typeShip = shipType();
            //string typeShip = "horizontal";
            //string typeShip = "vertical";
            List<Cell> workList = startCellsPossible.ChangeList(typeShip, sizeShip);
            int startCellNum = new Random().Next(0, workList.Count);
            Cell startCell = workList.ElementAtOrDefault(startCellNum);
            Ship ship = new Ship()
            {
                SizeShip = sizeShip,
                ShipPozV_G = typeShip,
                StartCell = startCell
            };
            MessageBox.Show(count.ToString());
            addShip(ship);
        }

        private void addShip(Ship ship)
        {
            //MessageBox.Show(ship.StartCell.X.ToString() + " " + ship.StartCell.Y.ToString());
            if (ship.ShipPozV_G == "vertical") { 
                foreach (Cell cell in GameField)
                {
                    if (cell.X == ship.StartCell.X && cell.Y >= ship.StartCell.Y && cell.Y < ship.StartCell.Y + ship.SizeShip) cell.Value = count.ToString();
                }
            }
            else
            {
                foreach (Cell cell in GameField)
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

        private void fillingListCells (Ship ship)
        {
            for (int i = 0; i < ship.SizeShip; i++) {
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
            FillCells.Add(cell);
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
        */
    }
}
