
using ExcelDataReader;
using System.Reflection;
using FoundryRulesAndUnits.Extensions;
using FoundryRulesAndUnits.Models;


namespace ItemClassGenerator.Models;

public record PageInfo(string name, string detail, string page, bool isRoot);

public class ManifestInfo
{
    public string filename { get; set; }
    public string author { get; set; }
    public string versionInfo { get; set; }
    public string revID { get; set; }
    public string change { get; set; }
    public string asOf { get; set; }
    public string distribution { get; set; }
    public string knowledgeCenter { get; set; }
    public List<DT_StatusText> status { get; set; } = new();

}

[System.Serializable]
public class Import_ExcelData
{
    private static int _currentErrorCount = 0;
    public string filename { get; set; }
    public List<PageInfo> PageNames { get; set; } = new();
    public List<ItemTypeSchema> ItemType { get; set; } = new();
    public ManifestInfo Info { get; set; }


    public bool HasDataOnTab(string name)
    {
        var propInfo = this.GetType().GetProperty(name);
        if (propInfo == null) return false;
        var result = propInfo.GetValue(this);
        return result != null && (result as System.Collections.ICollection).Count > 0;
    }
    


    public List<T> HasStatusList<T>() where T : DT_StatusText
    {
        var result = Info.status.Where(item => item is T).Select(item => (T)item).ToList();
        return result;
    }

    public bool TrackErrors()
    {
        _currentErrorCount = ErrorCount();
        return true;
    }
    public bool NoNewErrorsWereCreated()
    {
        var more = ErrorCount();
        return more == _currentErrorCount;
    }

    public int ErrorCount()
    {
        var values = HasStatusList<DT_Error>();
        return values.Count;
    }
    public List<DT_Error> AddError(string note, object obj = null)
    {
        note.WriteError();
        Info.status.Add(new DT_Error() { text = note, source = obj });
        return HasStatusList<DT_Error>();
    }
    public List<DT_Info> AddInfo(string note, object obj = null)
    {
        //note.WriteInfo();
        Info.status.Add(new DT_Info() { text = note, source = obj });
        return HasStatusList<DT_Info>();
    }
    public List<DT_Warning> AddWarning(string note, object obj = null)
    {
        //note.WriteWarning();
        Info.status.Add(new DT_Warning() { text = note, source = obj });
        return HasStatusList<DT_Warning>();
    }
    public List<DT_Success> AddSuccess(string note, object obj = null)
    {
        //note.WriteSuccess();
        Info.status.Add(new DT_Success() { text = note, source = obj });
        return HasStatusList<DT_Success>();
    }



     private List<T> DataReader<T>(IExcelDataReader workSheet, string domain, string sheetname) where T: Import_Base
    {
        var columnCount = workSheet.FieldCount;
        var columnDict = new Dictionary<int, PropertyInfo>();

        var propList = from prop in typeof(T).GetProperties() where prop.CanRead && prop.CanWrite select prop;

        workSheet.Read();
        for (var i = 0; i < columnCount; i++)
        {
            var columnName = workSheet.GetValue(i)?.ToString();
            var prop = propList.Where(item => item.Name.Matches(columnName)).FirstOrDefault();

            if (prop != null)
                columnDict.Add(i, prop);
        }

        var list = new List<T>();


        while (workSheet.Read())
        {
            var source = Activator.CreateInstance<T>();
            source.SheetName = sheetname.Trim();

            foreach (KeyValuePair<int, PropertyInfo> kvp in columnDict)
            {
                var value = workSheet.GetValue(kvp.Key)?.ToString().Trim();
                if (!string.IsNullOrEmpty(value)) 
                {
                    kvp.Value.SetValue(source, value);
                    //$"Key: {kvp.Key}, Name: {kvp.Value.Name}  Value: {value}".WriteInfo();
                }
                //else
                //    $"Error: {sheetname} {domain} {kvp.Key} {kvp.Value.Name} is empty".WriteError();
            }
            list.Add(source);
        }

        return list;
    }
   

 

    public void ReadExcel(IExcelDataReader workSheet)
    {

        var lookup = new Dictionary<string, Action<string,string>>() {

            {"PROPERTY", (dom,name)=> {
                ItemType ??= new List<ItemTypeSchema>();
                ItemType.AddRange(DataReader<ItemTypeSchema>(workSheet,dom,name));
            }},
        };

        do // for each worksheet
        {
            var sheetName = workSheet.Name;
            var split = sheetName.Split("_");
            var key = split.First().ToUpper().Trim();
            var last = split.Last().Trim();

            var pageInfo = new PageInfo(key,last,sheetName, key.Matches(last));


            if (lookup.TryGetValue(key, out Action<string,string> value))
            {
                $"spreadsheet key {key} sheet {sheetName} was parsed".WriteSuccess();
                value.Invoke(key,sheetName);
                PageNames.Add(pageInfo);
            } else
            {
                $"parsing spreadsheet: key [{key}] sheet [{sheetName}] not found".WriteError();
            }
        } while (workSheet.NextResult());


    }


    public string ParentReference(string referenceDesignation) 
    {
        string[] pathParts = referenceDesignation.Split('.');
        string refdes = string.Join(".", pathParts, 0, pathParts.Length - 1);
        return refdes;
    }

}
