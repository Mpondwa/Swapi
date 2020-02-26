using Swapi.Resources;
using Swapi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swapi.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        public BaseViewModel()
        {

        }

        private static ISwapiService _apiService;

        public ISwapiService Service
        {
            get
            {
                if (_apiService == null)
                {
                    _apiService = new SwapiService(AppResource.apiUrl);
                }
                return _apiService;
            }
        }

        public void SetService(ISwapiService service)
        {
            _apiService = service;
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private string _loadingText;

        public string LoadingText
        {
            get { return _loadingText; }
            set { SetProperty(ref _loadingText, value); }
        }
    }
}
