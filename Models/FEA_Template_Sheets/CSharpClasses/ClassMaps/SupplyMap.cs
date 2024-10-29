using CsvHelper.Configuration;

namespace GeneratedClasses
{
    public class SupplyMap : ClassMap<Supply>
    {
        public SupplyMap()
        {
            Map(m => m.InitialBinCost).Name("Initial Bin Cost");
            Map(m => m.RecurringBinCost).Name("Recurring Bin Cost");
            Map(m => m.HoldCostFraction).Name("Hold Cost Fraction");
            Map(m => m.CostPerRequisition).Name("Cost Per Requisition");
            Map(m => m.InitialCatalogingCost).Name("Initial Cataloging Cost");
            Map(m => m.RecurringCatalogingCost).Name("Recurring Cataloging Cost");
            Map(m => m.ProcurementLeadTime).Name("Procurement Lead Time");
            Map(m => m.TechnicalDocumentationCostPerPage).Name("Technical Documentation Cost Per Page");
            Map(m => m.DiscountRate).Name("Discount Rate");
            Map(m => m.WholesaleFillRate).Name("Wholesale Fill Rate");
        }
    }
}
