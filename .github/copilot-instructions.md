# GitHub Copilot Instructions for Fulfillment (Continued)

This document outlines the coding standards, conventions, and usage of GitHub Copilot for the Fulfillment (Continued) mod. By following these guidelines, you will be able to contribute effectively to the project and maintain a high standard of code quality.

## Mod Overview and Purpose

**Fulfillment (Continued)** is an update to the Fulfillment mod, enhancing the dynamic need system of RimWorld. The mod introduces a "Fulfillment" need for colonists, influencing their mood based on their engagement in passionate tasks. Key features include dynamic rate changes, balanced fulfillment rates, and different mood effects based on fulfillment levels.

## Key Features and Systems

### Dynamic Need System
- **Fulfillment Need**: A new need introduced for colonists, measuring their level of satisfaction with their work.
- **Passion and Burning Passion**: Affects the rate at which colonists gain the Fulfillment need.

### Dynamic Rate Changes
- **Passion Level**: The rate of fulfillment gain is influenced by the colonist's passion for the task.

### Balanced Fulfillment Rates
- **Dynamic Adjustments**: Ensures that the need drops and gains at rates designed for balanced gameplay.

### Fulfillment Levels and Effects
- **Very Low to Very High Fulfillment**: Different mood effects based on the colonist's current fulfillment level.

## Coding Patterns and Conventions

### General Guidelines
- **Consistent Naming**: Use clear and descriptive names for classes, methods, and variables.
- **Documentation**: Write meaningful comments and documentation for complex logic.
- **Code Organization**: Organize code into logical sections and use appropriate naming conventions.

### C# Conventions
- **Mod Class**: The main mod class (`FulfillmentMod.cs`) should inherit from `Mod` and implement necessary methods.
- **Category and Definitions**: Use `FulfillmentCategory` and `CustomThoughtDefOf` to categorize and define thoughts.
- **Mood Settings**: Implement `FulfillmentMoodSettings` for managing mood-related settings.

### XML Conventions
- **NeedDefs.xml**: Define the new Fulfillment need using XML.
- **ThoughtDefs.xml**: Define thoughts related to fulfillment using XML.

## XML Integration

The Fulfillment mod uses XML files to define new needs and thoughts. Here is a brief guide to integrating XML files:

1. **NeedDefs.xml**: Define the Fulfillment need using the `NeedDef` tag.
   xml
   <NeedDef>
     <label>Fulfillment</label>
     <description>A new need measuring satisfaction with work.</description>
     <statFactors>
       <li>
         <stat>Passion</stat>
         <factor>0.5</factor>
       </li>
     </statFactors>
   </NeedDef>
   

2. **ThoughtDefs.xml**: Define thoughts related to fulfillment using the `ThoughtDef` tag.
   xml
   <ThoughtDef>
     <label>Fulfilled</label>
     <description>Feeling fulfilled by engaging in passionate work.</description>
     <category>CustomThoughtCategory</category>
     <moodEffect>
       <baseMagnitude>5</baseMagnitude>
     </moodEffect>
   </ThoughtDef>
   

## Harmony Patching

Harmony is used to patch existing RimWorld code. Here is an example of a Harmony patch in the `HarmonyPatches` namespace:

csharp
namespace Fulfillment.HarmonyPatches
{
    [HarmonyPatch(typeof(JobDriver), "DriverTick")]
    public static class JobDriver_DriverTick
    {
        [HarmonyPostfix]
        public static void Postfix(JobDriver __instance)
        {
            // Patch logic here
        }
    }
}


## Suggestions for Copilot

1. **Use Descriptive Comments**: Help Copilot understand the context and purpose of the code by providing detailed comments.
2. **Provide Example Code**: Include example code snippets for complex logic to guide Copilot.
3. **Follow Conventions**: Use the established coding conventions to ensure consistency across the mod.
4. **Test and Validate**: Always test the generated code thoroughly to ensure it works as expected.

By following these guidelines, you will be able to effectively use GitHub Copilot to enhance the Fulfillment (Continued) mod and contribute to a high-quality RimWorld modding project.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

