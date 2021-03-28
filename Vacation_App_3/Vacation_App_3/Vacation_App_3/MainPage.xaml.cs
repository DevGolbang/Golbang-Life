using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using Vacation_App_3.Features;
namespace Vacation_App_3
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {   
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            
            base.OnAppearing();
            RESTAsync restAsyncReg = new RESTAsync();
            TODOlistView.ItemsSource = await App.DataBase.GetItemsAsync();
            CommonDataFormat commonDataFormat = await restAsyncReg.GetData();
            BindingContext = commonDataFormat;
        }
        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TODOAddPage { BindingContext = e.SelectedItem as TODODataFormat });
            }
        }
        
        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TODOAddPage { BindingContext = new TODODataFormat()});
        }
    }
}
