using Swapi.Models;
using System.Threading.Tasks;

namespace Swapi.Services
{
    public interface ISwapiService
    {
        Task<PeopleModel> GetPeople(string nextPage = "");

        Task<PeopleModel> GetPerson(string id);

        Task<FilmListModel> GetFilmList();

        Task<FilmModel> GetFilm(string filmUrl);

        Task<SpeciesModel> GetSpecies(string url);

        Task<VehicleModel> GetVehicle(string url);

        Task<VehicleListModel> GetVehicles();

        Task<StarshipModel> GetStarship(string url);
    }
}