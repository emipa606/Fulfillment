# GitHub Copilot Instructions for "Fulfillment (Continued)" Mod

## Mod Overview and Purpose

**Fulfillment (Continued)** is an updated version of Lewkah0's mod designed to deepen the emotional experience of colonists in RimWorld. The mod introduces the concept of "Fulfillment," a need that reflects whether colonists have engaged in activities they are passionate about. This mechanic enhances gameplay by providing colonists with longer-lasting feelings about their passionate endeavors, directly influencing their moods and adding a new layer of challenge and realism to managing your colony.

## Key Features and Systems

- **Dynamic Need System:** Adds a new "Fulfillment" need to colonists, affecting their mood based on recent activities.
- **Passion-Based Rate Changes:** The gain and decay of the Fulfillment need is based on the colonist's passion for the task.
- **Balanced Fulfillment Rates:** Carefully adjusted need levels ensure balanced gameplay and realistic emotional states for colonists.
- **Fulfillment Levels and Effects:** Affect mood with a range from Very Low to Very High, influencing overall happiness based on engaged activities.
  
    | Fulfillment Level            | Mood Effect | Description                                                                 |
    |------------------------------|-------------|-----------------------------------------------------------------------------|
    | Very Low Fulfillment (5%)    | -10         | "I feel very unfulfilled because I haven't gotten to do any work I'm passionate about!" |
    | Low Fulfillment (5% - 20%)   | -5          | "I feel unfulfilled because I haven't gotten to do enough work I'm passionate about." |
    | Medium Low Fulfillment (20% - 40%) | -2      | "I'm somewhat unfulfilled because I haven't gotten to do enough work I'm passionate about." |
    | Medium Fulfillment (40% - 55%) | +2        | "I'm somewhat fulfilled as I've been able to do some work I'm passionate about." |
    | Medium High Fulfillment (55% - 80%) | +5    | "I feel fulfilled because I've been able to engage in work that I'm passionate about." |
    | High Fulfillment (80% - 95%)  | +8         | "I'm highly fulfilled because I've been doing a lot of work I'm passionate about!" |
    | Very High Fulfillment (95%)   | +10        | "I'm extremely fulfilled because I've been doing a lot of work I'm passionate about continuously!" |

- **Exclusions:** Animals and mechanoids are not affected by this need.

## Coding Patterns and Conventions

- Utilizes static classes for utility functions and extensions (`JobDriver_DriverTick`, `Pawn_NeedsTracker` series).
- Uses object-oriented principles, inheriting from core classes (`Need`, `Thought_Memory`) for new game mechanics.
- Employs encapsulation to handle internal state and behavior, like mood effects and thought applications in the `Need_Fulfillment` class.

## XML Integration

- XML files are updated for keyed translations, ensuring internationalization support.
- XML integration is crucial for defining new thoughts, mood modulations, and need dependencies.

## Harmony Patching

- Use Harmony for robust code patching, enabling dynamic updates without disturbing core functionalities.
- Ensure Harmony patches are modular and reversible to avoid conflicts with other mods.

## Suggestions for Copilot

- **Refactoring and Optimization:** Use Copilot to suggest refactoring patterns that improve code readability and efficiency, especially in methods like `GainFulfillment` and `applyMoodEffects`.
- **Error Handling:** Implement comprehensive error handling to ensure smooth gameplay experience, using Copilot suggestions for try-catch blocks.
- **Code Documentation:** Employ Copilot to assist in creating detailed XML comments for classes and methods, improving maintainability.
- **Feature Expansion:** Utilize Copilot to draft and prototype additional features or balancing mechanics, like new interactions between Fulfillment levels and other needs.

By adhering to these guidelines, the "Fulfillment (Continued)" mod not only enhances gameplay by adding depth to colonist needs and moods but also ensures that the codebase remains clean, efficient, and maintainable for future development.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The .github/copilot-instructions.md file is included in the solution under the .github solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution .github copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.
