using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Mobile_IB120117.ViewModel
{
    public class VelicinaJela
    {
        public int VelicinaJelaID { get; set; }
        public string Naziv { get; set; }
        public Nullable<decimal> Cijena { get; set; }
        public int JeloID { get; set; }
    }

    public class RootModel2 : INotifyPropertyChanged
    {

        List<VelicinaJela> velicinaList;
        public List<VelicinaJela> VelicinaList
        {
            get { return velicinaList; }
            set
            {
                if (velicinaList != value)
                {
                    velicinaList = value;
                    OnPropertyChanged2();
                }
            }
        }

        VelicinaJela selectedvelicina;
        public VelicinaJela SelectedVelicina
        {
            get { return selectedvelicina; }
            set
            {
                if (selectedvelicina != value)
                {
                    selectedvelicina = value;
                    OnPropertyChanged2();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged2([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
