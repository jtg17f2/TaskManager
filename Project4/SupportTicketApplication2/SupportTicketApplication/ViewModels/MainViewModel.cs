using Newtonsoft.Json;
using SupportTicketApplication.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.IO;

namespace SupportTicketApplication.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public SupportTicket SelectedTicket { get; set; }
        public SupportTicket SearchResult { get; set; }
        public int index { get; set; }
        public ObservableCollection<SupportTicket> SupportTickets { get; set; }
        public ObservableCollection<SupportTicket> IncompleteSupportTickets { get; set; }
        public ObservableCollection<SupportTicket> prior { get; set; }

        public MainViewModel()
        {
            SupportTickets = new ObservableCollection<SupportTicket>();
            IncompleteSupportTickets = new ObservableCollection<SupportTicket>();
            prior = new ObservableCollection<SupportTicket>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void Remove()
        {
            var handler = new WebRequestHandler();
            var itemToRemove = JsonConvert.DeserializeObject<SupportTicket>(await handler.Post("http://localhost/SupportTicketAPI/ticket/delete", SelectedTicket.Id));
            SupportTickets.Remove(SupportTickets.FirstOrDefault(t => t.Id.Equals(itemToRemove.Id)));
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

            return SearchResult;
        }
        public void Save_List()
        {
            using (TextWriter tw = new StreamWriter("SupportTicketFile.txt"))
            {
                foreach (SupportTicket p in SupportTickets)
                {
                    tw.WriteLine(p);
                }
                tw.Close();
            }
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
