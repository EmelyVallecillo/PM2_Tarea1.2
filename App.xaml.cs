namespace MauiApp1
{
    public partial class App : Application
    {

        static Controllers.DBServices dBSvices;
        public static Controllers.DBServices DataBase
        {
            get
            {
                if (dBSvices == null)
                {
                    dBSvices = new Controllers.DBServices();
                }
                return dBSvices;
            }
        }
        public App()
        {
            InitializeComponent();
            //Indica mi pag inicial
            MainPage = new NavigationPage(new Views.PageInit());
        }
    }
}
