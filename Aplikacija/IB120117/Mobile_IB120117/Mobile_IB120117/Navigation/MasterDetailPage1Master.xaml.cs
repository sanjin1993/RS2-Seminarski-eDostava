using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_IB120117.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage1Master : ContentPage
    {
        public ListView ListView;

        public MasterDetailPage1Master()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPage1MasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPage1MasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPage1MenuItem> MenuItems { get; set; }

            public MasterDetailPage1MasterViewModel()
            {
                if (Global.prijavljeniKlijent != null)
                {

                    MenuItems = new ObservableCollection<MasterDetailPage1MenuItem>(new[]
                    {
                     new MasterDetailPage1MenuItem {  Title = "Pregled restorana",ImageSource="resume.png",TargetType=typeof(Restorani.PregledRestorana) },
                 
                    new MasterDetailPage1MenuItem {  Title = "Aktivne narudžbe",ImageSource="resume.png",TargetType=typeof(Narudzbe.TrenutneNarudzbe) },
                    new MasterDetailPage1MenuItem {  Title = "Historija narudžbi",ImageSource="resume.png",TargetType=typeof(Narudzbe.HistorijaNarudzbi) },
                    new MasterDetailPage1MenuItem { Title = "Uredi podatke", ImageSource="resume.png",TargetType=typeof(UserProfil)},
                });
                }
                else
                {
                    MenuItems = new ObservableCollection<MasterDetailPage1MenuItem>(new[]
                 {
                    new MasterDetailPage1MenuItem { Title = "Prijavi se", ImageSource = "log-in (2).png", TargetType = typeof(Login) } ,
                    new MasterDetailPage1MenuItem { Title = "Registruj se", ImageSource = "user.png", TargetType = typeof(Registration) }
                    });
                }
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}