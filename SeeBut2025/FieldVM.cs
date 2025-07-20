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

        public bool FreeCell (int  index, string typePlayer)
        {
            var workList = choiceField(typePlayer);
            bool freeCell = true;
            if (workList.FieldGame[index].Value != ".") freeCell = false;
            return freeCell;
        }
        private FieldCreat choiceField(string typePlayer)
        {
            FieldCreat workList = new FieldCreat();
            switch (typePlayer)
            {
                case "player":
                    workList = compField;
                    break;

                case "comp":
                    workList = playerField;
                    break;
            }
            return workList;
        }

    }
}
 