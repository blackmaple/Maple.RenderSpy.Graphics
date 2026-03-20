using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 获取流源频率
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetStreamSourceFreq_103(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<int>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeRef<int>, COM_HRESULT>)ptr;

        public const string Name = "GetStreamSourceFreq";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, uint StreamNumber, Maple.UnmanagedExtensions.UnsafeRef<int> pDivider) => _proc(pThis, StreamNumber, pDivider);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
