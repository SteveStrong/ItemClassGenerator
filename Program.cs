// See https://aka.ms/new-console-template for more information
using FoundryRulesAndUnits.Extensions;
using ItemClassGenerator.Models;
using ItemClassGenerator.Reader;

"".WriteInfo();
"Getting Started with c# item class generator".WriteSuccess();


var data = "CageCode,Classification,CompleteItemName,FederalSupplyClassification,ManufacturerPartNumber,MeanTimeBetweenFailures,NationalIdItemNumber,ProductionLeadTime,QuantityPerEndItem,ShelfLife,UnitOfIssue,UnitPrice,ConfigId,CreatedById,CreatedOn,CurrentState,Id,IsCurrent,IsReleased,KeyedName,LockedById,MajorRev,ManagedById,MinorRev,ModifiedById,ModifiedOn,NewVersion,NotLockable,OwnedById,PermissionId,State,TeamId,TotalQuantityRecommended\n";

var data1 = "complete_item_name,Description,Foreign,manufacturer_part_number,,,,FALSE,FALSE,FALSE,FALSE,FALSE,FALSE,Left,225,3200,,,,,,,name,,,FALSE,Float";

var reader = new RepairableUnitCsvReader();
var dto = reader.ProcessLineOfData(data1);

$"DTO: {dto}".WriteInfo();


ReflectionPropertyReporter.ReportProperties<RepairableUnitDTO>(dto).WriteNote();


var gen = new ArasItemGenerator();
var result = gen.GenerateItemClass("RepairableUnit", dto);

result.WriteSuccess(2);




// var sourceFolder = "Testing";

// var root = Directory.GetCurrentDirectory();

// $"sourceFolder: {sourceFolder}".WriteInfo();

// var batch = new BatchTools();

// var files = batch.GetSourceExcelFiles(sourceFolder);
// foreach (var item in files)
// {
//     $"Folder: {item.Folder} Filename: {item.Filename}".WriteInfo();
// }

//var reader = new RepairableUnitCsvReader();
//var repairableUnits = reader.ReadCsvFile("path/to/your/file.csv");
