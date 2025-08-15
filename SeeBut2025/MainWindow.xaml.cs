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
        private List<Button> buttonsListPlayer = new List<Button>();
        private List<Button> buttonsListComputer = new List<Button>();
        public FieldVM fieldVM = new FieldVM();
        private List<Cell> workList = new List<Cell>();
        private Binding binding = new Binding();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = fieldVM;
            addButtons(buttonsListPlayer);
            Thread.Sleep(5);
            addButtons(buttonsListComputer);
            Comp.Click += computerClick;
        }

        private void addButtons (List <Button> buttonsList)
        {
            for (int i = 0; i < 100; i++)
            {
                Button button = new Button();
                if (buttonsList == buttonsListComputer)
                {

                    button.Style = (Style)this.FindResource("ButtonsComp");
                    field1.Children.Add(button);
                    button.Click += playerClick;
                    workList = fieldVM.FieldGameComp;
                    binding = new Binding($"FieldGameComp[{i}].Value");
                    
                }
                    else
                    {
                        button.Style = (Style)this.FindResource("ButtonsPlayer");
                        fieldPlayer.Children.Add(button);
                        button.Click += computerClick;
                        workList = fieldVM.playerField.FieldGame;
                    binding = new Binding($"FieldGamePlayer[{i}].Value");
                }
                button.SetBinding(Button.ContentProperty, binding);
                buttonsList.Add(button);
            }
            foreach (Cell cell in workList) { cell.NumCell = workList.IndexOf(cell); }
        }
        void playerClick(object sender, EventArgs e)
        {
            Button playerButton = (Button)sender;
            TextBlock textBlock = new TextBlock();
            playerButton.IsEnabled = false;
            int index = buttonsListComputer.IndexOf(playerButton);
            if (fieldVM.FreeCell(index, fieldVM.compField))
            {
                textBlock = textBlockResultOfPressing("Transparent");
                playerButton.Content = textBlock;
            }
            else
                {
                Ship ship = fieldVM.CheckKilledShip(index,fieldVM.compField);
                if (ship == null)
                {
                    textBlock = textBlockResultOfPressing("Yellow"); playerButton.Content = textBlock;
                }
                    else
                    {
                        for (int i = ship.StartCell.NumCell; i < ship.StartCell.NumCell + ship.SizeShip; i++)
                        {
                            textBlock = textBlockResultOfPressing("Red");
                            buttonsListComputer[i].Content = textBlock;
                        }
                    }
                }
                
        }

       
        TextBlock textBlockResultOfPressing (String color)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Width = 18;
            textBlock.TextAlignment = TextAlignment.Center;
            switch (color)
            {
                case "Transparent":
                    textBlock.Background = new SolidColorBrush(Colors.Transparent);
                    textBlock.Foreground = new SolidColorBrush(Colors.Black);
                    textBlock.Text = ".";
                    break;
                case "Yellow":
                    textBlock.Background = new SolidColorBrush(Colors.Yellow);
                    textBlock.Foreground = new SolidColorBrush(Colors.Black);
                    textBlock.Text = "(!)";
                    break;
                case "Red":
                    textBlock.Background = new SolidColorBrush(Colors.Red);
                    textBlock.Foreground = new SolidColorBrush(Colors.Black);
                    textBlock.Text = "X";
                    break;
            }
            return textBlock;
        }
        void computerClick(object sender, EventArgs e)
        {
            computerLogic(buttonsListComputer, e);
        }

        void computerLogic (List<Button> buttonsList, EventArgs e)
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
        void fillListButtons(List<Button> buttonsList)
        {
            //for (int i = 0; i < buttonsList.Count; i++)
            //{
            //    buttonsList[i].Content = fieldVM.GameField[i].Value;
            //    if (fieldVM.GameField[i].Value == "*")
            //        buttonsList[i].IsEnabled = false;
            //}
        }
    }
}
