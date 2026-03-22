using Maple.RenderSpy.Graphics.COM;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 设置顶点着色器
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetVertexShader_92(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        // 原函数指针: private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, nint, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, nint, int>)ptr;
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, nint, COM_HRESULT> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, nint, COM_HRESULT>)ptr;

        public const string Name = "SetVertexShader";

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> pThis, nint pShader) => _proc(pThis, pShader);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
