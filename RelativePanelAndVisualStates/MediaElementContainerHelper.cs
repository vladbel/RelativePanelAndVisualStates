using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RelativePanelAndVisualStates
{
    public static class MediaElementContainerHelper
    {
        public static DependencyProperty ContainerProperty = DependencyProperty.RegisterAttached(
            "Container", typeof(FrameworkElement), typeof(MediaElementContainerHelper), new PropertyMetadata(null, OnContainerChanged));

        public static FrameworkElement GetContainer(DependencyObject d)
        {
            return (FrameworkElement)d.GetValue(ContainerProperty);
        }

        public static void SetContainer(DependencyObject d, FrameworkElement value)
        {
            d.SetValue(ContainerProperty, value);
        }

        private static void OnContainerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = d as FrameworkElement;
            var oldSource = e.OldValue as FrameworkElement;
            var newSource = e.NewValue as FrameworkElement;

            if (target!= null && oldSource != null)
            {
                RemoveContainerBindings(target, oldSource);
            }

            if (target != null && newSource != null)
            {
                SetupContainerBindings(target, newSource);
            }
        }

        private static void SetupContainerBindings(FrameworkElement target, FrameworkElement newSource)
        {
            newSource.SizeChanged += (sender, e) => ResizeTargetElement(newSource, target);
            newSource.Unloaded += (sender, e) => RemoveContainerBindings(target, newSource);

            ResizeTargetElement(newSource, target);
        }

        private static void RemoveContainerBindings(FrameworkElement target, FrameworkElement oldSource)
        {
            oldSource.SizeChanged -= (sender, e) => ResizeTargetElement(oldSource, target);
            oldSource.Unloaded -= (sender, e) => RemoveContainerBindings(target, oldSource);
        }

        private static void ResizeTargetElement(FrameworkElement source, FrameworkElement target)
        {
            if ( source.ActualHeight / 1.3 > source.ActualWidth)
            {
                target.Width = source.ActualWidth;
                target.Height = source.ActualHeight;
            }
            else
            {
                target.Width = source.ActualHeight / 1.5;
                target.Height = source.ActualHeight;
            }

        }
    }
}
