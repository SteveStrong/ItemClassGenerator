using CsvHelper.Configuration;

namespace GeneratedClasses
{
    public class SupportEquipmentMap : ClassMap<SupportEquipment>
    {
        public SupportEquipmentMap()
        {
            Map(m => m.SupportEquipmentId).Name("Support Equipment ID");
            Map(m => m.SupportEquipmentName).Name("Support Equipment Name");
            Map(m => m.Life).Name("Life");
            Map(m => m.DevelopmentCost).Name("Development Cost");
            Map(m => m.RepairOnly).Name("Repair Only");
            Map(m => m.LowestLevelAuthorized).Name("Lowest Level Authorized");
            Map(m => m.UnitPriceOrg).Name("Unit Price - ORG");
            Map(m => m.UnitPriceDsu).Name("Unit Price - DSU");
            Map(m => m.UnitPriceGsu).Name("Unit Price - GSU");
            Map(m => m.UnitPriceDepot).Name("Unit Price - DEPOT");
            Map(m => m.InstallationCostOrg).Name("Installation Cost - ORG");
            Map(m => m.InstallationCostDsu).Name("Installation Cost - DSU");
            Map(m => m.InstallationCostGsu).Name("Installation Cost - GSU");
            Map(m => m.InstallationCostDepot).Name("Installation Cost - DEPOT");
            Map(m => m.AnnualMaintenanceCostOrg).Name("Annual Maintenance Cost - ORG");
            Map(m => m.AnnualMaintenanceCostDsu).Name("Annual Maintenance Cost - DSU");
            Map(m => m.AnnualMaintenanceCostGsu).Name("Annual Maintenance Cost - GSU");
            Map(m => m.AnnualMaintenanceCostDepot).Name("Annual Maintenance Cost - DEPOT");
            Map(m => m.AnnualAvailableHoursOrg).Name("Annual Available Hours - ORG");
            Map(m => m.AnnualAvailableHoursDsu).Name("Annual Available Hours - DSU");
            Map(m => m.AnnualAvailableHoursGsu).Name("Annual Available Hours - GSU");
            Map(m => m.AnnualAvailableHoursDepot).Name("Annual Available Hours - DEPOT");
            Map(m => m.LowestLevelCommon).Name("Lowest Level Common");
            Map(m => m.EquipmentCostInPvfOrg).Name("Equipment Cost in PVF - ORG");
            Map(m => m.EquipmentCostInPvfDsu).Name("Equipment Cost in PVF - DSU");
            Map(m => m.EquipmentCostInPvfGsu).Name("Equipment Cost in PVF - GSU");
            Map(m => m.EquipmentCostInPvfDepot).Name("Equipment Cost in PVF - DEPOT");
        }
    }
}
