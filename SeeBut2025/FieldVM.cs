using SeeBat2025.Resources;
using SeeBut2025;
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
    public class FieldVM
    {
        public Battle battle = new Battle();
        public FieldForGame compField = new FieldForGame();
        public FieldForGame playerField = new FieldForGame();

        public FieldVM() {
            fieldGameComp = compField.FieldGame;
            fieldGamePlayer = playerField.FieldGame;
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

        private List<Cell> fieldGameComp;
        public List<Cell> FieldGameComp

        {
            get { return fieldGameComp; }
            set
            {
                fieldGameComp = value;
                OnPropertyChanged();
            }
        }

        private List<Cell> fieldGamePlayer;
        public List<Cell> FieldGamePlayer

        {
            get { return fieldGamePlayer; }
            set
            {
                fieldGamePlayer = value;
                OnPropertyChanged();
            }
        }

        public List<Cell> changePlayer (List<Cell> workList)
        {
            if (workList == fieldGamePlayer) workList = fieldGameComp;
            else workList = fieldGameComp;
            return workList;
        }
        public bool FreeCell (int  index, FieldForGame fieldForGame)
        {
            bool freeCell = true;
            if (WorkCell(index, fieldForGame).Value != ".") freeCell = false;
            return freeCell;
        }

        public Cell WorkCell(int index, FieldForGame fieldForGame)
        {
            Cell workCell = fieldForGame.FieldGame[index];
            return workCell;
        }

        
        public Ship CheckKilledShip (int index, FieldForGame fieldForGame)
        {
            Ship ship = battle.KilledShip(WorkCell(index, fieldForGame), fieldForGame);
            
            return ship;
        }
        public bool winCheck(FieldForGame fieldForGame)
        {
            bool win = false;
            if (fieldForGame.ShipsList.Count == 0)
            {
                MessageBox.Show("WIN!!!!!");
                win = true;
            }
            return win;
        }

    }
}
 