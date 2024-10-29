// See https://aka.ms/new-console-template for more information
using System.Data;
using FoundryRulesAndUnits.Extensions;
using ItemClassGenerator.Reader;
using ItemClassGenerator.Generators;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using FEA_Template;

// "".WriteInfo();
// "Getting Started with c# item class generator".WriteSuccess();

// var root = Directory.GetCurrentDirectory();
// root.WriteSuccess();

// var batch = new BatchTools();
// var inputs = batch.BatchConsumeExcel("Input");

// var gen = new ArasItemGenerator();
// foreach (var input in inputs)
// {

//     "......................".WriteInfo();
//     "Generating item class".WriteInfo();
//     var result = gen.GenerateItemClass("RepairableUnit", input.ItemType);
//     batch.WriteData("Output", "RepairableUnit.cs.txt", result);
// }



// //here is an example for writing a dataset to excel
// //this could help in writing the FEA_Template file to excel

// DataSet dataSet = new DataSet();

// var compass = new CompassGenerator();
// compass.AddDataToDataSet(dataSet);
// compass.WriteDataSetToExcel(dataSet, "output.xlsx");


namespace RebuildExcelFromCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            string excelOutputPath = "RebuiltWorkbook.xlsx";

            FEATemplate template = new FEATemplate();

            string csvDirectory = @"C:\Dev\ItemClassGenerator\Models\FEA_Template_Sheets\CSVSaves";

            var csvFiles = Directory.GetFiles(csvDirectory, "*.csv");

            foreach (var csvFile in csvFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(csvFile);

                var recordType = Type.GetType($"GeneratedClasses.{fileName}");

                if (recordType == null)
                {
                    Console.WriteLine($"Class {fileName} not found.");
                    continue;
                }

                var records = ReadCsvFile(csvFile, recordType);

                template.AssignToWorkbookData(recordType, records);
            }

            template.RebuildExcelFile(excelOutputPath);
            Console.WriteLine($"Excel file rebuilt at {excelOutputPath}");

            // Mapper example
            // Create instances of the two external classes
            // var external1 = new ExternalClass1
            // {
            //     arasProp1 = "SRU123",
            //     arasProp2 = "Standard Repair Unit A"
            // };

            // var external2 = new ExternalClass2
            // {
            //     arasProp1 = "RES456",
            //     arasProp2 = "Resource X",
            //     arasProp3 = "5 Hours"
            // };

            // var sruRepairMethods = new SRURepairMethods();

            // // Map from ExternalClass1
            // sruRepairMethods = Mapper.MapFromSource(external1, sruRepairMethods);

            // // Map from ExternalClass2
            // sruRepairMethods = Mapper.MapFromSource(external2, sruRepairMethods);

            // // Display the mapped SRURepairMethods object
            // Console.WriteLine($"SRU ID: {sruRepairMethods.SruId}");
            // Console.WriteLine($"SRU Name: {sruRepairMethods.SruName}");
            // Console.WriteLine($"Resource ID: {sruRepairMethods.ResourceId}");
            // Console.WriteLine($"Resource Name: {sruRepairMethods.ResourceName}");
            // Console.WriteLine($"Resource Utilization Time: {sruRepairMethods.ResourceUtilizationTime}");
        }

        static IList<object> ReadCsvFile(string filePath, Type recordType)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                string classMapName = $"GeneratedClasses.{recordType.Name}Map";
                var classMapType = Type.GetType(classMapName);

                if (classMapType == null)
                {
                    Console.WriteLine($"Error: Class map for {recordType.Name} not found. Expected type: {classMapName}");
                    return new List<object>();
                }

                csv.Context.RegisterClassMap(classMapType);

                var records = csv.GetRecords(recordType).ToList();

                Console.WriteLine($"Successfully read {records.Count} records for {recordType.Name}.");

                return records.Cast<object>().ToList();
            }
        }






    }
}
