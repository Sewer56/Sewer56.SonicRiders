using System;
using System.Linq;
using System.Reflection;

namespace Sewer56.SonicRiders.Utility;

public class ReflectionHelpers
{
    /// <summary>
    /// Gets all types which can be instantiated and assigned to a specified type (T).
    /// </summary>
    public static Type[] GetAllInstantiableTypes<T>(Assembly asm = null)
    {
        if (asm == null)
            asm = Assembly.GetExecutingAssembly();

        var types = asm.GetTypes().Where(x => x.IsAssignableTo(typeof(T)) && !x.IsAbstract && !x.IsInterface);
        return types.ToArray();
    }

    /// <summary>
    /// Creates all instances of a specified type T using reflection.
    /// </summary>
    public static T[] MakeAllInstances<T>(Assembly asm = null)
    {
        return GetAllInstantiableTypes<T>(asm).Select(x => (T)Activator.CreateInstance(x)).ToArray();
    }
}