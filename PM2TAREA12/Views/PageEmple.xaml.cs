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
    public partial class PageEmple : ContentPage
    {
        public PageEmple()
        {
            InitializeComponent();
        }
        Models.Empleado _employee;
        public PageEmple(Models.Empleado employee)
        {
            InitializeComponent();
            Title = "Editar Informacion";
            _employee = employee;
            txtnombre.Text = employee.nombres;
            txtapellido.Text = employee.apellidos;
            txtedad.Text = Convert.ToString(employee.edad);
            txtcorreo.Text = employee.correo;
            txtdireccion.Text = employee.direccion;
            txtnombre.Focus();
        }
        private async void btnguardar(object sender, EventArgs e)
        {
            //string.IsNullOrWhiteSpace(edad.Text)
            if (string.IsNullOrWhiteSpace(txtnombre.Text) || string.IsNullOrWhiteSpace(txtapellido.Text)  || string.IsNullOrWhiteSpace(txtedad.Text) || string.IsNullOrWhiteSpace(txtcorreo.Text) || string.IsNullOrWhiteSpace(txtdireccion.Text))
            {
                await DisplayAlert("Invalido", "Campos Vacios", "OK");
            }
            else if (_employee != null)
            {
                UpdateEmployee();
            }
            else
                AddnewEmpleado();


        }


        async void AddnewEmpleado()
        {
            var emple = new Models.Empleado
            {
                nombres = txtnombre.Text,
                apellidos = txtapellido.Text,
                edad = Convert.ToInt32(txtedad.Text),
                correo = txtcorreo.Text,
                direccion = txtdireccion.Text
            };


            if (await App.Dbemple.StoreEmple(emple) > 0)
            {
                await DisplayAlert("Aviso", "Empleado Agregado", "OK");
            }

            await Navigation.PopAsync();
        }

        async void UpdateEmployee()
        {
            _employee.nombres = txtnombre.Text; ;
            _employee.apellidos = txtapellido.Text;
            _employee.edad = Convert.ToInt32(txtedad.Text);
            _employee.correo = txtcorreo.Text;
            _employee.direccion = txtdireccion.Text;
            await App.Dbemple.StoreEmple(_employee);
            await Navigation.PopAsync();
        }

    }
}