using System;
using System.Collections;
using System.IO;
using System.Globalization;
using Easychart.Finance.DataProvider;

namespace WindowsDemo
{
	/// <summary>
	/// Summary description for DemoIntraDataManager.
	/// </summary>
	public class DemoIntraDataManager : IntraDataManagerBase
	{
		private string Root;
		public DemoIntraDataManager(string Root)
		{
			if (!Root.EndsWith("\\")) Root +="\\";
			this.Root = Root;
		}

		public CommonDataProvider LoadCSV(StreamReader sr)
		{
			//string Date = sr.ReadLine();
			string s = sr.ReadToEnd().Trim();
			string[] ss = s.Split('\n');

			int N = ss.Length;
			double[] CLOSE = new double[N];
			double[] VOLUME = new double[N];
			double[] DATE = new double[N];

			DateTimeFormatInfo dtfi = DateTimeFormatInfo.InvariantInfo;
			NumberFormatInfo nfi = NumberFormatInfo.InvariantInfo;
			for(int i=0; i<N; i++)
			{
				string[] sss = ss[i].Split(',');
				DATE[i] = DateTime.ParseExact(sss[0],"yyyyMMddHHmmss",dtfi).ToOADate();
				CLOSE[i] = double.Parse(sss[1],nfi);
				VOLUME[i] = double.Parse(sss[2],nfi);
			}

			CommonDataProvider cdp = new CommonDataProvider(this);
			cdp.LoadBinary("DATE",DATE);
			cdp.LoadBinary("CLOSE",CLOSE);
			cdp.LoadBinary("VOLUME",VOLUME);
			return cdp;
		}

		public override IDataProvider GetData(string Code, int Count)
		{
			string Filename = Root+Code+".txt";
			if (File.Exists(Filename))
			{
				using (StreamReader sr = new StreamReader(Filename))
				{
					CommonDataProvider cdp = LoadCSV(sr);
					cdp.SetStringData("Code",Code);
					return cdp;
				}
			}
			return CommonDataProvider.Empty;
		}
	}
}