using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::GetRasterStatus 函数指针 (VTable 索引 19)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetRasterStatus_19(nint ptr): Maple.Hook.Abstractions.IHookMethod
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DRASTER_STATUS*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DRASTER_STATUS*, int>)ptr;

        public const string Name = "GetRasterStatus";

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint iSwapChain, D3DRASTER_STATUS* pRasterStatus) => _proc(pThis, iSwapChain, pRasterStatus);

        public nint PtrMethod => new(_proc);
        public override string ToString() => PtrMethod.ToString("X8");
    }
}
