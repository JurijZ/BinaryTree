using System;
using System.IO;
using System.Text;
using static MaxSum.Program;

namespace MaxSum
{
    public static class Helper
    {
        // Function is based on the provided dataset - that is the root value is Odd (215)
        public static bool CheckOddEven(int i, int depth)
        {
            if (depth % 2 == 0)
            {
                if (i % 2 != 0)
                {
                    return true;
                }
            }
            else
            {
                if (i % 2 == 0)
                {
                    return true;
                }
            }            

            return false;
        }

        // Logging
        public static void Log(object message)
        {
            //Console.WriteLine(message);

            using (StreamWriter sw = File.AppendText(DateTime.Now.ToString("yyyyMMdd") + "_log.txt"))
            {
                sw.WriteLine(message);
            }
        }
    }
}
