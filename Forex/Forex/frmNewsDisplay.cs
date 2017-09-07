using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Forex
{
    public partial class frmNewsDisplay : Form
    {
        public string url;
        public frmNewsDisplay()
        {
            InitializeComponent();
        }

        private void mnuStore_Click(object sender, EventArgs e)
        {
            frmNews frm = new frmNews();
            frm.url = webNews.Url.ToString();
            frm.Store();
            frm.Show();
            
        }

        private void frmNewsDisplay_Load(object sender, EventArgs e)
        {
            
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                url = txtUrl.Text;
                if (url.IndexOf("http://") == -1)
                    url = "http://" + url;
                webNews.Navigate(url);
            }
        }

        private void webNews_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            txtUrl.Text = webNews.Url.ToString();
        }

        public void Display()
        {
            txtUrl.Text = url;
            if (url.IndexOf("http://") == -1)
                url = "http://" + url;
            webNews.Navigate(url);
        }
    }
}
