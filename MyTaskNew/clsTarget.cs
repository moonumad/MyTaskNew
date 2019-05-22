
using System.Collections.Generic;
using System.IO;

namespace MyTaskNew
{
  public  class clsTarget
    {
        public  static Dictionary<string, int>
            MyMapp = new Dictionary<string, int>();
        public static string TargetFilePath = @"c:/Files/Account.csv";
     
        public static void GetTargetMap()
        {
            MyMapp.Add("AccountCode", -1);
            MyMapp.Add("Name", -1);
            MyMapp.Add("Type", -1);
            MyMapp.Add("Open Date", -1);
            MyMapp.Add("Currency", -1);
            MyMapp.Add("AbcCode", -1);
            MyMapp.Add("My Account", -1);
            MyMapp.Add("RRSP", -1);
            MyMapp.Add("2018-01-01", -1);
            MyMapp.Add("CAD", -1);
        }
        /// <summary>
        /// write to targeted file.
        /// </summary>
        /// <param name="P_Map">Current Mapp</param>
        /// <param name="Lines">List of Data items in shape of string Line </param>
        public void WriteToFile(Dictionary<string, int> P_Map, List<string> Lines)
        {
            string Header = "";
            StreamWriter sw;
            bool IsHeader = false;
            FileStream fs;
            if (!File.Exists(TargetFilePath))
            {
                IsHeader = true;
                fs = File.Create(TargetFilePath);
            }
            else
            {
                fs =  File.Open(TargetFilePath,FileMode.Append);
            } 
            if (IsHeader)
            {
              //  fs = File.Create(TargetFilePath);

                sw = new StreamWriter(fs);
              
                foreach (var key in P_Map.Keys)
                {
                    if (Header.Length < 1)
                    {
                        Header = key;
               
                    }
                    else
                    {
                        Header = Header + "," + key;
                    }
                   
                }

            }
            
            sw = new StreamWriter(fs);
            if (IsHeader)
            {
                sw.WriteLine(Header);
                IsHeader = false;
            }
                foreach (string line in Lines)
            {
                sw.WriteLine(line);
            }
            
            sw.Dispose();
            fs.Dispose();
        }

    }
}
