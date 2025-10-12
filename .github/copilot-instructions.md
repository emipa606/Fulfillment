# GitHub Copilot Instructions for Fulfillment (Continued) Mod

Welcome to the development environment for the "Fulfillment (Continued)" mod for RimWorld. This file provides guidance and structured instructions to aid developers when using GitHub Copilot to improve and refine the mod.

## Mod Overview & Purpose

The "Fulfillment (Continued)" mod adds depth to colonist needs by introducing the concept of "Fulfillment." Colonists experience varying mood effects based on how passionately they engage with tasks, simulating the fulfilling sensation of engaging in favorite activities. The mod aims to enhance player immersion by allowing colonists to reflect long-lasting feelings of satisfaction or dissatisfaction concerning their activities.

## Key Features and Systems

- **Dynamic Need System**: Introduces a new "Fulfillment" need that affects colonist mood based on recent passionate task completion.
- **Dynamic Rate Changes**: Adjusts the rate of need gain based on the colonist's passion level for the task performed.
- **Balanced Fulfillment Rates**: Ensures gameplay is balanced by dynamically adjusting the decline and gain of fulfillment.

### Fulfillment Levels and Mood Effects

- Very Low Fulfillment (≤ 5%): -10 mood
- Low Fulfillment (5% - 20%): -5 mood
- Medium Low Fulfillment (20% - 40%): -2 mood
- Medium Fulfillment (40% - 55%): +2 mood
- Medium High Fulfillment (55% - 80%): +5 mood
- High Fulfillment (80% - 95%): +8 mood
- Very High Fulfillment (> 95%): +10 mood

**Note**: Fulfillment gradually decreases over time but at a faster rate when it's higher.

## Coding Patterns and Conventions

- **Class Definitions**: Each class should begin with a clear purpose comment. Use PascalCase for class and method names.
- **Consistent Indentation**: Follow the codebase standard of using four spaces per indentation level.
- **Descriptive Naming**: Method and variable names should clearly reflect their role in the code.

## XML Integration

Utilize XML definitions to configure mood effects and thoughts related to fulfillment levels. Ensure XML descriptions are clear and maintain readability. The XML files serve as data containers that the C# code accesses to apply effects and manage the mod's settings.

## Harmony Patching

This mod includes several Harmony patches to integrate new behaviors into existing game systems:

- **JobDriver_DriverTick_Patch.cs**: Patches the job driver tick method to add fulfillment checks after task completion.
- **Pawn_NeedsTracker_AllNeeds_Patch.cs**: Adjusts the needs tracking system to incorporate the new Fulfillment need.
- **Pawn_NeedsTracker_ShouldHaveNeed_Patch.cs**: Determines whether a pawn should have the Fulfillment need.

Be mindful of compatibility with other mods to prevent conflicts.

## Suggestions for Copilot

- **Real-time Suggestions**: Use Copilot for generating boilerplate code, especially for new methods that interact with RimWorld's API.
- **Refinement Suggestions**: Request help refining existing algorithms, such as those determining fulfillment decay rates.
- **Patch Application**: Seek guidance from Copilot on applying Harmony patches and ensuring they are fault-tolerant.
- **XML Management**: Leverage Copilot to assist with writing and maintaining XML definitions.

## Feedback & Support

Your feedback is invaluable for further refinement. For detailed feedback, contact me on Discord: lylerlurden.

If you appreciate the ongoing development of this mod, consider supporting it on GitHub or other channels.

---

Thank you for contributing to the "Fulfillment (Continued)" mod! Happy modding!

This file provides an overview and practical instructions to aid developers using GitHub Copilot when enhancing the "Fulfillment (Continued)" mod for RimWorld, capturing key elements from mod purpose to technical integration specifics.
