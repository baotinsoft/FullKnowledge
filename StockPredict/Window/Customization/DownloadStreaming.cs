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
	public delegate void OnNewPacket(string Code,DataPacket dp);
	/// <summary>
	/// Run will download real-time data from yahoo finance, and add the data to stream data manager.
	/// </summary>
	public class DownloadStreaming
	{
		//public string Code;
		private ArrayList alSymbols;
		private ChartWinControl ChartControl;
		private Thread tStream;
		private event OnNewPacket OnNewPacket;
		private int interval;

		public DownloadStreaming(string Symbol,ChartWinControl cwc, OnNewPacket onp, int interval)
		{
			alSymbols = new ArrayList();
			AddSymbol(Symbol);
			ChartControl = cwc;
			this.OnNewPacket = onp;
			this.interval = interval;
		}

		/// <summary>
		/// Add new symbol to the download list
		/// </summary>
		/// <param name="Symbol"></param>
		public void AddSymbol(string Symbol)
		{
			if (alSymbols.IndexOf(Symbol)<0)
				alSymbols.Add(Symbol);
		}

		/// <summary>
		/// Remove symbol from the download list
		/// </summary>
		/// <param name="Symbol"></param>
		public void RemoveSymbol(string Symbol)
		{
			alSymbols.Remove(Symbol);
		}

		/// <summary>
		/// Set the download list
		/// </summary>
		/// <param name="Symbol"></param>
		public void SetSymbol(string Symbol)
		{
			alSymbols.Clear();
			AddSymbol(Symbol);
		}

		private void Run()
		{
			while (true)
				try
				{
					DataPacket[] dps = DataPacket.DownloadMultiFromYahoo(
						string.Join(",",(string[])alSymbols.ToArray(typeof(string))));
					for(int i=0; i<alSymbols.Count; i++) 
					{
						if (OnNewPacket!=null)
							OnNewPacket(alSymbols[i].ToString(),dps[i]);
					}
						//StreamDataManager.AddNewPacket(alSymbols[i].ToString(),dps[i]);
					ChartControl.NeedRebind();
					Thread.Sleep(interval);
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
