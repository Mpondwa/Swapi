using Swapi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Swapi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeoplePage : ContentPage
    {
        PeopleViewModel _viewModel;

        public PeoplePage()
        {
            InitializeComponent();

            _viewModel = new PeopleViewModel();
            BindingContext = _viewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await Task.Run(() => _viewModel.GetData());
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            PeopleViewModel.SelectedPerson = (Models.PersonModel)e.SelectedItem;

            ((ListView)sender).SelectedItem = null;
            await Shell.Current.GoToAsync("personDetails");

        }
    }
}