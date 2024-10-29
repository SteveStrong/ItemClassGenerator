public class ClassToClassMap<TSource, TDestination>
{
    private readonly Dictionary<string, string> _propertyMappings = new();

    public void Map(Func<TSource, object> sourceProperty, Func<TDestination, object> destinationProperty)
    {
        var sourcePropertyName = GetPropertyName(sourceProperty);
        var destinationPropertyName = GetPropertyName(destinationProperty);

        _propertyMappings[sourcePropertyName] = destinationPropertyName;
    }

    public TDestination MapValues(TSource source, TDestination destination)
    {
        var sourceType = typeof(TSource);
        var destinationType = typeof(TDestination);

        foreach (var mapping in _propertyMappings)
        {
            var sourceProp = sourceType.GetProperty(mapping.Key);
            var destinationProp = destinationType.GetProperty(mapping.Value);

            if (sourceProp != null && destinationProp != null && destinationProp.CanWrite)
            {
                var value = sourceProp.GetValue(source);
                destinationProp.SetValue(destination, value);
            }
        }

        return destination;
    }

    private static string GetPropertyName<T>(Func<T, object> expression)
    {
        var body = expression.Method.GetParameters()[0].Name;
        return body!;
    }
}