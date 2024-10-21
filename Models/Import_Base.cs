using FoundryRulesAndUnits.Extensions;


namespace ItemClassGenerator.Models;

public class Import_Base
{

    public string GUID { get; set; } = Guid.NewGuid().ToString();
    public string SheetName { get; set; } = "";
}
