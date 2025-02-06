using ADETProjApp.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ADETProjApp.View
{
    /// <summary>
    /// Interaction logic for WordGameWindow.xaml
    /// </summary>
    public partial class WordGameWindow : INotifyPropertyChanged
    {
        private User _user;
        public User User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged();
                }
            }
        }
        private WordleLogic wordleLogic {  get; }
        private int attempt = 0;
        private const string PlaceholderText = " Enter your answer here...";

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public WordGameWindow()
        {
            InitializeComponent();

            User = UserManage.GetUser();
            wordleLogic = new WordleLogic();
            AnswerTextBox.Text = PlaceholderText;
            AnswerTextBox.Foreground = Brushes.Gray;
            AnswerTextBox.FontStyle = FontStyles.Italic;
        }

        private void AnswerTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (AnswerTextBox.Text == PlaceholderText)
            {
                AnswerTextBox.Text = string.Empty;
                AnswerTextBox.Foreground = Brushes.Black;
                AnswerTextBox.FontStyle = FontStyles.Normal;
            }
        }

        private void AnswerTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AnswerTextBox.Text))
            {
                AnswerTextBox.Text = PlaceholderText;
                AnswerTextBox.Foreground = Brushes.Gray;
                AnswerTextBox.FontStyle = FontStyles.Italic;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string checkWord = AnswerTextBox.Text.ToLower();
            string guessedWord = AnswerTextBox.Text.ToUpper();

            string filePath = "D:\\source\\repos\\ADETProjApp\\WORDS.txt";
            string fileContent = "";

            try
            {
                fileContent = File.ReadAllText(filePath);

            }
            catch (IOException ex)
            {
                MessageBox.Show($"An error occurred while reading the file: {ex.Message}");
            }

            if (guessedWord.Length == 5 && attempt < 6 && guessedWord != PlaceholderText.ToUpper() && fileContent.Contains(checkWord))
            {
                UpdateGrid(guessedWord);
                attempt++;
                AnswerTextBox.Clear();
                AnswerTextBox_LostFocus(null, null);

                if (wordleLogic.IsCorrectWord(guessedWord))
                {
                    MessageBox.Show("Congratulations! You've guessed the word.");
                    string username = User.username;
                    int points = 2;
                    MySqlConnection conn = DBConnection.connectDB();
                    UserManage.UpdateAddPoints(points);
                    OnPropertyChanged(nameof(User));
                    OnPropertyChanged(nameof(points));
                    try
                    {         
                        string query = "UPDATE user_tbl SET points = points + @points WHERE username = @username";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@points", points.ToString());
                        cmd.Parameters.AddWithValue("@username", username);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"{points.ToString()} points added successfully to @{username}.");
                        }
                        else
                        {
                            MessageBox.Show($"No rows updated for {username}.");
                        }
                    }
                    catch (Exception) { }
                    finally { conn.Close(); }
                    NextLevelButton.IsEnabled = true;
                    SubmitButton.IsEnabled = false;
                    AnswerTextBox.IsEnabled = false;
                }
                else if (attempt == 6)
                {
                    MessageBox.Show("\tGame Over! \nThe correct word was: " + wordleLogic.CorrectWord);
                    NextLevelButton.IsEnabled = true;
                    SubmitButton.IsEnabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid 5-letter word.");
            }
        }

        private void NextLevelButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to play again?", "Play Again", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                attempt = 0;
                wordleLogic.GenerateNewWord();
                ClearGrid();
                NextLevelButton.IsEnabled = false;
                SubmitButton.IsEnabled = true;
                AnswerTextBox.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Thank you for playing Wordle, I hope you enjoyed it!");
                NextLevelButton.IsEnabled = false;
                SubmitButton.IsEnabled = false;
                this.Close();
            }

        }

        private void UpdateGrid(string guessedWord)
        {
            for (int i = 0; i < 5; i++)
            {
                var lbl = (TextBlock)FindName($"Cell_{attempt}_{i}");
                lbl.Text = guessedWord[i].ToString();
                lbl.Background = new SolidColorBrush(wordleLogic.GetLetterColor(guessedWord[i], i));
            }
        }

        private void ClearGrid()
        {
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    var lbl = (TextBlock)FindName($"Cell_{row}_{col}");
                    lbl.Text = "";
                    lbl.Background = Brushes.White;
                }
            }
        }
    }

    public class WordleLogic
    {
        private readonly List<string> wordList;
        private string correctWord;
        private Random random;

        public WordleLogic()
        {
            wordList = new List<string>();
            string filePath = "D:\\source\\repos\\ADETProjApp\\WORDS.txt";

            random = new Random();

            try
            {
                string[] words = File.ReadAllLines(filePath);
                foreach (string word in words)
                {
                    wordList.Add(word);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

            correctWord = "";
            GenerateNewWord();
        }

        public string CorrectWord
        {
            get { return correctWord; }
        }

        public void GenerateNewWord()
        {
            correctWord = wordList[random.Next(wordList.Count)].ToUpper();
            MessageBox.Show(correctWord);
        }

        public bool IsCorrectWord(string guessedWord)
        {
            return guessedWord == correctWord;
        }

        public Color GetLetterColor(char letter, int position)
        {
            if (correctWord[position] == letter)
            {
                return Colors.LightGreen;
            }
            else if (correctWord.Contains(letter.ToString()))
            {
                return Colors.Orange;
            }
            else
            {
                return Colors.Gray;
            }
        }
    }
}
