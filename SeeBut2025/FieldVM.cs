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
        public FieldCreat compField = new FieldCreat();
        public FieldCreat playerField = new FieldCreat();

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

        public bool FreeCell (int  index, FieldCreat fieldCreat)
        {
            bool freeCell = true;
            if (WorkCell(index, fieldCreat).Value != ".") freeCell = false;
            return freeCell;
        }

        public Cell WorkCell(int index, FieldCreat fieldCreat)
        {
            Cell workCell = fieldCreat.FieldGame[index];
            return workCell;
        }

        //private FieldCreat choiceField(FieldCreat fieldCreat)
        //{
            
        //    switch (fieldCreat)
        //    {
        //        case "player":
        //            workList = compField;
        //            break;

        //        case "comp":
        //            workList = playerField;
        //            break;
        //    }
        //    return workList;
        //} 

        public Ship CheckKilledShip (int index, FieldCreat fieldCreat)
        {
            Ship ship = battle.KilledShip(WorkCell(index, fieldCreat), fieldCreat);
            return ship;
        }
        //private bool winCheck ()
        //{
        //    bool win = false;
        //    if (battle.ShipsList.Count == 0)
        //    {
        //        MessageBox.Show("WIN!!!!!");
        //        win = true;
        //    }
        //    return win;
        //}

    }
}
 