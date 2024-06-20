using DepotDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepotDiary.Code
{
    public class NormalClosing
    {
        //List<int> oddDepots = new List<int> { 1052, 1500, 1600, };
        List<int> oddDepots = new List<int> { 1500, 1052, 1600, 2400, 3 };
        Dictionary<int, Dictionary<string, PlantClosingTimes>> oddClosing = new Dictionary<int, Dictionary<string, PlantClosingTimes>>();
        string insertTemplate = @"insert into depot_diary_event(DDE_DATE, DDE_DEPOT_REFERENCE, DDE_ENTRY_TYPE, DDE_EMP_ENTERED_BY, DDE_WHEN_ENTERED, DDE_START_HR, DDE_END_HR, DDE_DIARY_REF, DDE_START_HR_2, DDE_END_HR_2) values ('{0}', {1}, 'N', 8314, sysdate, '{2}', '{3}', diary_seq.nextval, '{4}', '{5}');";
        public async Task<List<string>> GenerateNormalClosingAsync()
        {
            oddClosing[1500] = await SetAldershotTimes();
            oddClosing[1052] = await SetCroydonTimes();
            oddClosing[1600] = await SetReadingTimes();
            oddClosing[2400] = await SetNewhavenTimes();
            oddClosing[3] = await SetThealeTimes();

            List<string> result = new List<string>();
            DateTime startDate = new DateTime(2023, 4, 1);
            DateTime currDate = startDate;

            for(int i = 0; i <= 365; i++)
            {
                //Console.WriteLine(currDate);
                foreach(int depot in oddDepots)
                {
                    PlantClosingTimes pct = oddClosing[depot][currDate.DayOfWeek.ToString()];
                    string outStr = string.Format(insertTemplate, currDate.ToString("dd-MMM-yy"), depot, pct.close1, pct.open1, pct.close2, pct.open2);
                    result.Add(outStr);
                }
                currDate = currDate.AddDays(1);
            }

            return result;
        }

        public async Task<Dictionary<string, PlantClosingTimes>> SetAldershotTimes()
        {
            Dictionary<string, PlantClosingTimes> dictClosing = new Dictionary<string, PlantClosingTimes>();
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                PlantClosingTimes pot; ;

                if (day.ToString() == "Sunday")
                {
                    pot = new PlantClosingTimes
                    {
                        dayOfWeek = day.ToString(),
                        close1 = "0000",
                        open1 = "2400"
                    };
                }
                else if (day.ToString() == "Saturday")
                {
                    pot = new PlantClosingTimes
                    {
                        dayOfWeek = day.ToString(),
                        close1 = "0000",
                        open1 = "0600",
                        close2 = "1200",
                        open2 = "2400"
                    };

                }
                else
                {
                    pot = new PlantClosingTimes
                    {
                        dayOfWeek = day.ToString(),
                        close1 = "0000",
                        open1 = "0600",
                        close2 = "1300",
                        open2 = "2400"
                    };
                }
                dictClosing[day.ToString()] = pot;
            }

            return dictClosing;
        }

        public async Task<Dictionary<string, PlantClosingTimes>> SetCroydonTimes()
        {
            Dictionary<string, PlantClosingTimes> dictClosing = new Dictionary<string, PlantClosingTimes>();
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                PlantClosingTimes pot; ;

                if (day.ToString() == "Sunday")
                {
                    pot = new PlantClosingTimes
                    {
                        dayOfWeek = day.ToString(),
                        close1 = "0000",
                        open1 = "2400"
                    };
                }
                else if (day.ToString() == "Saturday")
                {
                    pot = new PlantClosingTimes
                    {
                        dayOfWeek = day.ToString(),
                        close1 = "0000",
                        open1 = "0600",
                        close2 = "1200",
                        open2 = "2400"
                    };

                }
                else
                {
                    pot = new PlantClosingTimes 
                    { 
                        dayOfWeek = day.ToString(), 
                        close1 = "0000", 
                        open1 = "0600", 
                        close2 = "2000", 
                        open2 = "2400" 
                    };
                }
                dictClosing[day.ToString()] = pot;
            }

            return dictClosing;
        }

        public async Task<Dictionary<string, PlantClosingTimes>> SetReadingTimes()
        {
            Dictionary<string, PlantClosingTimes> dictClosing = new Dictionary<string, PlantClosingTimes>();
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                PlantClosingTimes pot; ;

                if (day.ToString() == "Sunday")
                {
                    pot = new PlantClosingTimes
                    {
                        dayOfWeek = day.ToString(),
                        close1 = "0000",
                        open1 = "2400"
                    };
                }
                else if (day.ToString() == "Saturday")
                {
                    pot = new PlantClosingTimes
                    {
                        dayOfWeek = day.ToString(),
                        close1 = "0000",
                        open1 = "0600",
                        close2 = "1200",
                        open2 = "2400"
                    };

                }
                else if (day.ToString() == "Monday")
                {
                    pot = new PlantClosingTimes
                    {
                        dayOfWeek = day.ToString(),
                        close1 = "0000",
                        open1 = "0600",
                        close2 = "1200",
                        open2 = "2400"
                    };
                }
                else
                {
                    pot = new PlantClosingTimes
                    {
                        dayOfWeek = day.ToString(),
                        close1 = "0000",
                        open1 = "0600",
                        close2 = "1300",
                        open2 = "2400"
                    };
                }
                dictClosing[day.ToString()] = pot;
            }

            return dictClosing;
        }

        public async Task<Dictionary<string, PlantClosingTimes>> SetNewhavenTimes()
        {
            Dictionary<string, PlantClosingTimes> dictClosing = new Dictionary<string, PlantClosingTimes>();
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                PlantClosingTimes pot; ;

                if (day.ToString() == "Sunday")
                {
                    pot = new PlantClosingTimes
                    {
                        dayOfWeek = day.ToString(),
                        close1 = "0000",
                        open1 = "2400"
                    };
                }
                else if (day.ToString() == "Saturday")
                {
                    pot = new PlantClosingTimes
                    {
                        dayOfWeek = day.ToString(),
                        close1 = "0000",
                        open1 = "0600",
                        close2 = "1200",
                        open2 = "2400"
                    };

                }
                else
                {
                    pot = new PlantClosingTimes
                    {
                        dayOfWeek = day.ToString(),
                        close1 = "0200",
                        open1 = "0600"
                    };
                }
                dictClosing[day.ToString()] = pot;
            }

            return dictClosing;
        }

        public async Task<Dictionary<string, PlantClosingTimes>> SetThealeTimes()
        {
            Dictionary<string, PlantClosingTimes> dictClosing = new Dictionary<string, PlantClosingTimes>();
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                PlantClosingTimes pot; ;

                if (day.ToString() == "Sunday")
                {
                    pot = new PlantClosingTimes
                    {
                        dayOfWeek = day.ToString(),
                        close1 = "0000",
                        open1 = "2400"
                    };
                }
                else if (day.ToString() == "Saturday")
                {
                    pot = new PlantClosingTimes
                    {
                        dayOfWeek = day.ToString(),
                        close1 = "0000",
                        open1 = "0600",
                        close2 = "1200",
                        open2 = "2400"
                    };

                }
                else
                {
                    pot = new PlantClosingTimes
                    {
                        dayOfWeek = day.ToString(),
                        close1 = "0000",
                        open1 = "0600",
                        close2 = "2000",
                        open2 = "2400"
                    };
                }
                dictClosing[day.ToString()] = pot;
            }

            return dictClosing;
        }

    }


}
