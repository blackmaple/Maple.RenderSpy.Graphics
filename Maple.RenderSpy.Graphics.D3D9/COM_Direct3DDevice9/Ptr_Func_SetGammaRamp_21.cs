using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::SetGammaRamp 函数指针 (VTable 索引 21)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_SetGammaRamp_21(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, D3DGAMMARAMP*, void> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, uint, D3DGAMMARAMP*, void>)ptr;

        public void Invoke(COM_PTR_IUNKNOWN pThis, uint iSwapChain, uint Flags, D3DGAMMARAMP* pRamp) => _proc(pThis, iSwapChain, Flags, pRamp);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
