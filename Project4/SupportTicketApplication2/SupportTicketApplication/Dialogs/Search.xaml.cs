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

    public sealed partial class Search : ContentDialog
    {
        SupportTicket hello;
        public Search(IList<SupportTicket> supportTickets)
        {
            InitializeComponent();
            DataContext = new SupportTicket();
            
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var thisSearch = DataContext as SupportTicket;
            //thisSearch.Title = Search1;

            //SupportTicket support = new SupportTicket();
            // support = (DataContext as SupportTicket);
            //if(support.Completed == "no")
            //{
            //    IncompletesupportTickets.Add(support);
            //}

        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
