using System.Xml.Linq;

namespace AppSpese;

public partial class DettaglioPage : ContentPage
{

    string[] righe;
    private double totaleSpesa;

	public DettaglioPage(string name)
	{
        InitializeComponent();
        
        controllaFile(name);
    }

    public void controllaFile(string name)
    {

        if (File.Exists(Path.Combine(FileSystem.AppDataDirectory, name + ".txt")))
        {
            righe = File.ReadAllLines(Path.Combine(FileSystem.AppDataDirectory, name + ".txt"));
            scriviSpesa(name);
            calcolaTotaleSpesa(name);
        }
        else
        {
            lblFileName.Text = name;
            EdiSpese.Text = "Ancora nessun contenuto per questa lista";
            DisplayAlert("Errore", "File '" + name + "' non esiste", "OK");
        }
    }

    public void scriviSpesa(string name)
    {
        lblFileName.Text = name;
        foreach (string riga in righe)
        {
            string[] spesaSingola = riga.Split(";");
            if (spesaSingola.Length < 2) continue;
            EdiSpese.Text += "DESCRIZIONE: " + spesaSingola[0];
            EdiSpese.Text += "\nIMPORTO: " + spesaSingola[1];
            EdiSpese.Text += "\n------------------\n";
        }
    }

    public void calcolaTotaleSpesa(string name)
    {
        foreach (string riga in righe)
        {
            string[] spesaSingola = riga.Split(";");
            if (spesaSingola.Length < 2) continue;
            int sommatore;
            int.TryParse(spesaSingola[1], out sommatore);
            totaleSpesa += sommatore;
        }

        EdiSpese.Text += "\n\n"
                + "Totale spesa: " + totaleSpesa;
    }

    private async void btnTorna_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}