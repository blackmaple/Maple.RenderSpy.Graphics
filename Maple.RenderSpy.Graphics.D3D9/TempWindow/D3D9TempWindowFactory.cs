using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3D9;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.UI.WindowsAndMessaging;

namespace Maple.RenderSpy.Graphics.D3D9.TempWindow
{
    internal unsafe sealed class D3D9TempWindowFactory : IDisposable
    {
        nint _ClassNamePointer;
        WNDCLASSEXW _WNDCLASSEX;
        public D3D9TempWindowFactory()
        {
            var className = Guid.NewGuid().ToString("N");
            _ClassNamePointer = Marshal.StringToHGlobalUni(className);
            _WNDCLASSEX = new WNDCLASSEXW
            {
                cbSize = (uint)Unsafe.SizeOf<WNDCLASSEXW>(),
                style = WNDCLASS_STYLES.CS_OWNDC,
                lpfnWndProc = &DefWindowProc,
                cbClsExtra = 0,
                cbWndExtra = 0,
                hInstance = PInvoke.GetModuleHandle(default(char*)),
                hIcon = HICON.Null,
                hCursor = HCURSOR.Null,
                hbrBackground = Windows.Win32.Graphics.Gdi.HBRUSH.Null,
                lpszMenuName = default,
                lpszClassName = new PCWSTR((char*)_ClassNamePointer.ToPointer()),
                hIconSm = HICON.Null,
            };
            var status = PInvoke.RegisterClassEx(in _WNDCLASSEX);
            Debug.Assert(status != 0);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static LRESULT DefWindowProc(HWND hWnd, uint uMsg, WPARAM wParam, LPARAM lParam)
        {
            return PInvoke.DefWindowProc(hWnd, uMsg, wParam, lParam);
        }

        public D3D9TempWindow Create()
        {
            var hwnd = PInvoke.CreateWindowEx(
                WINDOW_EX_STYLE.WS_EX_LEFT,
                  _WNDCLASSEX.lpszClassName, default,
                  WINDOW_STYLE.WS_OVERLAPPEDWINDOW,
                  0, 0, 1, 1,
                  HWND.Null,
                  HMENU.Null,
                  _WNDCLASSEX.hInstance,
                  default);
            return new D3D9TempWindow(hwnd);
        }

        public void Dispose()
        {
            var pointer = this._ClassNamePointer;
            this._ClassNamePointer = nint.Zero;
            if (pointer != IntPtr.Zero)
            {
                PInvoke.UnregisterClass(new PCWSTR((char*)_ClassNamePointer.ToPointer()), this._WNDCLASSEX.hInstance);
                Marshal.FreeHGlobal(pointer);
            }
        }
    }



    internal partial class Direct3DDevice9FunctionsProvider(D3D9TempWindowFactory tempWindowFactory)
    {
        const string DLL = "d3d9.dll";
        const string Export = "Direct3DCreate9";
        Dictionary<string, nint> Functions { get; } = new Dictionary<string, nint>();
        D3D9TempWindowFactory TempWindowFactory { get; } = tempWindowFactory;
        public IReadOnlyDictionary<string, nint> Create()
        {
            if (TryGetLibrary(out var handle) == false && TryLoadLibrary(out handle) == false)
            {
                return RenderSpyGraphicsException.Throw<IReadOnlyDictionary<string, nint>>($"NOT FOUND {DLL}");
            }
            if (TryGetAddress(handle, out var address) == false)
            {
                return RenderSpyGraphicsException.Throw<IReadOnlyDictionary<string, nint>>($"NOT FOUND {Export}");
            }
            var ptrFunc = new Ptr_Func_Direct3DCreate9(address);
            using var ptr_com =   ptrFunc.Invoke(PInvoke.D3D_SDK_VERSION);
            using var frm = TempWindowFactory.Create();
            var createStatus = ptr_com.Interface_VTable.CreateDevice_16.Invoke(ptr_com,
                        PInvoke.D3DADAPTER_DEFAULT,
                    D3DDEVTYPE.D3DDEVTYPE_NULLREF,
                    frm,
                    PInvoke.D3DCREATE_SOFTWARE_VERTEXPROCESSING | PInvoke.D3DCREATE_DISABLE_DRIVER_MANAGEMENT,
                    new D3DPRESENT_PARAMETERS()
                    {
                        BackBufferWidth = 0,
                        BackBufferHeight = 0,
                        BackBufferFormat = D3DFORMAT.D3DFMT_UNKNOWN,
                        BackBufferCount = 0,
                        MultiSampleType = D3DMULTISAMPLE_TYPE.D3DMULTISAMPLE_NONE,
                        SwapEffect = D3DSWAPEFFECT.D3DSWAPEFFECT_DISCARD,
                        hDeviceWindow = frm,
                        Windowed = true,
                        EnableAutoDepthStencil = false,
                        AutoDepthStencilFormat = D3DFORMAT.D3DFMT_UNKNOWN,
                        FullScreen_RefreshRateInHz = 0,

                    },
                    out var ppReturnedDeviceInterface
                    );
            if (createStatus == false)
            {
                return RenderSpyGraphicsException.Throw<IReadOnlyDictionary<string, nint>>($"ERROR {nameof(Ptr_Func_CreateDevice_16)}");
            }

            Functions.Add(Ptr_Func_TestCooperativeLevel_3.Name, ppReturnedDeviceInterface.Interface_VTable.TestCooperativeLevel_3.PtrMethod);

            return Functions;
        }

        static bool TryLoadLibrary(out nint handle)
        {
            string systemDir = Environment.SystemDirectory;
            string d3d9Path = Path.Combine(systemDir, DLL);
            return NativeLibrary.TryLoad(d3d9Path, out handle);
        }

        static bool TryGetLibrary(out nint handle)
        {
            handle = GetModuleHandle(DLL);
            return handle != IntPtr.Zero;
        }

        static bool TryGetAddress(nint handle, out nint address)
        { 
            return NativeLibrary.TryGetExport(handle, Export, out address);
        }

        readonly unsafe struct Ptr_Func_Direct3DCreate9(nint ptr)
        {
            readonly delegate* unmanaged[Stdcall]<uint, COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3D9>> _proc
                = (delegate* unmanaged[Stdcall]<uint, COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3D9>>)ptr;

            public COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3D9> Invoke(uint SDKVersion)
                => _proc(SDKVersion);
        }


        [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
        [LibraryImport("d3d9.dll"), DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static partial COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3D9> Direct3DCreate9(uint SDKVersion);

        [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
        [LibraryImport("kernel32.dll", EntryPoint = "GetModuleHandleW", StringMarshalling = StringMarshalling.Utf16)]
        internal static partial IntPtr GetModuleHandle(string lpModuleName);
    }
}
