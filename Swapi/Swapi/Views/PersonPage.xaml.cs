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
    public partial class PersonPage : ContentPage
    {
        PersonViewModel _viewModel;
        public PersonPage()
        {
            InitializeComponent();

            _viewModel = new PersonViewModel();
            BindingContext = _viewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await Task.Run(async () => await _viewModel.GetData());
        }
    }
}