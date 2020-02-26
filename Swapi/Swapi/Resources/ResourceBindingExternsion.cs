using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Swapi.Resources
{
    [ContentProperty("Text")]
    public class ResourceBindingExtension : IMarkupExtension
    {
        readonly CultureInfo ci;

        public ResourceBindingExtension()
        {
            ci = CultureInfo.InvariantCulture;
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";
            string ResourceId = "Swapi.Resources.AppResource";

            ResourceManager resmgr = new ResourceManager(ResourceId
                                , typeof(ResourceBindingExtension).GetTypeInfo().Assembly);

            var translation = resmgr.GetString(Text, ci);

            if (translation == null)
            {
                System.Diagnostics.Debug.WriteLine("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name);
            }
            return translation;
        }
    }
}
