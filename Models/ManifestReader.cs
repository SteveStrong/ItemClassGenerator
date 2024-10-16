

using System.Text;
using ExcelDataReader;
using FoundryRulesAndUnits.Extensions;

namespace ItemClassGenerator.Models;

public class ManifestReader : ManifestTracker
{
    public Import_ExcelData ReadExcelManifest(string folder, string filename)
    {
        try
        {
            var filePath = StorageHelpers.LocalPath(folder, filename);

            if (File.Exists(filePath))
            {
                AddInfo($"ReadExcelManifest {filePath}");
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                // Need this to interpret ANSI-1252 bytes from excel.  Requires NuGet Package System.Text.Encoding.CodePages
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                var workSheet = ExcelReaderFactory.CreateReader(fileStream);

                var manifest = new Import_ExcelData()
                {
                    filename = filename,
                };
                manifest.ReadExcel(workSheet);

                AddSuccess($"Import_ExcelData Created");
                return manifest;
            }
            else
            {
                AddError($"File not found: {filePath}");
            }
        }
        catch (Exception ex)
        {
            AddError(ex.Message);
        }
        return new Import_ExcelData();
    }
}