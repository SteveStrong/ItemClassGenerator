using CsvHelper.Configuration;

namespace GeneratedClasses
{
    public class RepairPlacementMap : ClassMap<RepairPlacement>
    {
        public RepairPlacementMap()
        {
            Map(m => m.EndItemRepairOrg).Name("End Item Repair - ORG");
            Map(m => m.EndItemRepairDsu).Name("End Item Repair - DSU");
            Map(m => m.EndItemRepairGsu).Name("End Item Repair - GSU");
            Map(m => m.EndItemRepairDepot).Name("End Item Repair - DEPOT");
            Map(m => m.EndItemRepairContractor).Name("End Item Repair -  Contractor");
            Map(m => m.LruRepairOrg).Name("LRU Repair - ORG");
            Map(m => m.LruRepairDsu).Name("LRU Repair - DSU");
            Map(m => m.LruRepairGsu).Name("LRU Repair - GSU");
            Map(m => m.LruRepairDepot).Name("LRU Repair - DEPOT");
            Map(m => m.LruRepairContractor).Name("LRU Repair - Contractor");
            Map(m => m.SruRepairOrg).Name("SRU Repair - ORG");
            Map(m => m.SruRepairDsu).Name("SRU Repair - DSU");
            Map(m => m.SruRepairGsu).Name("SRU Repair - GSU");
            Map(m => m.SruRepairDepot).Name("SRU Repair - DEPOT");
            Map(m => m.SruRepairContractor).Name("SRU Repair -  Contractor");
        }
    }
}
