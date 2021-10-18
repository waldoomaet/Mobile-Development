using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace App1.Models
{
    public abstract class NavigationParametersManager
    {
        public NavigationParametersManager() { }
        public NavigationParametersManager(INavigationParameters navegationParameters)
        {
            this.ToObject(navegationParameters);
        }

        private void ToObject(INavigationParameters navegationParameters)
        {
            foreach (var pair in navegationParameters)
            {
                PropertyInfo prop = this.GetType().GetProperty(pair.Key);
                prop.SetValue(this, pair.Value);
            }
        }
        public INavigationParameters ToNavigationParameters()
        {
            var navParameters = new NavigationParameters();
            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                navParameters.Add(prop.Name, prop.GetValue(this));
            }
            return navParameters;
        }
    }
}
