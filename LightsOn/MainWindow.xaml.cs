using System;
using System.Collections.Generic;
using System.Linq;
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

namespace LightsOn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button[] Board;
        private Game game;
        private SolidColorBrush White = new SolidColorBrush(Colors.White);
        private SolidColorBrush Black = new SolidColorBrush(Colors.Black);
        public MainWindow()
        {
            InitializeComponent();
            Set_Board();
            game = new Game();
            for (int i = 0; i < 25; i++) Board[i].Content = $"{String.Join(", ",game.Board[i].AdjacentTiles)}";
        }

        private void Set_Board()
        {
            var list = new List<Button>();
            foreach (var b in ButtonGrid.Children)
            {
                list.Add((Button)b);
            }
            Board = list.ToArray();
        }

        private void Click_Button(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).Tag);
            int[] adjacent_Buttons_Ids = game.Click_Tile_And_Get_Adjacent_Tiles_Ids(id);
            foreach (int buttonId in adjacent_Buttons_Ids) ToggleLight(buttonId);
            ToggleLight(id);
        }

        private void ToggleLight(int id)
        {
            var button = Board[id - 1];
            var IslightOn = game.IsLightOn(id);
            if (IslightOn) button.Background = White;
            else button.Background = Black;
        }
    }
}
