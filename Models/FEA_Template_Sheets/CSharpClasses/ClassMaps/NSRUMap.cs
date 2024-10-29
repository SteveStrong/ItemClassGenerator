using CsvHelper.Configuration;

namespace GeneratedClasses
{
    public class NSRUMap : ClassMap<NSRU>
    {
        public NSRUMap()
        {
            Map(m => m.Id).Name("ID");
            Map(m => m.Name).Name("Name");
            Map(m => m.Cage).Name("CAGE");
            Map(m => m.PartNumber).Name("Part Number");
            Map(m => m.NsnOrNiin).Name("NSN or NIIN");
            Map(m => m.Lcn).Name("LCN");
            Map(m => m.SmrCode).Name("SMR Code");
            Map(m => m.FalseRemovalRate).Name("False Removal Rate");
            Map(m => m.NumberOfParts).Name("Number of Parts");
            Map(m => m.NumberOrPartsNeedingNsn).Name("Number or Parts Needing NSN");
            Map(m => m.TotalPriceOfPartsForAverageReplacement).Name("Total Price of Parts for Average Replacement ($)");
            Map(m => m.WeightOfPartsForAverageReplacementLbs).Name("Weight of Parts for Average Replacement (lbs)");
            Map(m => m.ParentLruId).Name("Parent LRU Id");
            Map(m => m.ParentLruName).Name("Parent LRU Name");
            Map(m => m.Mtbf).Name("MTBF");
        }
    }
}
