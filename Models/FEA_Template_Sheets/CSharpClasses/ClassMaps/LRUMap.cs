using CsvHelper.Configuration;

namespace GeneratedClasses
{
    public class LRUMap : ClassMap<LRU>
    {
        public LRUMap()
        {
            Map(m => m.Id).Name("ID");
            Map(m => m.Name).Name("Name");
            Map(m => m.Cage).Name("CAGE");
            Map(m => m.PartNumber).Name("Part Number");
            Map(m => m.LruHasNsn).Name("LRU Has NSN");
            Map(m => m.NsnOrNiin).Name("NSN or NIIN");
            Map(m => m.Lcn).Name("LCN");
            Map(m => m.SmrCode).Name("SMR Code");
            Map(m => m.UnitPrice).Name("Unit Price");
            Map(m => m.PackagedWeight).Name("Packaged Weight");
            Map(m => m.FalseRemovalRate).Name("False Removal Rate");
            Map(m => m.WashoutRate).Name("Washout Rate");
            Map(m => m.Mtbf).Name("MTBF");
            Map(m => m.Mttr).Name("MTTR");
            Map(m => m.DiagnosisTime).Name("Diagnosis Time");
            Map(m => m.TatOrg).Name("TAT - ORG");
            Map(m => m.TatDsu).Name("TAT - DSU");
            Map(m => m.TatGsu).Name("TAT - GSU");
            Map(m => m.TatDepot).Name("TAT - DEPOT");
            Map(m => m.IssueFloat).Name("Issue Float");
            Map(m => m.PeculiarRepair).Name("Peculiar Repair?");
            Map(m => m.PeculiarRepairMttr).Name("Peculiar Repair MTTR");
            Map(m => m.Redundancy).Name("Redundancy");
            Map(m => m.NumberRedundant).Name("Number Redundant");
            Map(m => m.MinOperable).Name("Min Operable");
            Map(m => m.TechnicalDocumentationPages).Name("Technical Documentation (pages)");
            Map(m => m.TpsDevelopmentCost).Name("TPS Development Cost");
            Map(m => m.AnnualTpsMaintenanceCost).Name("Annual TPS Maintenance Cost");
            Map(m => m.ContractorRepairConsidered).Name("Contractor Repair Considered");
            Map(m => m.ContractorWashoutRate).Name("Contractor Washout Rate");
            Map(m => m.ContractorOneTimeInstallCost).Name("Contractor One Time Install Cost");
            Map(m => m.ContractorDiagnosticCost).Name("Contractor Diagnostic Cost");
            Map(m => m.ContractorRepairCost).Name("Contractor Repair Cost");
            Map(m => m.ContractorTurnAroundTime).Name("Contractor Turn Around Time");
            Map(m => m.ContractorShipEchelon).Name("Contractor Ship Echelon");
            Map(m => m.ContractorReceiveEchelon).Name("Contractor Receive Echelon");
            Map(m => m.IsMultipleInstance).Name("Is Multiple Instance");
            Map(m => m.NumberOfInstances).Name("Number of Instances");
        }
    }
}
