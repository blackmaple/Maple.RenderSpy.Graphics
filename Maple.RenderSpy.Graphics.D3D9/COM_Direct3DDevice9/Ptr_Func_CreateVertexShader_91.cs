using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 创建顶点着色器
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CreateVertexShader_91(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, Maple.UnmanagedExtensions.UnsafeRef<int>, Maple.UnmanagedExtensions.UnsafeOut<nint>, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, Maple.UnmanagedExtensions.UnsafeRef<int>, Maple.UnmanagedExtensions.UnsafeOut<nint>, COM_HRESULT>)ptr;

        public const string Name = "CreateVertexShader";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, Maple.UnmanagedExtensions.UnsafeRef<int> pFunction, Maple.UnmanagedExtensions.UnsafeOut<nint> ppShader) => _proc(pThis, pFunction, ppShader);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
