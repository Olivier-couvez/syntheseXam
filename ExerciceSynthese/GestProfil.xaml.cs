using ExerciceSynthese.Dal;
using ExerciceSynthese.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExerciceSynthese
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GestProfil : ContentPage
    {
        Profil monProfil;
        public GestProfil()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            monProfil = new Profil();
            monProfil = new ProfilDal().Select(1);
            if (monProfil != null)
            {
                nom.Text = monProfil.Nom;
                prenom.Text = monProfil.Prenom;
                age.Text = Convert.ToString( monProfil.Age);
            }
        }

        private void btnRetour_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void btnValider_Clicked(object sender, EventArgs e)
        {
            monProfil = new Profil();
            monProfil.Nom = nom.Text;
            monProfil.Prenom = prenom.Text;
            monProfil.Age = Convert.ToInt16(age.Text);
            new ProfilDal().Sauvegarder(monProfil);
            Navigation.PopModalAsync();
        }
    }
}