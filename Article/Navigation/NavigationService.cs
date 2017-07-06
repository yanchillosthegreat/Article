using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Article.Navigation
{
    public interface INavigationService
    {
        void Navigate(Type sourcePageType);
        void Navigate(Type sourcePageType, object parameter);
        void GoBack();
    }

    public enum PageType
    {
        AttachedProperties = 1,
        Behaviors = 2,
        EditingTemplates = 3
    }

    public class NavigationService : INavigationService
    {
        private static NavigationService instance;
        public static NavigationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NavigationService();
                }
                return instance;
            }
        }

        public void Navigate(Type sourcePageType)
        {
            ((Frame)Window.Current.Content).Navigate(sourcePageType);
        }

        public void Navigate(Type sourcePageType, object parameter)
        {
            ((Frame)Window.Current.Content).Navigate(sourcePageType, parameter);
        }

        public void GoBack()
        {
            ((Frame)Window.Current.Content).GoBack();
        }
    }
}
