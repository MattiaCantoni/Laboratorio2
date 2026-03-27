using AppSpese.Models;
using System.Security.AccessControl;

namespace AppSpese
{
    public partial class MainPage : ContentPage
    {

        private static string _listaFile = Path.Combine(FileSystem.AppDataDirectory, 
            "lista.txt");


        public MainPage()
        {
            InitializeComponent();
            visualizzaListe();
        }


        private void BtnSalvaSpese_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(EntNomeLista.Text) || string.IsNullOrEmpty(EntDescrizione.Text) || string.IsNullOrEmpty(EntImporto.Text))
            {
                DisplayAlert("Errore", "Riempire tutti i campi prima di salvare", "OK");
                return;
            }

            EntNomeLista.Text = EntNomeLista.Text.Trim().ToLower();
            EntDescrizione.Text = EntDescrizione.Text.Trim().ToLower();
            EntImporto.Text = EntImporto.Text.Trim().ToLower();
            string nomeFile = EntNomeLista.Text + ".txt";

            string meseFile = Path.Combine(FileSystem.AppDataDirectory, nomeFile);

            File.AppendAllText(meseFile, EntDescrizione.Text + ";" + EntImporto.Text + Environment.NewLine);

            if (File.Exists(_listaFile))
            {
                string[] arrSpese = File.ReadAllLines(_listaFile);
                if (!arrSpese.Contains<string>(nomeFile)) //controlla se c'è già il mese nella lista
                {
                    File.AppendAllText(_listaFile, nomeFile + Environment.NewLine);
                }
                EdiListe.Text = "";
                visualizzaListe();
            }
            else
            {
                File.AppendAllText(_listaFile, nomeFile + Environment.NewLine);
                EdiListe.Text += nomeFile + "\n";
            }

            EntDescrizione.Text = "";
            EntImporto.Text = "";
            DisplayAlert("Fatto", "Salvataggio spesa completato correttamente", "OK");
        }

        //Quando l'utente preme il pulsante di visualizzazione,
        //l'app deve navigare alla seconda pagina passando al suo
        //costruttore il percorso del file della lista corrente.
        private async void BtnVediSpese_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(EntNomeLista.Text))
            {
                DisplayAlert("Errore", "Inserire il nome della lista per visualizzare il contenuto", "OK");
                return;
            }
            await Navigation.PushAsync(new DettaglioPage(EntNomeLista.Text));
        }

        public void visualizzaListe()
        {
            if (File.Exists(_listaFile))
            {
                string[] arrSpese = File.ReadAllLines(_listaFile);
                foreach (string riga in arrSpese)
                {
                    EdiListe.Text += riga + "\n";
                }
            }
        }
    }

}
