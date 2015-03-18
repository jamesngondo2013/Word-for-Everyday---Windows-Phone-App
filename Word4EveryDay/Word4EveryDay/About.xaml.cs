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
    public partial class About : PhoneApplicationPage
    {
        public About()
        {
            InitializeComponent();
            aboutUs();
        }
        public void aboutUs()
        {
            textAbout.Text = "Are you searching for inspiring words to give expression to your thoughts? Why not let God's Word communicate the encouraging message for you? This App is a collection of bible based inspirational messages which will uplift your spirit with messages and quotes from the Bible. " + "Please, read your message today, be inspired and then  share it with friends or " +
            " relatives on Facebook, Twitter, Yahoo, Google Mail, Hotmail etc. by clicking on a relevant share button on your device. Remember, God has blessed us so that we become a blessing to somebody else today. Stay blessed.";
            tweet.Text = "NOTE: Twitter limits Tweet length to 140 characters. Facebook only takes 420 characters. Therefore, you'll have to trim the length of some of the Inpirational messages before you tweet or share on facebook.";
        }
    }

}