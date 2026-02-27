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

    private async void btnGiocaAncora_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}
