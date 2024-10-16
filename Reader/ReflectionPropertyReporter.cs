using System;
using System.Reflection;
using System.Text;

namespace ItemClassGenerator.Reader;

public static class ReflectionPropertyReporter
{
    public static string ReportProperties<T>(T obj) where T : class
    {
        if (obj == null)
            return "Object is null";

        Type type = obj.GetType();
        PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        StringBuilder report = new StringBuilder();
        report.AppendLine($"Property values for {type.Name}:");

        foreach (PropertyInfo property in properties)
        {
            object value = property.GetValue(obj);
            string valueString = value == null ? "null" : value.ToString();
            report.AppendLine($"{property.Name}: {valueString}");
        }

        return report.ToString();
    }
}