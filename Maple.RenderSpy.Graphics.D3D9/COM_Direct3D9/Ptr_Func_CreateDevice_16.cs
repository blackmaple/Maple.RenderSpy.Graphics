using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using Maple.UnmanagedExtensions;
using System;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3D9
{

    /// <summary>
    /// 封装 IDirect3D9::CreateDevice 函数指针 (VTable 索引 16)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal readonly unsafe struct Ptr_Func_CreateDevice_16(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DDEVTYPE, HWND, uint, UnsafeIn<D3DPRESENT_PARAMETERS>, UnsafeOut<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>>, COM_HRESULT> 
            _proc = (delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN, uint, D3DDEVTYPE, HWND, uint, UnsafeIn<D3DPRESENT_PARAMETERS>, UnsafeOut<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>>, COM_HRESULT>)ptr;

        public COM_HRESULT Invoke(COM_PTR_IUNKNOWN pThis, uint Adapter, D3DDEVTYPE DeviceType, HWND hFocusWindow, uint BehaviorFlags, in D3DPRESENT_PARAMETERS pPresentationParameters, out COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> ppReturnedDeviceInterface) 
            => _proc(pThis, Adapter, DeviceType, hFocusWindow, BehaviorFlags, UnsafeIn<D3DPRESENT_PARAMETERS>.FromIn(in pPresentationParameters), UnsafeOut<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>>.FromOut(out ppReturnedDeviceInterface));

        public override string ToString()
        {
            return (new nint(_proc)).ToString("X8");
        }
    }
}