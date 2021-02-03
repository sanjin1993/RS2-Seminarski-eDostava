using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Mobile_IB120117.ViewModel
{
    public class VrsteJela
    {
        public int VrsteJelaID { get; set; }
        public string Naziv { get; set; }
    }

    public class RootModel1 : INotifyPropertyChanged
    {

        List<VrsteJela> vrsteList;
        public List<VrsteJela> VrsteList
        {
            get { return vrsteList; }
            set
            {
                if (vrsteList != value)
                {
                    vrsteList = value;
                    OnPropertyChanged1();
                }
            }
        }

        VrsteJela selectedvrste;
        public VrsteJela SelectedVrste
        {
            get { return selectedvrste; }
            set
            {
                if (selectedvrste != value)
                {
                    selectedvrste = value;
                    OnPropertyChanged1();
                }
            }
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged1([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

      
    }
}
