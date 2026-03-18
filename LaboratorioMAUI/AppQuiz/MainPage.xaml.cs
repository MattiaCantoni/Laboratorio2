using AppQuiz.Models;
using Microsoft.Maui.Graphics.Text;
using System;
namespace AppQuiz
{
    public partial class MainPage : ContentPage
    {
        //Creiamo la lista delle domande
        private List<QuestionBase> _questions = new List<QuestionBase>();
        private int _currentIndex = 0;
        private int _score = 0;

        private static readonly string _filePath = Path.Combine(
    FileSystem.AppDataDirectory, "questions.txt");

        public MainPage()
        {
            InitializeComponent();

            QuestionTextLabel.IsVisible = false;
            ScoreLabel.IsVisible = false;
            lblDomanda.IsVisible = false;

            entOpenQuestion.IsVisible = false;
            btnConferma.IsVisible = false;
            TrueButton.IsVisible = false;
            FalseButton.IsVisible = false;

            btnResult.IsVisible = false;
            btnReplay.IsVisible = false;
            
        }

        //L'evento porta con se il sender che è il bottone
        private void OnAnswer_Clicked(object sender, EventArgs e)
        {
            if (_currentIndex < _questions.Count)
            {
                QuestionBase current = _questions[_currentIndex];

                Button btn = (Button)sender; //Downcast

                if (TrueButton == btn || FalseButton == btn)
                {
                    string userAnswer = btn.CommandParameter.ToString();

                    addPoints(_currentIndex, userAnswer);
                }
                else if (btnConferma == btn)
                {
                    string userAnswer = entOpenQuestion.Text;
                    addPoints(_currentIndex, userAnswer);
                }
                entOpenQuestion.Text = null;
            } 
            else
            {
                OnQuizFinished();
                entOpenQuestion.Text = null;
            }
            _currentIndex++;
            ShowQuestion();
        }

        private void addPoints(int index, string userAnswer)
        {

            if (_questions[index].CheckAnswer(userAnswer))
            {
                _score += _questions[index].Points;
                DisplayAlert("Esatto", _questions[index].Points + " punti", "OK");
            }
            else
            {
                _score += 0;
                DisplayAlert("Errato", "0 punti", "OK");
            }
        }

        private void ShowQuestion()
        {
            if (_currentIndex < _questions.Count)
            {
                
                //Creo un oggetto Question che contiene la domanda corrente
                QuestionBase current = _questions[_currentIndex];


                if (current is TrueFalseQuestion)
                {
                    htsTrueFalse.IsVisible = true;
                    TrueButton.IsVisible = true;
                    FalseButton.IsVisible = true;
                    entOpenQuestion.IsVisible = false;
                    btnConferma.IsVisible = false;
                } else if (current is OpenQuestion){
                    entOpenQuestion.IsVisible = true;
                    btnConferma.IsVisible = true;
                    TrueButton.IsVisible = false;
                    FalseButton.IsVisible = false;
                    htsTrueFalse.IsVisible = false;
                }

                QuestionTextLabel.Text = current.Text;
                ScoreLabel.Text = $"Punti: {_score.ToString()}"; //Cast in stringa
                QuestionImage.Source = current.ImgName;
            }
            else
            {
                QuestionTextLabel.Text = $"Punteggio finale: {_score}";
                btnResult.IsVisible = true;
                entOpenQuestion.IsVisible = false;
                btnConferma.IsVisible = false;
                htsTrueFalse.IsVisible = false;
                ScoreLabel.IsVisible = false;
                TrueButton.IsVisible = false;
                FalseButton.IsVisible = false;
            }
        }

        private void btnResult_Clicked(object sender, EventArgs e)
        {
            OnQuizFinished();
        }

        private async void OnQuizFinished()
        {
            //Richiamiamo il metodo PushAsync e gli passiamo il nuovo oggetto ResultPage
            //Attendiamo senza bloccare la pagina grazie ad await e async
            await Navigation.PushAsync(new ResultPage(_score));
        }

        private async void btnReplay_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }


        public void LoadQuestions(int numberOfQuestions)
        {
            if (!File.Exists(_filePath))
            {
                throw new Exception("Il file non esiste");
            }
            try
            {
                string[] content = File.ReadAllLines(_filePath);
                var rng = new Random();
                rng.Shuffle(content);
                
                for (int i = 0; i < content.Length; i++)
                {
                    if (i < numberOfQuestions)
                    {
                        
                        string a = content[i];
                        string[] questionArray = a.Split(";");
                        if (questionArray[0] == "TF")
                        {
                            string question = questionArray[1];
                            int addScore;
                            int.TryParse(questionArray[2], out addScore);
                            bool response;
                            bool.TryParse(questionArray[3], out response);
                            string image = questionArray[4];
                            _questions.Add(new TrueFalseQuestion(question, addScore, response, image));
                        }
                        else if (questionArray[0] == "OPEN")
                        {
                            string question = questionArray[1];
                            int addScore;
                            int.TryParse(questionArray[2], out addScore);
                            string response = questionArray[3];
                            string image = questionArray[4];
                            _questions.Add(new OpenQuestion(question, addScore, response, image));
                        }
                        else
                        {
                            DisplayAlert("Errore", "Tipo di domanda non specificato", "OK");
                        }
                    }              
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Errore", "Impossibile leggere il punteggio: " + ex.Message, "OK");
            }
        }

        private void btnQuestionSetup_Clicked(object sender, EventArgs e)
        {
            int numberOfQuestions;
            int.TryParse(entQuestionsSetups.Text, out numberOfQuestions);
            LoadQuestions(numberOfQuestions);

            lblQuestionsSetup.IsVisible = false;
            entQuestionsSetups.IsVisible = false;
            btnQuestionsSetup.IsVisible = false;
            btnAddQuestion.IsVisible = false;
            QuestionTextLabel.IsVisible = true;
            ScoreLabel.IsVisible = true;
            lblDomanda.IsVisible = true;
            
            ShowQuestion();
        }

        private void btnAddQuestion_Clicked(object sender, EventArgs e)
        {
            lblQuestionsSetup.IsVisible = false;
            entQuestionsSetups.IsVisible = false;
            btnQuestionsSetup.IsVisible = false;
            btnAddQuestion.IsVisible = false;
            vslAccesso.IsVisible = true;
        }

        private void btnAccesso_Clicked(object sender, EventArgs e)
        {
            if (entAccesso.Text.Equals("1234"))
            {
                vslAccesso.IsVisible = false;
                vslAddQuestion.IsVisible = true;
            }
            else
            {
                vslAccesso.IsVisible = false;
                lblQuestionsSetup.IsVisible = true;
                entQuestionsSetups.IsVisible = true;
                btnQuestionsSetup.IsVisible = true;
                btnAddQuestion.IsVisible = true;
            }
        }
    }
}
