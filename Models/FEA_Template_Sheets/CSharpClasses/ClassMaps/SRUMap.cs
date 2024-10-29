using CsvHelper.Configuration;

namespace GeneratedClasses
{
    public class SRUMap : ClassMap<SRU>
    {
        public SRUMap()
        {
            Map(m => m.Id).Name("ID");
            Map(m => m.Name).Name("Name");
            Map(m => m.Cage).Name("CAGE");
            Map(m => m.PartNumber).Name("Part Number");
            Map(m => m.HasNsn).Name("Has NSN");
            Map(m => m.NsnOrNiin).Name("NSN or NIIN");
            Map(m => m.Lcn).Name("LCN");
            Map(m => m.SmrCode).Name("SMR Code");
            Map(m => m.UnitPrice).Name("Unit Price");
            Map(m => m.Weight).Name("Weight");
            Map(m => m.FalseRemovalRate).Name("False Removal Rate");
            Map(m => m.WashoutRate).Name("Washout Rate");
            Map(m => m.AveragePriceOfPieceParts).Name("Average Price of Piece Parts");
            Map(m => m.NumberOfPartsNeedingNsn).Name("Number of Parts Needing NSN");
            Map(m => m.ParentlruId).Name("ParentLRU ID");
            Map(m => m.Mtbf).Name("MTBF");
            Map(m => m.TurnAroundTimeOrg).Name("Turn Around Time - ORG");
            Map(m => m.TurnAroundTimeDsu).Name("Turn Around Time - DSU");
            Map(m => m.TurnAroundTimeGsu).Name("Turn Around Time - GSU");
            Map(m => m.TurnAroundTimeDepot).Name("Turn Around Time - DEPOT");
            Map(m => m.Mttr).Name("MTTR");
            Map(m => m.TechnicalDocumentationPages).Name("Technical Documentation Pages");
            Map(m => m.TpsDevelopmentCost).Name("TPS Development Cost");
            Map(m => m.AnnualTpsMaintenanceCost).Name("Annual TPS Maintenance Cost");
            Map(m => m.DiagnosticTime).Name("Diagnostic Time");
            Map(m => m.ContractorRepairConsidered).Name("Contractor Repair Considered");
            Map(m => m.ContractorWashoutRate).Name("Contractor Washout Rate");
            Map(m => m.ContractorOneTimeInstallCost).Name("Contractor One Time Install Cost");
            Map(m => m.ContractorDiagnosticCost).Name("Contractor Diagnostic Cost");
            Map(m => m.ContractorRepairCost).Name("Contractor Repair Cost");
            Map(m => m.ContractorResponseTime).Name("Contractor Response Time");
            Map(m => m.ContractorShipEchelon).Name("Contractor Ship Echelon");
            Map(m => m.ContractorReceiveEchelon).Name("Contractor Receive Echelon");
        }
    }
}
