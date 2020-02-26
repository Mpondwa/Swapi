using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Swapi.Services;
using Swapi.Tests.MockData;
using Swapi.ViewModels;

namespace Swapi.Tests
{
    [TestClass]
    public class PeoplePageUnitTest
    {
        [TestMethod]
        public async Task TestGetDataCountMethod()
        {
            ISwapiService mockService = new MockSwapiService();

            PeopleViewModel vm = new PeopleViewModel();
            vm.SetService(mockService);

            await vm.GetData();

            Assert.AreEqual(20, vm.People.Count);
        }

        [TestMethod]
        public async Task TestGetDataMethod()
        {
            ISwapiService mockService = new MockSwapiService();

            PeopleViewModel vm = new PeopleViewModel();
            vm.SetService(mockService);

            await vm.GetData();

            Assert.IsTrue(vm.HasNextPage);
        }

        [TestMethod]
        public async Task TestNextPageMethod()
        {
            ISwapiService mockService = new MockSwapiService();

            PeopleViewModel vm = new PeopleViewModel();
            vm.SetService(mockService);

            await vm.GetData();

            Assert.AreEqual("https://swapi.co/api/people/?format=json&page=2", vm.nextPage);
        }
    }
}
