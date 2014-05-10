using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cron.NET
{
    public static class Parser
    {
        public static int maxMinute = 59;
        public static int maxSecond = 59;
        public static int maxHour = 23;
        public static int maxWeekday = 7;
        public static int maxDay = 31;
        public static int maxMonth = 12;

        static string multMatch = "(.,.)+,?";
        static string pMatch = ".-.";
        static string eachMatch = "\\d+/.";
        static string meachMatch = "\\d+-\\d+/.";

        public static void Parse(string line)
        {
            string[] fields = line.Split(new char[] { ' ', '\t' });

            //if (fields.Length < 6) return;

            if (Regex.IsMatch(fields[0], multMatch))
            {
                Console.WriteLine("Have multi match");
            }
            else if (Regex.IsMatch(fields[0], meachMatch))
            {
                Console.WriteLine("Have multieach match");
            }
            else if (Regex.IsMatch(fields[0], eachMatch))
            {
                Console.WriteLine("Have each match");
            }
            else if (Regex.IsMatch(fields[0], pMatch))
            {
                Console.WriteLine("Have p match");
            }
            else Console.WriteLine("ERROR!");
        }
    }
}
