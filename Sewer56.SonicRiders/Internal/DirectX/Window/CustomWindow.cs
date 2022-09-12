using System;
using System.Runtime.InteropServices;

namespace Sewer56.SonicRiders.Internal.DirectX.Window;

internal class CustomWindow : IDisposable
{
    public IntPtr Hwnd { get; private set; }

    private const int ErrorClassAlreadyExists = 1410;
    private bool _disposed;
    private WndProc _wndProcDelegate;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed) 
            return;

        if (disposing)
        {
            // Dispose managed resources
        }

        // Dispose unmanaged resources
        if (Hwnd != IntPtr.Zero)
        {
            DestroyWindow(Hwnd);
            Hwnd = IntPtr.Zero;
        }
    }

    public CustomWindow(string className)
    {
        if (className == null) 
            throw new Exception("className is null");

        if (className == String.Empty) 
            throw new Exception("className is empty");

        _wndProcDelegate = CustomWndProc;
        Wndclass wndClass = new Wndclass();
        wndClass.lpszClassName = className;
        wndClass.lpfnWndProc = Marshal.GetFunctionPointerForDelegate(_wndProcDelegate);

        UInt16 classAtom = RegisterClassW(ref wndClass);
        int lastError = Marshal.GetLastWin32Error();

        if (classAtom == 0 && lastError != ErrorClassAlreadyExists)
            throw new Exception("Could not register window class");

        // Create window
        Hwnd = CreateWindowExW(0, className, String.Empty, 0, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
    }

    private static IntPtr CustomWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
    {
        return DefWindowProcW(hWnd, msg, wParam, lParam);
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    struct Wndclass
    {
        public uint style;
        public IntPtr lpfnWndProc;
        public int cbClsExtra;
        public int cbWndExtra;
        public IntPtr hInstance;
        public IntPtr hIcon;
        public IntPtr hCursor;
        public IntPtr hbrBackground;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszMenuName;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszClassName;
    }

    delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    #region Native
    [DllImport("user32.dll", SetLastError = true)]
    static extern UInt16 RegisterClassW([In] ref Wndclass lpWndClass);

    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr CreateWindowExW
    (
        UInt32 dwExStyle,
        [MarshalAs(UnmanagedType.LPWStr)]
        string lpClassName,
        [MarshalAs(UnmanagedType.LPWStr)]
        string lpWindowName,
        UInt32 dwStyle,
        Int32 x,
        Int32 y,
        Int32 nWidth,
        Int32 nHeight,
        IntPtr hWndParent,
        IntPtr hMenu,
        IntPtr hInstance,
        IntPtr lpParam
    );

    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr DefWindowProcW(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool DestroyWindow(IntPtr hWnd);
    #endregion
}