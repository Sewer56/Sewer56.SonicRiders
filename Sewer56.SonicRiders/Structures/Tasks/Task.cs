using System.Runtime.InteropServices;

namespace Sewer56.SonicRiders.Structures.Tasks
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct Task
    {
        /// <summary>
        /// Pointer to task data, such as <see cref="Menus.MainMenu"/> struct or <see cref="Menus.CharacterSelectMenu"/> struct.
        /// </summary>
        [FieldOffset(0x10)]
        public void* TaskDataPtr;

        /// <summary>
        /// Status of the individual task, such as <see cref="Enums.Task.MenuTaskState"/>
        /// </summary>
        [FieldOffset(0x14)]
        public byte TaskStatus;
    }
}