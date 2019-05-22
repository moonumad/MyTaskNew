using System;
using System.Collections.Generic;
using System.IO;
namespace MyTaskNew
{
 public abstract  class AbsFile
    {
        public string FileName;
        public int ThreashHold = 50000; // just to manage larg files 
        public bool FlagHeader = false;
        /// <summary>
        /// Convert string array as Current Map
        /// </summary>
        /// <param name="myMap"> Current Map</param>
        /// <param name="Line">Line as string Array</param>
        /// <returns></returns>
        public virtual string GetMappedLine(Dictionary<string, int> myMap, string[] Line)
        {
            string result="";
            string[] Arr = Line;
            string currentVal;
            int count = 0;
            foreach (var val in myMap.Values)
            {
                if (val == -1)
                {
                    currentVal = "";
                }
                else
                {
                    currentVal = Arr[val];
                    if (count==2)
                    {
                        switch (currentVal)
                        {
                            case "1":
                                currentVal = "Trading";
                                break;
                            case "2":
                                currentVal = "RRSP";
                                break;
                            case "3":
                                currentVal = "RESP";
                                break;
                            case "4":
                                currentVal = "FUND";
                                break;
                        }

                    }

                    if (count == 4)
                    {
                        switch (currentVal)
                        {
                            case "C":
                                currentVal = "CAD";
                                break;
                            case "CD":
                                currentVal = "CAD";
                                break;
                            case "U":
                                currentVal = "USD";
                                break;
                            case "US":
                                currentVal = "USD";
                                break;
                        }

                    }
                    if (count == 9)
                    {
                        switch (currentVal)
                        {
                            case "C":
                                currentVal = "1";
                                break;
                            case "CD":
                                currentVal = "1";
                                break;
                            default:
                                currentVal = "0";
                                break;
                        }

                    }


                }
                if (result.Length < 1)
                {
                    result = currentVal;

                }
                else
                {
                    result = result + "," + currentVal;
                }

                count = count + 1;
            }
            return result;
        }
        /// <summary>
        /// Base function to define the current map from target map
        /// </summary>
        /// <param name="myMap">Inbout Map</param>
        /// <returns>Current Map</returns>
        public abstract Dictionary<string, int> AddMap(Dictionary<string, int> myMap);
        /// <summary>
        /// Read file and write it as mapping
        /// </summary>
        /// <param name="FlagHeader">Flag True if file has header</param>
        public virtual void ExecFile()
        {
            try {
                var MyObj = new clsTarget();
                var MyMap = clsTarget.MyMapp;
                int count = 0;
                if (!File.Exists(FileName))
                {
                    Console.WriteLine("File is not available!");
                    return;
                }
                StreamReader sr = new StreamReader(FileName);
                string line = "";
                int lineNo = 0;
                string[] ArrLine;
                string strLine;
                List<string> DataList = new List<string>();
                while ((line = sr.ReadLine()) != null)
                {
                    lineNo = lineNo + 1;
                    if (FlagHeader && lineNo == 1)
                    {
                        count = count + 1;
                        continue;
                    }
                    ArrLine = line.Split(',');
                    strLine = GetMappedLine(MyMap, ArrLine);
                    DataList.Add(strLine);
                    count = count + 1;

                    if (count == ThreashHold)
                    {
                        MyObj.WriteToFile(MyMap, DataList);
                        count = 0;
                        DataList.Clear();
                    }

                }
                if (count > 0)
                {
                    MyObj.WriteToFile(MyMap, DataList);
                    count = 0;
                    DataList.Clear();
                }
                sr.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
    
}
