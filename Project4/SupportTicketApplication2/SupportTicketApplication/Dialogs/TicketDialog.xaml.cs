using Newtonsoft.Json;
using SupportTicketApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SupportTicketApplication.Dialogs
{
    public sealed partial class TicketDialog : ContentDialog
    {
        private IList<SupportTicket> supportTickets;
        public TicketDialog(IList<SupportTicket> supportTickets)
        {
            InitializeComponent();
            DataContext = new SupportTicket();
            this.supportTickets = supportTickets;
        }

        public TicketDialog(IList<SupportTicket> supportTickets, SupportTicket selectedTicket)
        {
            InitializeComponent();
            DataContext = selectedTicket;
            this.supportTickets = supportTickets;
        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var thisTicket = DataContext as SupportTicket;
            thisTicket = JsonConvert.DeserializeObject<SupportTicket>(await new WebRequestHandler().Post("http://localhost/SupportTicketAPI/ticket/AddOrUpdate", thisTicket));

            var index = supportTickets.IndexOf(supportTickets.FirstOrDefault(t => t.Id.Equals(thisTicket.Id)));
            if (index < 0)
            {
                supportTickets.Add(thisTicket);
            }
            else
            {
                supportTickets.RemoveAt(index);
                supportTickets.Insert(index, thisTicket);
            }

        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
