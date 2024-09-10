using System;

public class RepairableUnitDTO
{
    public string CageCode { get; set; }
    public string Classification { get; set; }
    public string CompleteItemName { get; set; }
    public string FederalSupplyClassification { get; set; }
    public string ManufacturerPartNumber { get; set; }
    public string MeanTimeBetweenFailures { get; set; }
    public string NationalIdItemNumber { get; set; }
    public decimal? ProductionLeadTime { get; set; }
    public int? QuantityPerEndItem { get; set; }
    public string ShelfLife { get; set; }
    public string UnitOfIssue { get; set; }
    public decimal? UnitPrice { get; set; }
    public string ConfigId { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedOn { get; set; }
    public string Css { get; set; }
    public string CurrentState { get; set; }
    public int? Generation { get; set; }
    public string Id { get; set; }
    public bool? IsCurrent { get; set; }
    public bool? IsReleased { get; set; }
    public string KeyedName { get; set; }
    public string LockedById { get; set; }
    public string MajorRev { get; set; }
    public string ManagedById { get; set; }
    public string MinorRev { get; set; }
    public string ModifiedById { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public bool? NewVersion { get; set; }
    public bool? NotLockable { get; set; }
    public string OwnedById { get; set; }
    public string PermissionId { get; set; }
    public string State { get; set; }
    public string TeamId { get; set; }
    public int? TotalQuantityRecommended { get; set; }
}