using Swapi.Common;
using Swapi.Models;
using Swapi.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Swapi.ViewModels
{
    public class PersonViewModel : BaseViewModel
    {
        public PersonViewModel()
        {
            Person = PeopleViewModel.SelectedPerson;
        }

        public PersonModel Person { get; set; }

        private ObservableCollection<FilmModel> _films;

        public ObservableCollection<FilmModel> Films
        {
            get { return _films; }
            set { SetProperty(ref _films, value); }
        }

        private ObservableCollection<VehicleModel> _vehicles;

        public ObservableCollection<VehicleModel> Vehicles
        {
            get { return _vehicles; }
            set { SetProperty(ref _vehicles, value); }
        }

        private ObservableCollection<SpeciesModel> _species;

        public ObservableCollection<SpeciesModel> Species
        {
            get { return _species; }
            set { SetProperty(ref _species, value); }
        }

        private ObservableCollection<StarshipModel> _starships;

        public ObservableCollection<StarshipModel> Starships
        {
            get { return _starships; }
            set { SetProperty(ref _starships, value); }
        }

        public async Task GetData()
        {
            IsLoading = true;
            try
            {

                //Get Films
                var tempFilms = new List<FilmModel>();
                if (Person.Films != null)
                {
                    var tasks = new List<Task<FilmModel>>();
                    for (int i = 0; i < Person.Films.Count; i++)
                    {
                        tasks.Add(Service.GetFilm(Person.Films[i]));
                    }

                    foreach (var t in tasks)
                    {
                        tempFilms.Add(t.Result);
                    }

                    await Task.WhenAll(tasks);
                }

                //Get Species
                var tempSpecies = new List<SpeciesModel>();
                if (Person.Species != null)
                {
                    var tasks = new List<Task<SpeciesModel>>();
                    for (int i = 0; i < Person.Species.Count; i++)
                    {
                        tasks.Add(Service.GetSpecies(Person.Species[i]));
                    }

                    foreach (var t in tasks)
                    {
                        tempSpecies.Add(t.Result);
                    }

                    await Task.WhenAll(tasks);
                }

                //Get Vehicles
                var tempVehicles = new List<VehicleModel>();
                if (Person.Vehicles != null)
                {
                    var tasks = new List<Task<VehicleModel>>();
                    for (int i = 0; i < Person.Vehicles.Count; i++)
                    {
                        tasks.Add(Service.GetVehicle(Person.Vehicles[i]));
                    }

                    foreach (var t in tasks)
                    {
                        tempVehicles.Add(t.Result);
                    }

                    await Task.WhenAll(tasks);
                }

                //Get Starships
                var tempStarships = new List<StarshipModel>();
                if (Person.Starships != null)
                {
                    var tasks = new List<Task<StarshipModel>>();
                    for (int i = 0; i < Person.Starships.Count; i++)
                    {
                        tasks.Add(Service.GetStarship(Person.Starships[i]));
                    }

                    foreach (var t in tasks)
                    {
                        tempStarships.Add(t.Result);
                    }

                    await Task.WhenAll(tasks);
                }

                Films = new ObservableCollection<FilmModel>(tempFilms);
                Vehicles = new ObservableCollection<VehicleModel>(tempVehicles);
                Species = new ObservableCollection<SpeciesModel>(tempSpecies);
                Starships = new ObservableCollection<StarshipModel>(tempStarships);

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
