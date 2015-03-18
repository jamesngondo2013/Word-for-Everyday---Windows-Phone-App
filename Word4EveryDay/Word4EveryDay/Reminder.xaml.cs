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
using Microsoft.Phone.Scheduler;


namespace Word4EveryDay
{
    public partial class Reminder : PhoneApplicationPage
    {
        public Reminder()
        {
            InitializeComponent();
            remList();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            this.RefreshAlarmList();
        }
        private void RefreshAlarmList()
        {
            IEnumerable<Alarm> alarms = ScheduledActionService.GetActions<Alarm>();
            this.lbAlarms.ItemsSource = alarms;
        }
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {// save
            
                string alarmName = Guid.NewGuid().ToString();
                // use guid for alarm name, since alarm names must be unique
                Alarm alarm = new Alarm(alarmName);
                // NOTE: setting the Title property is not supported for alarms
                //alarm.Title = this.txtTitle.Text;

                alarm.Content = this.txtContent.Text;
                alarm.Sound = new Uri("/Tones/crash.wav", UriKind.Relative);
                double hours = 0.0;
                double minutes = 0.0;
                double totalMinutes = 0.0;
                double.TryParse(this.textHours.Text, out hours);
                double.TryParse(this.textMin.Text, out minutes);

                totalMinutes = (hours * 60) + minutes;

                //NOTE: the value of BeginTime must be after the current time
                //set the BeginTime time property in order to specify when the alarm should be shown
                // alarm.BeginTime = DateTime.Now.AddSeconds(seconds);

                // NOTE: ExpirationTime must be after BeginTime
                // the value of the ExpirationTime property specifies when the schedule of the alarm expires
                // very useful for recurring alarms, ex:
                // show alarm every day at 5PM but stop after 10 days from now

                alarm.BeginTime = DateTime.Now.AddMinutes(totalMinutes);
                alarm.ExpirationTime = DateTime.Now.AddDays(365);
                alarm.RecurrenceType = RecurrenceInterval.Daily;
                ScheduledActionService.Add(alarm);


                this.NavigationService.GoBack();
           
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {//back
            // NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            //this.NavigationService.GoBack();
        }

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {// cancel reminder
            //this.NavigationService.GoBack();
            Alarm selectedAlarm = this.lbAlarms.SelectedItem as Alarm;
            if (selectedAlarm != null)
            {
                ScheduledActionService.Remove(selectedAlarm.Name);
                this.RefreshAlarmList();
            }
        }
        private void remList()
        {
            reminderList.Text = "BELOW IS THE LIST OF YOUR SCHEDULED REMINDERS. TO REMOVE, CLICK ON THE DESIRED REMINDER & THEN (X) BUTTON";
        }

        private void textMin_Tap(object sender, GestureEventArgs e)
        {
            textMin.Text = "";
        }

        private void textHours_Tap(object sender, GestureEventArgs e)
        {
            textHours.Text = "";
        }
        


    }
}