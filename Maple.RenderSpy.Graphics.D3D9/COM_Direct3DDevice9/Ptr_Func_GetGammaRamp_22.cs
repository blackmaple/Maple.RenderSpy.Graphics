using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9
{
    /// <summary>
    /// 封装 IDirect3DDevice9::GetGammaRamp 函数指针 (VTable 索引 22)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_GetGammaRamp_22(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DGAMMARAMP*, void> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DGAMMARAMP*, void>)ptr;

        public void Invoke(COM_PTR_IUNKNOWN pThis, uint iSwapChain, D3DGAMMARAMP* pRamp) => _proc(pThis, iSwapChain, pRamp);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}
