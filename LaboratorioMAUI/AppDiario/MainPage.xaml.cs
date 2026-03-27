using AppDiario.Models;

namespace AppDiario
{
    public partial class MainPage : ContentPage
    {
        string percorsoFile = Path.Combine(FileSystem.AppDataDirectory, "note.txt");

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnSalva_Clicked(object sender, EventArgs e)
        {
            Nota nuovaNota = new Nota(); //Creo una nuova nota

            nuovaNota.Titolo = entTitolo.Text;  //Leggo l'entry titolo
            nuovaNota.Testo = entTesto.Text;    //Leggo l'entry testo

            if (string.IsNullOrEmpty(nuovaNota.Titolo))
            {
                await DisplayAlert("Errore", "Inserisci almeno il titolo", "OK");
                return;
            }

            //Il metodo DaOggettoARiga ritorna una stringa composta
            //dagli attributi della nota (Titolo;Testo)
            string rigaDaScrivere = nuovaNota.DaOggettoARiga();

            //La classe File mette a disposizione il metodo per appendere il testo
            File.AppendAllText(percorsoFile, rigaDaScrivere + Environment.NewLine);

            entTitolo.Text = "";
            entTesto.Text = "";

            await DisplayAlert("Fatto", "nota salvata correttamente", "OK");
        }

        private void btnLeggi_Clicked(object sender, EventArgs e)
        {
            if (File.Exists(percorsoFile)) 
            {
                //Dichiaro e inizializzo una array che viene popolato con le righe del txt
                string[] righe = File.ReadAllLines(percorsoFile);
                editDisplay.Text = "";

                //Usiamo il foreach per ciclare l'array delle righe
                foreach (string riga in righe)
                {
                    Nota n = Nota.DaRigaAOggetto(riga);

                    if (n != null)
                    {
                        editDisplay.Text = editDisplay.Text + "TITOLO: " + n.Titolo + "\n";
                        editDisplay.Text = editDisplay.Text + "TESTO: " + n.Testo + "\n";
                        editDisplay.Text = editDisplay.Text + "------------------------\n";

                    }
                }
            }
            else
            {
                editDisplay.Text = "Il file è vuoto o non esiste ancora.";
            }
        }

    }
}
