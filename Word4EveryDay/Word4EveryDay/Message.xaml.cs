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
using System.Xml.Linq;
using Microsoft.Phone.Tasks;
using System.Windows.Navigation;

namespace Word4EveryDay
{
    public partial class Message : PhoneApplicationPage
    {
        public Message()
        {
            InitializeComponent();


            var msgReply = MessageBox.Show("Welcome to Word for Everyday. If you are reading this today, I assume you are in need of inspiration or are looking for some inspiring scriptures to send to someone in need. I pray that you find what you are looking for.", "Word For Everyday", MessageBoxButton.OK);
           
            Random rand = new Random();
            int random = rand.Next(1, 9);
            XDocument LoadData = XDocument.Load("Message3.xml"); //xml file name
            var SearchData = from c in LoadData.Descendants("Messg")//xml tags
                             where c.Attribute("TheDay").Value == random.ToString()
                             select new InspirationalMsg()
                             {
                                 
                                 InspMessage = c.Attribute("TheInspMessage").Value,

                             };

            displayMsg.ItemsSource = SearchData;
            displayMsg.Visibility = Visibility.Visible;
        }
        
        public class InspirationalMsg
        {
            string day;
            string msg;
            int id;

            public string Day
            {
                get { return day; }
                set { day = value; }
            }

            public string InspMessage
            {
                get { return msg; }
                set { msg = value; }
            }

            public int Id
            {
                get { return id; }
                set { id = value; }
            }

        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {//facebook
            string myMessage = "";
            if (displayMsg.Items.Count > 0)
            {
                var value = (InspirationalMsg)displayMsg.Items.ElementAt(0);
                myMessage = value.InspMessage;
            }
            ShareLinkTask shareLinkTask = new ShareLinkTask();
            //shareLinkTask.LinkUri = new Uri("http://www.facebook.com", UriKind.Absolute);
            shareLinkTask.LinkUri = new Uri("http://www.facebook.com/sharer.php?u=[url to share]&t=[title of content]", UriKind.Absolute);
            shareLinkTask.Message = myMessage;
            shareLinkTask.Show();

        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {// email
            string myMessage = "";
            if (displayMsg.Items.Count > 0)
            {
                var value = (InspirationalMsg)displayMsg.Items.ElementAt(0);
                myMessage = value.InspMessage;
            }
            EmailComposeTask task = new EmailComposeTask();
            task.Subject = "Your Word Of Inspiration for Today";
            task.Body = myMessage;
            task.Show();

        }
        //protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        //{
        //    base.OnNavigatedTo(e);

        //}
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }
       
    }
}