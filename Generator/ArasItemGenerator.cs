

using Humanizer;
using ItemClassGenerator.Models;
using System.Text;

namespace ItemClassGenerator.Generators;

// https://www.c-sharpcorner.com/article/getting-started-with-humanizer-in-c-sharp/
// https://blog.devgenius.io/humanizer-an-exciting-library-in-c-ba2527410e42
public class ArasItemGenerator
{
    public ArasItemGenerator()
    {
        
    }

    public static string MapDataType(string dataType)
    {
        return dataType switch
        {
            "String" => "string",
            "Int" or "Integer" => "int",
            "Long" => "long",
            "Float" => "float",
            "Double" => "double",
            "Decimal" => "decimal",
            "Bool" or "Boolean" => "bool",
            "DateTime" => "DateTime",
            "Guid" => "Guid",
            "Item" => "object", // or a specific custom class if needed
            "Text" => "string",
            _ => "object"
        };
    }

    public static string CleanPropertyName(string source)
    {
        if ( string.IsNullOrEmpty(source) ) return "";  
        var name = source.Trim();

        name = name.Replace('/', '-');
        name = name.Replace('"', '-');
        name = name.Replace(' ', '-');
        name = name.Replace(',', '-');
        name = name.Replace(':', '-');
        name = name.Trim(Path.GetInvalidFileNameChars());
        name = name.Trim(Path.GetInvalidPathChars());
        return name;
    }

    public string FillProperty(ItemTypeSchema schema)
    {
        var arasName = schema.Name;
        var propertytype = MapDataType(schema.DataType);
        var propertyname = schema.Label ?? arasName;
        propertyname = propertyname.Dehumanize();
        propertyname = CleanPropertyName(propertyname);

        var temp1 = $$"""           
                                    public {{propertytype}} {{propertyname}}
                                    {
                                        get { return ({{propertytype}})this.GetProperty("{{arasName}}"); }
                                        set { this.SetProperty("{{arasName}}", value); }
                                    }

                     """;
        return temp1;
    }

    public string FillProperties(List<ItemTypeSchema> list)
    {
        var properties = new StringBuilder();
        foreach (var schema in list)
        {
            properties.Append(FillProperty(schema));
        }
        return properties.ToString();
    }

    public string FillFileHeading(string className, string properties, string extended)
    {

        var temp1 = $$"""
                      using Aras.IOM;
                      using ReadyOne.Common;

                      namespace ReadyOne.SupportAnalysis.Models
                      {
                            public partial class {{className}} : ReadyOne.Common.Models.IItemType
                            {
                            	#region ctor 
                                    public {{className}}(IDataAccessLayer dal, Item item = null, string _type = "{{className}}", string action = null) : base(dal, item, _type, action)
                                    {
                                    }
                                #endregion

                                #region Properties

                                    {{properties}}
                                #endregion

                                #region ExtendedProperties
                                    {{extended}}
                                #endregion
                            }
                      }
                     """;
        return temp1;
    }

    public string GenerateItemClass(string name, List<ItemTypeSchema> schema)
    {
        var className = name.Replace(" ", "_");

        var properties = FillProperties(schema);

        var result = FillFileHeading(className,properties, "");

        return result;
    }
    
}