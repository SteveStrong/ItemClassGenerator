
namespace ItemClassGenerator.Models;

public class ItemTypeSchema : Import_Base
{
    public string Name { get; set; }
    public string Label { get; set; }
    public string DataType { get; set; }
    public string DataSource { get; set; }
    public string Length { get; set; }
    public string Precision { get; set; }
    public string Scale { get; set; }
    public string Required { get; set; }
    public string Unique { get; set; }
    public string Indexed { get; set; }
    public string Federated { get; set; }
    public string Hidden { get; set; }
    public string Hidden2 { get; set; }
    public string Alignment { get; set; }
    public string Width { get; set; }
    public string SortOrder { get; set; }
    public string KeyedNameOrder { get; set; }
    public string OrderBy { get; set; }
    public string DefaultValue { get; set; }
    public string DefaultSearch { get; set; }
    public string Pattern { get; set; }
    public string ClassPath { get; set; }
    public string ForeignProperty { get; set; }
    public string Tooltip { get; set; }
    public string HelpText { get; set; }
    public string TrackHistory { get; set; }
    public string ItemBehavior { get; set; }
}
