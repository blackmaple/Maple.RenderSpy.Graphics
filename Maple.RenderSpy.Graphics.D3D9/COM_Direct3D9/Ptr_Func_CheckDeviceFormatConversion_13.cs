using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3D9
{
    /// <summary>
    /// 封装 IDirect3D9::CheckDeviceFormatConversion 函数指针 (VTable 索引 13)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CheckDeviceFormatConversion_13(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DDEVTYPE, D3DFORMAT, D3DFORMAT, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DDEVTYPE, D3DFORMAT, D3DFORMAT, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint Adapter, D3DDEVTYPE DeviceType, D3DFORMAT SourceFormat, D3DFORMAT TargetFormat) => _proc(pThis, Adapter, DeviceType, SourceFormat, TargetFormat);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}