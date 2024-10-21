// See https://aka.ms/new-console-template for more information
using FoundryRulesAndUnits.Extensions;
using ItemClassGenerator.Models;
using ItemClassGenerator.Reader;

"".WriteInfo();
"Getting Started with c# item class generator".WriteSuccess();

var root = Directory.GetCurrentDirectory();
root.WriteSuccess();

var batch = new BatchTools();
batch.BatchConsumeExcel("Input");


// var dto = new ItemTypeSchema();

// ReflectionPropertyReporter.ReportProperties<ItemTypeSchema>(dto).WriteNote();


// var gen = new ArasItemGenerator();
// var result = gen.GenerateItemClass("RepairableUnit", dto);

// result.WriteSuccess(2);




