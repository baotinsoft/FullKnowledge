using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Security.Policy;
using System.Security;
using System.Security.Permissions;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Diagnostics;
using System.Net;
using System.Text;
using Easychart.Finance;
using Easychart.Finance.DataProvider;
using Easychart.Finance.Win;
using Easychart.Finance.DataClient;
using StockPredict;

// This is a simple sample for windows form applications
namespace WindowsDemo
{
	/// <summary>
	/// Summary description for DemoForm.
	/// </summary>
	public class DemoForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MainMenu mmMain;
		private System.Windows.Forms.OpenFileDialog odLoadData;
		private System.Windows.Forms.MenuItem mmLoadDataForecast;
		private System.Windows.Forms.MenuItem miAbout;
		private System.Windows.Forms.MenuItem miExit;

		private System.Windows.Forms.MenuItem miHotKey;
		private System.Windows.Forms.MenuItem menuItem3;
		public static DemoForm MainForm;
		private System.Windows.Forms.MenuItem miHelp;
		private System.Windows.Forms.ColorDialog cdFormulaColor;
		private System.Windows.Forms.MenuItem miLoadBinary;
		private System.Windows.Forms.Panel pnBottom;
		private System.Windows.Forms.Panel pnClient;
		private System.Windows.Forms.MenuItem miLoadFromEasyChart;
		private Easychart.Finance.Win.ChartWinControl ChartControl;
		private Easychart.Finance.Win.SizeToolControl sizeToolControl;
		private System.Windows.Forms.MenuItem miPrint;
		private System.Windows.Forms.MenuItem miPreview;
		private System.Windows.Forms.MenuItem miSp2;
		private System.Windows.Forms.MenuItem miSetup;
		private System.Windows.Forms.MenuItem miSp1;
		private System.Windows.Forms.MenuItem miLoadFromProphet;
		private System.Windows.Forms.MenuItem miLoadXml;
		private System.Windows.Forms.MenuItem miMetaStock;
		private System.Windows.Forms.MenuItem miText;
		private System.Windows.Forms.MenuItem miLoadFromYahooStreaming;
		private System.Windows.Forms.MenuItem miForexText;
		private System.Windows.Forms.MenuItem miLoadBond;
		private DataClientBase DataClient;
		private DataClientBase dcbStream = null;
		private System.Windows.Forms.MenuItem mmData;
		private System.Windows.Forms.MenuItem mmLoadData;
        private MenuItem mmMining;
        private MenuItem miCreateDM;
		private DataClientBase dcbForex = null;

		public DemoForm()
		{
			//
			// Required for Windows Form Designer support
			//
			PluginManager.Load(Environment.CurrentDirectory+"\\Plugins\\");
			PluginManager.OnPluginChanged +=new FileSystemEventHandler(OnPluginChange);

			InitializeComponent();
			KeyMessageFilter.AddMessageFilter(ChartControl);
			DataClient =  new EasyChartDataClient(); //new YahooDataClient();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing)
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			MainForm = new DemoForm();
			//Application.ThreadException += new ThreadExceptionEventHandler(MainForm.OnThreadException);
			Application.Run(MainForm);
		}

		/// <summary>
		/// Handles the exception event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="t"></param>
		public void OnThreadException(object sender, ThreadExceptionEventArgs t) 
		{
			try
			{
				this.ShowThreadExceptionDialog(t.Exception);
			}
			catch
			{
				try
				{
					MessageBox.Show("Fatal Error", "Fatal Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
				}
				finally
				{
					Application.Exit();
				}
			}
		}
 
		/// <summary>
		/// Creates the error message and displays it.
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		private DialogResult ShowThreadExceptionDialog(Exception e) 
		{
			string errorMsg = "Messages:\n\n";
			errorMsg = errorMsg + e.Message;
			return MessageBox.Show(errorMsg, "Messages!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            Easychart.Finance.ExchangeIntraday exchangeIntraday1 = new Easychart.Finance.ExchangeIntraday();
            this.mmMain = new System.Windows.Forms.MainMenu(this.components);
            this.mmData = new System.Windows.Forms.MenuItem();
            this.mmLoadData = new System.Windows.Forms.MenuItem();
            this.mmLoadDataForecast = new System.Windows.Forms.MenuItem();
            this.miLoadFromEasyChart = new System.Windows.Forms.MenuItem();
            this.miLoadFromProphet = new System.Windows.Forms.MenuItem();
            this.miLoadBinary = new System.Windows.Forms.MenuItem();
            this.miLoadXml = new System.Windows.Forms.MenuItem();
            this.miText = new System.Windows.Forms.MenuItem();
            this.miMetaStock = new System.Windows.Forms.MenuItem();
            this.miLoadFromYahooStreaming = new System.Windows.Forms.MenuItem();
            this.miForexText = new System.Windows.Forms.MenuItem();
            this.miLoadBond = new System.Windows.Forms.MenuItem();
            this.miSp2 = new System.Windows.Forms.MenuItem();
            this.miSetup = new System.Windows.Forms.MenuItem();
            this.miPreview = new System.Windows.Forms.MenuItem();
            this.miPrint = new System.Windows.Forms.MenuItem();
            this.miSp1 = new System.Windows.Forms.MenuItem();
            this.miExit = new System.Windows.Forms.MenuItem();
            this.miHelp = new System.Windows.Forms.MenuItem();
            this.miHotKey = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.miAbout = new System.Windows.Forms.MenuItem();
            this.odLoadData = new System.Windows.Forms.OpenFileDialog();
            this.cdFormulaColor = new System.Windows.Forms.ColorDialog();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.sizeToolControl = new Easychart.Finance.Win.SizeToolControl();
            this.ChartControl = new Easychart.Finance.Win.ChartWinControl();
            this.pnClient = new System.Windows.Forms.Panel();
            this.mmMining = new System.Windows.Forms.MenuItem();
            this.miCreateDM = new System.Windows.Forms.MenuItem();
            this.pnBottom.SuspendLayout();
            this.pnClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // mmMain
            // 
            this.mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mmData,
            this.mmMining,
            this.miHelp});
            // 
            // mmData
            // 
            this.mmData.Index = 0;
            this.mmData.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mmLoadData,
            this.mmLoadDataForecast,
            this.miLoadFromEasyChart,
            this.miLoadFromProphet,
            this.miLoadBinary,
            this.miLoadXml,
            this.miText,
            this.miMetaStock,
            this.miLoadFromYahooStreaming,
            this.miForexText,
            this.miLoadBond,
            this.miSp2,
            this.miSetup,
            this.miPreview,
            this.miPrint,
            this.miSp1,
            this.miExit});
            this.mmData.Text = "&Dữ Liệu";
            // 
            // mmLoadData
            // 
            this.mmLoadData.Index = 0;
            this.mmLoadData.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.mmLoadData.Text = "&Vẽ Dữ Liệu Nguồn";
            this.mmLoadData.Click += new System.EventHandler(this.mmLoadData_Click);
            // 
            // mmLoadDataForecast
            // 
            this.mmLoadDataForecast.Index = 1;
            this.mmLoadDataForecast.Text = "Vẽ Dữ Liệu Nguồn và Dự Báo";
            this.mmLoadDataForecast.Click += new System.EventHandler(this.mmLoadDataForecast_Click);
            // 
            // miLoadFromEasyChart
            // 
            this.miLoadFromEasyChart.Index = 2;
            this.miLoadFromEasyChart.Text = "";
            // 
            // miLoadFromProphet
            // 
            this.miLoadFromProphet.Index = 3;
            this.miLoadFromProphet.Text = "";
            // 
            // miLoadBinary
            // 
            this.miLoadBinary.Index = 4;
            this.miLoadBinary.Text = "";
            // 
            // miLoadXml
            // 
            this.miLoadXml.Index = 5;
            this.miLoadXml.Text = "";
            // 
            // miText
            // 
            this.miText.Index = 6;
            this.miText.Text = "";
            // 
            // miMetaStock
            // 
            this.miMetaStock.Index = 7;
            this.miMetaStock.Text = "";
            // 
            // miLoadFromYahooStreaming
            // 
            this.miLoadFromYahooStreaming.Index = 8;
            this.miLoadFromYahooStreaming.Text = "";
            // 
            // miForexText
            // 
            this.miForexText.Index = 9;
            this.miForexText.Text = "";
            // 
            // miLoadBond
            // 
            this.miLoadBond.Index = 10;
            this.miLoadBond.Text = "";
            // 
            // miSp2
            // 
            this.miSp2.Index = 11;
            this.miSp2.Text = "-";
            // 
            // miSetup
            // 
            this.miSetup.Index = 12;
            this.miSetup.Text = "";
            // 
            // miPreview
            // 
            this.miPreview.Index = 13;
            this.miPreview.Text = "";
            // 
            // miPrint
            // 
            this.miPrint.Index = 14;
            this.miPrint.Text = "";
            // 
            // miSp1
            // 
            this.miSp1.Index = 15;
            this.miSp1.Text = "-";
            // 
            // miExit
            // 
            this.miExit.Index = 16;
            this.miExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.miExit.Text = "Exit";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // miHelp
            // 
            this.miHelp.Index = 2;
            this.miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miHotKey,
            this.menuItem3,
            this.miAbout});
            this.miHelp.Text = "&Trợ Giúp";
            // 
            // miHotKey
            // 
            this.miHotKey.Index = 0;
            this.miHotKey.Text = "Hot Keys";
            this.miHotKey.Click += new System.EventHandler(this.miHotKey_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "-";
            // 
            // miAbout
            // 
            this.miAbout.Index = 2;
            this.miAbout.Text = "";
            // 
            // odLoadData
            // 
            this.odLoadData.DefaultExt = "csv";
            this.odLoadData.Filter = "csv files (*.csv)|*.csv|data files (*.dat)|*.dat|All files (*.*)|*.*";
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.sizeToolControl);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 489);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(776, 24);
            this.pnBottom.TabIndex = 3;
            // 
            // sizeToolControl
            // 
            this.sizeToolControl.ChartControl = this.ChartControl;
            this.sizeToolControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sizeToolControl.Location = new System.Drawing.Point(0, 0);
            this.sizeToolControl.Name = "sizeToolControl";
            this.sizeToolControl.Size = new System.Drawing.Size(776, 24);
            this.sizeToolControl.TabIndex = 0;
            // 
            // ChartControl
            // 
            this.ChartControl.AdjustData = ((bool)(configurationAppSettings.GetValue("ChartControl.AdjustData", typeof(bool))));
            this.ChartControl.AreaPercent = ((string)(configurationAppSettings.GetValue("ChartControl.AreaPercent", typeof(string))));
            this.ChartControl.BackColor = System.Drawing.SystemColors.Control;
            this.ChartControl.CausesValidation = false;
            this.ChartControl.ChartDragMode = Easychart.Finance.ChartDragMode.Chart;
            this.ChartControl.ColumnWidth = 5;
            this.ChartControl.DefaultFormulas = ((string)(configurationAppSettings.GetValue("ChartControl.DefaultFormulas", typeof(string))));
            this.ChartControl.Designing = false;
            this.ChartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartControl.EndTime = new System.DateTime(((long)(0)));
            this.ChartControl.FavoriteFormulas = ((string)(configurationAppSettings.GetValue("ChartControl.FavoriteFormulas", typeof(string))));
            this.ChartControl.ForeColor = System.Drawing.Color.Coral;
            exchangeIntraday1.TimePeriods = new Easychart.Finance.TimePeriod[0];
            exchangeIntraday1.TimeZone = -4;
            this.ChartControl.IntradayInfo = exchangeIntraday1;
            this.ChartControl.Location = new System.Drawing.Point(0, 0);
            this.ChartControl.MaxPrice = 0;
            this.ChartControl.MinColumnWidth = 1;
            this.ChartControl.MinPrice = 0;
            this.ChartControl.Name = "ChartControl";
            this.ChartControl.PriceLabelFormat = "{CODE} O:{OPEN} H:{HIGH} L:{LOW} C:{CLOSE} Chg:{CHANGE}";
            this.ChartControl.ResetYAfterXChanged = false;
            this.ChartControl.ShowCrossCursor = ((bool)(configurationAppSettings.GetValue("ChartControl.ShowCrossCursor", typeof(bool))));
            this.ChartControl.ShowCursorLabel = ((bool)(configurationAppSettings.GetValue("ChartControl.ShowCursorLabel", typeof(bool))));
            this.ChartControl.ShowIndicatorValues = ((bool)(configurationAppSettings.GetValue("ChartControl.ShowIndicatorValues", typeof(bool))));
            this.ChartControl.ShowOverlayValues = ((bool)(configurationAppSettings.GetValue("ChartControl.ShowOverlayValues", typeof(bool))));
            this.ChartControl.ShowStatistic = ((bool)(configurationAppSettings.GetValue("ChartControl.ShowStatistic", typeof(bool))));
            this.ChartControl.Size = new System.Drawing.Size(776, 489);
            this.ChartControl.Skin = ((string)(configurationAppSettings.GetValue("ChartControl.Skin", typeof(string))));
            this.ChartControl.StartTime = new System.DateTime(((long)(0)));
            this.ChartControl.StickRenderType = Easychart.Finance.StickRenderType.Column;
            this.ChartControl.TabIndex = 0;
            this.ChartControl.NativePaint += new Easychart.Finance.NativePaintHandler(this.ChartControl_NativePaint);
            this.ChartControl.BeforeApplySkin += new Easychart.Finance.Win.ApplySkinHandler(this.ChartControl_BeforeApplySkin);
            this.ChartControl.AfterApplySkin += new System.EventHandler(this.ChartControl_AfterApplySkin);
            this.ChartControl.DataChanged += new System.EventHandler(this.ChartControl_DataChanged);
            // 
            // pnClient
            // 
            this.pnClient.Controls.Add(this.ChartControl);
            this.pnClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnClient.Location = new System.Drawing.Point(0, 0);
            this.pnClient.Name = "pnClient";
            this.pnClient.Size = new System.Drawing.Size(776, 489);
            this.pnClient.TabIndex = 4;
            // 
            // mmMining
            // 
            this.mmMining.Index = 1;
            this.mmMining.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miCreateDM});
            this.mmMining.Text = "Dự &Báo";
            // 
            // miCreateDM
            // 
            this.miCreateDM.Index = 0;
            this.miCreateDM.Text = "Tạo mô hình cho Stock mới";
            this.miCreateDM.Click += new System.EventHandler(this.miCreateDM_Click);
            // 
            // DemoForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(776, 513);
            this.Controls.Add(this.pnClient);
            this.Controls.Add(this.pnBottom);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.Menu = this.mmMain;
            this.Name = "DemoForm";
            this.Text = "DemoForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closed += new System.EventHandler(this.DemoForm_Closed);
            this.Load += new System.EventHandler(this.DemoForm_Load);
            this.pnBottom.ResumeLayout(false);
            this.pnClient.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void OnPluginChange(object source, FileSystemEventArgs e)
		{
			ChartControl.NeedRefresh();
		}

		private void DemoForm_Load(object sender, System.EventArgs e)
		{
			mmMain.MenuItems.Clear();
			mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																			  this.mmData,
																			  ChartControl.GetEditMenu(),
																			  ChartControl.GetViewMenu(),
																			  ChartControl.GetChartMenu(),
                                                                              this.mmMining,
																			  this.miHelp,
			});


			LoadCSVFile(Environment.CurrentDirectory+"\\CCI.CSV");
			ChartControl.ContextMenu = null;
			ChartControl.Focus();
		}

		/// <summary>
		/// Load CSV data from file
		/// </summary>
		/// <param name="FileName"></param>
		private void LoadCSVFile(string FileName)
		{
			DataManagerBase dmb = new YahooCSVDataManager(Path.GetDirectoryName(FileName),Path.GetExtension(FileName));
			ChartControl.DataManager = dmb;
			ChartControl.Symbol = Path.GetFileNameWithoutExtension(FileName);
			ChartControl.EndTime = DateTime.MinValue;
		}

        /// <summary>
        /// Load More CSV data from file
        /// </summary>
        /// <param name="FileName"></param>
        private void LoadMoreCSVFile(string FileName)
        {
            DataManagerBase dmb = new YahooCSVDataManager(Path.GetDirectoryName(FileName), Path.GetExtension(FileName));
            ChartControl.DataManager = dmb;
            ChartControl.Symbol = Path.GetFileNameWithoutExtension(FileName);
            //string s = ChartControl.DefaultFormulas;
            //ChartControl.DefaultFormulas= "Main;Compare(INTL);Compare(MSFT)";RawData(CLOSE)
            ChartControl.DefaultFormulas = "Main;Compare(CCI)#Compare(CCI_FORECAST)";
            ChartControl.EndTime = DateTime.MinValue;
        }

		/// <summary>
		/// Load data from csv file(comma seperated text file, can be opened from excel)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mmLoadData_Click(object sender, System.EventArgs e)
		{
			odLoadData.FilterIndex = 1;
			odLoadData.InitialDirectory = Environment.CurrentDirectory;
			if (odLoadData.ShowDialog()==DialogResult.OK) 
				LoadCSVFile(odLoadData.FileName);                
		}

		/// <summary>
		/// Load stock data from yahoo finance
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
//		private void mmLoadFromYahoo_Click(object sender, System.EventArgs e)
//		{
//			string s = InputBox.ShowInputBox("Quote:","MSFT");
//			if (s!="") 
//			{
//				YahooDataManager ydm = new YahooDataManager();
//				ydm.CacheRoot = FormulaHelper.Root+"Cache";
//				ChartControl.DataManager = ydm;
//				ChartControl.EndTime = DateTime.MinValue;
//				ChartControl.Symbol = s;
//			}
//		}
//
//		private void miLoadFromEasyChart_Click(object sender, System.EventArgs e)
//		{
//			string s = InputBox.ShowInputBox("Quote:","MSFT");
//			if (s!="")
//			{
//				if (!DataClient.Logined)
//					DataFeedLogin.Login(DataClient);
//				if (DataClient.Logined)
//				{
//					ChartControl.DataManager = new DataClientDataManager(DataClient,false);
//					ChartControl.EndTime = DateTime.MinValue;
//					ChartControl.Symbol = s;
//				}
//			}
//		}

		/// <summary>
		/// Load binary array to the chart. this demo shows how to load your own data.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
//		private void miLoadBinary_Click(object sender, System.EventArgs e)
//		{
//			ChartControl.HistoryDataManager = new RandomDataManager(false);
//			ChartControl.IntraDataManager = new RandomDataManager(true);
//			ChartControl.Symbol = "MSFT";
//			ChartControl.EndTime = DateTime.MinValue;
//		}

		/// <summary>
		/// Show about box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
//		private void miAbout_Click(object sender, System.EventArgs e)
//		{
//			AboutForm.ShowForm();
//		}

		/// <summary>
		/// Exit program
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void miExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Show hot key in web browser
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void miHotKey_Click(object sender, System.EventArgs e)
		{
			if (File.Exists("HotKey.html"))
				Process.Start("HotKey.html");
		}

//		private void miFormulaEditor_Click(object sender, System.EventArgs e)
//		{
//			FormulaSourceEditor.Open("","");
//		}

        //private void ChartControl_CursorPosChanged(Easychart.Finance.FormulaChart Chart, int Pos, Easychart.Finance.DataProvider.IDataProvider idp)
        //{
        //    //lClose.Text = "Volume="+idp["VOLUME"][Pos] +"   $"+idp["CLOSE"][Pos].ToString();
        //}

        private void ChartControl_NativePaint(object sender, Easychart.Finance.NativePaintArgs e)
        {
            //			PointF p1 = ChartControl.Chart.GetPointAt(new DateTime(2004,1,9),27.66);
            //			PointF p2 = ChartControl.Chart.GetPointAt(new DateTime(2003,11,20),25.1);
            //			e.Graphics.DrawLine(Pens.Red,p1,p2);
        }

		private void ChartControl_DataChanged(object sender, System.EventArgs e)
		{
			Text = ChartControl.Caption;
		}

//		private void miSquareRoot_Click(object sender, System.EventArgs e)
//		{
//			ChartControl.Chart[1].AxisY.Scale = ScaleType.SquareRoot;
//			ChartControl.NeedRedraw();
//		}
//
//		private void miLineColor_Click(object sender, System.EventArgs e)
//		{
//			if (cdFormulaColor.ShowDialog()==DialogResult.OK)
//			{
//				ChartControl.Chart[1][1].FormulaUpColor = cdFormulaColor.Color;
//				ChartControl.NeedRedraw();
//			};
//		}
//
//		private void miCrossCursor_Click(object sender, System.EventArgs e)
//		{
//			ChartControl.ShowCrossCursor = !ChartControl.ShowCrossCursor;
//		}
//
//		private void miFormulaValue_Click(object sender, System.EventArgs e)
//		{
//			FormulaData fd = ChartControl.Chart[1][0];
//			MessageBox.Show(ChartControl.Chart[1].Formulas[0].Name+" = "+fd[fd.Length-1].ToString("f2"));
//		}

		private void DemoForm_Closed(object sender, System.EventArgs e)
		{
			DynamicConfig.Save(ChartControl);
			if (dcbStream!=null)
				dcbStream.StopStreaming();
			if (dcbForex!=null)
				dcbForex.StopStreaming();
		}

//		private void miPrint_Click(object sender, System.EventArgs e)
//		{
//			ChartControl.Print();
//		}

//		private void miPreview_Click(object sender, System.EventArgs e)
//		{
//			ChartControl.PrintPreview();
//			
//		}

//		private void miSetup_Click(object sender, System.EventArgs e)
//		{
//			ChartControl.PrintSetup();
//		}

        //private void miTwoIndi_Click(object sender, System.EventArgs e)
        //{
        //    if (ChartControl.Chart.Areas.Count>2)
        //    {
        //        ChartControl.Chart[2].Formulas.Clear();
        //        ChartControl.Chart[2].AddFormula("RSI");
        //        ChartControl.Chart[2].AddFormula("VOL");
        //        ChartControl.Chart[2].Bind();
        //        ChartControl.Chart[2].Formulas[1].AxisYIndex = 1;
        //        ChartControl.NeedRebind();
        //    }
        //}

		//DataClientBase dcb = new ProphetDataClient();
//		private void miLoadFromProphet_Click(object sender, System.EventArgs e)
//		{
//			//			string s = InputBox.ShowInputBox("Quote:","MSFT");
//			//			if (s!="")
//			//			{
//			//				if (!dcb.Logined)
//			//					DataFeedLogin.Login(dcb);
//			//
//			//				if (dcb.Logined)
//			//				{
//			//					DataClientDataManager dcdm = new DataClientDataManager(dcb,false);
//			//					ChartControl.DataManager = dcdm;
//			//					ChartControl.CurrentDataCycle = "DAY";
//			//					ChartControl.Symbol = s;
//			//				}
//			//			}
//		}

//		private void miLineType_Click(object sender, System.EventArgs e)
//		{
//			Array a = Enum.GetValues(typeof(StockRenderType));
//			ChartControl.StockRenderType = (StockRenderType)( ((int)ChartControl.StockRenderType+1) % a.Length );
//		}

//		private void miLoadXml_Click(object sender, System.EventArgs e)
//		{
//			ChartControl.DataManager = new XmlDataManager();
//			ChartControl.Symbol = "example";
//			ChartControl.CurrentDataCycle = DataCycle.Day;
//		}

//		private void miMetaStock_Click(object sender, System.EventArgs e)
//		{
//			odLoadData.FilterIndex = 2;
//			if (odLoadData.ShowDialog()==DialogResult.OK)
//			{
//				string Filename = odLoadData.FileName;
//				MSDataManager mdm = new MSDataManager(Filename);
//				ChartControl.DataManager = mdm;
//				ChartControl.Symbol = mdm.GetSymbol(Path.GetFileNameWithoutExtension(Filename));
//			}
//		}

//		private void miGetData_Click(object sender, System.EventArgs e)
//		{
//			IDataProvider idp = ChartControl.Chart.DataProvider;
//			if (idp!=null)
//			{
//				FormulaData fdDate = idp["DATE"];
//				FormulaData fdClose = idp["CLOSE"];
//				FormulaData fdHigh = idp["HIGH"];
//				FormulaData fdLow = idp["LOW"];
//				FormulaData fdOpen = idp["OPEN"];
//
//				StringBuilder sb = new StringBuilder();
//
//				for(int i=Math.Max(0,fdClose.Length-10) ; i<fdClose.Length; i++) 
//				{
//					sb.Append(DateTime.FromOADate(fdDate[i]).ToString("yyyy-MM-dd")+ " C:"+fdClose[i].ToString()+" ");
//					sb.Append("H: "+fdHigh[i]+" L:"+fdLow[i]+" O:"+fdOpen[i]);
//					sb.Append("\r\n");
//				}
//
//				MessageBox.Show(sb.ToString());
//			}
//		}

		private void ChartControl_AfterApplySkin(object sender, System.EventArgs e)
		{
			foreach(FormulaArea fa in ChartControl.Chart.Areas) 
			{
				foreach(FormulaData fd in fa.FormulaDataArray)
					if (fd.ParentFormula.FormulaName=="RSI(14)")
						fd.FormulaUpColor = Color.CadetBlue;
			}

			bool b = ChartControl.HistoryDataManager is BondTextDataManager;
			ChartControl.Chart.SetBondFormat(b,b?"Y4":"Z2");
			ChartControl.LatestValueType = b?LatestValueType.StockOnly:LatestValueType.All;

			FormulaChart fc = ChartControl.Chart;
			if (fc.Areas.Count>1 && fc[1].Formulas.Count>1)
				fc[1][1].FormulaUpColor = Color.DarkGreen;
		}

		private void ChartControl_BeforeApplySkin(object sender, Easychart.Finance.FormulaSkin fs)
		{
			//fs.AxisY.Format = "R2";
			//fs.ShowXAxisInLastArea = true;
		}

//		private void miOverlayVolume_Click(object sender, System.EventArgs e)
//		{
//			ChartControl.DefaultFormulas = "MAIN#OverlayV!#MA(14)#MA(60);RSI(14)#RSI(28);MACD";
//		}

		/// <summary>
		/// Assign data manager to current chart control
		/// </summary>
		/// <param name="dmb">Data manager to assign</param>
		/// <param name="DefaultSymbol"></param>
		/// <param name="DefaultCycle"></param>
		/// <param name="DefaultBars"></param>
		/// <returns></returns>
		private string LoadDataManager(DataManagerBase dmb,string DefaultSymbol,DataCycle DefaultCycle,int DefaultBars)
		{
			string s = InputBox.ShowInputBox("Quote:",DefaultSymbol);
			if (s!="") 
			{
				ChartControl.DataManager = dmb;
				ChartControl.Symbol = s;
				ChartControl.StockBars = DefaultBars;
				ChartControl.CurrentDataCycle = DefaultCycle;
			}
			return s;
		}

		/// <summary>
		/// Load data from yahoo, and start a streaming data thread to update current price.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
//		private void miLoadFromYahooStreaming_Click(object sender, System.EventArgs e)
//		{
//			//Use yahoo data manager as inner data manager
//			YahooDataManager ydm = new YahooDataManager();
//			ydm.CacheRoot = FormulaHelper.Root+"Cache";
//
//			//MemoryDataManager manage stock data in memory, 
//			//Use AddNewPacket to add streaming data packet to it.
//			//Use RemoveSymbol to remove data from memory.
//			//It takes an inner data manager, all historical data is from the inner data manager
//			MemoryDataManager mdm = new MemoryDataManager(ydm);
//				
//			//Assign memory data manager to the chart control.
//			string s = LoadDataManager(mdm,"MSFT",DataCycle.Day,200);
//
//			//Avoid flicker when refresh the chart
//			ChartControl.MemoryCrossCursor = true;
//			
//			//Show 15 days future bar.
//			ChartControl.EndTime = DateTime.Today.AddDays(15);
//			//Show chart from 8 months ago.
//			ChartControl.StartTime = DateTime.Today.AddMonths(-8);
//			
//			//You can use mdm.AddNewPacket to add a single bar
//			//mdm.AddNewPacket(new DataPacket("MSFT",DateTime.Now,25,28,24,26,100000,26));
//
//			//dcbStream is a DataClientBase class, 
//			//It will let you add streaming data to MemoryDataManager in a thread.
//			if (dcbStream==null)
//			{
//				dcbStream = new YahooDataClient();
//				//You can use other data client,
//				//dcbStream = new ProphetDataClient();
//				//dcbStream.Login("...","...");
//
//				//When streaming packet arrive, call  dcb_OnStreamingData
//				dcbStream.OnStreamingData +=new StreamingDataChanged(dcb_OnStreamingData);
//				dcbStream.UtcStreamingTime = false;
//				
//				//Start the download thread
//				dcbStream.StartStreaming(s);
//			} 
//			else  
//			{
//				//SetStreamingSymbol will set symbol for downloading
//				//You can use AddSymbol for multi-symbols downloading
//				dcbStream.SetStreamingSymbol(s);
//			}
//		}

//		private void miText_Click(object sender, System.EventArgs e)
//		{
//			LoadDataManager(new TextDataManager(),"TEST", DataCycle.Day,200);
//		}

//		private void miForexText_Click(object sender, System.EventArgs e)
//		{
//			MemoryDataManager mdm = new MemoryDataManager(new ForexTextDataManager());
//			string s = LoadDataManager(mdm,"EURUSD", DataCycle.Parse("Minute15"),150)+"=X";
//
////			if (dcbForex==null)
////			{
////				dcbForex = new YahooDataClient();
////				dcbForex.OnStreamingData+=new StreamingDataChanged(dcb_OnStreamingData);
////				dcbForex.UtcStreamingTime = false;
////				dcbForex.StartStreaming(s);
////			} 
////			else dcbForex.SetStreamingSymbol(s);
//		}

//		private void miLoadBond_Click(object sender, System.EventArgs e)
//		{
//			LoadDataManager(new BondTextDataManager(),"ZT1", DataCycle.Parse("Minute10"),200);
//		}

		/// <summary>
		/// Refresh the chart when new data streaming data come
		/// </summary>
		/// <param name="dp"></param>
		private void dcb_OnStreamingData(object sender, DataPacket dp)
		{
			if (dp.Symbol.EndsWith("=X"))
				dp.Symbol = dp.Symbol.Substring(0,dp.Symbol.Length-2);

			if (ChartControl.HistoryDataManager is MemoryDataManager)
			{
				MemoryDataManager mdm = ChartControl.HistoryDataManager as MemoryDataManager;
				
				//Add streaming data to mdm
				mdm.AddNewPacket(dp);
				if (ChartControl.Symbol==dp.Symbol)
					ChartControl.NeedRebind();
				//GC.Collect();  //Release memory
			}
		}

//		private void miChangeFormulaParameter_Click(object sender, System.EventArgs e)
//		{
//
//			if (ChartControl.Chart.Areas.Count>0) 
//			{
//				//Get first area
//				FormulaArea fa = ChartControl.Chart.Areas[0];
//				if (fa.Formulas.Count>2)
//					//Get third formula and set N parameter to 20
//					fa.Formulas[2].SetParam("N","20");
//			}
//			ChartControl.SaveChartProperties();
//			ChartControl.NeedRebind();
//		}

		/// <summary>
		/// Add RSI(10) to fa if not exist
		/// </summary>
		/// <param name="fa"></param>
		private void AddFormula(FormulaArea fa)
		{
			if (fa!=null)
			{
				string Indicator = "RSI(10)";
				ArrayList al = new ArrayList();
				al.AddRange(fa.FormulaToStrings());
				if (al.IndexOf(Indicator)<0)
				{
					al.Add(Indicator);
					fa.Formulas.Clear();
					fa.StringsToFormula((string[])al.ToArray(typeof(string)));
					ChartControl.NeedRebind();
				}
			}
		}

//		private void miAddFormula1_Click(object sender, System.EventArgs e)
//		{
//			if (ChartControl.Chart.Areas.Count>2) 
//				AddFormula(ChartControl.Chart.Areas[2]);
//		}
//
//		private void miAddFormula2_Click(object sender, System.EventArgs e)
//		{
//			AddFormula(ChartControl.Chart.SelectedArea);
//		}
//
//		private void miAddFormula3_Click(object sender, System.EventArgs e)
//		{
//			if (ChartControl.Chart.Areas.Count<8)
//				ChartControl.DefaultFormulas +=";RSI(10)";
//		}

		private void MoveFormula(FormulaArea fa1,FormulaArea fa2,int Index)
		{
			if (fa1!=null && fa2!=null)
			{
				ArrayList al = new ArrayList();
				al.AddRange(fa1.FormulaToStrings());
				if (al.Count>Index)
				{
					string s = (string)al[Index];
					al.RemoveAt(Index);
					fa1.Formulas.Clear();
					fa1.StringsToFormula((string[])al.ToArray(typeof(string)));

					s = fa2.FormulaToString('#')+'#'+s;
					fa2.Formulas.Clear();
					fa2.StringToFormula(s,'#');
					ChartControl.NeedRebind();
				}
			}
		}

        private void mmLoadDataForecast_Click(object sender, EventArgs e)
        {
            odLoadData.FilterIndex = 1;
            odLoadData.InitialDirectory = Environment.CurrentDirectory;
            if (odLoadData.ShowDialog() == DialogResult.OK)
            {
                //LoadCSVFile(odLoadData.FileName);
                LoadMoreCSVFile(odLoadData.FileName.Replace(".csv","_forecast.csv"));
            }
        }

        private void miCreateDM_Click(object sender, EventArgs e)
        {
            frmDM frm = new frmDM();
            frm.Show();
        }

//		private void miMoveFormula_Click(object sender, System.EventArgs e)
//		{
//			if (ChartControl.Chart.Areas.Count>3)
//				MoveFormula(ChartControl.Chart[2],ChartControl.Chart[3],1);
//		}
//
//		private void miRemoveSelectedArea_Click(object sender, System.EventArgs e)
//		{
//			ChartControl.CloseArea(ChartControl.Chart.SelectedArea);
//		}
	}
}