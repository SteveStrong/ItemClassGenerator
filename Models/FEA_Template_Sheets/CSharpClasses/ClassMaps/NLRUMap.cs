using CsvHelper.Configuration;

namespace GeneratedClasses
{
    public class NLRUMap : ClassMap<NLRU>
    {
        public NLRUMap()
        {
            Map(m => m.Id).Name("ID");
            Map(m => m.Name).Name("Name");
            Map(m => m.Cage).Name("CAGE");
            Map(m => m.PartNumber).Name("Part Number");
            Map(m => m.NsnOrNiin).Name("NSN or NIIN");
            Map(m => m.Lcn).Name("LCN");
            Map(m => m.SmrCode).Name("SMR Code");
            Map(m => m.NumberOfParts).Name("Number of Parts");
            Map(m => m.NumberNeedingNsn).Name("Number Needing NSN");
            Map(m => m.FalseRemovalRate).Name("False Removal Rate");
            Map(m => m.Mtbf).Name("MTBF");
            Map(m => m.AverageReplacementPrice).Name("Average Replacement Price");
            Map(m => m.AverageReplacementWeight).Name("Average Replacement Weight");
            Map(m => m.EndItemPeculiarRepair).Name("End Item Peculiar Repair?");
            Map(m => m.MttrWithPeculiarRepair).Name("MTTR with Peculiar Repair");
            Map(m => m.Redundancy).Name("Redundancy");
            Map(m => m.NumberRedundant).Name("Number Redundant");
            Map(m => m.NumberRedundantRequired).Name("Number Redundant Required");
            Map(m => m.IssueEiFloat).Name("Issue EI Float");
            Map(m => m.IsMultipleInstance).Name("Is Multiple Instance");
            Map(m => m.NumberOfInstances).Name("Number of Instances");
        }
    }
}
