namespace Esercizio02Equation
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnCalcola(object sender, EventArgs e)
        {
            string strA = EntA.Text;
            string strB = EntB.Text;
            string strC = EntC.Text;


            if (string.IsNullOrEmpty(strA) || string.IsNullOrEmpty(strB) || string.IsNullOrEmpty(strC))
            {
                return;
            }
            try
            {

                double valA = Convert.ToDouble(strA);
                double valB = Convert.ToDouble(strB);
                double valC = Convert.ToDouble(strC);

                if (valA == 0)
                {
                    VisualizzaErrore();
                    return;
                }

                double delta = Math.Pow(valB, 2) - 4 * valA * valC;
                double x1;
                double x2;
                
                if(delta > 0)
                {
                    LblRisultato.TextColor = Colors.Green;
                    x1 = (-valB + Math.Sqrt(delta)) / (2 * valA);

                    x2 = (-valB - Math.Sqrt(delta) )/ (2 * valA);

                    LblRisultato.Text = String.Format("x1 = {0:F2};", x1);
                    LblRisultato.Text += String.Format(" x2 = {0:F2};", x2);
                    LblRisultato.Text += String.Format(" Δ = {0:F2};", x2);
                }
                else if (delta == 0)
                {
                    LblRisultato.TextColor = Colors.Blue;
                    x1 = (-valB) / (2 * valA);
                    x2 = x1;
                    LblRisultato.Text = String.Format("x1 = x2 = {0:F2}", x1);
                }
                else
                {
                    LblRisultato.TextColor = Colors.Red;
                    LblRisultato.Text = "Nessuna soluzione reale";
                }

            }
            catch (Exception ex)
            {
                VisualizzaErrore();
            }

        }

        public void VisualizzaErrore()
        {
            LblRisultato.Text = "Inserire valore valido";
            LblRisultato.TextColor = Colors.Orange;
        }

    }

}
