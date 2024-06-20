using DepotDiary.Code;

var fileOps = new FileOperations();
var xlOps = new EppFunctions();

//var res = await xlOps.CreatePlannedInsertsAsync();
//fileOps.WriteFromList(res, @"depot_diary_planned_maint_230320");
//foreach(var item in res)
//{
//    Console.WriteLine(item);
//}

//var ncOps = new NormalClosing();
//var res2 = await ncOps.GenerateNormalClosingAsync();

//fileOps.WriteFromList(res2, @"depot_diary_normal_entries_230320");

var hardStopRes = await xlOps.CreateHardStops();
fileOps.WriteFromList(hardStopRes, @"hard_stop_entries_240620");
