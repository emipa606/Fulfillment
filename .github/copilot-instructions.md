# GitHub Copilot Instructions for Fulfillment Mod (Continued)

## Overview and Purpose

**Mod Name:** Fulfillment (Continued)  
**Author:** Lewkah0 (Updated by the community)  
**Description:**  
The Fulfillment mod for RimWorld introduces a new need system for colonists to reflect how fulfilled they are by engaging in tasks they are passionate about. This mod enhances the immersion by making colonists' mood dependent on the frequency and nature of their work, stimulating players to engage more thoughtfully with task assignments.

## Key Features and Systems

### 1. Dynamic Need System
- **Fulfillment Need:** Colonists now have a "Fulfillment" need that influences their mood depending on their engagement in passionate tasks.
- **Dynamic Rate Changes:** The rate of Fulfillment gained is contingent on the passion level of the colonist for the tasks they perform.

### 2. Fulfillment Levels and Effects
- **Very Low to Very High Fulfillment:** Varying mood effects ranging from -10 to +10 based on the levels of fulfillment.
- **Balanced Gameplay:** Rates of need drops and gains ensure the mod is balanced and works smoothly with RimWorld's existing systems.

### 3. Compatibility
- Mod is compatible with existing saves and designed to work well with other mods.
- Compatible with RimWorld's mod-loading order. It's recommended to load this mod after core gameplay modifications.

## Coding Patterns and Conventions

The Fulfillment mod follows a structured coding approach for maintainability and readability:

- **Naming Conventions:** Follow C# standard naming. For example, `CamelCase` for methods and `PascalCase` for classes.
- **Modularity:** Significant functionality is encapsulated within its respective utility or class (e.g., `FulfillmentNeedUtility.cs`).
- **Data Handling:** Use of `ExposeData` to manage saving/loading state.

## XML Integration

The mod uses XML files to define new game content and settings:

- **NeedDefs.xml**: Defines custom needs and their integration into the game for colonists.
- **ThoughtDefs.xml**: Establishes thoughts and mood effects related to different Levels of Fulfillment.
- **About.xml**: Details mod metadata for proper integration and information display in-game.

## Harmony Patching

To seamlessly integrate with core RimWorld code, Harmony patches are employed:

- **Harmony Setup:** Uses `brrainz.harmony` to patch specific methods like `Pawn_NeedsTracker_ShouldHaveNeed` with Postfix operations.
- **Patching Strategy:** The use of postfix patches ensures the modifications only affect their target sections, preserving game stability.

## Suggestions for Copilot

1. **Implementation of New Mechanics:** Seek suggestions on new dynamic need mechanisms or balance adjustments based on community feedback.
2. **Optimization Patterns:** Use C# performance patterns to optimize frequently called code paths within the mod, especially in need computations.
3. **Error Handling:** Include comprehensive logging capabilities for debugging and tracking mod performance during runtime.
4. **Localization Enhancements:** Automate suggestions for keyed translations to support multi-language debugging.
5. **Test Coverage:** Generate unit tests for critical systems like `FulfillmentNeedUtility` to ensure the robustness of need calculations.

---

Feedback and contributions to this mod are greatly appreciated. For detailed discussions regarding the development or issues, please join our Discord channel or submit feedback through the GitHub repository.

For technical issues or troubleshooting, check the following:
- Ensure mod compatibility by loading the Fulfillment mod without other mods initially.
- Use the Log Uploader for logging and error-reporting.

Thank you for contributing to the improvement of RimWorld's modding community!

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

