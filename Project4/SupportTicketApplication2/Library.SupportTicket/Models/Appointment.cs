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
    public class Appointment : SupportTicket, INotifyPropertyChanged
    {

        //public static readonly DependencyProperty StartTimeProperty = DependencyProperty.Register(
        //   "StartTime",
        //   typeof(string),
        //   typeof(SupportTicket),
        //   new PropertyMetadata(null));

        //public static readonly DependencyProperty StopTimeProperty = DependencyProperty.Register(
        //   "StopTime",
        //   typeof(string),
        //   typeof(SupportTicket),
        //   new PropertyMetadata(null));

        //public static readonly DependencyProperty ListProperty = DependencyProperty.Register(
        //   "Lit",
        //   typeof(string),
        //   typeof(SupportTicket),
        //   new PropertyMetadata(null));


        private string starttime;
        public string StartTime
        {
            get
            {
                return starttime;
            }

            set
            {
                starttime = value;
                NotifyPropertyChanged();
                
            }
        }

        private string stoptime;
        public string StopTime
        {
            get
            {
                return stoptime;
            }

            set
            {
                stoptime = value;
                NotifyPropertyChanged();
                
            }
        }
        private string list;
        public string Lit
        {
            get
            {
                return list;
            }

            set
            {
                list = value;
                NotifyPropertyChanged();
                
            }
        }
        public override string ToString()
        
        {
           
                return $"Appointment: {Title} - {Description} - {StartTime} - {StopTime} - {Priority} - {Lit}";
           
        }

        public Appointment()
        {
            Id = Guid.Empty;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
