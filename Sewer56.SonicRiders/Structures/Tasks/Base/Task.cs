using System;
using System.Runtime.InteropServices;
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
        public int MaybeTaskIndex;

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
        public int MaybeTaskIndex;

        /// <summary>
        /// Pointer to task data, such as <see cref="TitleSequence"/> struct or <see cref="CharacterSelect"/> struct.
        /// </summary>
        public T* TaskData;

        /// <summary>
        /// Status of the individual task, such as <see cref="TitleSequenceTaskState"/>
        /// </summary>
        public uint TaskStatus;

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
        public int MaybeTaskIndex;

        /// <summary>
        /// Pointer to task data, such as <see cref="TitleSequence"/> struct or <see cref="CharacterSelect"/> struct.
        /// </summary>
        [FieldOffset(0x10)]
        public void* TaskDataPtr;

        /// <summary>
        /// Status of the individual task, such as <see cref="TitleSequenceTaskState"/>
        /// </summary>
        [FieldOffset(0x14)]
        public uint TaskStatus;

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

    /// <summary>
    /// Specifies a task for an individual SET object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SetObjectTask<T> where T : unmanaged
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
        public int MaybeTaskIndex;

        /// <summary>
        /// Pointer to task data, such as <see cref="TitleSequence"/> struct or <see cref="CharacterSelect"/> struct.
        /// </summary>
        public T* TaskData;

        /// <summary>
        /// Status of the individual task.
        /// </summary>
        public ushort TaskStatus;

        /// <summary>
        /// ID of the indvidual object.
        /// </summary>
        public ushort ItemId;

        /// <summary>
        /// The ASCII character used to denote the "portal" the object belongs to.
        /// Portals are bounding box regions. If the object is outside the portal, it is not rendered.
        /// </summary>
        public byte Portal;

        public byte field_19;

        /// <summary>
        /// The individual attribute assigned to this task.
        /// </summary>
        public ushort Attribute;

        /// <summary>
        /// Seems to hold an index in the object layout, or some other count.
        /// </summary>
        public ushort index_1C;

        /// <summary>
        /// Unknown
        /// </summary>
        public ushort field_1E;
    }
}