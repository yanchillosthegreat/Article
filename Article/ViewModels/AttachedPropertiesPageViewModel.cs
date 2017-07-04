﻿using Article.Common;
using Article.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.ViewModels
{
    public class AttachedPropertiesPageViewModel
    {
        private DelegateCommand _navigateBackCommand = default(DelegateCommand);
        public DelegateCommand NavigateBackCommand => _navigateBackCommand ?? (_navigateBackCommand = new DelegateCommand(NavigateBack));

        public AttachedPropertiesPageViewModel()
        {

        }

        public void NavigateBack()
        {
            NavigationService.Instance.GoBack();
        }
    }
}
