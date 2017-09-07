using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockPredict
{
    public partial class frmBrowser : Form
    {
        public string url;
        public frmBrowser()
        {
            InitializeComponent();
        }

        private void frmBrowser_Load(object sender, EventArgs e)
        {
            wbBrowser.Url = new Uri(url);
        }
    }
}
