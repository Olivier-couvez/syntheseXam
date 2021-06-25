using ExerciceSynthese.Dal;
using ExerciceSynthese.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExerciceSynthese
{
	public partial class MainPage : ContentPage
	{
        List<Tache> mesTaches;
		public MainPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            dtpDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            mesTaches = new List<Tache>();
            mesTaches = new TacheDal().SelectAll();
            ListeDesTaches.ItemsSource = mesTaches;
        }

        private void btnProfil_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new GestProfil());
        }

        private void btnAjouttache_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AjoutTache());
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            Tache modTache = (Tache)((Switch)sender).BindingContext;
            if (modTache != null)
            {
                modTache.Etat = e.Value;
                new TacheDal().Sauvegarder(modTache);
            }
            
        }

        private void Taches_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushModalAsync(new AfficheDetailTache(e));
        }

        private void btnFin_clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
