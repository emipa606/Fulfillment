using System.Reflection;
using HarmonyLib;
using Verse;

namespace FulfillmentModNamespace;

[StaticConstructorOnStartup]
public static class FulfillmentMod
{
    static FulfillmentMod()
    {
        new Harmony("com.Lewkah0.fulfillmentmod").PatchAll(Assembly.GetExecutingAssembly());
    }
}