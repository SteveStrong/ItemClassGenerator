using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using ItemClassGenerator.Models;

namespace ItemClassGenerator.Reader;

public class RepairableUnitCsvReader
{
    public List<ItemTypeSchema> ReadCsvFile(string filePath)
    {
        var repairableUnits = new List<ItemTypeSchema>();

        using (var reader = new StreamReader(filePath))
        {
            // Skip the header row
            reader.ReadLine();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var dto = ProcessLineOfData(line);

                repairableUnits.Add(dto);
            }
        }

        return repairableUnits;
    }

    public ItemTypeSchema ProcessLineOfData(string line)
    {
        var values = line.Split(',');
        var dto = new ItemTypeSchema
        {
            Name = values[0],
            Label = values[1],
            Data_Type = values[2],
            Data_Source = values[3],
            Length = values[4],
            Precision = values[5],
            Scale = values[6],
            Required = values[7],
            Unique = values[8],
            Indexed = values[9],
        };
        return dto;
    }

    private int? ParseInt(string value)
    {
        return int.TryParse(value, out int result) ? result : (int?)null;
    }

    private decimal? ParseDecimal(string value)
    {
        return decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result) ? result : (decimal?)null;
    }

    private bool? ParseBool(string value)
    {
        return bool.TryParse(value, out bool result) ? result : (bool?)null;
    }

    private DateTime? ParseDateTime(string value)
    {
        return DateTime.TryParse(value, out DateTime result) ? result : (DateTime?)new DateTime();
    }
}