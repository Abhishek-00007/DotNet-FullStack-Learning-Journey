using System;
using System.Reflection;

// Step 1: Create Custom Attribute
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
public class CustomInfoAttribute : Attribute
{
    public string Description { get; set; }
    public int Version { get; set; }

    public CustomInfoAttribute(string description, int version)
    {
        Description = description;
        Version = version;
    }
}

// Step 2: Apply Attribute
[CustomInfo("This is a sample class.", 1)]
class SampleClass
{
    [CustomInfo("This is a sample method.", 2)]
    public void SampleMethod() { }

    [CustomInfo("This is a sample property.", 3)]
    public string SampleProperty { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Type type = typeof(SampleClass);

        // Class Attribute
        var classAttr = (CustomInfoAttribute)Attribute.GetCustomAttribute(type, typeof(CustomInfoAttribute));
        Console.WriteLine($"Class Description: {classAttr.Description}, Version: {classAttr.Version}");

        // Method Attribute
        MethodInfo method = type.GetMethod("SampleMethod");
        var methodAttr = (CustomInfoAttribute)Attribute.GetCustomAttribute(method, typeof(CustomInfoAttribute));
        Console.WriteLine($"Method Description: {methodAttr.Description}, Version: {methodAttr.Version}");

        // Property Attribute
        PropertyInfo prop = type.GetProperty("SampleProperty");
        var propAttr = (CustomInfoAttribute)Attribute.GetCustomAttribute(prop, typeof(CustomInfoAttribute));
        Console.WriteLine($"Property Description: {propAttr.Description}, Version: {propAttr.Version}");
    }
}