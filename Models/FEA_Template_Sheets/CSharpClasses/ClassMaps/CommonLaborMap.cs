using CsvHelper.Configuration;

namespace GeneratedClasses
{
    public class CommonLaborMap : ClassMap<CommonLabor>
    {
        public CommonLaborMap()
        {
            Map(m => m.UnloadedHourlyRateOrg).Name("Unloaded Hourly Rate - ORG");
            Map(m => m.UnloadedHourlyRateDsu).Name("Unloaded Hourly Rate - DSU");
            Map(m => m.UnloadedHourlyRateGsu).Name("Unloaded Hourly Rate - GSU");
            Map(m => m.UnloadedHourlyRateDepot).Name("Unloaded Hourly Rate - DEPOT");
            Map(m => m.ProductivityFactorOrg).Name("Productivity Factor - ORG");
            Map(m => m.ProductivityFactorGsu).Name("Productivity Factor - GSU");
            Map(m => m.ProductivityFactorDsu).Name("Productivity Factor - DSU");
            Map(m => m.ProductivityFactorDepot).Name("Productivity Factor - DEPOT");
            Map(m => m.LoadingFactorOrg).Name("Loading Factor - ORG");
            Map(m => m.LoadingFactorDsu).Name("Loading Factor - DSU");
            Map(m => m.LoadingFactorGsu).Name("Loading Factor - GSU");
            Map(m => m.LoadingFactorDepot).Name("Loading Factor - DEPOT");
            Map(m => m.EffectiveHourlyRateOrg).Name("Effective Hourly Rate - ORG");
            Map(m => m.EffectiveHourlyRateDsu).Name("Effective Hourly Rate - DSU");
            Map(m => m.EffectiveHourlyRateGsu).Name("Effective Hourly Rate - GSU");
            Map(m => m.EffectiveHourlyRateDepot).Name("Effective Hourly Rate - DEPOT");
        }
    }
}
