# GitHub Copilot Instructions for "Fulfillment (Continued)" Mod

## Mod Overview and Purpose

**Fulfillment (Continued)** is a RimWorld mod that introduces a new dynamic need system for colonists, focusing on their sense of fulfillment from performing activities they are passionate about. This mod enhances the emotional depth and realism of gameplay by making colonists experience longer-lasting effects based on their engagements in preferred tasks. This continuation of Lewkah0’s mod includes added keyed translations and is designed to integrate smoothly with existing saves while being compatible with other mods.

## Key Features and Systems

- **Dynamic Need System**: 
  - Introduces a "Fulfillment" need for colonists, affecting their mood based on recent involvement in tasks they are passionate about.
  
- **Dynamic Rate Changes**: 
  - The need's gain rate is influenced by the colonist's level of passion or burning passion for their current task.
  
- **Balanced Fulfillment Rates**: 
  - Carefully calibrated need drop and gain rates contribute to balanced gameplay, ensuring a strategic challenge.

- **Fulfillment Levels and Effects**: 
  - Varied levels of fulfillment provide specific mood bonuses or penalties. 
  - High fulfillment levels grant positive mood effects, increasing a colonist's happiness.

- **Game Compatibility**:
  - Compatible with existing saves and other mods. Load after core gameplay mods to optimize mod integration and performance.

## Coding Patterns and Conventions

1. **Class Organization**:
   - Utilize static classes (`File: JobDriver_DriverTick.cs, Pawn_NeedsTracker_AllNeeds.cs`) for utility functions that don't require instance data.
   - Inherit classes like `Need_Fulfillment : Need` to extend RimWorld’s built-in classes and systems.

2. **Method Design**:
   - Prefixed private helper methods with `private` such as `applyMoodEffects()` and `applyHediffOrThought(ThoughtDef thoughtDef)` to encapsulate functionality within the class.

3. **Configuration Management**:
   - Use `ModSettings` (`FulfillmentMoodSettings.cs`) to handle user-customizable settings, providing methods such as `ResetToDefaults()` for restored default settings.

## XML Integration

- XML configuration files are utilized for defining keyed translations and thought definitions.
- Ensure continuous integration of these XML files by testing changes in various scenarios to maintain compatibility and functionality.

## Harmony Patching

- Incorporate Harmony for runtime method patching, allowing modification of core RimWorld behavior without altering original source code.
- Focus on non-invasive patches to maintain the mod’s compatibility and prevent conflicts.

## Suggestions for Copilot

1. **Extension Methods and Utilities**:
   - Use Copilot to propose extension methods for dealing with repetitive tasks, like automatically updating mood based on fulfillment.

2. **XML Data Handling**:
   - Enable Copilot to suggest XML parsing and serialization for smooth integration of new translations or thought definitions.

3. **Debugging and Validation**:
   - Employ Copilot to generate debugging code or validation methods to ensure fulfillment rates remain balanced under dynamic game conditions.

4. **Code Readability and Maintenance**:
   - Enhance method documentation and class comments with Copilot for better code maintenance and understanding by other developers.

5. **Performance Optimization**:
   - Leverage Copilot for optimizing loops, especially within the dynamic rate changes, to maintain efficient game performance.

By following these guidelines, developers can effectively expand on the "Fulfillment (Continued)" mod, providing a richer gameplay experience for RimWorld players while maintaining a clean, maintainable, and extendable codebase.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.
