using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace StockPredict
{
    class AnalysisLib
    {
        public static string[] arrSRules;
        public static int iTotal; // total rules in AnalysisRules.txt file

        //public static void Test()
        //{
        //    ReadRules();
        //    double[,] dArrVal = new double [10,4];
        //    dArrVal[7, 0] = 2;//C
        //    dArrVal[7, 1] = 1;//O
            
        //    dArrVal[8, 0] = 4;//C
        //    dArrVal[8, 1] = 3.6;//O

        //    dArrVal[9, 0] = 0.4;//C
        //    dArrVal[9, 1] = 2;//O

        //    int i = CheckRules(dArrVal);
        //    int j = 0;
        //}

        /*---------------------------------
        * Description: read rules into arrSRules array
        ----------------------------------- */
        public static void ReadRules()
        {
            StreamReader sr = new StreamReader("D:/Master/AnalysisRules.txt");
            sr.ReadLine(); // first line: guide
            iTotal = Convert.ToInt32(sr.ReadLine()); // second line: total rules
            arrSRules = new string[iTotal];

            for (int i=0;i<iTotal;i++)
            {
                sr.ReadLine();  // name of rule
                arrSRules[i] = sr.ReadLine(); // rule
            }
            sr.Close();
        }

        /*---------------------------------
        * Description: check rules
        * Input:
        *  dArrVal : array contains ClosePrice, OpenPrice, LowPrice, HighPrice
        * Output:
        *  0: not found, 1: increase; 2: decrease
        ----------------------------------- */
        public static int CheckRules(double[,] dArrVal)
        {
            string[] sArrTerm = { "C", "O", "L", "H" };
            string[] sArrTmp, sArrPhrase, sArrPart;
            double dLeft = 0, dRight = 0;
            double dLeft1 = 0, dLeft2 = 0, dRight1 = 0, dRight2 = 0;

            int iRes = 0;
            bool bFlag = false;//, bFlagRule = false;
            for (int i = 0; i < iTotal; i++)
            {
                sArrTmp = arrSRules[i].Split(':');
                iRes = Convert.ToInt32(sArrTmp[1]); // if condition of rule is ok then return result of rule
                sArrPhrase = sArrTmp[0].Split('&');
                for (int j = 0; j < sArrPhrase.Length; j++)
                {
                    sArrPart = sArrPhrase[j].Split('>');
                    if (sArrPart[0].Length == 2 && sArrPart[1].Length == 2) //when phrase is only comparation
                    {
                        string sTmp1 = sArrPart[0].Substring(0, 1);
                        int iPos1 = Convert.ToInt32(sArrPart[0].Substring(1, 1));
                        string sTmp2 = sArrPart[1].Substring(0, 1);
                        int iPos2 = Convert.ToInt32(sArrPart[1].Substring(1, 1));

                        for (int k = 0; k < 4; k++)
                        {
                            if (sTmp1 == sArrTerm[k]) dLeft = dArrVal[iPos1, k];
                            if (sTmp2 == sArrTerm[k]) dRight = dArrVal[iPos2, k];
                        }
                    }
                    else //when phrase is expression
                    {
                        //Left
                        if (sArrPart[0].Length == 7)
                        {
                            string[] sArrSign = sArrPart[0].Split('/');
                            int iDivide = Convert.ToInt32(sArrSign[1]);
                            string[] sArrSubPart = sArrSign[0].Split('-');

                            string sTmp1 = sArrSubPart[0].Substring(0, 1); // left 1
                            int iPos1 = Convert.ToInt32(sArrSubPart[0].Substring(1, 1));
                            string sTmp2 = sArrSubPart[1].Substring(0, 1); // left 2
                            int iPos2 = Convert.ToInt32(sArrSubPart[1].Substring(1, 1));

                            for (int k = 0; k < 4; k++)
                            {
                                if (sTmp1 == sArrTerm[k]) dLeft1 = dArrVal[iPos1, k];
                                if (sTmp2 == sArrTerm[k]) dLeft2 = dArrVal[iPos2, k];
                            }
                            dLeft = (dLeft1 - dLeft2) / iDivide;
                         }
                        else if (sArrPart[0].Length == 5)
                        {
                            string[] sArrSubPart = sArrPart[0].Split('-');

                            string sTmp1 = sArrSubPart[0].Substring(0, 1); // left 1
                            int iPos1 = Convert.ToInt32(sArrSubPart[0].Substring(1, 1));
                            string sTmp2 = sArrSubPart[1].Substring(0, 1); // left 2
                            int iPos2 = Convert.ToInt32(sArrSubPart[1].Substring(1, 1));

                            for (int k = 0; k < 4; k++)
                            {
                                if (sTmp1 == sArrTerm[k]) dLeft1 = dArrVal[iPos1, k];
                                if (sTmp2 == sArrTerm[k]) dLeft2 = dArrVal[iPos2, k];
                            }
                            dLeft = dLeft1 - dLeft2;
                        }
                        else
                        {
                            string sTmp1 = sArrPart[0].Substring(0, 1); 
                            int iPos1 = Convert.ToInt32(sArrPart[0].Substring(1, 1));
                            for (int k = 0; k < 4; k++)
                            {
                                if (sTmp1 == sArrTerm[k]) {dLeft = dArrVal[iPos1, k];break;}
                            }
                        }


                        //Right
                        if (sArrPart[1].Length == 7)
                        {
                            string[] sArrSign = sArrPart[1].Split('/');
                            int iDivide = Convert.ToInt32(sArrSign[1]);
                            string[] sArrSubPart = sArrSign[0].Split('-');

                            string sTmp1 = sArrSubPart[0].Substring(0, 1); // right 1
                            int iPos1 = Convert.ToInt32(sArrSubPart[0].Substring(1, 1));
                            string sTmp2 = sArrSubPart[1].Substring(0, 1); // right 2
                            int iPos2 = Convert.ToInt32(sArrSubPart[1].Substring(1, 1));

                            for (int k = 0; k < 4; k++)
                            {
                                if (sTmp1 == sArrTerm[k]) dRight1 = dArrVal[iPos1, k];
                                if (sTmp2 == sArrTerm[k]) dRight2 = dArrVal[iPos2, k];
                            }
                            dRight = (dRight1 - dRight2) / iDivide;
                        }
                        else if (sArrPart[1].Length == 5)
                        {
                            string[] sArrSubPart = sArrPart[1].Split('-');

                            string sTmp1 = sArrSubPart[0].Substring(0, 1); // right 1
                            int iPos1 = Convert.ToInt32(sArrSubPart[0].Substring(1, 1));
                            string sTmp2 = sArrSubPart[1].Substring(0, 1); // right 2
                            int iPos2 = Convert.ToInt32(sArrSubPart[1].Substring(1, 1));

                            for (int k = 0; k < 4; k++)
                            {
                                if (sTmp1 == sArrTerm[k]) dRight1 = dArrVal[iPos1, k];
                                if (sTmp2 == sArrTerm[k]) dRight2 = dArrVal[iPos2, k];
                            }
                            dRight = dRight1 - dRight2;
                        }
                        else
                        {
                            string sTmp1 = sArrPart[1].Substring(0, 1);
                            int iPos1 = Convert.ToInt32(sArrPart[1].Substring(1, 1));
                            for (int k = 0; k < 4; k++)
                            {
                                if (sTmp1 == sArrTerm[k]) { dRight = dArrVal[iPos1, k]; break; }
                            }
                        }
                            
                    }

                    if (dLeft > dRight) bFlag = true;   // next phrase
                    else
                    {
                        bFlag = false;
                        break; // next rule;
                    }

                } // phrase
                if (bFlag == true) return iRes;
            } // rule
            return 0;
        }

  
        /*---------------------------------
        * Description: identify trend
        * Input:
        *  bTrend: trend of ART 
        *  dArrVal : array contains ClosePrice, OpenPrice, LowPrice, HighPrice
        * Output:
        *  1x: trend of ART; 2x: trend of Analysis
        *  1: increase; 2: decrease
       ----------------------------------- */
        public static int IdentifyTrend(bool bTrend, double[,] dArrVal, string sStockCode)
        {
            int iTrend = 0;
            ReadRules();
            iTrend = CheckRules(dArrVal);

            int iTrendMS = bTrend ? 1 : 2;

            if (iTrend == 0) return 10 + iTrendMS;
            else
            {
                if (iTrendMS == iTrend)
                    return 10 + iTrend;
                else //not equal
                {
                    General.GetParam();
                    if(iTrend==1) //increase
                    {
                        ADOLib.MAXIMUM_SERIES_VALUE = dArrVal[9, 0] * (1 + General.iLimit);
                        ADOLib.MINIMUM_SERIES_VALUE = dArrVal[9, 0];
                    }
                    else //decrease
                    {
                        ADOLib.MAXIMUM_SERIES_VALUE = dArrVal[9, 0];
                        ADOLib.MINIMUM_SERIES_VALUE = dArrVal[9, 0] * (1 - General.iLimit);
                    }
                    ADOLib.UpdateMMbyAnalysis(sStockCode);
                    return 20 + iTrend;
                }
            }
        }
 
        /*---------------------------------
        * Description: Handle forecasting for special days
        * Input:
        *  dArrVal : array contains ClosePrice, OpenPrice, LowPrice, HighPrice
        * Output:
        *  0: not found, 1: increase; 2: decrease
       ----------------------------------- */
        public static double HandleSpecialDay(double dVal, int iCase)
        {
            switch (iCase)
            {

            }
            return dVal;
        }
    }
}
