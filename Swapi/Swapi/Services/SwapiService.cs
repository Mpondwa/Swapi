using Newtonsoft.Json;
using Swapi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Swapi.Services
{
    public class SwapiService : ISwapiService
    {
        HttpClient _client;
        public SwapiService(string url)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(url);
        }

        public async Task<PeopleModel> GetPeople(string nextPage = "")
        {
            try
            {
                if (nextPage != "")
                {
                    nextPage = "&" + nextPage;
                }

                var results = await _client.GetAsync($"people/?format=json{nextPage}");

                string data = await results.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<PeopleModel>(data));
            }
            catch (Exception ex)
            {
                //LOG:
                Trace.WriteLine("API [GetPeople] ERROR: " + ex.Message);
                throw;
            }
        }

        public async Task<PeopleModel> GetPerson(string id)
        {
            try
            {
                var results = await _client.GetAsync($"people/{id}/?format=json");

                string data = await results.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<PeopleModel>(data));
            }
            catch (Exception ex)
            {
                //LOG:
                Trace.WriteLine("API [GetPerson] ERROR: " + ex.Message);
                throw;
            }
        }


        public async Task<FilmListModel> GetFilmList()
        {
            try
            {
                var results = await _client.GetAsync($"films/?format=json");

                string data = await results.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<FilmListModel>(data));
            }
            catch (Exception ex)
            {
                //LOG:
                Trace.WriteLine("API [GetFilms] ERROR: " + ex.Message);
                throw;
            }
        }
        public async Task<FilmModel> GetFilm(string filmUrl)
        {
            try
            {
                var client = new HttpClient();
                var results = await client.GetAsync(filmUrl);

                string data = await results.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<FilmModel>(data));
            }
            catch (Exception ex)
            {
                //LOG:
                Trace.WriteLine("API [GetFilms] ERROR: " + ex.Message);
                throw;
            }
        }

        public async Task<SpeciesModel> GetSpecies(string url)
        {
            try
            {
                var client = new HttpClient();
                var results = await client.GetAsync(url);

                string data = await results.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<SpeciesModel>(data));
            }
            catch (Exception ex)
            {
                //LOG:
                Trace.WriteLine("API [GetSpecies] ERROR: " + ex.Message);
                throw;
            }
        }
        public async Task<VehicleModel> GetVehicle(string url)
        {
            try
            {
                var client = new HttpClient();
                var results = await client.GetAsync(url);

                string data = await results.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<VehicleModel>(data));
            }
            catch (Exception ex)
            {
                //LOG:
                Trace.WriteLine("API [GetVehicle] ERROR: " + ex.Message);
                throw;
            }
        }

        public async Task<VehicleListModel> GetVehicles()
        {
            try
            {
                var results = await _client.GetAsync($"vehicles/?format=json");

                string data = await results.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<VehicleListModel>(data));
            }
            catch (Exception ex)
            {
                //LOG:
                Trace.WriteLine("API [GetFilms] ERROR: " + ex.Message);
                throw;
            }
        }

        public async Task<StarshipModel> GetStarship(string url)
        {
            try
            {
                var client = new HttpClient();
                var results = await client.GetAsync(url);

                string data = await results.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<StarshipModel>(data));
            }
            catch (Exception ex)
            {
                //LOG:
                Trace.WriteLine("API [GetStarship] ERROR: " + ex.Message);
                throw;
            }
        }
    }
}
