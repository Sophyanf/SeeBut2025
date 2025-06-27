using SeeBat2025.Resources;
using SeeBut2025;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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
        //public Field field ;
        public Battle battle { get; set; } = new Battle();

        public MainWindow()
        {
            //field = new Field();
            InitializeComponent();
            addButton();
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
                
        }
        void playerClick(object sender, EventArgs e)
        {
            Button playerButton = (Button)sender;
            playerButton.IsEnabled = false;
            int index = buttonsList.IndexOf(playerButton);
            playerButton.Content = battle.GameField[index].Value;
            if (battle.GameField[index].Value != ".")
                battle.checkCell(battle.GameField[index]);
        }
    }
}
