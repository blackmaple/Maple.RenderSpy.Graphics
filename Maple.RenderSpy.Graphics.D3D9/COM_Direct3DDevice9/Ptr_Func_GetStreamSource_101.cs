using Maple.RenderSpy.Graphics.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 获取流源
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetStreamSource_101(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<int>, Maple.UnmanagedExtensions.UnsafeRef<int>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeOut<nint>, Maple.UnmanagedExtensions.UnsafeRef<int>, Maple.UnmanagedExtensions.UnsafeRef<int>, COM_HRESULT>)ptr;

        public const string Name = "GetStreamSource";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, uint StreamNumber, Maple.UnmanagedExtensions.UnsafeOut<nint> ppStreamData, Maple.UnmanagedExtensions.UnsafeRef<int> pOffsetInBytes, Maple.UnmanagedExtensions.UnsafeRef<int> pStride) => _proc(pThis, StreamNumber, ppStreamData, pOffsetInBytes, pStride);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
