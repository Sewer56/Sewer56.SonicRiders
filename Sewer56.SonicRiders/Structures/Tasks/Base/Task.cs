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
        /// <summary>
        /// Function to execute for this task.
        /// </summary>
        public delegate* unmanaged[Cdecl]<void> FunctionToExecute;

        /// <summary>
        /// Function to execute for this task.
        /// </summary>
        public int field_4;

        /// <summary>
        /// Pointer to next task.
        /// </summary>
        public Task* NextTaskPtr;

        /// <summary>
        /// Function to execute for this task.
        /// </summary>
        public int MaybeMaxHeapSize;

        /// <summary>
        /// Pointer to task data, such as <see cref="TitleSequence"/> struct or <see cref="CharacterSelect"/> struct.
        /// </summary>
        public T* TaskData;
        
        /// <summary>
        /// Status of the individual task, such as <see cref="TitleSequenceTaskState"/>
        /// </summary>
        public TStatus TaskStatus;

        /// <summary>
        /// Pointer to previous task.
        /// </summary>
        public Task* PrevTaskPtr;

        /// <summary>
        /// Seems to be arbitrary use.
        /// </summary>
        public int field_1C;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Task<T> where T : unmanaged
    {
        /// <summary>
        /// Function to execute for this task.
        /// </summary>
        public delegate* unmanaged[Cdecl]<void> FunctionToExecute;

        /// <summary>
        /// Function to execute for this task.
        /// </summary>
        public int field_4;

        /// <summary>
        /// Pointer to next task.
        /// </summary>
        public Task* NextTaskPtr;

        /// <summary>
        /// Function to execute for this task.
        /// </summary>
        public int MaybeMaxHeapSize;

        /// <summary>
        /// Pointer to task data, such as <see cref="TitleSequence"/> struct or <see cref="CharacterSelect"/> struct.
        /// </summary>
        public T* TaskData;

        /// <summary>
        /// Status of the individual task, such as <see cref="TitleSequenceTaskState"/>
        /// </summary>
        public byte TaskStatus;

        /// <summary>
        /// Pointer to previous task.
        /// </summary>
        public Task* PrevTaskPtr;

        /// <summary>
        /// Seems to be arbitrary use.
        /// </summary>
        public int field_1C;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct Task
    {
        /// <summary>
        /// Function to execute for this task.
        /// </summary>
        [FieldOffset(0)]
        public delegate* unmanaged[Cdecl]<void> FunctionToExecute;

        /// <summary>
        /// Function to execute for this task.
        /// </summary>
        [FieldOffset(4)]
        public int field_4;

        /// <summary>
        /// Pointer to next task.
        /// </summary>
        [FieldOffset(8)]
        public Task* NextTaskPtr;

        /// <summary>
        /// Function to execute for this task.
        /// </summary>
        [FieldOffset(0x0C)]
        public int MaybeMaxHeapSize;

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

        /// <summary>
        /// Pointer to previous task.
        /// </summary>
        [FieldOffset(0x18)]
        public Task* PrevTaskPtr;

        /// <summary>
        /// Seems to be arbitrary use.
        /// </summary>
        [FieldOffset(0x1C)]
        public int field_1C;
    }
}