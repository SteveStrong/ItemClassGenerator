using CsvHelper.Configuration;

namespace GeneratedClasses
{
    public class EndItemMap : ClassMap<EndItem>
    {
        public EndItemMap()
        {
            Map(m => m.Name).Name("Name");
            Map(m => m.CageCode).Name("CAGE Code");
            Map(m => m.PartNumber).Name("Part Number:");
            Map(m => m.NsnOrNiin).Name("NSN or NIIN");
            Map(m => m.SmrCode).Name("SMR Code");
            Map(m => m.Lcn).Name("LCN");
            Map(m => m.Life).Name("Life");
            Map(m => m.UnitPrice).Name("Unit Price ($)");
            Map(m => m.PackagedWeight).Name("Packaged Weight");
            Map(m => m.NumberOfSystems).Name("Number of Systems");
            Map(m => m.AnnualOperatingHours).Name("Annual Operating Hours");
            Map(m => m.AvailabilityTarget).Name("Availability Target");
            Map(m => m.Mtbf).Name("MTBF");
            Map(m => m.DsDelayCost).Name("DS Delay Cost");
            Map(m => m.DsDelayTime).Name("DS Delay Time");
            Map(m => m.IsAnAssembly).Name("Is An Assembly");
            Map(m => m.AdditionalDiscards).Name("% Additional Discards");
            Map(m => m.Mttr).Name("MTTR");
            Map(m => m.DiagnosticTime).Name("Diagnostic Time");
            Map(m => m.NumberOfPages).Name("Number of Pages");
            Map(m => m.TpsDevelopmentCost).Name("TPS Development Cost");
            Map(m => m.AnnualTpsMaintenanceCost).Name("Annual TPS Maintenance Cost");
            Map(m => m.NumberOfShopsOrg).Name("Number of Shops - ORG");
            Map(m => m.NumberOfShopsDsu).Name("Number of Shops - DSU");
            Map(m => m.NumberOfShopsGsu).Name("Number of Shops - GSU");
            Map(m => m.TatOrg).Name("TAT - ORG");
            Map(m => m.TatDsu).Name("TAT - DSU");
            Map(m => m.TatGsu).Name("TAT - GSU");
            Map(m => m.TatDepot).Name("TAT - DEPOT");
            Map(m => m.ContractorRepair).Name("Contractor Repair");
            Map(m => m.ContractorWashoutRate).Name("Contractor Washout Rate");
            Map(m => m.ContractorOneTimeInstallCost).Name("Contractor - One Time Install Cost");
            Map(m => m.ContractorCostPerFailure).Name("Contractor - Cost Per Failure");
            Map(m => m.ContractorDiagnosticCost).Name("Contractor - Diagnostic Cost");
            Map(m => m.ContractorResponseTime).Name("Contractor - Response Time");
            Map(m => m.ShipToContractor).Name("Ship To Contractor");
            Map(m => m.ReceivedFromContractor).Name("Received From Contractor");
            Map(m => m.EndItemFloats).Name("End Item Floats");
            Map(m => m.EndItemFloatSpecialOrderShipTime).Name("End Item Float - Special Order Ship Time");
            Map(m => m.EndItemFloatMeanTimeToInstall).Name("End Item Float - Mean Time To Install");
            Map(m => m.EndItemFloatIssueEchelon).Name("End Item Float - Issue Echelon");
            Map(m => m.EndItemFloatRepairEchelon).Name("End Item Float - Repair Echelon");
        }
    }
}
