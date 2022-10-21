using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2TAREA12.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePrincipal : ContentPage
    {
        public PagePrincipal()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listemple.ItemsSource = await App.Dbemple.ListaEmpleadosAll();

        }
        private void listemple_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Hola como estas
        }

        private async void tlbadd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageEmple());
        }

        private void tlbmapa_Clicked(object sender, EventArgs e)
        {

        }

        async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as Models.Empleado;
            await Navigation.PushAsync(new PageEmple(emp));
        
        }

        async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as Models.Empleado;
            var result = await DisplayAlert("Borrar", $"Borrar {emp.nombres} de la base de datos", "SI", "NO");
            if (result)
            {
                await App.Dbemple.DeleteEmple(emp);
                listemple.ItemsSource = await App.Dbemple.ListaEmpleadosAll();
            }

        }
    }
}