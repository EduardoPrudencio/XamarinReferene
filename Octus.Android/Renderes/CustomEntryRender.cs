using System;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Views;
using Android.Graphics;
using Octus.Controls;
using Octus.Droid.Renderes;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRender))]
namespace Octus.Droid.Renderes
{
    public class CustomEntryRender : EntryRenderer
    {
        public CustomEntryRender(Context context):base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                if ((int)Android.OS.Build.VERSION.SdkInt < 21)
                {
                    SetLayerType(LayerType.Software, null);
                }
            }

            AjustRenderization();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            AjustRenderization();
        }


        private void AjustRenderization()
        {
            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}
