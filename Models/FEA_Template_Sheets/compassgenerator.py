import pandas as pd
import os
import re
import json

# Define a function to clean column names for C# property names
def clean_column_name_for_csharp(column_name):
    clean_name = re.sub(r'\W|^(?=\d)', '_', column_name)
    clean_name = ''.join(word.capitalize() for word in clean_name.split('_'))
    if clean_name and clean_name[0].isdigit():
        clean_name = '_' + clean_name
    return clean_name

# Define a function to clean sheet names for C#
def clean_sheet_name(sheet_name):
    return sheet_name.replace(" ", "")

# Function to generate cleaned C# classes and store original names
def generate_classes_and_store_names(excel_data, output_dir):
    original_names = {}  # Dictionary to store original and cleaned names

    if not os.path.exists(output_dir):
        os.makedirs(output_dir)

    # Iterate through each sheet
    for sheet_name, df in excel_data.items():
        cleaned_sheet_name = clean_sheet_name(sheet_name)

        # Store original sheet name
        original_names[cleaned_sheet_name] = {
            'original_sheet_name': sheet_name,
            'original_columns': list(df.columns)
        }

        class_name = cleaned_sheet_name
        properties = []
        existing_names = set()

        for column in df.columns:
            # Clean column names
            property_name = clean_column_name_for_csharp(column)

            # Avoid duplicate property names
            if property_name in existing_names or not property_name:
                counter = 2
                new_property_name = f"{property_name}_{counter}"
                while new_property_name in existing_names:
                    counter += 1
                    new_property_name = f"{property_name}_{counter}"
                property_name = new_property_name

            existing_names.add(property_name)

            # Create the C# property
            properties.append(f"public string {property_name} {{ get; set; }}")

        # Write the class file
        with open(os.path.join(output_dir, f"{class_name}.cs"), 'w') as file:
            file.write("using System;\nusing System.Collections.Generic;\n\n")
            file.write(f"public class {class_name}\n{{\n    ")
            file.write("\n    ".join(properties))
            file.write("\n}\n")

    # Save the original names to a JSON file (for use in C#)
    with open(os.path.join(output_dir, 'original_names.json'), 'w') as json_file:
        json.dump(original_names, json_file)

    print("Classes and original names saved.")


# Load the Excel file
file_path = "FEA_Template.xlsx"  # Replace with your Excel file path
output_dir = "CSharpClasses"  # Directory where C# files and JSON will be saved
excel_data = pd.read_excel(file_path, sheet_name=None)

# Generate the classes and store the original names
generate_classes_and_store_names(excel_data, output_dir)
# Define a function to clean column names for proper C# property names
def clean_column_name_for_csharp(column_name):
    # Remove invalid characters, capitalize words, and concatenate
    clean_name = re.sub(r'\W|^(?=\d)', '_', column_name)
    clean_name = ''.join(word.capitalize() for word in clean_name.split('_'))
    
    # Ensure the name doesn't start with a digit
    if clean_name and clean_name[0].isdigit():
        clean_name = '_' + clean_name
    
    return clean_name

# Function to generate cleaned C# classes from the Excel file
def generate_cleaned_csharp_class(sheet_name, df):
    class_name = sheet_name.replace(" ", "")  # Removing spaces for class names
    properties = []
    existing_names = set()  # Track existing property names
    
    for column in df.columns:
        # Clean column names for C# property names
        property_name = clean_column_name_for_csharp(str(column))
        
        # Identify the data type of each column and map it to a C# equivalent
        sample_data = df[column].dropna().iloc[0] if not df[column].dropna().empty else None
        if isinstance(sample_data, int):
            csharp_type = "int"
        elif isinstance(sample_data, float):
            csharp_type = "double"
        else:
            csharp_type = "string"
        
        # Avoid duplicate property names
        if property_name in existing_names or not property_name:
            counter = 2
            new_property_name = f"{property_name}_{counter}"
            while new_property_name in existing_names:
                counter += 1
                new_property_name = f"{property_name}_{counter}"
            property_name = new_property_name

        existing_names.add(property_name)

        # Create the C# property
        property_str = f"public {csharp_type}? {property_name} {{ get; set; }}"
        properties.append(property_str)
    
    # Combine all properties into the class definition
    class_def = f"public class {class_name}\n{{\n    " + "\n    ".join(properties) + "\n}"
    return class_name, class_def

# Function to generate CsvHelper class maps from the Excel file
def generate_class_map(sheet_name, df):
    class_name = sheet_name.replace(" ", "")  # Removing spaces for class names
    map_properties = []
    
    for column in df.columns:
        # Clean column names for C# property names
        property_name = clean_column_name_for_csharp(str(column))
        
        # Create the CsvHelper map property
        map_property = f'Map(m => m.{property_name}).Name("{column}");'
        map_properties.append(map_property)
    
    # Combine all map properties into the class map definition
    class_map_def = f"public class {class_name}Map : ClassMap<{class_name}>\n{{\n    public {class_name}Map()\n    {{\n        " + "\n        ".join(map_properties) + "\n    }\n}"
    return class_name, class_map_def

# Function to save the generated C# classes to files
def save_classes_to_files(classes, output_dir):
    # Ensure the output directory exists
    if not os.path.exists(output_dir):
        os.makedirs(output_dir)

    class_names = []

    # Write each class to a separate .cs file
    for sheet_name, (class_name, class_def) in classes.items():
        file_name = f"{class_name}.cs"
        file_path = os.path.join(output_dir, file_name)
        with open(file_path, 'w') as file:
            # Include necessary using directives and namespace
            file.write("using System;\nusing System.Collections.Generic;\n\n")
            file.write("namespace GeneratedClasses\n{\n")
            file.write("    " + class_def.replace("\n", "\n    ") + "\n")
            file.write("}\n")
        print(f"Class for sheet '{sheet_name}' saved to {file_path}")
        class_names.append(class_name)
    
    return class_names

# Function to save CsvHelper class maps to files
def save_class_maps_to_files(class_maps, output_dir):
    map_output_dir = os.path.join(output_dir, "ClassMaps")
    if not os.path.exists(map_output_dir):
        os.makedirs(map_output_dir)

    for sheet_name, (class_name, class_map_def) in class_maps.items():
        file_name = f"{class_name}Map.cs"
        file_path = os.path.join(map_output_dir, file_name)
        with open(file_path, 'w') as file:
            # Include necessary using directives and namespace
            file.write("using CsvHelper.Configuration;\n\n")
            file.write("namespace GeneratedClasses\n{\n")
            file.write("    " + class_map_def.replace("\n", "\n    ") + "\n")
            file.write("}\n")
        print(f"Class map for sheet '{sheet_name}' saved to {file_path}")

# Load the Excel file and generate C# classes and CSVs
file_path = "FEA_Template.xlsx"  # Replace with your Excel file path
class_output_dir = "CSharpClasses"  # Directory where .cs files will be saved
csv_output_dir = "CSVSaves"  # Directory where .csv files will be saved

# Load the Excel data
excel_data = pd.read_excel(file_path, sheet_name=None)

# Generate the C# classes and class maps with cleaned column names
cleaned_classes = {sheet: generate_cleaned_csharp_class(sheet, df) for sheet, df in excel_data.items()}
class_maps = {sheet: generate_class_map(sheet, df) for sheet, df in excel_data.items()}

# Save the generated classes to files and get the class names
class_names = save_classes_to_files(cleaned_classes, class_output_dir)

# Save the generated class maps to files
save_class_maps_to_files(class_maps, class_output_dir)

def save_sheets_to_csv(sheets, output_dir):
    # Ensure the output directory exists
    if not os.path.exists(output_dir):
        os.makedirs(output_dir)

    # Save each sheet as a CSV file
    for sheet_name, df in sheets.items():
        csv_file_name = f"{sheet_name.replace(' ', '')}.csv"
        csv_file_path = os.path.join(output_dir, csv_file_name)
        df.to_csv(csv_file_path, index=False)  # Save DataFrame as CSV without index
        print(f"Sheet '{sheet_name}' saved to {csv_file_path}")
# Save each sheet as a CSV file
save_sheets_to_csv(excel_data, csv_output_dir)


