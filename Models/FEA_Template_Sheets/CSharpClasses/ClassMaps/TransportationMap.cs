using CsvHelper.Configuration;

namespace GeneratedClasses
{
    public class TransportationMap : ClassMap<Transportation>
    {
        public TransportationMap()
        {
            Map(m => m.OrderShipTimeOrgDsu).Name("Order Ship Time - ORG-DSU");
            Map(m => m.OrderShipTimeDsuGsu).Name("Order Ship Time - DSU-GSU");
            Map(m => m.OrderShipTimeGsuDepot).Name("Order Ship Time - GSU-DEPOT");
            Map(m => m.CostLbMiOrgDsu).Name("Cost ($/lb*mi) - ORG-DSU");
            Map(m => m.CostLbMiDsuGsu).Name("Cost ($/lb*mi) - DSU-GSU");
            Map(m => m.CostLbMiGsuDepot).Name("Cost ($/lb*mi) - GSU-DEPOT");
            Map(m => m.DistanceMiOrgDsu).Name("Distance (mi) - ORG-DSU");
            Map(m => m.DistanceMiDsuGsu).Name("Distance (mi) - DSU-GSU");
            Map(m => m.DistanceMiGsuDepot).Name("Distance (mi) - GSU-DEPOT");
            Map(m => m.CostLbOrgDsu).Name("Cost ($/lb) - ORG-DSU");
            Map(m => m.CostLbDsuGsu).Name("Cost ($/lb) - DSU-GSU");
            Map(m => m.CostLbGsuDepot).Name("Cost ($/lb) - GSU-DEPOT");
        }
    }
}
