
using DepotDiary.Models;
using OfficeOpenXml;

namespace DepotDiary.Code
{
    public class EppFunctions
    {
        public Dictionary<string, string> depots = new Dictionary<string, string>() {
            { "Aldershot", "1500" },
            { "Heathrow", "1700" },
            { "Erith", "1800" },
            { "Croydon", "1052" },
            { "Theale", "3" },
            { "Newhaven", "2400" },
            { "Reading", "1600" }
        };

        public async Task<List<string>> CreatePlannedInsertsAsync()
        {

            string insertTemplate = "insert into depot_diary_event(DDE_DATE, DDE_DEPOT_REFERENCE, DDE_ENTRY_TYPE, DDE_EMP_ENTERED_BY, DDE_WHEN_ENTERED, DDE_START_HR, DDE_END_HR, DDE_DIARY_REF) values ('{0}', {1}, 'P', 8314, sysdate, '0001', '2400', diary_seq.nextval);";
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            List<string> plannedInserts = new List<string>();

            string path = @"c:\pch\PlannedMaintenance2023.xlsx";
            FileInfo fileInfo = new FileInfo(path);

            ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

            int rows = worksheet.Dimension.Rows;
            int columns = worksheet.Dimension.Columns;

            for (int i = 2; i <= rows; i++)
            {
                string dateParsed = DateTime.Parse(worksheet.Cells[i, 3].Value.ToString()).ToString("dd-MMM-yy");
                string insert = string.Format(insertTemplate, dateParsed, worksheet.Cells[i, 2].Value.ToString());
                plannedInserts.Add(insert);
            }

            return plannedInserts;
        }

        public async Task<List<string>> CreateHardStops()
        {
            string insertTemplate = "insert into depot_diary_event(DDE_DATE, DDE_DEPOT_REFERENCE, DDE_ENTRY_TYPE, DDE_EMP_ENTERED_BY, DDE_WHEN_ENTERED, DDE_START_HR, DDE_END_HR, DDE_DIARY_REF) values ('{0}', {1}, 'H', 8314, sysdate, '{2}', '{3}', diary_seq.nextval);";
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            List<HardStop> hardStopInserts = new List<HardStop>();
            List<string> hardStopInsertsString = new List<string>();

            string path = @"c:\pch\Hard_stop_schedule_2024.xlsx";
            FileInfo fileInfo = new FileInfo(path);

            ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

            int rows = worksheet.Dimension.Rows;
            int columns = worksheet.Dimension.Columns;
            for(int c = 4; c <= columns; c += 5)
            {
                for (int i = 1; i <= rows; i++)
                {
                    if (worksheet.Cells[i, c].Value != null)
                    {
                        var newHardStop = new HardStop
                        {
                            Day = worksheet.Cells[i, c-3].Value.ToString(),
                            StopDate = DateTime.Parse(worksheet.Cells[i, c-2].Value.ToString()),
                            Times = worksheet.Cells[i, c-1].Value.ToString(),
                            Depot = worksheet.Cells[i, c].Value.ToString()
                        };

                        hardStopInserts.Add(newHardStop);
                    }
                }
            }

            foreach (var hardStop in hardStopInserts)
            {
                hardStopInsertsString.Add(string.Format(insertTemplate, hardStop.StopDate.ToString("dd-MMM-yy"), depots[hardStop.Depot], hardStop.StartTime, hardStop.StopTime));
            }

            return hardStopInsertsString;
        }
    }
}
