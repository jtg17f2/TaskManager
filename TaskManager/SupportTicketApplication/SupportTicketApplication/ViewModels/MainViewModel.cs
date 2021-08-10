using SupportTicketApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SupportTicketApplication.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {   
        public SupportTicket SelectedTicket { get; set; }
        public SupportTicket SearchResult { get; set; }
        public int index { get; set; }

        public Searching value { get; set; }
        public ObservableCollection<SupportTicket> SupportTickets { get; set; }
        public ObservableCollection<SupportTicket> IncompleteSupportTickets { get; set; }
        public ObservableCollection<SupportTicket> temp { get; set; }
        public ObservableCollection<SupportTicket> prior { get; set; }
        public MainViewModel()
        {
            SupportTickets = new ObservableCollection<SupportTicket>();
            IncompleteSupportTickets = new ObservableCollection<SupportTicket>();
            temp = new ObservableCollection<SupportTicket>();
           prior = new ObservableCollection<SupportTicket>();
            value = new Searching();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Remove()
        {

            SupportTickets.Remove(SelectedTicket);
        }

        public void find()
        {
            int num = SupportTickets.IndexOf(SelectedTicket);
            SupportTickets[num] = SupportTickets[SupportTickets.Count() - 1];
            SupportTickets.RemoveAt(SupportTickets.Count() - 1);

        }

        public void AddToInc()
        {


            for (int i = 0; i < SupportTickets.Count(); i++)
            {
    
                if (SupportTickets[i].Completed == "no" && IncompleteSupportTickets.Contains(SupportTickets[i]) == false)
                    IncompleteSupportTickets.Add(SupportTickets[i]);
            }
           // temp.Clear();
        }

        public void RemFromInc()
        {
            IncompleteSupportTickets.Clear();
           // temp = SupportTickets;
        }

        public SupportTicket SearchTicket()
        {
            string upper = value.Search1;
            upper = value.Search1.ToUpper();
            string uppername, upperdescription, upperattendee;
            for (int i = 0; i < SupportTickets.Count(); i++)
            {
                uppername = SupportTickets[i].Title.ToUpper();
                upperdescription = SupportTickets[i].Description.ToUpper();
                var task = SupportTickets[i];
                if (uppername.Contains(upper))
                {
                    SearchResult = SupportTickets[i];
                    return SearchResult;
                }
            }
            return SearchResult;
        }
        public ObservableCollection<SupportTicket> Priortize()
        {
            prior.Clear();
            for (int i = 0; i < SupportTickets.Count(); i++)
            {
                if (SupportTickets[i].Priority == "High")
                    prior.Add(SupportTickets[i]);
            }
            for (int i = 0; i < SupportTickets.Count(); i++)
            {
                if (SupportTickets[i].Priority == "Med")
                    prior.Add(SupportTickets[i]);
            }
            for (int i = 0; i < SupportTickets.Count(); i++)
            {
                if (SupportTickets[i].Priority == "Low")
                    prior.Add(SupportTickets[i]);
            }
            for (int i = 0; i < SupportTickets.Count(); i++)
            {
                if (SupportTickets[i].Priority == "" || SupportTickets[i].Priority == null)
                    prior.Add(SupportTickets[i]);
            }

            return prior;
        }

       

    }
}
