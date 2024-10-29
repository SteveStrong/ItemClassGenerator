using System;
using System.Collections.Generic;

namespace GeneratedClasses
{
    public class WorkbookData
    {
        public List<SupportEquipment> SupportEquipmentList { get; set; } = new List<SupportEquipment>();
        public List<Personnel> PersonnelList { get; set; } = new List<Personnel>();
        public List<RepairPlacement> RepairPlacementList { get; set; } = new List<RepairPlacement>();
        public List<EndItem> EndItemList { get; set; } = new List<EndItem>();
        public List<GlobalSettings> GlobalSettingsList { get; set; } = new List<GlobalSettings>();
        public List<LRU> LRUList { get; set; } = new List<LRU>();
        public List<NLRU> NLRUList { get; set; } = new List<NLRU>();
        public List<SRU> SRUList { get; set; } = new List<SRU>();
        public List<NSRU> NSRUList { get; set; } = new List<NSRU>();
        public List<EndItemRepairMethods> EndItemRepairMethodsList { get; set; } = new List<EndItemRepairMethods>();
        public List<LRURepairMethods> LRURepairMethodsList { get; set; } = new List<LRURepairMethods>();
        public List<SRURepairMethods> SRURepairMethodsList { get; set; } = new List<SRURepairMethods>();
        public List<Transportation> TransportationList { get; set; } = new List<Transportation>();
        public List<CommonLabor> CommonLaborList { get; set; } = new List<CommonLabor>();
        public List<Supply> SupplyList { get; set; } = new List<Supply>();
        public List<CalculatedValues> CalculatedValuesList { get; set; } = new List<CalculatedValues>();
    }
}
