using PizzAPP.Models;
namespace PizzAPP
{
    public partial class MainPage : ContentPage
    {
        private static readonly string _filePath = Path.Combine(
    FileSystem.AppDataDirectory, "pizze.txt");

        List<Pizza> listaPizze = new List<Pizza>();

        public MainPage()
        {
            InitializeComponent();
            LoadPizze();
        }

        private void PickPizze_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pizza selectPizza = (Pizza) PickPizze.SelectedItem;

            imgPizza.Source = selectPizza.Image;
            lblNome.Text = selectPizza.Nome;
            lblPrezzo.Text = selectPizza.Prezzo.ToString();
            lblIngredienti.Text = selectPizza.Ingredienti;
        }






        public void LoadPizze()
        {
            if (!File.Exists(_filePath))
            {
                throw new Exception("Il file non esiste");
            }
            try
            {
                string[] content = File.ReadAllLines(_filePath);
                
                for (int i = 0; i < content.Length; i++)
                {
                    string a = content[i];
                    string[] array = a.Split(";");

                    string nome = array[0];
                    float prezzo;
                    float.TryParse(array[1], out prezzo);
                    string image = array[2];
                    string ingridients = array[3];
                        
                    Pizza nuovaPizza = new(nome, prezzo, image, ingridients);

                    listaPizze.Add(nuovaPizza);
                }
                PickPizze.ItemsSource = listaPizze;
            }
            catch (Exception ex)
            {
                DisplayAlert("Errore", "Errore" + ex.Message, "OK");
            }
        }
         
         
         

    }

}
