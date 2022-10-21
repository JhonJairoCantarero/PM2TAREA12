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
    public partial class PageTwo : ContentPage
    {
        public PageTwo()
        {
            InitializeComponent();
            //HOLA

        }

        public PageTwo(String pmessage)
        {
            InitializeComponent();
            lbcorreo.Text = pmessage;
        }
    }
}