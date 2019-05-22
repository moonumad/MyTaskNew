using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace MyTaskNew
{
    public class FileOne : AbsFile
    {
        public FileOne()
        {
           
            clsTarget.GetTargetMap();
            FlagHeader = true;
            var MyMap = AddMap(clsTarget.MyMapp);
            FileName = @"c:/Files/FileOne.csv";
        }
        /// <summary>
        /// Define Map for file one 
        /// </summary>
        /// <param name="MyMap">Targeted Map</param>
        /// <returns>Current Map</returns>
        public override Dictionary<string, int> AddMap(Dictionary<string, int> MyMap)
        {
            MyMap["AccountCode"]=1;
            MyMap["Name"]=3;
            MyMap["Type"]=4;
            MyMap["Open Date"]=5;
            MyMap["Currency"]=6;
            MyMap["AbcCode"]=7;
            MyMap["My Account"]=8;
            MyMap["RRSP"]=9;
            MyMap["2018-01-01"]=10;
            MyMap["CAD"]=11;
            return MyMap;

        }

        public override void ExecFile()
        {
            try
            {
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
                string[] Arr;// 0 index is Numeric, 1 Account Code
                string[] ArrMerg;
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
                    Arr = ArrLine[0].Split('|');// 0 index is Numeric, 1 Account Code
                    ArrMerg = Arr.Concat(ArrLine).ToArray();
                    strLine = GetMappedLine(MyMap, ArrMerg);
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
