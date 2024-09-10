using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class RepairableUnitCsvReader
{
    public List<RepairableUnitDTO> ReadCsvFile(string filePath)
    {
        var repairableUnits = new List<RepairableUnitDTO>();

        using (var reader = new StreamReader(filePath))
        {
            // Skip the header row
            reader.ReadLine();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var values = line.Split(',');
                var dto = new RepairableUnitDTO
                {
                    CageCode = values[0],
                    Classification = values[1],
                    CompleteItemName = values[2],
                    FederalSupplyClassification = values[3],
                    ManufacturerPartNumber = values[4],
                    MeanTimeBetweenFailures = values[5],
                    NationalIdItemNumber = values[6],
                    ProductionLeadTime = ParseDecimal(values[7]),
                    QuantityPerEndItem = ParseInt(values[8]),
                    ShelfLife = values[9],
                    UnitOfIssue = values[10],
                    UnitPrice = ParseDecimal(values[11]),
                    ConfigId = values[12],
                    CreatedById = values[13],
                   // CreatedOn = ParseDateTime(values[14]),
                    CurrentState = values[15],
                    Id = values[16],
                    IsCurrent = ParseBool(values[17]),
                    IsReleased = ParseBool(values[18]),
                    KeyedName = values[19],
                    LockedById = values[20],
                    MajorRev = values[21],
                    ManagedById = values[22],
                    MinorRev = values[23],
                    ModifiedById = values[24],
                   // ModifiedOn = ParseDateTime(values[25]),
                    NewVersion = ParseBool(values[26]),
                    NotLockable = ParseBool(values[27]),
                    OwnedById = values[28],
                    PermissionId = values[29],
                    State = values[30],
                    TeamId = values[31],
                    TotalQuantityRecommended = ParseInt(values[32])
                };

                repairableUnits.Add(dto);
            }
        }

        return repairableUnits;
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