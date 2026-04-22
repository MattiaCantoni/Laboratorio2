using HelloList.Models;

namespace HelloList
{
    public partial class MainPage : ContentPage
    {
        //Lista di Frutto
        List<Frutto> frutti;


        public MainPage()
        {
            InitializeComponent();
            ShowGUI();
        }

        private void ShowGUI()
        {
            frutti = new List<Frutto>();
            frutti.Add(new Frutto("Mela", "Italia"));
            frutti.Add(new Frutto("Kiwi", "Groenlandia"));
            frutti.Add(new Frutto("Ananas", "Svizzera"));
            //frutti.Remove("Mela"); //Rimuoviamo la mela
            //frutti.Insert(1, "Banana"); //Si colloca all'indice 1
            //frutti.RemoveAt(1);
            //Popolato l'Item Source del Picker
            PickFrutti.ItemsSource = frutti;
        }

        private void PickFrutti_SelectedIndexChanged(object sender, EventArgs e)
        {
            Frutto selectFruit = (Frutto) PickFrutti.SelectedItem;

            EntFrutti.Text = selectFruit.Provenienza;

        }
    }

}
