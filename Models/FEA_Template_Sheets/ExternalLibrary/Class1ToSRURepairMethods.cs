using GeneratedClasses;
using ExternalLibrary;
public class ExternalClass1ToSRURepairMethodsMap
{
    public SRURepairMethods Map(ExternalClass1 source, SRURepairMethods destination)
    {
        destination.SruId = source.arasProp1;
        destination.SruName = source.arasProp2;
        return destination;
    }
}
