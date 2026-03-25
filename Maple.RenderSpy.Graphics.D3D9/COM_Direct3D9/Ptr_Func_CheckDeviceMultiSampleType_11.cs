using Maple.RenderSpy.Graphics.Windows.COM;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3D9
{
    /// <summary>
    /// 封装 IDirect3D9::CheckDeviceMultiSampleType 函数指针 (VTable 索引 11)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CheckDeviceMultiSampleType_11(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DDEVTYPE, D3DFORMAT, int, D3DMULTISAMPLE_TYPE, uint*, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DDEVTYPE, D3DFORMAT, int, D3DMULTISAMPLE_TYPE, uint*, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint Adapter, D3DDEVTYPE DeviceType, D3DFORMAT SurfaceFormat, int Windowed, D3DMULTISAMPLE_TYPE MultiSampleType, uint* pQualityLevels) => _proc(pThis, Adapter, DeviceType, SurfaceFormat, Windowed, MultiSampleType, pQualityLevels);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}