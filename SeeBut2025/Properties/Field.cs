using SeeBut2025.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SeeBut2025
{
    internal class Field
    {
        public List<Cell> GameField { get; set; } = new List<Cell>();
        private List<Cell> listForShip = new List<Cell>();
        private List<Ship> ShipsList = new List<Ship>();

        public Field()
        {
            fillList();
            ship4Creat();
            ship3Creat();
            fieldGame = GameField;
            }

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

        private List<Cell> fieldGame = new List<Cell>() ;
        public List<Cell> FieldGame

        {
            get { return fieldGame; }
            set
            {
                fieldGame = value;
                OnPropertyChanged();
            }
        }

        //fieldGame.Add(GameField[i, j]);
        private void fillList()
        {

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    Cell cell = new Cell { X = j, Y = i, Num = i * 10 + j, Value = "." };
                    GameField.Add(cell);
                }
           // fieldGame = GameField;
        }
        private void fillListFree(int typeShip, int shipSize)
        {
            if (typeShip == 0)
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10-shipSize; j++)
                {
                    Cell cell = new Cell { X = j, Y = i, Num = i * 10 + j, Value = "." };
                    listForShip.Add(cell);
                }
        }

        private void ship4Creat ()
        {
            int typeShip = new Random().Next(0, 2); //0 - вертикальный, 1 - горизонтальный
            fillListFree(typeShip, 4);
            int startCell = new Random().Next(0, listForShip.Count);
            addShip(typeShip, 4);
            listForShip.Clear();
        }

        private void ship3Creat()
        {
            List<Cell> listForShip = new List<Cell>();
            int typeShip = new Random().Next(0, 2); //0 - вертикальный, 1 - горизонтальный
            fillListFree(typeShip, 3);
            List<Cell> listRemove = new List<Cell>();
            foreach (Ship ship in ShipsList) { 
                if (ship.ShipPozV_G == 0)
                {
                    for (int i = ship.StartCell.Y - 1; i < ship.StartCell.Y + ship.SizeShip+1; i++)
                        for (int j = ship.StartCell.X-1; j <= ship.StartCell.X + 1; j++) 
                            listRemove.Add(new Cell { X = j, Y = i});
                    
                }
            }
            foreach (Cell cell in listForShip)
                foreach(Cell cell1 in listRemove)
                {
                    if (cell.X == cell1.X && cell.Y == cell1.Y) listForShip.Remove(cell);
                }
            
            addShip(typeShip, 3);
            listForShip.Clear();
        }

        private void addShip(int typeShip, int sizeShip)
        {
            Ship ship = new Ship();
            ship.SizeShip = sizeShip;
            ship.ShipPozV_G = typeShip;
            ship.StartCell = new Cell();
            int startCell = new Random().Next(1, listForShip.Count);

            ship.StartCell.X = listForShip[startCell].X;
            ship.StartCell.Y = listForShip[startCell].Y;
            foreach (Cell cell in GameField)
            {
                if (cell.X == ship.StartCell.X && cell.Y >= ship.StartCell.Y && cell.Y < ship.StartCell.Y + ship.SizeShip) cell.Value = "X";
            }
            ShipsList.Add(ship);
        }
    }
}
