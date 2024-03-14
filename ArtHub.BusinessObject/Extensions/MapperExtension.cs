namespace ArtHub.BusinessObject.Extensions
{
    public static class MapperExtension
    {
        // Set value of the source object to the destination object
        // in the same property name and type
        public static void MapperValue<TDestination, TSource>(this TDestination destination, TSource source)
        {
            foreach (var sourceProperty in source!.GetType().GetProperties())
            {
                var sourcePropertyName = sourceProperty.Name;
                var sourcePropertyValue = sourceProperty.GetValue(source);
                var sourcePropertyType = sourceProperty.PropertyType;

                var destinationProperty = destination!.GetType().GetProperty(sourcePropertyName);
                var destinationPropertyType = destinationProperty!.PropertyType;

                if (sourcePropertyType == destinationPropertyType)
                {
                    destinationProperty.SetValue(destination, sourcePropertyValue);
                }
            }
        }
    }
}
