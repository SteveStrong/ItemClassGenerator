﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Getting Started with c# item class generator");

var reader = new RepairableUnitCsvReader();
var repairableUnits = reader.ReadCsvFile("path/to/your/file.csv");
