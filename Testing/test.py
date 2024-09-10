import pandas as pd

df = pd.read_csv('lsa_repairableunit.csv')  

def generate_csharp_property(row):
    csharp_type = 'string'  
    if row['Data Type'] == 'Integer':
        csharp_type = 'int'
    elif row['Data Type'] == 'Decimal':
        csharp_type = 'decimal'
    elif row['Data Type'] == 'Boolean':
        csharp_type = 'bool'
    elif row['Data Type'] == 'Date':
        csharp_type = 'DateTime'
    elif row['Data Type'] == 'Item' or row['Data Type'] == 'Foreign':
        csharp_type = 'string'
    label = row['Label'] if isinstance(row['Label'], str) else row['Name']
    property_name = ''.join(word.capitalize() for word in label.split())
    property_template = f"""
    public {csharp_type} {property_name}
    {{
        get {{ return this.GetProperty("{row['Name']}"); }}
        set {{ this.SetProperty("{row['Name']}", value); }}
    }}
    """

    if row['Data Type'] == 'Foreign' and row['Data Source [...]'] == 'name':
        property_template = f"""
        public {csharp_type} {property_name}Name
        {{
            get {{ return this.GetPropertyAttribute("{row['Name']}", "name"); }}
            set {{ this.Item.setPropertyAttribute("{row['Name']}", "name", value); }}
        }}
        """
    return property_template

csharp_properties = [generate_csharp_property(row) for _, row in df.iterrows()]

csharp_class = f"""
public partial class RepairableUnit : ReadyOne.Common.Models.IItemType
{{
    #region ctor

    public RepairableUnit(IDataAccessLayer dal, Item item = null, string _type = "lsa_RepairableUnit", string action = null) : base(dal, item, _type, action)
    {{ }}

    #endregion

    #region Properties
    {''.join(csharp_properties)}
    #endregion
}}
"""

print(csharp_class)

