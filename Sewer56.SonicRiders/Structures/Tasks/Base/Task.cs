using System;
using System.Runtime.InteropServices;
using Sewer56.SonicRiders.Structures.Tasks.Enums;
using Sewer56.SonicRiders.Structures.Tasks.Enums.States;

namespace Sewer56.SonicRiders.Structures.Tasks.Base
{
    // Note: CLR does not allow generics with Explicit Layout
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Task<T, TStatus> where T : unmanaged where TStatus : unmanaged, Enum
    {
        private fixed byte _padding[0x10];

        /// <summary>
        /// Pointer to task data, such as <see cref="TitleSequence"/> struct or <see cref="CharacterSelect"/> struct.
        /// </summary>
        public T* TaskData;
        
        /// <summary>
        /// Status of the individual task, such as <see cref="TitleSequenceTaskState"/>
        /// </summary>
        public TStatus TaskStatus;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Task<T> where T : unmanaged
    {
        private fixed byte _padding[0x10];

        /// <summary>
        /// Pointer to task data, such as <see cref="TitleSequence"/> struct or <see cref="CharacterSelect"/> struct.
        /// </summary>
        public T* TaskData;

        /// <summary>
        /// Status of the individual task, such as <see cref="TitleSequenceTaskState"/>
        /// </summary>
        public byte TaskStatus;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct Task
    {
        /// <summary>
        /// Pointer to task data, such as <see cref="TitleSequence"/> struct or <see cref="CharacterSelect"/> struct.
        /// </summary>
        [FieldOffset(0x10)]
        public void* TaskDataPtr;

        /// <summary>
        /// Status of the individual task, such as <see cref="TitleSequenceTaskState"/>
        /// </summary>
        [FieldOffset(0x14)]
        public byte TaskStatus;
    }
}