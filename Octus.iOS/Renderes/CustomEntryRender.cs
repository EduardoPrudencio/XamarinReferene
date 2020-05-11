using System;
using System.ComponentModel;
using Octus.Controls;
using Octus.iOS.Renderes;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRender))]
namespace Octus.iOS.Renderes
{
    public class CustomEntryRender : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Element != null)
                AjustRenderization();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
                e.PropertyName == VisualElement.WidthProperty.PropertyName)
            {
                AjustRenderization();
            }
        }

        private void AjustRenderization()
        {
            Control.BorderStyle = UIKit.UITextBorderStyle.None;
        }
    }
}
