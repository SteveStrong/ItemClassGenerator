using GeneratedClasses;
using ExternalLibrary;
public class ExternalClass2ToSRURepairMethodsMap
{
    public SRURepairMethods Map(ExternalClass2 source, SRURepairMethods destination)
    {
        destination.ResourceId = source.arasProp1;
        destination.ResourceName = source.arasProp2;
        destination.ResourceUtilizationTime = source.arasProp3;
        return destination;
    }
}
