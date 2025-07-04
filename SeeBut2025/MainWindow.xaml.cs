using SeeBat2025.Resources;
using SeeBut2025;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SeeBat2025
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Button> buttonsList = new List<Button>();
        private List<Cell> workList = new List<Cell>();
        public Battle battle { get; set; } = new Battle();

        public MainWindow()
        {
            InitializeComponent();
            addButton();
            Comp.Click += computerClick;
        }

        private void addButton ()
        {
            
            for (int i = 0; i < 100; i++)
            {
                Button button = new Button();
                field1.Children.Add(button);
                buttonsList.Add(button);
                button.Content = battle.GameField[i].Value;
                button.Click += playerClick;
            }
            workList = battle.GameField;
            foreach (Cell cell in workList) { cell.NumCell = workList.IndexOf(cell); }
        }
        void playerClick(object sender, EventArgs e)
        {
            Button playerButton = (Button)sender;
            playerButton.IsEnabled = false;
            MessageBox.Show(playerButton.ToString());
            //int index = buttonsList.IndexOf(playerButton);
            //playerButton.Content = battle.GameField[index].Value;
            //if (battle.GameField[index].Value != ".")
            //    battle.ComputerLogic(battle.GameField[index]);
            //fillListButtons();
            //for (int i = 0; i < battle.GameField.Count; i++)
            //    if (battle.GameField[i].Value == "!") battle.GameField[i].Value = ".";
        }

        void computerClick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int buttonNum = rnd.Next(0, workList.Count);
            Thread.Sleep(5);
            MessageBox.Show(buttonNum.ToString());
            int index = workList[buttonNum].NumCell;
            MessageBox.Show(index.ToString());
            playerClick(buttonsList[index], e);
            workList.Remove(workList[buttonNum]);
        }

        void fillListButtons()
        {
            for (int i = 0; i < buttonsList.Count; i++)
            {
                buttonsList[i].Content = battle.GameField[i].Value;
                if (battle.GameField[i].Value == "*")
                    buttonsList[i].IsEnabled = false;
            }
        }
    }
}
