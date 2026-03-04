namespace AppQuiz;

public partial class ResultPage : ContentPage
{
	//Percorso dove leggere e salvare il file txt
	private static readonly string _filePath = Path.Combine(
		FileSystem.AppDataDirectory, "bestscore.txt");

    int _score = 0;

    public ResultPage(int score)
	{
		_score = score;
		InitializeComponent();
		SaveBestScore(_score);
        ShowGUI(_score);
	}

	private void ShowGUI(int score)
	{
		lblScore.Text = score.ToString();
	}

    private async void btnGiocaAncora_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }


	private void SaveBestScore(int score)
	{
		//Allochiamo lo score estratto dal file txt nella variabile best
		int best = LoadBestScore();

		//Se lo score del giocatore è maggiore di quello salvato
		if (score > best)
		{
			try
			{
				File.WriteAllText(_filePath, score.ToString());
			}
			catch (Exception ex)
			{
				DisplayAlert("Errore", "Impossibile salvare il punteggio: " + ex.Message, "OK");
			}
		}
	}


	private int LoadBestScore()
	{
		if (!File.Exists(_filePath))
		{
			return 0;
		}

		//È buona abitudune gestire l'eccezione R/W!
		try
		{
			//Legge il contenuto del file txt
			string content = File.ReadAllText(_filePath);

			//Variabile locale per contenere il best score
			int best;

			//TryParse fa gestione eccezioni già interna
			//Ritorna true se non incontra eccezioni
			if (int.TryParse(content, out best))
			{
				return best;
			}
			else
			{
				DisplayAlert("Errore", "Il file del punteggio contiene un valore non valido.", "OK");
				return 0;
			}
		}
		catch (Exception ex)
		{
			DisplayAlert("Errore", "Impossibile leggere il punteggio: " + ex.Message, "OK");
			return 0;
		}
	}


		

}
