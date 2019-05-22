using System;


namespace MyTaskNew
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var objOne = new FileOne();
                objOne.ExecFile();
                //var objTwo = new FileTwo();
                //objTwo.ReadFileNew();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
