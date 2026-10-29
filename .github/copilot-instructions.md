# GitHub Copilot Instructions for Combat Bionics (Continued)

## Mod Overview and Purpose
Combat Bionics (Continued) is an update to the Freefolks mod for RimWorld. It adds advanced bionic implants that enhance combat capabilities, allowing players to carry more weapons and engage in Mandalorian-style combat. The mod introduces various bionics such as a minigun arm, swarm wrist, jump pack spine, flamethrower arm, laser wrist, tesla wrist, and tear gas arm, each with unique combat advantages. The mod requires the Vanilla Factions Expanded (VFE) series and the Royalty mod for some features.

## Key Features and Systems
- **Minigun Arm**: A bionic arm with a built-in retractable minigun.
- **Swarm Wrist**: An advanced bionic hand with a built-in missile swarm launcher.
- **Jump Pack Spine**: A bionic spine with a built-in jump pack system, requiring the Royalty mod.
- **Flamer Wrist**: A bionic arm with a built-in flamethrower, requiring the VWE - Heavy Weapons mod.
- **Laser Wrist**: A bionic hand with a built-in laser shooter, requiring the VWE - Laser mod.
- **Tesla Wrist**: A bionic hand with a built-in electric weapon, requiring the VWE - Laser mod.
- **Tear Gas Arm**: A bionic arm with a built-in tear gas launcher, requiring the VWE - Non-Lethal mod.

## Coding Patterns and Conventions
- **Namespaces**: Use a consistent namespace structure, typically `CombatBionics` or `CombatBionics.<Feature>`.
- **File Structure**: Organize code files logically, such as separating bionics, recipes, and projectiles into different folders.
- **Naming Conventions**: Use PascalCase for class and method names, and camelCase for local variables.
- **Comments**: Provide clear comments for complex logic and important sections of code.
- **Error Handling**: Implement robust error handling to ensure mod stability and user-friendliness.

## XML Integration
The mod uses XML files to define its bionics, recipes, and other game elements. Here are some guidelines for working with these files:

- **Def Files**: Place all def files in the `Defs` folder, organizing them by feature (e.g., `Bionics`, `Recipes`).
- **HediffDef**: Define the properties of each bionic in `HediffDef` files.
- **RecipeDef**: Define the recipes for installing the bionics in `RecipeDef` files.
- **ThingDef**: Define the physical properties of the bionic items in `ThingDef` files.

Example of a `HediffDef` file:
xml
<HediffDef>
    <label>Minigun Arm</label>
    <description>A bionic arm with a built-in retractable minigun.</description>
    <defName>MinigunArm</defName>
    <isPermanent>true</isPermanent>
    <pawnEffect>CombatBionics.MinigunArmEffect</pawnEffect>
</HediffDef>


## Harmony Patching
Combat Bionics uses Harmony for patching vanilla game mechanics to integrate the bionics smoothly. Here are some guidelines for using Harmony:

- **Patch Classes**: Define patch classes with the `[HarmonyPatch]` attribute, specifying the target method or class.
- **Prefix/Postfix Methods**: Use `Prefix` and `Postfix` methods to modify or extend the behavior of the target method.
- **Static Methods**: Ensure that patch methods are static to avoid issues with instance state.

Example of a Harmony patch:
csharp
using HarmonyLib;
using RimWorld;
using Verse;

namespace CombatBionics.Patches
{
    [HarmonyPatch(typeof(Pawn), "TakeDamage")]
    public static class Pawn_TakeDamage_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(Pawn __instance, ref DamageInfo dinfo)
        {
            // Custom damage handling logic
            return true;
        }
    }
}


## Suggestions for Copilot
- **Code Snippets**: Generate code snippets for common tasks such as creating a new bionic, defining a recipe, or implementing a Harmony patch.
- **XML Templates**: Provide XML templates for defining bionics, recipes, and other game elements.
- **Error Handling**: Suggest best practices for error handling and logging.
- **Mod Integration**: Offer guidance on integrating with other mods and ensuring compatibility.

By following these guidelines, you can effectively use GitHub Copilot to enhance the Combat Bionics (Continued) mod and ensure a smooth development experience.

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

