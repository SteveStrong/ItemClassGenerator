using CsvHelper.Configuration;

namespace GeneratedClasses
{
    public class PersonnelMap : ClassMap<Personnel>
    {
        public PersonnelMap()
        {
            Map(m => m.PersonnelId).Name("Personnel ID");
            Map(m => m.PersonnelName).Name("Personnel Name");
            Map(m => m.RepairOnly).Name("Repair Only");
            Map(m => m.SalaryOrg).Name("Salary - ORG");
            Map(m => m.SalaryDsu).Name("Salary - DSU");
            Map(m => m.SalaryGsu).Name("Salary - GSU");
            Map(m => m.SalaryDepot).Name("Salary - DEPOT");
            Map(m => m.TrainingCostOrg).Name("Training Cost - ORG");
            Map(m => m.TrainingCostDsu).Name("Training Cost - DSU");
            Map(m => m.TrainingCostGsu).Name("Training Cost - GSU");
            Map(m => m.TrainingCostDepot).Name("Training Cost - DEPOT");
            Map(m => m.LoadingFactorOrg).Name("Loading Factor (%) - ORG");
            Map(m => m.LoadingFactorDsu).Name("Loading Factor (%) - DSU");
            Map(m => m.LoadingFactorGsu).Name("Loading Factor (%) - GSU");
            Map(m => m.LoadingFactorDepot).Name("Loading Factor (%) - DEPOT");
            Map(m => m.TurnoverRateOrg).Name("Turnover Rate - ORG");
            Map(m => m.TurnoverRateDsu).Name("Turnover Rate - DSU");
            Map(m => m.TurnoverRateGsu).Name("Turnover Rate - GSU");
            Map(m => m.TurnoverRateDepot).Name("Turnover Rate - DEPOT");
            Map(m => m.AnnualHoursOrg).Name("Annual Hours - ORG");
            Map(m => m.AnnualHoursDsu).Name("Annual Hours - DSU");
            Map(m => m.AnnualHoursGsu).Name("Annual Hours - GSU");
            Map(m => m.AnnualHoursDepot).Name("Annual Hours - DEPOT");
            Map(m => m.LowestAuthorizedEchelon).Name("Lowest Authorized Echelon");
            Map(m => m.LowestLevelCommon).Name("Lowest Level Common");
            Map(m => m.PersonnelCostOrg).Name("Personnel Cost - ORG");
            Map(m => m.PersonnelCostDsu).Name("Personnel Cost - DSU");
            Map(m => m.PersonnelCostGsu).Name("Personnel Cost - GSU");
            Map(m => m.PersonnelCostDepot).Name("Personnel Cost - DEPOT");
        }
    }
}
