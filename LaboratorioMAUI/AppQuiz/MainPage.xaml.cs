using AppQuiz.Models;

namespace AppQuiz
{
    public partial class MainPage : ContentPage
    {
        //Creiamo la lista delle domande
        private List<QuestionBase> _questions = new List<QuestionBase>();
        private int _currentIndex = 0;
        private int _score = 0;

        public MainPage()
        {
            InitializeComponent();
            _questions.Add(new TrueFalseQuestion("Il C# è un linguaggio a oggetti?", 10, "csharplogo.png", true));
            _questions.Add(new TrueFalseQuestion("Python è un linguaggio compilato", 15, "python.png", false));
            ShowQuestion();
        }

        //L'evento porta con se il sender che è il bottone
        private void OnAnswer_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender; //Downcast
            //Trasforma command parameter in stringa e gli fa il Parse
            bool userAnswer = bool.Parse(btn.CommandParameter.ToString());

            if (_questions[_currentIndex].CheckAnswer(userAnswer))
            {
                _score += _questions[_currentIndex].Points;
            } 
            else
            {
                _score += 0;
            }
            _currentIndex++;
            ShowQuestion();
        }

        private void ShowQuestion()
        {
            if (_currentIndex < _questions.Count)
            {
                //Creo un oggetto Question che contiene la domanda corrente
                QuestionBase current = _questions[_currentIndex];
                QuestionTextLabel.Text = current.Text;
                ScoreLabel.Text = $"Punti: {_score.ToString()}"; //Cast in stringa
                QuestionImage.Source = current.ImgName;
            }
            else
            {
                QuestionTextLabel.Text = $"Punteggio finale: {_score}";
                ScoreLabel.IsVisible = false;
                TrueButton.IsVisible = false;
                FalseButton.IsVisible = false;
            }
        }
        /*
        private void ResetButton_Clicked(object sender, EventArgs e)
        {
            _questions = new List<QuestionBase>();
            _currentIndex = 0;
            _score = 0;
            ScoreLabel.IsVisible = true;
            TrueButton.IsVisible = true;
            FalseButton.IsVisible = true;
        }
        */
    }
}
