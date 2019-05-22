
using System.Collections.Generic;


namespace MyTaskNew
{
    public class FileTwo: AbsFile
    {
        public FileTwo()
        {
            clsTarget.GetTargetMap();
            var MyMap = AddMap(clsTarget.MyMapp);
            FileName = @"c:/Files/FileTwo.csv";
        }
        /// <summary>
        /// Define Map for file one 
        /// </summary>
        /// <param name="MyMap">Targeted Map</param>
        /// <returns>Current Map</returns>
        public override Dictionary<string, int> AddMap(Dictionary<string, int> MyMap)
        {

            MyMap["Name"] = 0;
            MyMap["AccountCode"] = 3;
            MyMap["Type"] = 1;
            MyMap["Currency"] = 2;
            MyMap["My Account"] = 4;
            MyMap["RRSP"] = 5;
            MyMap["CAD"] = 6;
            return MyMap;
            
        }
      
    }
}
