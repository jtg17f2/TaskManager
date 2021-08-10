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
using Newtonsoft.Json;
using APISerializationExample;

namespace SupportTicketApplication.Models
{
    [JsonConverter(typeof(ProductJsonConverter))]
    public class SupportTicket : INotifyPropertyChanged
    {
        //public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        //    "Title",
        //    typeof(string),
        //    typeof(SupportTicket),
        //    new PropertyMetadata(null));

        //public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(
        //    "Description",
        //    typeof(string),
        //    typeof(SupportTicket),
        //    new PropertyMetadata(null));

        //public static readonly DependencyProperty PriorityProperty = DependencyProperty.Register(
        //   "Priority",
        //   typeof(string),
        //   typeof(SupportTicket),
        //   new PropertyMetadata(null));

        //public static readonly DependencyProperty SearchProperty = DependencyProperty.Register(
        //   "Search1",
        //   typeof(string),
        //   typeof(SupportTicket),
        //   new PropertyMetadata(null));

        //public static readonly DependencyProperty IndexProperty =
        //DependencyProperty.Register("Index", typeof(string), typeof(Window), new PropertyMetadata(null));
        private string title;
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
                NotifyPropertyChanged();
                
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
                NotifyPropertyChanged();
                
            }
        }

        private string completed;
        public string Completed
        {
            get
            {
                return completed;
            }

            set
            {
                completed = value;
                NotifyPropertyChanged();

            }
        }
       
        private string prior;
        public string Priority
        {
            get
            {
                return prior;
            }

            set
            {
                prior = value;
                NotifyPropertyChanged();
                
            }
        }

        private Guid id;
        public Guid Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                NotifyPropertyChanged();

            }
        }

        //public string Title { 
        //    get { return (string)GetValue(TitleProperty); }
        //    set { SetValue(TitleProperty, value); }
        //}

        //public string Search1
        //{
        //    get { return (string)GetValue(SearchProperty); }
        //    set { SetValue(SearchProperty, value); }
        //}
        //public string Description {
        //    get { return (string)GetValue(DescriptionProperty); }
        //    set { SetValue(DescriptionProperty, value); }
        //}

        //public string Priority
        //{
        //    get { return (string)GetValue(PriorityProperty); }
        //    set { SetValue(PriorityProperty, value); }
        //}

        public SupportTicket()
        {
           // Id = Guid.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
