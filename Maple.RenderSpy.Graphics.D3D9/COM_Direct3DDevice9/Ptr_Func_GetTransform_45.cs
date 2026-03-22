using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
using Windows.Win32.Graphics.Direct3D;
using Maple.UnmanagedExtensions;
using Maple.RenderSpy.Graphics.COM;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::GetTransform 函数指针 (VTable 索引 45)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetTransform_45(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, global::Windows.Win32.Graphics.Direct3D9.D3DTRANSFORMSTATETYPE, UnsafeRef<global::Windows.Win32.Graphics.Direct3D.D3DMATRIX>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, global::Windows.Win32.Graphics.Direct3D9.D3DTRANSFORMSTATETYPE, UnsafeRef<global::Windows.Win32.Graphics.Direct3D.D3DMATRIX>, COM_HRESULT>)ptr;

        public const string Name = "GetTransform";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, global::Windows.Win32.Graphics.Direct3D9.D3DTRANSFORMSTATETYPE State, UnsafeRef<global::Windows.Win32.Graphics.Direct3D.D3DMATRIX> pMatrix) => _proc(pThis, State, pMatrix);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
