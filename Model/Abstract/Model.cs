using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Model
{
    public class Model: IModel, INotifyPropertyChanged
    {
        public Model()
        {
            Id = Guid.NewGuid();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}