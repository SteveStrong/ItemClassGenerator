using System;
using System.Collections.Generic;
using ClosedXML.Excel;
using Newtonsoft.Json;
using GeneratedClasses;

namespace FEA_Template
{
    public class FEATemplate
    {
        Dictionary<string, OriginalSheetInfo> OriginalNames = LoadOriginalNames("./Models/FEA_Template_Sheets/CSharpClasses/original_names.json");
        public List<SupportEquipment> SupportEquipmentList { get; set; } = new List<SupportEquipment>();
        public List<Personnel> PersonnelList { get; set; } = new List<Personnel>();
        public List<RepairPlacement> RepairPlacementList { get; set; } = new List<RepairPlacement>();
        public List<EndItem> EndItemList { get; set; } = new List<EndItem>();
        public List<GlobalSettings> GlobalSettingsList { get; set; } = new List<GlobalSettings>();
        public List<LRU> LRUList { get; set; } = new List<LRU>();
        public List<NLRU> NLRUList { get; set; } = new List<NLRU>();
        public List<SRU> SRUList { get; set; } = new List<SRU>();
        public List<NSRU> NSRUList { get; set; } = new List<NSRU>();
        public List<EndItemRepairMethods> EndItemRepairMethodsList { get; set; } = new List<EndItemRepairMethods>();
        public List<LRURepairMethods> LRURepairMethodsList { get; set; } = new List<LRURepairMethods>();
        public List<SRURepairMethods> SRURepairMethodsList { get; set; } = new List<SRURepairMethods>();
        public List<Transportation> TransportationList { get; set; } = new List<Transportation>();
        public List<CommonLabor> CommonLaborList { get; set; } = new List<CommonLabor>();
        public List<Supply> SupplyList { get; set; } = new List<Supply>();
        public List<CalculatedValues> CalculatedValuesList { get; set; } = new List<CalculatedValues>();
        public class OriginalSheetInfo
        {
            [JsonProperty("original_sheet_name")]
            public required string OriginalSheetName { get; set; }

            [JsonProperty("original_columns")]
            public required List<string> OriginalColumns { get; set; }
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
        public void RebuildExcelFile(string outputPath)
        {
            using (var workbook = new XLWorkbook())
            {
                foreach (var sheetEntry in OriginalNames)
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

                    var workbookDataType = this.GetType();
                    var listProperty = workbookDataType.GetProperty($"{sheetName}List");

                    if (listProperty != null)
                    {
                        var dataList = listProperty.GetValue(this) as IEnumerable<object>;
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
        public void AssignToWorkbookData(Type recordType, IList<object> records)
        {
            var property = this.GetType().GetProperty($"{recordType.Name}List");

            if (property != null)
            {
                var typedList = typeof(List<>).MakeGenericType(recordType);
                var typedRecords = Activator.CreateInstance(typedList);

                foreach (var record in records)
                {
                    typedList.GetMethod("Add")?.Invoke(typedRecords, new[] { record });
                }

                property.SetValue(this, typedRecords);
            }
            else
            {
                Console.WriteLine($"Error: Property {recordType.Name}List not found in WorkbookData.");
            }
        }
    }
}
