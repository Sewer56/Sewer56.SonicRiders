using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using Sewer56.SonicRiders.Structures.Enums;

namespace Sewer56.SonicRiders.Functions
{
    public partial class Functions
    {
        /// <summary>
        /// Allows you to play a music track.
        /// CRI SDK: ADXT_StartFname
        /// </summary>
        public static readonly IFunction<PlayMusicFn> PlayMusic = SDK.ReloadedHooks.CreateFunction<PlayMusicFn>(0x0054EB30);

        /// <summary>
        /// Allows you to load an AFS file.
        /// CRI SDK: ADXF_LoadPartitionNwFn
        /// </summary>
        public static readonly IFunction<ADXF_LoadPartitionNwFn> LoadAFSNoWait = SDK.ReloadedHooks.CreateFunction<ADXF_LoadPartitionNwFn>(0x0054D770);

        /// <summary>
        /// Checks the status of the CRI AFS partition load.
        /// CRI SDK: ADXF_GetPtStat
        /// </summary>
        public static readonly IFunction<ADXF_GetPtStatFn> AfsGetStatus = SDK.ReloadedHooks.CreateFunction<ADXF_GetPtStatFn>(0x0054DA60);

        /// <summary>
        /// Executes the CRI ADX & AFS Engine. Updates the internal status of the CRI library.
        /// CRI SDK: ADXF_GetPtStat
        /// </summary>
        public static readonly IFunction<CdeclReturnIntFn> ADXM_ExecMain = SDK.ReloadedHooks.CreateFunction<CdeclReturnIntFn>(0x0054CD30);

        /// <summary>
        /// Plays a music track.
        /// </summary>
        /// <param name="unknown">This is an unknown pointer. Presumably to some object from the CRI SDK.</param>
        /// <param name="song">The relative file path to the Data folder inside the game directory.</param>
        /// <remarks>ADXT_StartFname</remarks>
        [Function(CallingConventions.Cdecl)]
        public unsafe delegate int PlayMusicFn(void* unknown, string song);

        /// <summary>
        /// Requests to read partition information of AFS file. And sets the partition ID.
        /// After you called this function, you must check status by <see cref="ADXF_GetPtStatFn"/>
        /// function and wait for partition load to complete. You can use the partition once the 
        /// partition load will complete.
        /// </summary>
        /// <param name="ptid">Partition ID. Riders uses 0 - 2.</param>
        /// <param name="fName">AFS file name.</param>
        /// <param name="dir">Directory information.</param>
        /// <param name="ptInfo">Partition information read-in area.</param>
        [Function(CallingConventions.Cdecl)]
        public unsafe delegate int ADXF_LoadPartitionNwFn(int ptid, string fName, void* dir, void* ptInfo);

        /// <summary>
        /// Gets the partition loading state. 
        /// Use this function after calling <see cref="ADXF_LoadPartitionNwFn"/> function and wait for partition load to complete. 
        /// You can use the partition if partition load completes.
        /// </summary>
        /// <param name="ptid">Partition ID.</param>
        /// <returns></returns>
        [Function(CallingConventions.Cdecl)]
        public unsafe delegate AdxfStat ADXF_GetPtStatFn(int ptid);
    }
}
