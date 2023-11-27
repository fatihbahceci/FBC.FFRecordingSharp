using FBC.FFRecordingSharp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBC.FFRecordingSharp.Controls
{
    public partial class CreditsControl : UserControl
    {
        public CreditsControl()
        {
            InitializeComponent();
        }

        private void linkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sender is LinkLabel link)
            {
                //Open the link in the default browser
               FBCHelper.OpenUrlInDefaultBrowser(link.Text);
            }
        }
    }
}
