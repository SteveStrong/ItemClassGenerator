// See https://aka.ms/new-console-template for more information
using System.Data;
using FoundryRulesAndUnits.Extensions;
using ItemClassGenerator.Reader;
using ItemClassGenerator.Generators;



"".WriteInfo();
"Getting Started with c# item class generator".WriteSuccess();

var root = Directory.GetCurrentDirectory();
root.WriteSuccess();

var batch = new BatchTools();
var inputs = batch.BatchConsumeExcel("Input");

var gen = new ArasItemGenerator();
foreach (var input in inputs)
{

    "......................".WriteInfo();
    "Generating item class".WriteInfo();
    var result = gen.GenerateItemClass("RepairableUnit", input.ItemType);
    batch.WriteData("Output", "RepairableUnit.cs.txt", result);
}



//here is an example for writing a dataset to excel
//this could help in writing the FEA_Template file to excel

DataSet dataSet = new DataSet();

var compass = new CompassGenerator();
compass.AddDataToDataSet(dataSet);
compass.WriteDataSetToExcel(dataSet, "output.xlsx");

