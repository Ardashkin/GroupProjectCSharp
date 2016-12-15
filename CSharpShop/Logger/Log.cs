using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logger
{
    public static class Log
    {
        private static DateTime currentDate;
        public static void Write(string message)
        {
            string path;
            currentDate = DateTime.Now;
            path = AppDomain.CurrentDomain.BaseDirectory + @"/" + currentDate.ToShortDateString() + ".log";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write(String.Format("{0} => {1}", currentDate, message));
            }
        }
    }
}
