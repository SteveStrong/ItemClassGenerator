

using System.Text;
using FoundryRulesAndUnits.Extensions;


namespace ItemClassGenerator.Reader;

public record SourceSpec(string Folder, string Filename);

public class BatchTools
{
    public string ClientPath(string root)
    {
        var current = Directory.GetCurrentDirectory();
        var source = Path.Combine(current, root);
        return source;
    }

    public string ServerPath(string root, string folder)
    {
        var current = Directory.GetCurrentDirectory();
        string source = Path.Combine(current, root, folder);
        return source;
    }


    // public string WriteToFolder<T>(string folder, string filename, T source) where T : class
    // {
    //     try
    //     {
    //         var result = CodingExtensions.Dehydrate<T>(source, true);
    //         FileHelpers.WriteData(folder, filename, result);
    //         return result;
    //     }
    //     catch (Exception ex)
    //     {
    //         //AddStatus<DT_Error>($"WriteToFolder {ex.Message}");
    //         return ex.Message;
    //     }
    // }

    // public T ReadFromFolder<T>(string folder, string filename) where T : class
    // {
    //     try
    //     {
    //         var text = FileHelpers.ReadData(folder, filename);
    //         var result = CodingExtensions.Hydrate<T>(text, true);
    //         return result;
    //     }
    //     catch (Exception ex)
    //     {
    //         //AddStatus<DT_Error>($"ReadFromFolder {ex.Message}");
    //         return null;
    //     }
    // }

    public List<SourceSpec> GetSourceExcelFiles(string root, string target="")
    {
        var batch = new List<SourceSpec>();

        var source = ClientPath(root);
        $"Source: {source}".WriteInfo();
        var folders = Directory.GetDirectories(source);

        foreach (var folder in folders)
        {
            var files = Directory.GetFiles(folder);
            foreach (var file in files)
            {
                var filename = Path.GetFileName(file);
                if ( filename.EndsWith(".xlsx") )
                    batch.Add(new SourceSpec(folder, filename));
            }
        }

        return batch;
    }


    public List<SourceSpec> GetSourceXMLFiles(string root, string target="")
    {
        var batch = new List<SourceSpec>();

        var source = ClientPath(root);
        var folders = Directory.GetDirectories(source);

        foreach (var folder in folders)
        {
            var files = Directory.GetFiles(folder);
            foreach (var file in files)
            {
                var filename = Path.GetFileName(file);
                if ( filename.EndsWith(".xml") )
                    batch.Add(new SourceSpec(folder, filename));
            }
        }

        return batch;
    }
       
  
}