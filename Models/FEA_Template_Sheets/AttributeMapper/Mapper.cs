using System.Reflection;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class MapFromAttribute : Attribute
{
    public string SourcePropertyName { get; }
    public Type SourceType { get; }

    public MapFromAttribute(Type sourceType, string sourcePropertyName)
    {
        SourceType = sourceType;
        SourcePropertyName = sourcePropertyName;
    }
}

public static class Mapper
{
    public static TDestination MapFromSource<TSource, TDestination>(TSource source, TDestination destination)
    {
        var destinationType = typeof(TDestination);
        var sourceType = typeof(TSource);

        var destProperties = destinationType.GetProperties();

        foreach (var destProp in destProperties) {
            var mapFromAttrs = destProp.GetCustomAttributes<MapFromAttribute>();

            var mapFromAttr = mapFromAttrs.FirstOrDefault(attr => attr.SourceType == sourceType);

            if (mapFromAttr != null) {
                var sourcePropName = mapFromAttr.SourcePropertyName;

                var sourceProp = sourceType.GetProperty(sourcePropName);
                if (sourceProp != null) {
                    var value = sourceProp.GetValue(source);
                    destProp.SetValue(destination, value);
                }
            }
        }

        return destination;
    }

    public static TDestination MapFromSource<TSource, TDestination>(TSource source) where TDestination : new()
    {
        var destination = new TDestination();
        return MapFromSource(source, destination);
    }
}
