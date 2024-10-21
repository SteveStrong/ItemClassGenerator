

using ItemClassGenerator.Models;
using System.Text;

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

    public string GenerateItemProperty(ItemTypeSchema schema)
    {
        var propertytype = MapDataType(schema.DataType);

        var sb = new StringBuilder();
        sb.AppendLine($@"   public {propertytype} {schema.Name} {{

            get; set;
            }}");
            
        return sb.ToString();
    }

    public string GenerateItemClass(string className, List<ItemTypeSchema> schema)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"using System;");
        sb.AppendLine();

        sb.AppendLine();
        sb.AppendLine($"public class {className}");
        sb.AppendLine("{");
        foreach (var item in schema)
        {
            sb.AppendLine(GenerateItemProperty(item));
        }
        sb.AppendLine("}");
        return sb.ToString();
    }
    
}