namespace AppDiario
{
    public partial class MainPage : ContentPage
    {
        string percorsoFile = Path.Combine(FileSystem.AppDataDirectory, "note.txt");

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnSalva_Clicked(object sender, EventArgs e)
        {

        }

        private void btnLeggi_Clicked(object sender, EventArgs e)
        {

        }
    }
}
