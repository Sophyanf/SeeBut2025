using SeeBat2025;
using SeeBat2025.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SeeBut2025
{
    public class Battle : Field
    {
        public void checkCell (Cell cell)
        {
            int indexCell = 0;
            //indexCell = FillCells.IndexOf(FillCells.FirstOrDefault(c => c.X == cell.X && c.Y == cell.Y));
            string string1 = "";
            foreach (var cell1 in FillCells)
            {
                string1 +=cell1.X.ToString() + " " + cell1.Y.ToString() + "\n";

            }
            MessageBox.Show(string1);
        }

        //private int shipsCells (int index)
        //{
        //    int shipIndex = -1;
        //    if (index >= 0 && index < 4) { shipIndex = 0; }
        //    else if (index >= 4 && shipIndex < 7) { shipIndex = 1; }
        //        else if (index >= 7 && shipIndex < 10) { shipIndex = 2; }
        //            else if (index >= 10 && shipIndex < 12) { shipIndex = 3; }
        //                else if (index >= 12 && shipIndex < 14) { shipIndex = 4; }
        //                    else if (index >= 14 && shipIndex < 16) { shipIndex = 5; }
        //                        else if (index == 16 ) { shipIndex = 6; }
        //                            else if (index == 17 ) { shipIndex = 7; }
        //                                else if (index == 18) { shipIndex = 8; }
        //                                    else if (index == 19) { shipIndex = 9; }

        //    return shipIndex;
        //}



    }
}
