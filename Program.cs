// See https://aka.ms/new-console-template for more information
using System.Data;
using FoundryRulesAndUnits.Extensions;
using ItemClassGenerator.Reader;
using ClosedXML.Excel;



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

// Add some sample data to the DataSet
AddDataToDataSet(dataSet);

// Write the DataSet to a multi-tab Excel file
WriteDataSetToExcel(dataSet, "output.xlsx");



static void AddDataToDataSet(DataSet dataSet)
{
    // Add a table for sales data
    DataTable salesData = new DataTable("Support Equipment");
    salesData.Columns.Add("Support Equipment ID", typeof(string));
    salesData.Columns.Add("Support Equipment Name", typeof(string));
    salesData.Columns.Add("Life", typeof(string));

    salesData.Rows.Add("Support Equipment ID", "Support Equipment Name", "Life");
    salesData.Rows.Add("se-1", "AN/PSM-45", "10");

    dataSet.Tables.Add(salesData);

    // Add a table for inventory data
    DataTable inventoryData = new DataTable("Personnel");
    inventoryData.Columns.Add("Product", typeof(string));
    inventoryData.Columns.Add("Stock", typeof(int));
    inventoryData.Rows.Add("Widget A", 250);
    inventoryData.Rows.Add("Widget B", 175);
    inventoryData.Rows.Add("Widget C", 100);
    dataSet.Tables.Add(inventoryData);
}

static void WriteDataSetToExcel(DataSet dataSet, string fileName)
{
    try
    {
        using (var workbook = new XLWorkbook())
        {
            // Loop through each table in the DataSet
            foreach (DataTable table in dataSet.Tables)
            {
                // Add a new worksheet for each table
                var worksheet = workbook.Worksheets.Add(table.TableName);

                // Write the table data to the worksheet
                worksheet.Cell(1, 1).InsertData(table.Rows);
            }

            // Save the workbook to a file
            workbook.SaveAs(fileName);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error writing DataSet to Excel: {ex.Message}");
    }
}