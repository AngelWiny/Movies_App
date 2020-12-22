using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Movies_Totaltech_test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviePage : ContentPage
    {
        public MoviePage()
        {
            InitializeComponent();
            // (App.Current.MainPage as NavigationPage).BarBackgroundColor = Color.Transparent;
            var vm = DependencyService.Get<MoviesVM>();
            this.BindingContext = vm;
        }
    }
}