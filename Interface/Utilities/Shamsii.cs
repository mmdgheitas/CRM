using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace TakHozour
{
    class Shamsii
    {
        private string Year, Day, Month, Hour, Minute, Second;
        public string Date(System.DateTime Now)
        {
            PersianCalendar PerCal = new PersianCalendar();

            Year = PerCal.GetYear(Now).ToString();
            Month = PerCal.GetMonth(Now).ToString();
            Day = PerCal.GetDayOfMonth(Now).ToString();
            Day = (Day.Length == 1) ? "0" + Day : Day;
            Month = (Month.Length == 1) ? "0" + Month : Month;
           // if (Day == "31")
             //   Day = "30";
            return (Year + '/' + Month + '/' + Day);
        }
        public string DateTime(System.DateTime Now)
        {
            PersianCalendar PerCal = new PersianCalendar();
           
            Year = PerCal.GetYear(Now).ToString();
            Month = PerCal.GetMonth(Now).ToString();
            Day = PerCal.GetDayOfMonth(Now).ToString();
            Hour = PerCal.GetHour(Now).ToString();
            Minute = PerCal.GetMinute(Now).ToString();
            Second = PerCal.GetSecond(Now).ToString();
            Day = (Day.Length == 1) ? "0" + Day : Day;
            Month = (Month.Length == 1) ? "0" + Month : Month;
            Hour = (Hour.Length == 1) ? "0" + Hour : Hour;
            Minute = (Minute.Length == 1) ? "0" + Minute : Minute;
            Second = (Second.Length == 1) ? "0" + Second : Second;
           

            return (Year + '/' + Month + '/' + Day + ' ' + Hour + ':' + Minute + ':' + Second);
        }



        internal List<string> DateTime2(System.DateTime dateTime)
        {
            PersianCalendar PerCal = new PersianCalendar();
            List<String> l = new List<String>();

            Year = PerCal.GetYear(dateTime).ToString();
           
            Month = PerCal.GetMonth(dateTime).ToString();
            Day = PerCal.GetDayOfMonth(dateTime).ToString();
            Hour = PerCal.GetHour(dateTime).ToString();
            Minute = PerCal.GetMinute(dateTime).ToString();
            Second = PerCal.GetSecond(dateTime).ToString();
            Day = (Day.Length == 1) ? "0" + Day : Day;
            Month = (Month.Length == 1) ? "0" + Month : Month;
            Hour = (Hour.Length == 1) ? "0" + Hour : Hour;
            Minute = (Minute.Length == 1) ? "0" + Minute : Minute;
            Second = (Second.Length == 1) ? "0" + Second : Second;
           
            l.Add(Year);
            l.Add(Month);
            l.Add(Day);
            l.Add(Hour);
            l.Add(Minute);
            l.Add(Second);
            return l;
        }

        internal List<string> Date2(System.DateTime dateTime)
        {
            PersianCalendar PerCal = new PersianCalendar();
            List<String> l = new List<String>();

            Year = PerCal.GetYear(dateTime).ToString();
            Month = PerCal.GetMonth(dateTime).ToString();
            Day = PerCal.GetDayOfMonth(dateTime).ToString();
            Day = (Day.Length == 1) ? "0" + Day : Day;
            Month = (Month.Length == 1) ? "0" + Month : Month;
         
            l.Add(Year);
            l.Add(Month);
            l.Add(Day);
            return l;
        }

        public List<int> JodaKonDate(string p)
        {
            p = p + "/";
            List<int> l = new List<int>();
            for (int i = 0; i < p.Count() - 1; i++)
            {
                int j = i;
                while (p[j] != '/') { j++; }
                l.Add(Int32.Parse(p.Substring(i, j - i)));
                i = j;
            }
            return l;
        }

        public List<int> JodaKonDateTime(string p)
        {
            p = p + "/";
            p=p.Replace(' ', '/');
            p = p.Replace(':', '/');
            List<int> l = new List<int>();
            for (int i = 0; i < p.Count() - 1; i++)
            {
                int j = i;
                while (p[j] != '/')  
                    j++;
                if(j>i)
                    l.Add(Int32.Parse(p.Substring(i, j - i)));
                i = j;
            }
            return l;
        }
        public String DateTimeMiladi(System.DateTime Now)
        {
            PersianCalendar PerCal = new PersianCalendar();

            Hour = PerCal.GetHour(Now).ToString();
            Minute = PerCal.GetMinute(Now).ToString();
            Second = PerCal.GetSecond(Now).ToString();
            Hour = (Hour.Length == 1) ? "0" + Hour : Hour;
            Minute = (Minute.Length == 1) ? "0" + Minute : Minute;
            Second = (Second.Length == 1) ? "0" + Second : Second;



            return (Now.ToShortDateString().ToString().Trim() + ' ' + Hour + ':' + Minute + ':' + Second);
        }

    }
}
