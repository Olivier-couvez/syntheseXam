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
    public partial class AjoutTache : ContentPage
    {
        Tache maTache;

        public AjoutTache()
        {
            InitializeComponent();
        }

        private void btnRetour_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void btnValider_Clicked(object sender, EventArgs e)
        {
            maTache = new Tache();
            maTache.Date = dtpDate.Date;
            maTache.Title = entTitre.Text;
            maTache.Description = edtDescription.Text;
            maTache.Etat = true;
            new TacheDal().Sauvegarder(maTache);
            Navigation.PopModalAsync();
        }
    }
}