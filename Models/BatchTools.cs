

using FoundryRulesAndUnits.Extensions;



namespace ItemClassGenerator.Models;

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
    // public async Task<string> ReadFileToStringAsync(IBrowserFile file)
    // {
    //     using var stream = file.OpenReadStream();
    //     using var memoryStream = new MemoryStream();
    //     await stream.CopyToAsync(memoryStream);
    //     return Encoding.UTF8.GetString(memoryStream.ToArray());
    // }
    



    public void BatchCompileExcel(string root)
    {
        //var compiler = new ManifestCompiler();

        var sources = GetSourceExcelFiles(root);
        foreach (var source in sources)
        {
            "".WriteInfo();
            $"CompileManifest {source.Filename}".WriteInfo();
            $"CompileManifest {source.Folder}".WriteNote();

            var reader = new ManifestReader();
            var manifest = reader.ReadExcelManifest(source.Folder, source.Filename);
            reader.WriteErrors();
            reader.WriteWarnings();

            //save as json back to same folder
            var json = CodingExtensions.Dehydrate<Import_ExcelData>(manifest, true);
            var filename = source.Filename.Replace(".xlsx", ".json");
            var folder = ServerPath(root, source.Folder);
            FileHelpers.WriteData(folder, filename, json);


            if (reader.ErrorCount() > 0) return;

            manifest.filename = source.Filename;

            //compiler.CompileManifest(manifest, service!);
            //compiler.WriteErrors();
            //compiler.WriteWarnings();
            //compiler.WriteSuccesses();
        }
    }

      
 
}