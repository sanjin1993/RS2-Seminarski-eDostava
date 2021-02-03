using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Mobile_IB120117.ViewModel
{
        public class Naselja
        {
            public string NaseljeID { get; set; }
            public string Naziv { get; set; }
        }

        public class RootModel : INotifyPropertyChanged
        {

            List<Naselja> naseljeList;
            public List<Naselja> NaseljeList
        {
                get { return naseljeList; }
                set
                {
                    if (naseljeList != value)
                    {
                    naseljeList = value;
                        OnPropertyChanged();
                    }
                }
            }

            Naselja selectedNaselje;
            public Naselja SelectedNaselje
        {
                get { return selectedNaselje; }
                set
                {
                    if (selectedNaselje != value)
                    {
                    selectedNaselje = value;
                        OnPropertyChanged();
                    }
                }
            }


            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }

          
        }
    
}
