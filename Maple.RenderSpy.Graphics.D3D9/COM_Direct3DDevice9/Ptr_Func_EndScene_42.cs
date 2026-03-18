using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::EndScene 函数指针 (VTable 索引 42)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe struct Ptr_Func_EndScene_42(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {

        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, COM_HRESULT> 
            _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, COM_HRESULT>)ptr;
        public const string Name = "EndScene";


        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> pThis) => _proc(pThis);

        public nint PtrMethod => new(_proc);
        public override string ToString()
        {
            return PtrMethod.ToString("X8");
        }
    }
}
