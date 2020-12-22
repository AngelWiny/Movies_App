using Movies_Totaltech_test;
using Movies_Totaltech_test.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(MoviesVM))]
namespace Movies_Totaltech_test
{
    public class MoviesVM : BaseVM
    {
        #region Variables

        private MoviesPage _topRatedMovies;
        private MoviesPageUpcomming _upcommingMovies;
        private MoviesPage _popularMovies;
        private Movie _selectedMovie;
        private MovieDetail _movieDetail;
        private MovieCredits _movieCredits;
        #endregion


        #region Properties

        public MoviesPage TopRatedMovies
        {
            get { return _topRatedMovies; }
            set
            {
                _topRatedMovies = value;
                OnPropertyChanged();
            }
        }
        public MoviesPageUpcomming UpcommingMovies
        {
            get { return _upcommingMovies; }
            set
            {
                _upcommingMovies = value;
                OnPropertyChanged();
            }
        }
        public MoviesPage PopularMovies
        {
            get { return _popularMovies; }
            set
            {
                _popularMovies = value;
                OnPropertyChanged();
            }
        }

        public Movie SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                _selectedMovie = value;
                if (value != null)
                {
                    OnPropertyChanged();
                    //SelectedMovieChanged();
                }
            }
        }
        public MovieDetail Detail
        {
            get { return _movieDetail; }
            set { _movieDetail = value; OnPropertyChanged(); }
        }
        public MovieCredits Credits
        {
            get { return _movieCredits; }
            set
            {
                _movieCredits = value;
                OnPropertyChanged();
            }
        }



        #endregion

        #region Commands

        public Command InitMainPageCommand => new Command(async () =>
        {
            await GetTopRaitedMovies();
            await GetUpcommingMovies();
            await GetPopularMovies();

        });

        public Command InitDetailPageCommand => new Command(async () => await SelectedMovieChanged());

        #endregion

        #region Methods

        private async Task SelectedMovieChanged()
        {
            await GetMovieDetail();
            await GetMovieCredits();
            await (App.Current.MainPage as NavigationPage).Navigation.PushAsync(new MoviePage());
            //SelectedMovie = null;
        }

        #endregion

        #region API

        private async Task GetTopRaitedMovies()
        {
            string url = $"top_rated?api_key={App.APIKey}&language=en-US&page=1";
            TopRatedMovies = await App.Client.ExecuteRequestAsync<MoviesPage>(url);
        }

        private async Task GetUpcommingMovies()
        {
            string url = $"upcoming?api_key={App.APIKey}&language=en-US&page=1";
            UpcommingMovies = await App.Client.ExecuteRequestAsync<MoviesPageUpcomming>(url);
        }

        private async Task GetPopularMovies()
        {
            string url = $"popular?api_key={App.APIKey}&language=en-US&page=1";
            PopularMovies = await App.Client.ExecuteRequestAsync<MoviesPage>(url);
        }

        private async Task GetMovieDetail()
        {
            string url = $"{SelectedMovie.id}?api_key={App.APIKey}&language=en-US";
            Detail = await App.Client.ExecuteRequestAsync<MovieDetail>(url);
        }

        private async Task GetMovieCredits()
        {
            string url = $"{SelectedMovie.id}/credits?api_key={App.APIKey}&language=en-US";
            Credits = await App.Client.ExecuteRequestAsync<MovieCredits>(url);
        }

        #endregion
    }
}
