using Article.Common;
using Article.Navigation;
using Article.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.ViewModels
{
    public class MainPageViewModel
    {
        private DelegateCommand<int> _navigateCommand = default(DelegateCommand<int>);
        public DelegateCommand<int> NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand<int>(Navigate));

        public MainPageViewModel()
        {

        }

        private void Navigate(int pageType)
        {
            switch ((PageType)pageType)
            {
                case PageType.AttachedProperties:
                    NavigationService.Instance.Navigate(typeof(AttachedPropertiesPage));
                    break;
                case PageType.Behaviors:
                    NavigationService.Instance.Navigate(typeof(BehaviorsPage));
                    break;
                case PageType.EditingTemplates:
                    NavigationService.Instance.Navigate(typeof(EditingTemplatesPage));
                    break;
            }
        }
    }
}
