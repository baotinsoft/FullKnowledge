using System;
using System.Data;
using System.Collections;
using System.Reflection;
using System.IO;
using System.Globalization;
using Easychart.Finance.DataProvider;
using Easychart.Finance;

namespace WindowsDemo
{
	/// <summary>
	/// 1.Cache the historical data to memory
	/// 2.Add streaming data
	/// </summary>
	public class StreamDataManager:DataManagerBase
	{
		static private Hashtable htPacket = new Hashtable();
		static private Hashtable htHistorical = new Hashtable();

		static public void AddNewPacket(string Code,DataPacket dp)
		{
			htPacket[Code] = dp;
		}

		public StreamDataManager()
		{
		}

		public override IDataProvider GetData(string Code, int Count)
		{
			CommonDataProvider cdp = (CommonDataProvider)htHistorical[Code];
			if (cdp==null)
			{
				YahooDataManager ydm = new YahooDataManager();
				ydm.StartTime = this.StartTime;
				ydm.EndTime = this.EndTime;
				ydm.CacheRoot = FormulaHelper.Root+"Cache";
				cdp = (CommonDataProvider)ydm[Code,Count];
				htHistorical[Code] = cdp;
			}
			DataPacket dp = (DataPacket)htPacket[Code];
			if (dp!=null)
				cdp.Merge(dp);
			return cdp;
		}

	}
}
