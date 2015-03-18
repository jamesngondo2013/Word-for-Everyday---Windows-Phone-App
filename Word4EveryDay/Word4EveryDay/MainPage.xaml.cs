using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Word4EveryDay
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void about_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void message_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Message.xaml", UriKind.Relative));
        }

        private void reminder_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Reminder.xaml", UriKind.Relative));
        }
    }
}