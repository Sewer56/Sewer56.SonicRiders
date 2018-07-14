
# Introduction

Sewer56.SonicRiders is an easy to use, and complete to all reverse engineering knowledge of the game C# library designed for the use of hacking with Reloaded Mod Loader. The library provides definitions, implementations and direct memory access to all of the known game's functions, variables and structures.

## Usage

*Sewer56.SonicRiders.Fields* provides you with direct easy access to different data structures live in game memory through the use of pointers - allowing you to easily edit memory on the fly.

Example:
```csharp
Fields.Players.Player[0].ExtremeGear = Structures.Enums.ExtremeGear.TurboStar;
```

*Sewer56.SonicRiders.Mathematics*  provides you with various formulas to calculate various statistics on players depending on several key factors, for example 

```csharp
public static float GetGearSpeed(ExtremeGear* extremeGear, FormationTypes formationType)
```

would return the regular driving speed at level 1 for a specified gear and character combination.

*Sewer56.SonicRiders.Structures* provides the various different structures, enumerables and other custom definitions for the game 
```csharp
    public struct RunningPhysics2
    {
        /// <summary>
        /// The maximum speed until a switch to gear 2 is performed.
        /// </summary>
        public float GearOneMaxSpeed;

        /// <summary>
        /// The maximum speed of gear 2.
        /// </summary>
        public float GearTwoMaxSpeed;

        /// <summary>
        /// Defines the speed limit for gear 2.
        /// </summary>
        public float MaxSpeed;

        /// <summary>
        /// Defines the acceleration of gear 1.
        /// </summary>
        public float GearOneAcceleration;

        /// <summary>
        /// Defines the acceleration of gear 2.
        /// </summary>
        public float GearTwoAcceleration;

        /// <summary>
        /// Defines the acceleration of gear 3. (When exceeding gearTwoMaxSpeed)
        /// </summary>
        public float GearThreeAcceleration;

        /// <summary>
        /// Unknown
        /// </summary>
        public float Field_18;
    }
```
