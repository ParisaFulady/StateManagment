using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AStateManagment.Entities
{
    public class Car:INotifyPropertyChanged,INotifyPropertyChanging
    {
        private int _carID;
        public int CarID {
            get
            {
                return _carID;
            }
            set
            {
                if (_carID != value)
                {
                    //PropertyChanging

                    PropertyChanged.Invoke(this,new PropertyChangedEventArgs("CarID"));
                }
               
            }
        }
      
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
    }
}
