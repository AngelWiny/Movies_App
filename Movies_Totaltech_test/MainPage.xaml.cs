using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Movies_Totaltech_test
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public MoviesVM VM { get; set; }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            VM = DependencyService.Get<MoviesVM>();
            this.BindingContext = VM;
            VM?.InitMainPageCommand?.Execute(null);

        }

        private async void lstTopRaited_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            VM.InitDetailPageCommand.Execute(null);
            //await Navigation.PushAsync(new MoviePage());
        }
    }
}
