using Windows.Win32.Graphics.Direct3D9;
using Maple.RenderSpy.Graphics.D3D;
using System;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3D9
{

    /// <summary>
    /// 封装 IDirect3D9::CreateDevice 函数指针 (VTable 索引 16)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CreateDevice_16(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DDEVTYPE, void*, uint, D3DPRESENT_PARAMETERS*, void**, int> _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DDEVTYPE, void*, uint, D3DPRESENT_PARAMETERS*, void**, int>)ptr;

        public int Invoke(COM_PTR_IUNKNOWN pThis, uint Adapter, D3DDEVTYPE DeviceType, void* hFocusWindow, uint BehaviorFlags, D3DPRESENT_PARAMETERS* pPresentationParameters, void** ppReturnedDeviceInterface) => _proc(pThis, Adapter, DeviceType, hFocusWindow, BehaviorFlags, pPresentationParameters, ppReturnedDeviceInterface);

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}