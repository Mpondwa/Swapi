using Newtonsoft.Json;
using Swapi.Models;
using Swapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapi.Tests.MockData
{
    public class MockSwapiService : ISwapiService
    {
        public Task<FilmModel> GetFilm(string filmUrl)
        {
            throw new NotImplementedException();
        }

        public Task<FilmListModel> GetFilmList()
        {
            throw new NotImplementedException();
        }

        public async Task<PeopleModel> GetPeople(string nextPage = "")
        {
            string data = MockData.People;
            return await Task.Run(() => JsonConvert.DeserializeObject<PeopleModel>(data));
        }

        public Task<PeopleModel> GetPerson(string id)
        {
            throw new NotImplementedException();
        }

        public Task<SpeciesModel> GetSpecies(string url)
        {
            throw new NotImplementedException();
        }

        public Task<StarshipModel> GetStarship(string url)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleModel> GetVehicle(string url)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleListModel> GetVehicles()
        {
            throw new NotImplementedException();
        }
    }
}
