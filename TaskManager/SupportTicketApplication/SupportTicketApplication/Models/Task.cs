using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition;
using Windows.UI.WebUI;
using Windows.UI.Xaml;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace SupportTicketApplication.Models
{
    public class Task : SupportTicket, INotifyPropertyChanged
    {
        //public static readonly DependencyProperty CompletedProperty = DependencyProperty.Register(
        //    "Completed",
        //    typeof(string),
        //    typeof(SupportTicket),
        //    new PropertyMetadata(null));

        //public static readonly DependencyProperty DeadlineProperty = DependencyProperty.Register(
        //    "Deadline",
        //    typeof(string),
        //    typeof(SupportTicket),
        //    new PropertyMetadata(null));

        private string deadline;
        public string Deadline
        {
            get
            {
                return deadline;
            }

            set
            {
                deadline = value;
                NotifyPropertyChanged();

            }
        }

       
        public override string ToString()
        {
            return $"Task: {Title} - {Description} - {Deadline} - {Completed} - {Priority}";
        }

        public Task()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
