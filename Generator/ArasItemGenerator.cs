

using System.Text;

public class ArasItemGenerator
{
    public ArasItemGenerator()
    {
        
    }

    public string GenerateItemClass(string className)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"using System;");
        sb.AppendLine();
        sb.AppendLine($"namespace ItemClassGenerator.Models;");
        sb.AppendLine();
        sb.AppendLine();
        sb.AppendLine($"public class {className}");
        sb.AppendLine("{");

        sb.AppendLine("}");
        return sb.ToString();
    }
    
}