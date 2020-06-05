# Introduction

Sewer56.SonicRiders is an easy to use, and complete to all reverse engineering knowledge of the game C# library designed for the use of hacking with Reloaded II. The library provides definitions, implementations and direct memory access to all of the known game's functions, variables and structures.

## Usage

### API

*Sewer56.SonicRiders.API* provides you with direct easy access to API that allows you to easily perform various different actions such as editing different data structures through the use of pointer wrappers - allowing you to easily edit memory on the fly.

Example:
```csharp
Player.Players[0].ExtremeGear = Structures.Enums.ExtremeGear.TurboStar;
```

### Functions

*Sewer56.SonicRiders.Functions* provides you with a huge listing of game functions. These functions can be easily called or hooked.

**Calling Example**
```csharp
Functions.GetInputs.GetWrapper()(/* No Parameters */);
```

**Hooking Example**
```csharp
_blockInputsHook = Functions.GetInputs.Hook(BlockGameInputsIfEnabled).Activate();

private int BlockGameInputsIfEnabled()
{
	// Skips game controller input obtain function is menu is open.
    if (!_isEnabled)
    	return _blockInputsHook.OriginalFunction();

    return 0;
}
```

### Structures
*Sewer56.SonicRiders.Structures* provides the various different structures, enumerables and other custom definitions for the game:

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

### Utility Functions

*Sewer56.SonicRiders.Utility*  provides you with various utility functions such as custom formulas to calculate various statistics on players depending on several key factors, for example:

```csharp
public static float GetGearSpeed(ExtremeGear* extremeGear, FormationTypes formationType)
```

would return the regular driving speed at level 1 for a specified gear and character combination.
