// See https://aka.ms/new-console-template for more information
using FoundryRulesAndUnits.Extensions;
using ItemClassGenerator.Reader;

Console.WriteLine("Getting Started with c# item class generator");

var sourceFolder = "Testing";
var root = Directory.GetCurrentDirectory();

var batch = new BatchTools();

var files = batch.GetSourceExcelFiles(sourceFolder);
foreach (var item in files)
{
    $"Folder: {item.Folder} Filename: {item.Filename}".WriteInfo();
}

//var reader = new RepairableUnitCsvReader();
//var repairableUnits = reader.ReadCsvFile("path/to/your/file.csv");
