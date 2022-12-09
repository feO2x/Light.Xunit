using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Light.Xunit;

/// <summary>
/// Represents a trait discoverer that is optimized for handling the <see cref="TestOrderAttribute"/>.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global -- instantiated by Xunit
public sealed class TestOrderDiscoverer : TraitDiscoverer
{
    /// <summary>
    /// Gets the type name of this trait discoverer.
    /// </summary>
    public const string TypeName = AssemblyInfos.AssemblyName + "." + nameof(TestOrderDiscoverer);

    /// <summary>
    /// Gets the assembly name where this type resides in.
    /// </summary>
    public const string AssemblyName = AssemblyInfos.AssemblyName;

    /// <summary>
    /// Checks if the specified attribute is a <see cref="TestOrderAttribute"/>. If not, then the base class implementation
    /// will handle the attribute. Otherwise, the order of the attribute is returned with the key "Test Order".
    /// </summary>
    public override IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
    {
        var order = traitAttribute.GetNamedArgument<int>(nameof(TestOrderAttribute.Order));
        var orderAsText = ConvertOrderNumberToString(order);
        return new[] { new KeyValuePair<string, string>(TestOrderAttribute.TraitName, orderAsText) };
    }

    private static string ConvertOrderNumberToString(int order)
    {
        switch (order)
        {
            case 0:  return "0";
            case 1:  return "1";
            case 2:  return "2";
            case 3:  return "3";
            case 4:  return "4";
            case 5:  return "5";
            case 6:  return "6";
            case 7:  return "7";
            case 8:  return "8";
            case 9:  return "9";
            case 10: return "10";
            case 11: return "11";
            case 12: return "12";
            case 13: return "13";
            case 14: return "14";
            case 15: return "15";
            case 16: return "16";
            case 17: return "17";
            case 18: return "18";
            case 19: return "19";
            case 20: return "20";
            default:
                return order.ToString();
        }
    }
}