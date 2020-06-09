using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X64;
using SharpDX.Direct3D9;
using CallingConventions = Reloaded.Hooks.Definitions.X86.CallingConventions;

namespace Sewer56.SonicRiders.Internal.DirectX
{
    /// <summary>
    /// Provides access to DirectX 9 functions.
    /// </summary>
    public class DX9Hook
    {
        /// <summary>
        /// Contains the DX9 device VTable.
        /// </summary>
        public IVirtualFunctionTable DeviceVTable { get; private set; }

        /// <summary>
        /// Contains the DX9 VTable.
        /// </summary>
        public IVirtualFunctionTable Direct3D9VTable { get; private set; }

        public DX9Hook(IReloadedHooks _hooks)
        {
            // Obtain the pointer to the IDirect3DDevice9 instance by creating our own blank windows form and creating a  
            // IDirect3DDevice9 targeting that form. The returned device should be the same one as used by the program.
            using (var direct3D = new Direct3D())
            using (var renderForm = new Form())
            using (var device = new Device(direct3D, 0, DeviceType.NullReference, IntPtr.Zero, CreateFlags.HardwareVertexProcessing, new PresentParameters() { BackBufferWidth = 1, BackBufferHeight = 1, DeviceWindowHandle = renderForm.Handle }))
            {
                Direct3D9VTable = _hooks.VirtualFunctionTableFromObject(direct3D.NativePointer, Enum.GetNames(typeof(IDirect3D9)).Length);
                DeviceVTable = _hooks.VirtualFunctionTableFromObject(device.NativePointer, Enum.GetNames(typeof(IDirect3DDevice9)).Length);
            }
        }

        /// <summary>
        /// Defines the IDirect3DDevice9.EndScene function, allowing us to render ontop of the DirectX instance.
        /// </summary>
        /// <param name="device">Pointer to the individual Direct3D9 device.</param>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [Reloaded.Hooks.Definitions.X86.Function(CallingConventions.Stdcall)]
        public delegate IntPtr EndScene(IntPtr device);

        /// <summary>
        /// Defines the IDirect3DDevice9.Reset function, called when the resolution or Windowed/Fullscreen state changes.
        /// changes.
        /// </summary>
        /// <param name="device">Pointer to the individual Direct3D9 device.</param>
        /// <param name="presentParameters">Pointer to a D3DPRESENT_PARAMETERS structure, describing the new presentation parameters.</param>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [Reloaded.Hooks.Definitions.X86.Function(CallingConventions.Stdcall)]
        public delegate IntPtr Reset(IntPtr device, ref PresentParameters presentParameters);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [Function(Reloaded.Hooks.Definitions.X64.CallingConventions.Microsoft)]
        [Reloaded.Hooks.Definitions.X86.Function(CallingConventions.Stdcall)]
        public unsafe delegate IntPtr CreateDevice(IntPtr direct3DPointer, uint adapter, DeviceType deviceType, IntPtr hFocusWindow, CreateFlags behaviorFlags, ref PresentParameters pPresentationParameters, int** ppReturnedDeviceInterface);
    }

    /// <summary>
    /// Contains a full list of IDirect3DDevice9 functions to be used alongside
    /// <see cref="DX9Hook"/> as an indexer into the Virtual Function Table entries.
    /// </summary>
    public enum IDirect3DDevice9
    {
        QueryInterface = 0,
        AddRef = 1,
        Release = 2,
        TestCooperativeLevel = 3,
        GetAvailableTextureMem = 4,
        EvictManagedResources = 5,
        GetDirect3D = 6,
        GetDeviceCaps = 7,
        GetDisplayMode = 8,
        GetCreationParameters = 9,
        SetCursorProperties = 10,
        SetCursorPosition = 11,
        ShowCursor = 12,
        CreateAdditionalSwapChain = 13,
        GetSwapChain = 14,
        GetNumberOfSwapChains = 15,
        Reset = 16,
        Present = 17,
        GetBackBuffer = 18,
        GetRasterStatus = 19,
        SetDialogBoxMode = 20,
        SetGammaRamp = 21,
        GetGammaRamp = 22,
        CreateTexture = 23,
        CreateVolumeTexture = 24,
        CreateCubeTexture = 25,
        CreateVertexBuffer = 26,
        CreateIndexBuffer = 27,
        CreateRenderTarget = 28,
        CreateDepthStencilSurface = 29,
        UpdateSurface = 30,
        UpdateTexture = 31,
        GetRenderTargetData = 32,
        GetFrontBufferData = 33,
        StretchRect = 34,
        ColorFill = 35,
        CreateOffscreenPlainSurface = 36,
        SetRenderTarget = 37,
        GetRenderTarget = 38,
        SetDepthStencilSurface = 39,
        GetDepthStencilSurface = 40,
        BeginScene = 41,
        EndScene = 42,
        Clear = 43,
        SetTransform = 44,
        GetTransform = 45,
        MultiplyTransform = 46,
        SetViewport = 47,
        GetViewport = 48,
        SetMaterial = 49,
        GetMaterial = 50,
        SetLight = 51,
        GetLight = 52,
        LightEnable = 53,
        GetLightEnable = 54,
        SetClipPlane = 55,
        GetClipPlane = 56,
        SetRenderState = 57,
        GetRenderState = 58,
        CreateStateBlock = 59,
        BeginStateBlock = 60,
        EndStateBlock = 61,
        SetClipStatus = 62,
        GetClipStatus = 63,
        GetTexture = 64,
        SetTexture = 65,
        GetTextureStageState = 66,
        SetTextureStageState = 67,
        GetSamplerState = 68,
        SetSamplerState = 69,
        ValidateDevice = 70,
        SetPaletteEntries = 71,
        GetPaletteEntries = 72,
        SetCurrentTexturePalette = 73,
        GetCurrentTexturePalette = 74,
        SetScissorRect = 75,
        GetScissorRect = 76,
        SetSoftwareVertexProcessing = 77,
        GetSoftwareVertexProcessing = 78,
        SetNPatchMode = 79,
        GetNPatchMode = 80,
        DrawPrimitive = 81,
        DrawIndexedPrimitive = 82,
        DrawPrimitiveUP = 83,
        DrawIndexedPrimitiveUP = 84,
        ProcessVertices = 85,
        CreateVertexDeclaration = 86,
        SetVertexDeclaration = 87,
        GetVertexDeclaration = 88,
        SetFVF = 89,
        GetFVF = 90,
        CreateVertexShader = 91,
        SetVertexShader = 92,
        GetVertexShader = 93,
        SetVertexShaderConstantF = 94,
        GetVertexShaderConstantF = 95,
        SetVertexShaderConstantI = 96,
        GetVertexShaderConstantI = 97,
        SetVertexShaderConstantB = 98,
        GetVertexShaderConstantB = 99,
        SetStreamSource = 100,
        GetStreamSource = 101,
        SetStreamSourceFreq = 102,
        GetStreamSourceFreq = 103,
        SetIndices = 104,
        GetIndices = 105,
        CreatePixelShader = 106,
        SetPixelShader = 107,
        GetPixelShader = 108,
        SetPixelShaderConstantF = 109,
        GetPixelShaderConstantF = 110,
        SetPixelShaderConstantI = 111,
        GetPixelShaderConstantI = 112,
        SetPixelShaderConstantB = 113,
        GetPixelShaderConstantB = 114,
        DrawRectPatch = 115,
        DrawTriPatch = 116,
        DeletePatch = 117,
        CreateQuery = 118,
    }

    /// <summary>
    /// Contains a full list of IDirect3DDevice9Ex functions to be used alongside
    /// <see cref="DX9Hook"/> as an indexer into the Virtual Function Table entries.
    /// </summary>
    public enum Direct3DDevice9Ex
    {
        SetConvolutionMonoKernel = 119,
        ComposeRects = 120,
        PresentEx = 121,
        GetGPUThreadPriority = 122,
        SetGPUThreadPriority = 123,
        WaitForVBlank = 124,
        CheckResourceResidency = 125,
        SetMaximumFrameLatency = 126,
        GetMaximumFrameLatency = 127,
        CheckDeviceState_ = 128,
        CreateRenderTargetEx = 129,
        CreateOffscreenPlainSurfaceEx = 130,
        CreateDepthStencilSurfaceEx = 131,
        ResetEx = 132,
        GetDisplayModeEx = 133,
    }

    /// <summary>
    /// Contains the D3D9 interface.
    /// </summary>
    public enum IDirect3D9
    {
        /*** IUnknown methods ***/
        QueryInterface,
        AddRef,
        Release,

        /*** IDirect3D9 methods ***/
        RegisterSoftwareDevice,
        GetAdapterCount,
        GetAdapterIdentifier,
        GetAdapterModeCount,
        EnumAdapterModes,
        GetAdapterDisplayMode,
        CheckDeviceType,
        CheckDeviceFormat,
        CheckDeviceMultiSampleType,
        CheckDepthStencilMatch,
        CheckDeviceFormatConversion,
        GetDeviceCaps,
        GetAdapterMonitor,
        CreateDevice
    }
}