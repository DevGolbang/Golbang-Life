using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Vacation_App_3.Features;

namespace Vacation_App_3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TODOAddPage : ContentPage
    {
        public TODOAddPage()
        {
            InitializeComponent();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var item = (TODODataFormat)BindingContext;
            await App.DataBase.SaveItemAsync(item);
            await Navigation.PopAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var item = (TODODataFormat)BindingContext;
            await App.DataBase.DeleteItemAsync(item);
            await Navigation.PopAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}