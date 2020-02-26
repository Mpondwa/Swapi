using Swapi.Common;
using Swapi.Models;
using Swapi.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Swapi.ViewModels
{
    public class PeopleViewModel : BaseViewModel
    {
        public PeopleViewModel()
        {
            OnLoadMore = new AsyncDelegateCommand(LoadMoreAction);
        }

        public string nextPage;
        int pages = 2;

        public static PersonModel SelectedPerson { get; set; }

        private PersonModel _featured;

        public PersonModel Featured
        {
            get { return _featured; }
            set { SetProperty(ref _featured, value); }
        }

        private bool _hasNextPage;

        public bool HasNextPage
        {
            get { return _hasNextPage; }
            set { SetProperty(ref _hasNextPage, value); }
        }

        private ObservableCollection<PersonModel> _people;

        public ObservableCollection<PersonModel> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }

        private ObservableCollection<VehicleModel> _vehicles;

        public ObservableCollection<VehicleModel> Vehicles
        {
            get { return _vehicles; }
            set { SetProperty(ref _vehicles, value); }
        }

        private ObservableCollection<FilmModel> _films;

        public ObservableCollection<FilmModel> Films
        {
            get { return _films; }
            set { SetProperty(ref _films, value); }
        }

        public ICommand OnLoadMore { get; set; }


        private async Task LoadMoreAction(object arg)
        {
            if (IsLoading)
            {
                return;
            }

            IsLoading = true;

            try
            {
                var morePeople = await Service.GetPeople(nextPage.Substring(nextPage.IndexOf("page=")));

                foreach (var p in morePeople.PeopleList)
                {
                    People.Add(p);
                }

                nextPage = morePeople.NextPage;
                HasNextPage = nextPage != null;
                OnPropertyChanged("People");
            }
            catch (Exception)
            {
                //TODO: Handle specific exception

                AlertHelper.ShowMessage("Error", AppResource.err_DataLoadMessage, "OK");
            }

            IsLoading = false;
        }

        public async Task GetData()
        {
            IsLoading = true;
            try
            {

                //Get the first 20 people
                var tasks = new List<Task<PeopleModel>>();
                for (int i = 1; i <= pages; i++)
                {
                    tasks.Add(Service.GetPeople("page=" + i.ToString()));
                }

                await Task.WhenAll(tasks);

                var tempPeople = new List<PersonModel>();

                foreach (var t in tasks)
                {
                    tempPeople.AddRange(t.Result.PeopleList);
                }

                People = new ObservableCollection<PersonModel>(tempPeople);
                nextPage = tasks.Last()?.Result.NextPage;
                HasNextPage = nextPage != null;
            }
            catch (Exception)
            {
                //TODO: Handle specific exception

                AlertHelper.ShowMessage("Error", AppResource.err_DataLoadMessage, "OK");
            }

            IsLoading = false;
        }
    }
}
