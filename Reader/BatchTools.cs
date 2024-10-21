

using FoundryRulesAndUnits.Extensions;
using ItemClassGenerator.Models;
using System.Diagnostics;



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

    public string WriteData(string folder, string filename, string data)
    {
        try
        {
            FileHelpers.WriteData(folder, filename, data);
            return data;
        }
        catch (Exception ex)
        {
            //AddStatus<DT_Error>($"WriteToFolder {ex.Message}");
            return ex.Message;
        }
    }

    public string WriteToFolder<T>(string folder, string filename, T source) where T : class
    {
        try
        {
            var result = CodingExtensions.Dehydrate<T>(source, true);
            FileHelpers.WriteData(folder, filename, result);
            return result;
        }
        catch (Exception ex)
        {
            //AddStatus<DT_Error>($"WriteToFolder {ex.Message}");
            return ex.Message;
        }
    }

    public T ReadFromFolder<T>(string folder, string filename) where T : class
    {
        try
        {
            var text = FileHelpers.ReadData(folder, filename);
            var result = CodingExtensions.Hydrate<T>(text, true);
            return result;
        }
        catch (Exception ex)
        {
            //AddStatus<DT_Error>($"ReadFromFolder {ex.Message}");
            return null;
        }
    }

    public List<SourceSpec> GetSourceExcelFiles(string root, string target="")
    {
        var batch = new List<SourceSpec>();

        var source = ClientPath(root);
        var extra = @"\bin\Debug\net8.0";
        var directory = source.Replace(extra, "");

        "".WriteInfo();
        $"GetSourceExcelFiles source {directory}".WriteInfo();

        var folders = Directory.GetDirectories(directory);
        foreach (var folder in folders)
        {
            $"GetSourceExcel Folder {folder}".WriteNote();
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


    

    public List<Import_ExcelData> BatchConsumeExcel(string root)
    {
        //var compiler = new ManifestCompiler();
        var list = new List<Import_ExcelData>();

        var sources = GetSourceExcelFiles(root);
        foreach (var source in sources)
        {
            "".WriteInfo();
            $"CompileManifest {source.Filename}".WriteInfo();
            $"CompileManifest {source.Folder}".WriteNote();

            var reader = new ManifestReader();
            var manifest = reader.ReadExcelManifest(source.Folder, source.Filename);
            manifest.filename = source.Filename;

            reader.WriteErrors();
            reader.WriteWarnings();

            //save as json back to same folder
            var json = CodingExtensions.Dehydrate<Import_ExcelData>(manifest, true);
            var filename = source.Filename.Replace(".xlsx", ".json");
            var folder = ServerPath(root, source.Folder);
            FileHelpers.WriteData(folder, filename, json);

            list.Add(manifest);

        }
        return list;

    }

      
 
}