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
using ClosedXML.Excel;
using GeneratedClasses;
using Newtonsoft.Json;
using ExternalLibrary;

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
            string jsonFilePath = @"C:\Dev\ItemClassGenerator\Models\FEA_Template_Sheets\CSharpClasses\original_names.json";

            var originalNames = LoadOriginalNames(jsonFilePath);

            WorkbookData workbookData = new WorkbookData();

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

                AssignToWorkbookData(workbookData, recordType, records);
            }

            RebuildExcelFile(workbookData, excelOutputPath, originalNames);
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

            // // Create an empty instance of SRURepairMethods
            // var sruRepairMethods = new SRURepairMethods();

            // // Create instances of the mappers
            // var mapper1 = new ExternalClass1ToSRURepairMethodsMap();
            // var mapper2 = new ExternalClass2ToSRURepairMethodsMap();

            // // Map the values from external classes to SRURepairMethods
            // sruRepairMethods = mapper1.Map(external1, sruRepairMethods);
            // sruRepairMethods = mapper2.Map(external2, sruRepairMethods);

            // // Display the mapped SRURepairMethods object
            // Console.WriteLine($"SRU ID: {sruRepairMethods.SruId}");
            // Console.WriteLine($"SRU Name: {sruRepairMethods.SruName}");
            // Console.WriteLine($"Resource ID: {sruRepairMethods.ResourceId}");
            // Console.WriteLine($"Resource Name: {sruRepairMethods.ResourceName}");
            // Console.WriteLine($"Resource Utilization Time: {sruRepairMethods.ResourceUtilizationTime}");
        }
        public class OriginalSheetInfo
        {
            [JsonProperty("original_sheet_name")]
            public string OriginalSheetName { get; set; }

            [JsonProperty("original_columns")]
            public List<string> OriginalColumns { get; set; }
        }

        public static Dictionary<string, OriginalSheetInfo> LoadOriginalNames(string jsonFilePath)
        {
            try
            {
                var json = File.ReadAllText(jsonFilePath);
                var settings = new JsonSerializerSettings
                {
                    Error = (sender, args) =>
                    {
                        Console.WriteLine($"Deserialization Error: {args.ErrorContext.Error.Message}");
                        args.ErrorContext.Handled = true;
                    }
                };

                var result = JsonConvert.DeserializeObject<Dictionary<string, OriginalSheetInfo>>(json, settings);

                if (result == null)
                {
                    throw new JsonSerializationException("Deserialization resulted in null object");
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading JSON file: {ex.Message}", ex);
            }
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

        static void AssignToWorkbookData(object workbookData, Type recordType, IList<object> records)
        {
            var property = workbookData.GetType().GetProperty($"{recordType.Name}List");

            if (property != null)
            {
                var typedList = typeof(List<>).MakeGenericType(recordType);
                var typedRecords = Activator.CreateInstance(typedList);

                foreach (var record in records)
                {
                    typedList.GetMethod("Add").Invoke(typedRecords, new[] { record });
                }

                property.SetValue(workbookData, typedRecords);
            }
            else
            {
                Console.WriteLine($"Error: Property {recordType.Name}List not found in WorkbookData.");
            }
        }




        static void RebuildExcelFile(WorkbookData workbookData, string outputPath, Dictionary<string, OriginalSheetInfo> originalNames)
        {
            using (var workbook = new XLWorkbook())
            {
                foreach (var sheetEntry in originalNames)
                {
                    var sheetName = sheetEntry.Key;
                    var sheetInfo = sheetEntry.Value;

                    var worksheet = workbook.Worksheets.Add(sheetInfo.OriginalSheetName);

                    int colIndex = 1;
                    foreach (var originalColumnName in sheetInfo.OriginalColumns)
                    {
                        worksheet.Cell(1, colIndex).Value = originalColumnName;
                        colIndex++;
                    }

                    var workbookDataType = workbookData.GetType();
                    var listProperty = workbookDataType.GetProperty($"{sheetName}List");

                    if (listProperty != null)
                    {
                        var dataList = listProperty.GetValue(workbookData) as IEnumerable<object>;
                        if (dataList != null && dataList.Any())
                        {
                            var itemType = dataList.First().GetType();
                            var itemProperties = itemType.GetProperties();

                            int rowIndex = 2;
                            foreach (var item in dataList)
                            {
                                colIndex = 1;
                                foreach (var itemProp in itemProperties)
                                {
                                    var cellValue = itemProp.GetValue(item);

                                    switch (cellValue)
                                    {
                                        case int intValue:
                                            worksheet.Cell(rowIndex, colIndex).Value = intValue;
                                            break;
                                        case double doubleValue:
                                            worksheet.Cell(rowIndex, colIndex).Value = doubleValue;
                                            break;
                                        case bool boolValue:
                                            worksheet.Cell(rowIndex, colIndex).Value = boolValue;
                                            break;
                                        case DateTime dateTimeValue:
                                            worksheet.Cell(rowIndex, colIndex).Value = dateTimeValue;
                                            break;
                                        case null:
                                            worksheet.Cell(rowIndex, colIndex).Value = "";
                                            break;
                                        default:
                                            worksheet.Cell(rowIndex, colIndex).Value = cellValue.ToString();
                                            break;
                                    }

                                    colIndex++;
                                }
                                rowIndex++;
                            }
                        }
                    }
                }

                workbook.SaveAs(outputPath);
            }
        }

    }
}
