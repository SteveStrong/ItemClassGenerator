using FoundryRulesAndUnits.Extensions;
using FoundryRulesAndUnits.Models;

namespace ItemClassGenerator.Models;

public class ManifestTracker
{
    protected List<DT_StatusText> _status { set; get; } = new();
    public List<T> HasStatusList<T>() where T : DT_StatusText
    {
        var result = _status.Where(item => item is T).Select(item => (T)item).ToList();
        return result;
    }

    public int ErrorCount()
    {
        var values = HasStatusList<DT_Error>();
        return values.Count;
    }
    public void WriteErrors()
    {
        var values = HasStatusList<DT_Error>();
        foreach (var item in values)
        {
            item.text.WriteError();
        }
    }

    public void WriteWarnings()
    {
        var values = HasStatusList<DT_Warning>();
        foreach (var item in values)
        {
            item.text.WriteWarning();
        }
    }

    public void WriteInfos()
    {
        var values = HasStatusList<DT_Info>();
        foreach (var item in values)
        {
            item.text.WriteInfo();
        }
    }

    public void WriteSuccesses()
    {
        var values = HasStatusList<DT_Success>();
        foreach (var item in values)
        {
            item.text.WriteSuccess();
        }
    }

    public List<DT_StatusText> AnyStatusText()
    {
        return _status;
    }
    public void ClearAllStatusText()
    {
        _status = new();
    }

    public List<DT_Error> AddError(string note, object obj = null!)
    {
        note.WriteError();
        _status.Add(new DT_Error() { text = note, source = obj });
        return HasStatusList<DT_Error>();
    }
    public List<DT_Info> AddInfo(string note, object obj = null!)
    {
        //note.WriteInfo();
        _status.Add(new DT_Info() { text = note, source = obj });
        return HasStatusList<DT_Info>();
    }
    public List<DT_Warning> AddWarning(string note, object obj = null!)
    {
        //note.WriteWarning();
        _status.Add(new DT_Warning() { text = note, source = obj });
        return HasStatusList<DT_Warning>();
    }
    public List<DT_Success> AddSuccess(string note, object obj = null!)
    {
        //note.WriteSuccess();
        _status.Add(new DT_Success() { text = note, source = obj });
        return HasStatusList<DT_Success>();
    }


}