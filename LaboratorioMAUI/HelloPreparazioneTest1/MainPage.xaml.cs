namespace HelloPreparazioneTest1
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        bool isPointerInside = false;

        void OnMenuEnter(object sender, PointerEventArgs e)
        {
            isPointerInside = true;
            Dropdown.IsVisible = true;
        }

        void OnMenuExit(object sender, PointerEventArgs e)
        {
            isPointerInside = false;
            Dropdown.IsVisible = false;
        }

        void OnDropdownEnter(object sender, PointerEventArgs e)
        {
            isPointerInside = false;
            Dropdown.IsVisible = false;
        }

        void OnDropdownExit(object sender, PointerEventArgs e)
        {
            isPointerInside = false;
            Dropdown.IsVisible = false;
        }


    }

}
