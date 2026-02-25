namespace AppQuiz;

public partial class ResultPage : ContentPage
{

    int _score = 0;

    public ResultPage(int score)
	{
		_score = score;
		InitializeComponent();

        ShowGUI();
	}

	private void ShowGUI()
	{
		lblScore.Text = _score.ToString();
	}

}