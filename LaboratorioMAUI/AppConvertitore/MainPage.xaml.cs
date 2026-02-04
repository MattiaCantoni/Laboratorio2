namespace AppConvertitore
{
    public partial class MainPage : ContentPage
    {

        public MainPage() // Costruttore della pagina
        {
            // Permette di costruire i componenti della UI
            InitializeComponent();
        }

        private void btnConverti_Clicked(object sender, EventArgs e)
        {
            string valoreImporto = EntFranchi.Text;
            if (string.IsNullOrEmpty(valoreImporto)) 
            {
                return;
            }
            try
            {
                double franchi = Convert.ToDouble(valoreImporto);
                if (franchi > 0)
                {
                    double euro = franchi * 1.07;
                    lblRisultato.Text = String.Format("Risultato: {0:F2} €", euro); // 0: numerico, F2: 2 valori dopo la virgola
                    lblRisultato.TextColor = Colors.White;
                }
                else
                {
                    VisualizzaErrore();
                }
            }
            catch(Exception ex)
            {
                VisualizzaErrore();
            }
        }

        public void VisualizzaErrore()
        {
            lblRisultato.Text = "Inserire solo numeri positivi";
            lblRisultato.TextColor = Colors.Red;
        }

        private void btnResetPage(object sender, EventArgs e)
        {
            EntFranchi.Text = "";
            lblRisultato.Text = "Pronto per convertire";
            lblRisultato.TextColor = Colors.White;
            EntFranchi.Focus();
        }
    }
}
