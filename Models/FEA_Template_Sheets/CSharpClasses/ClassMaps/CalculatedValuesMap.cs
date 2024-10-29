using CsvHelper.Configuration;

namespace GeneratedClasses
{
    public class CalculatedValuesMap : ClassMap<CalculatedValues>
    {
        public CalculatedValuesMap()
        {
            Map(m => m.PresentValueFactor).Name("Present Value Factor");
            Map(m => m.BinCostPvf).Name("Bin Cost (PVF)");
            Map(m => m.HoldingFactorPvf).Name("Holding Factor (PVF)");
            Map(m => m.CatalogingCostPvf).Name("Cataloging Cost (PVF)");
            Map(m => m.EffectiveCommonLaborOrg).Name("Effective Common Labor - ORG");
            Map(m => m.EffectiveCommonLaborDsu).Name("Effective Common Labor - DSU");
            Map(m => m.EffectiveCommonLaborGsu).Name("Effective Common Labor - GSU");
            Map(m => m.EffectiveCommonLaborDepot).Name("Effective Common Labor - DEPOT");
            Map(m => m.TransportationCostPvfOrgToDsu).Name("Transportation Cost (PVF) - ORG to DSU");
            Map(m => m.TransportationCostPvfDsuToGsu).Name("Transportation Cost (PVF) - DSU to GSU");
            Map(m => m.TransportationCostPvfGsuToDepot).Name("Transportation Cost (PVF) - GSU to DEPOT");
            Map(m => m.EndItemUnitPricePvf).Name("End Item Unit Price (PVF)");
            Map(m => m.InherentAvailability).Name("Inherent Availability");
            Map(m => m.DerivedMtbf).Name("Derived MTBF");
            Map(m => m.FailureDensityPerYear).Name("Failure Density per Year");
        }
    }
}
