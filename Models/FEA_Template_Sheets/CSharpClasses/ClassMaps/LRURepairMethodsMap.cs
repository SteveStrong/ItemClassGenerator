using CsvHelper.Configuration;

namespace GeneratedClasses
{
    public class LRURepairMethodsMap : ClassMap<LRURepairMethods>
    {
        public LRURepairMethodsMap()
        {
            Map(m => m.LruId).Name("LRU ID");
            Map(m => m.LruName).Name("LRU Name");
            Map(m => m.PeculiarRepair).Name("Peculiar Repair?");
            Map(m => m.ResourceId).Name("Resource ID");
            Map(m => m.ResourceName).Name("Resource Name");
            Map(m => m.ResourceUtilizationTime).Name("Resource Utilization Time");
        }
    }
}
