using CsvHelper.Configuration;

namespace GeneratedClasses
{
    public class GlobalSettingsMap : ClassMap<GlobalSettings>
    {
        public GlobalSettingsMap()
        {
            Map(m => m.ContractorRepair).Name("Contractor Repair");
            Map(m => m.RedundantLrus).Name("Redundant LRUs");
            Map(m => m.OrgLabel).Name("ORG Label");
            Map(m => m.DsuLabel).Name("DSU Label");
            Map(m => m.GsuLabel).Name("GSU Label");
            Map(m => m.DepotLabel).Name("Depot Label");
            Map(m => m.EndItemLabel).Name("End Item Label");
            Map(m => m.LruLabel).Name("LRU Label");
            Map(m => m.SruLabel).Name("SRU Label");
            Map(m => m.TurnAroundTimeOrg).Name("Turn Around Time - ORG");
            Map(m => m.TurnAroundTimeDsu).Name("Turn Around Time - DSU");
            Map(m => m.TurnAroundTimeGsu).Name("Turn Around Time - GSU");
            Map(m => m.TurnAroundTimeDepot).Name("Turn Around Time - DEPOT");
            Map(m => m.ClassificationLevel).Name("Classification Level");
        }
    }
}
