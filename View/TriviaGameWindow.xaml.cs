using ADETProjApp.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
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
    /// Interaction logic for TriviaGameWindow.xaml
    /// </summary>
    public partial class TriviaGameWindow : INotifyPropertyChanged
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
        private int currentQuestionIndex = 0;
        private int points = 0;
        private int mistakes = 0;
        private List<Question> questions;
        private List<Question> remainingQuestions;
        private bool isAnswered = false;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TriviaGameWindow()
        {

            InitializeComponent();
            User = UserManage.GetUser();
            LoadQuestions();
            ShuffleQuestions();
            DisplayQuestion();
        }

        private void PointsToDbAndModel()
        {
            if(points == 0)
            {
                return;
            }
            string username = User.username;
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
        }

        private void LoadQuestions()
        {
            questions = new List<Question>
            {
                new Question("Which bird cannot fly?", new[] { "Chicken", "Duck", "Ostrich", "Goose" }, 2),
                new Question("What is the capital of France?", new[] { "Berlin", "Madrid", "Paris", "Lisbon" }, 2),
                new Question("What is the value of pi to three decimal places?", new[] { "3.141", "3.142", "3.143", "3.144" }, 0),
                new Question("Which planet is known as the Red Planet?", new[] { "Earth", "Mars", "Jupiter", "Saturn" }, 1),
                new Question("What is the largest mammal?", new[] { "Elephant", "Blue Whale", "Shark", "Giraffe" }, 1),
                new Question("Who wrote 'Hamlet'?", new[] { "Mark Twain", "J.K. Rowling", "William Shakespeare", "Charles Dickens" }, 2),
                new Question("Which element has the chemical symbol O?", new[] { "Gold", "Oxygen", "Silver", "Osmium" }, 1),
                new Question("What is the boiling point of water?", new[] { "90°C", "100°C", "110°C", "120°C" }, 1),
                new Question("Who painted the Mona Lisa?", new[] { "Vincent van Gogh", "Pablo Picasso", "Leonardo da Vinci", "Claude Monet" }, 2),
                new Question("What is the fastest land animal?", new[] { "Cheetah", "Lion", "Horse", "Elephant" }, 0),
                new Question("What is the smallest prime number?", new[] { "0", "1", "2", "3" }, 2),
                new Question("Which ocean is the largest?", new[] { "Atlantic Ocean", "Indian Ocean", "Arctic Ocean", "Pacific Ocean" }, 3),
                new Question("What is the hardest natural substance on Earth?", new[] { "Gold", "Iron", "Diamond", "Platinum" }, 2),
                new Question("How many planets are in the Solar System?", new[] { "7", "8", "9", "10" }, 1),
                new Question("What is the capital of Japan?", new[] { "Kyoto", "Osaka", "Tokyo", "Nagoya" }, 2),
                new Question("What is the largest continent?", new[] { "Africa", "Asia", "Europe", "North America" }, 1),
                new Question("Who invented the telephone?", new[] { "Thomas Edison", "Alexander Graham Bell", "Nikola Tesla", "Albert Einstein" }, 1),
                new Question("What is the chemical formula for water?", new[] { "H2O", "O2", "CO2", "NaCl" }, 0),
                new Question("Which country is known as the Land of the Rising Sun?", new[] { "China", "Japan", "Korea", "Thailand" }, 1),
                new Question("Who discovered penicillin?", new[] { "Marie Curie", "Alexander Fleming", "Isaac Newton", "Charles Darwin" }, 1),
                new Question("What is the tallest mountain in the world?", new[] { "K2", "Kangchenjunga", "Mount Everest", "Lhotse" }, 2),
                new Question("Which is the longest river in the world?", new[] { "Amazon River", "Nile River", "Yangtze River", "Mississippi River" }, 1),
                new Question("What is the capital of Australia?", new[] { "Sydney", "Melbourne", "Canberra", "Brisbane" }, 2),
                new Question("Who wrote 'Pride and Prejudice'?", new[] { "Charlotte Brontë", "Emily Brontë", "Jane Austen", "Mary Shelley" }, 2),
                new Question("What is the chemical symbol for gold?", new[] { "Au", "Ag", "Pb", "Hg" }, 0),
                new Question("Which planet is known as the Gas Giant?", new[] { "Earth", "Mars", "Jupiter", "Saturn" }, 2),
                new Question("Who painted the ceiling of the Sistine Chapel?", new[] { "Leonardo da Vinci", "Michelangelo", "Raphael", "Donatello" }, 1),
                new Question("What is the square root of 64?", new[] { "6", "7", "8", "9" }, 2),
                new Question("Who developed the theory of relativity?", new[] { "Isaac Newton", "Albert Einstein", "Galileo Galilei", "Stephen Hawking" }, 1),
                new Question("Which country is known for the maple leaf?", new[] { "USA", "Canada", "UK", "Australia" }, 1),
                new Question("What is the largest desert in the world?", new[] { "Sahara Desert", "Gobi Desert", "Arabian Desert", "Antarctic Desert" }, 3),
                new Question("Who is the author of 'Harry Potter' series?", new[] { "J.R.R. Tolkien", "J.K. Rowling", "George R.R. Martin", "C.S. Lewis" }, 1),
                new Question("What is the capital of Italy?", new[] { "Rome", "Venice", "Florence", "Milan" }, 0),
                new Question("Which planet is closest to the sun?", new[] { "Earth", "Venus", "Mercury", "Mars" }, 2),
                new Question("Who is known as the 'Father of Computers'?", new[] { "Bill Gates", "Charles Babbage", "Alan Turing", "Steve Jobs" }, 1),
                new Question("What is the largest organ in the human body?", new[] { "Heart", "Liver", "Skin", "Lungs" }, 2),
                new Question("Who was the first man to walk on the moon?", new[] { "Buzz Aldrin", "Yuri Gagarin", "Michael Collins", "Neil Armstrong" }, 3),
                new Question("Which element has the atomic number 1?", new[] { "Helium", "Oxygen", "Hydrogen", "Nitrogen" }, 2),
                new Question("What is the capital of Canada?", new[] { "Toronto", "Ottawa", "Montreal", "Vancouver" }, 1),
                new Question("Who wrote 'The Great Gatsby'?", new[] { "Ernest Hemingway", "F. Scott Fitzgerald", "Mark Twain", "John Steinbeck" }, 1),
                new Question("Which planet is known as the Earth's twin?", new[] { "Mars", "Venus", "Jupiter", "Saturn" }, 1),
                new Question("What is the largest ocean on Earth?", new[] { "Atlantic Ocean", "Indian Ocean", "Arctic Ocean", "Pacific Ocean" }, 3),
                new Question("Who invented the light bulb?", new[] { "Alexander Graham Bell", "Thomas Edison", "Nikola Tesla", "Benjamin Franklin" }, 1),
                new Question("Which country is famous for the Eiffel Tower?", new[] { "Italy", "Spain", "France", "Germany" }, 2),
                new Question("What is the chemical symbol for sodium?", new[] { "Na", "K", "Ca", "Mg" }, 0),
                new Question("Who wrote 'Moby-Dick'?", new[] { "Herman Melville", "Mark Twain", "Jules Verne", "Charles Dickens" }, 0),
                new Question("What is the longest bone in the human body?", new[] { "Femur", "Tibia", "Fibula", "Humerus" }, 0),
                new Question("Which country is known as the Land of Fire and Ice?", new[] { "Greenland", "Iceland", "Norway", "Sweden" }, 1),
                new Question("Who is the author of '1984'?", new[] { "Aldous Huxley", "George Orwell", "Ray Bradbury", "J.D. Salinger" }, 1),
                new Question("What is the main ingredient in guacamole?", new[] { "Tomato", "Avocado", "Pepper", "Lettuce" }, 1),
                new Question("Which planet has the most moons?", new[] { "Mars", "Venus", "Jupiter", "Saturn" }, 3)
            };
        }

        private void ShuffleQuestions()
        {
            var random = new Random();
            questions = questions.OrderBy(q => random.Next()).ToList();
            questions = questions.Take(5).ToList();
            remainingQuestions = questions;
        }

        private void DisplayQuestion()
        {
            if (mistakes >= 3)
            {
                MessageBox.Show("    Sorry, you have reached 3 mistakes.");
                if (MessageBox.Show("Do you want to play another game?", "Game Over", MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    MessageBox.Show("Thank you for playing! I hope you enjoyed it. \nSee you again next time!");
                    PointsToDbAndModel();
                    this.Close();
                }
                else
                {
                    PointsToDbAndModel();
                    ResetGame();
                }
                return;
            }

            if (remainingQuestions.Count == 0)
            {
                if (MessageBox.Show("That's All. Do you want to play another game?", "Game Over", MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    MessageBox.Show("Thank you for playing! I hope you enjoyed it. \nSee you again next time!");
                    PointsToDbAndModel();
                    this.Close();
                }
                else
                {
                    PointsToDbAndModel();
                    ResetGame();
                }
                return;
            }

            var question = remainingQuestions[currentQuestionIndex];
            lblQuestion.Text = question.Text;
            AdjustFontSizeToFit(lblQuestion);

            btnAnswer1.Content = question.Answers[0];
            btnAnswer2.Content = question.Answers[1];
            btnAnswer3.Content = question.Answers[2];
            btnAnswer4.Content = question.Answers[3];

            btnNext.IsEnabled = false;
            isAnswered = false;

            btnAnswer1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#054BAD"));
            btnAnswer2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#054BAD"));
            btnAnswer3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#054BAD"));
            btnAnswer4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#054BAD"));
        }

        private void AdjustFontSizeToFit(TextBlock textBlock)
        {
            double fontSize = 20;
            textBlock.TextWrapping = TextWrapping.Wrap;
            while (fontSize > 10 && (textBlock.ActualHeight > textBlock.Height || textBlock.ActualWidth > textBlock.Width))
            {
                fontSize--;
                textBlock.FontSize = fontSize;
            }
        }

        private void ResetGame()
        {
            points = 0;
            lblPoints.Text = $"Points: {points}";
            mistakes = 0;
            currentQuestionIndex = 0;
            questions.Clear();
            remainingQuestions.Clear();
            LoadQuestions();
            ShuffleQuestions();
            DisplayQuestion();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            remainingQuestions.RemoveAt(currentQuestionIndex);
            DisplayQuestion();
        }

        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (isAnswered) return;

            var button = sender as Button;
            var selectedAnswer = int.Parse(button.Tag.ToString());
            var question = remainingQuestions[currentQuestionIndex];

            var correctButton = FindName($"btnAnswer{question.CorrectAnswerIndex + 1}") as Button;

            if (selectedAnswer == question.CorrectAnswerIndex)
            {
                points += 1;
                lblPoints.Text = $"Points: {points}";
                button.Background = Brushes.Green;
                MessageBox.Show("    Your answer is correct!");
            }
            else
            {
                mistakes++;
                button.Background = Brushes.Red;
                correctButton.Background = Brushes.Green;
                MessageBox.Show($"     Sorry, your answer is wrong. \n\n    The correct answer is: {correctButton.Content}");
            }
            isAnswered = true;
            btnNext.IsEnabled = true;
        }
    }

    public class Question
    {
        public string Text { get; }
        public string[] Answers { get; }
        public int CorrectAnswerIndex { get; }

        public Question(string text, string[] answers, int correctAnswerIndex)
        {
            Text = text;
            Answers = answers;
            CorrectAnswerIndex = correctAnswerIndex;
        }

    }
}
