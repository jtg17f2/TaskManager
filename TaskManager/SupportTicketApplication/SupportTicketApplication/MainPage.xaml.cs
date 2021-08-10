using SupportTicketApplication.Dialogs;
using SupportTicketApplication.Models;
using SupportTicketApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SupportTicketApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public class TextboxText
    {
        public string textdata { get; set; }

    }

    

   

    public sealed partial class MainPage : Page
    {
        int count = 0;
        public MainPage()
        {
            
            InitializeComponent();
            DataContext = new MainViewModel();
            
        }

        private async void AddNew_Click(object sender, RoutedEventArgs e)
        {
            var diag = new TicketDialog((DataContext as MainViewModel).SupportTickets);
            await diag.ShowAsync();
        }

        private async void AddNewAppointment_Click(object sender, RoutedEventArgs e)
        {
            var diag = new AppointmentDialog((DataContext as MainViewModel).SupportTickets);
            await diag.ShowAsync();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).Remove();
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {

            var diag = new TicketDialog((DataContext as MainViewModel).SupportTickets);
            await diag.ShowAsync();
            (DataContext as MainViewModel).find();
           // (DataContext as MainViewModel).Remove();

        }

        private async void ListIncomplete_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).AddToInc();
            // totalRecording.DataContext = new TextboxText() { textdata = index1 };

        }

        private async void ListAll_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).RemFromInc();
            // totalRecording.DataContext = new TextboxText() { textdata = index1 };

        }
        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            var diag = new Search((DataContext as MainViewModel).SupportTickets);
            await diag.ShowAsync();
            

        }
        private async void Prioritize_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).Priortize();
        }






    }
}
