using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Article.Controls.Behaviors
{
    public class FlipViewItemFadeInBehavior : Behavior<FlipView>
    {
        public double Duration { get; set; }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += FlipView_SelectionChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectionChanged -= FlipView_SelectionChanged;
        }

        private void FlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var flipView = sender as FlipView;
            var selectedItem = flipView.SelectedItem as UIElement;

            Storyboard sb = new Storyboard();
            DoubleAnimation da = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(Duration)),
                From = 0d,
                To = 1d
            };

            Storyboard.SetTargetProperty(da, "(UIElement.Opacity)");
            Storyboard.SetTarget(da, selectedItem);
            sb.Children.Add(da);
            sb.Begin();
        }
    }
}
