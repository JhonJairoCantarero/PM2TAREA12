using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM2TAREA12
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        

        private async void btnsegunda_Clicked(object sender, EventArgs e)
        {
            var emple = new Models.Empleado
            {
                nombres = txtnombre.Text,
                apellidos = txtapellido.Text,
                edad = Convert.ToInt32(txtedad.Text),
                correo = txtcorreo.Text
            };

            var page = new Views.PageTwo();
            page.BindingContext = emple;

            await Navigation.PushAsync(page);
 
        }
    }
}
