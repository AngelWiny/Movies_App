using Movies_Totaltech_test.APIClient;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Movies_Totaltech_test
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Client = new ApiClient();
            MainPage = new NavigationPage(new MainPage());
        }

        public static string APIKey => "397fb87842020a2a0b688cfcd79c0c09";
        public static ApiClient Client { get; set; }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
