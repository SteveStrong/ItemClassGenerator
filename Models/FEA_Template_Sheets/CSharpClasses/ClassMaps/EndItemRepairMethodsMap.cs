using CsvHelper.Configuration;

namespace GeneratedClasses
{
    public class EndItemRepairMethodsMap : ClassMap<EndItemRepairMethods>
    {
        public EndItemRepairMethodsMap()
        {
            Map(m => m.EndItemName).Name("End Item Name");
            Map(m => m.ResourceId).Name("Resource ID");
            Map(m => m.ResourceName).Name("Resource Name");
            Map(m => m.ResourceUtilizationTime).Name("Resource Utilization Time");
        }
    }
}
