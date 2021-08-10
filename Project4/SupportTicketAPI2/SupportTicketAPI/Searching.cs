using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Windows.UI.Composition;
//using Windows.UI.WebUI;
//using Windows.UI.Xaml;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SupportTicketApplication.Models
{
    public class Searching : INotifyPropertyChanged
    {
        private string search1;
        public string Search1
        {
            get
            {
                return search1;
            }

            set
            {
                search1 = value;
                NotifyPropertyChanged();

            }
        }
        public Searching()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
