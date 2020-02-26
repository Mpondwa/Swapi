using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Swapi.Common
{
    public class AlertHelper
    {
        public static void ShowMessage(string caption, string message, string cancelText)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.DisplayAlert(caption, message, cancelText);
            });
        }

    }
}
