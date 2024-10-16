using FoundryRulesAndUnits.Extensions;


namespace ItemClassGenerator.Models;

public class Import_Base
{

    public string GUID { get; set; } = Guid.NewGuid().ToString();
    public string SheetName { get; set; } = "";
    public string domain { get; set; }
    public string version { get; set; }
    public string type { get; set; }  
    public string name { get; set; } 

    public string category { get; set; } = "";

}
