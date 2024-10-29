using CsvHelper.Configuration;

namespace GeneratedClasses
{
    public class SRURepairMethodsMap : ClassMap<SRURepairMethods>
    {
        public SRURepairMethodsMap()
        {
            Map(m => m.SruId).Name("SRU ID");
            Map(m => m.SruName).Name("SRU Name");
            Map(m => m.ResourceId).Name("Resource Id");
            Map(m => m.ResourceName).Name("Resource Name");
            Map(m => m.ResourceUtilizationTime).Name("Resource Utilization Time");
        }
    }
}
