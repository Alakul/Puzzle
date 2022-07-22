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

namespace Puzzle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string buttonFirstId = null;
        private int puzzleCount = 36;
        private int[] puzzles;
        private bool firstGame = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void CheckIfFirstGame()
        {
            if (firstGame == false){
                for (int i = 1; i <= puzzleCount; i++){
                    Button button = (Button)FindName("button" + i);
                    board.Children.Remove(button);
                }
            }
        }

        public void Generate(object sender, RoutedEventArgs args)
        {
            CheckIfFirstGame();
            GetElements();

            for (int i = 0; i < puzzleCount; i++)
            {
                string number = puzzles[i].ToString();
                string index = (i + 1).ToString();

                string buttonName = "button" + index;

                Button button = new Button();
                button.Width = 66.6;
                button.Height = 66.6;
                button.Name = buttonName;
                button.IsEnabled = true;
                button.Style = (Style)FindResource("ButtonImage");

                Image image = new Image();
                image.Name = "image" + index;
                image.Source = new BitmapImage(new Uri("/Images/Puzzles/" + number + ".jpg", UriKind.Relative));

                button.Content = image;
                button.Click += new RoutedEventHandler(Swap);

                RegisterNames(button, image);

                board.Children.Add(button);
            }

            start.IsEnabled = false;
            firstGame = false;
        }

        public void RegisterNames(Button button, Image image)
        {
            if (firstGame == false){
                UnregisterName(button.Name);
                UnregisterName(image.Name);
            }
            RegisterName(button.Name, button);
            RegisterName(image.Name, image);
        }

        public bool CheckIfWin()
        {
            for (int i=1; i<puzzleCount; i++){
                if (puzzles[i - 1] > puzzles[i]){
                    return false;
                }
            }
            return true;
        }

        public void SetWinValues()
        {
            if (CheckIfWin()){
                win.Text = "Gratulacje!";
                start.IsEnabled = true;
                start.Content = "ZAGRAJ JESZCZE RAZ";
                puzzles = null;

                for (int i = 1; i <= puzzleCount; i++){
                    Button button = (Button)FindName("button" + i);
                    button.IsEnabled = false;
                }
            }
        }

        public void GetElements()
        {
            Random random = new Random();
            puzzles = new int[puzzleCount];
            int number;

            for (int i=0; i<puzzleCount; i++)
            {
                do {
                    number = random.Next(1, puzzleCount + 1);
                }
                while (puzzles.Contains(number));

                puzzles[i] = number;        
            }
        }
        public void Swap(object sender, RoutedEventArgs args)
        {
            if (buttonFirstId == null)
            {
                Button buttonFirst = sender as Button;
                buttonFirstId = buttonFirst.Name;
                buttonFirst.BorderBrush = Brushes.White;
                buttonFirst.BorderThickness = new Thickness(2);
            }
            else if (buttonFirstId != null)
            {
                Button buttonSecond = sender as Button;
                string buttonSecondName = buttonSecond.Name;

                if (buttonSecondName != buttonFirstId)
                {
                    Button buttonFirst = (Button)FindName(buttonFirstId);
                    string buttonFirstName = buttonFirst.Name;
                    string buttonFirstNumber = buttonFirstName.Replace("button", "");                  
                    string buttonSecondNumber = buttonSecondName.Replace("button", "");

                    var imageF = (Image)FindName("image"+ buttonFirstNumber);
                    var sourceF = imageF.Source;

                    var imageS = (Image)FindName("image" + buttonSecondNumber);
                    var sourceS = imageS.Source;
                    
                    var tmp = sourceF;
                    imageF.Source = sourceS;
                    imageS.Source = tmp;

                    int firstNumber = int.Parse(buttonFirstNumber);
                    int secondNumber = int.Parse(buttonSecondNumber);

                    var tmp2 = puzzles[firstNumber - 1];
                    puzzles[firstNumber - 1] = puzzles[secondNumber - 1];
                    puzzles[secondNumber - 1] = tmp2;

                    buttonFirstId = null;
                    buttonFirst.BorderThickness = new Thickness(0);
                }
                else {
                    Button buttonFirst = sender as Button;
                    buttonFirstId = null;
                    buttonFirst.BorderThickness = new Thickness(0);
                }        
            }

            SetWinValues();
        }
    }
}
