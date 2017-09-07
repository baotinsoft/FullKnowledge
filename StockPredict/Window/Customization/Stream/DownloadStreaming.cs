using System;
using System.Data;
using System.Collections;
using System.Reflection;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Easychart.Finance.DataProvider;
using Easychart.Finance;
using Easychart.Finance.Win;

namespace WindowsDemo
{
	/// <summary>
	/// Run will download real-time data from yahoo finance, and add the data to stream data manager.
	/// </summary>
	public class DownloadStreaming
	{
		public string Code;
		ChartWinControl ChartControl;
		Thread tStream;

		public DownloadStreaming(string Code,ChartWinControl cwc)
		{
			this.Code = Code;
			this.ChartControl = cwc;
		}

		private void Run()
		{
			while (true)
				try
				{
					StreamDataManager.AddNewPacket(Code,DataPacket.DownloadFromYahoo(Code));
					ChartControl.NeedRebind();
					Thread.Sleep(2000);
				} 
				catch
				{
				}
		}

		public void Start()
		{
			tStream = new Thread(new ThreadStart(Run));
			tStream.Start();
		}

		public void Stop()
		{
			tStream.Abort();
		}
	}
}
