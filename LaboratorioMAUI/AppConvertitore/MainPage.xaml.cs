namespace AppConvertitore
{
    public partial class MainPage : ContentPage
    {

        public MainPage() // Costruttore della pagina
        {
            // Inizializza i componenti grafici
            InitializeComponent();
        }

        private void btnConverti_Clicked(object sender, EventArgs e)
        {
            string valoreImporto = entConversione.Text;

            double franchi = Convert.ToDouble(valoreImporto);

            double euro = franchi * 1.07;

            //lblRisultato =;
        }
    }

}
