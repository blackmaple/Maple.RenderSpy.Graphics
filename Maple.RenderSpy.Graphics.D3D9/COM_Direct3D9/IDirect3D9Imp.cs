using Maple.RenderSpy.Graphics.D3D;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;
namespace Maple.RenderSpy.Graphics.D3D9.COM_Direct3D9
{
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct IDirect3D9Imp
    {
        public Ptr_Func_RegisterSoftwareDevice_3 RegisterSoftwareDevice_3;
        public Ptr_Func_GetAdapterCount_4 GetAdapterCount_4;
        public Ptr_Func_GetAdapterIdentifier_5 GetAdapterIdentifier_5;
        public Ptr_Func_GetAdapterModeCount_6 GetAdapterModeCount_6;
        public Ptr_Func_EnumAdapterModes_7 EnumAdapterModes_7;
        public Ptr_Func_GetAdapterDisplayMode_8 GetAdapterDisplayMode_8;
        public Ptr_Func_CheckDeviceType_9 CheckDeviceType_9;
        public Ptr_Func_CheckDeviceFormat_10 CheckDeviceFormat_10;
        public Ptr_Func_CheckDeviceMultiSampleType_11 CheckDeviceMultiSampleType_11;
        public Ptr_Func_CheckDepthStencilMatch_12 CheckDepthStencilMatch_12;
        public Ptr_Func_CheckDeviceFormatConversion_13 CheckDeviceFormatConversion_13;
        public Ptr_Func_GetDeviceCaps_14 GetDeviceCaps_14;
        public Ptr_Func_GetAdapterMonitor_15 GetAdapterMonitor_15;
        public Ptr_Func_CreateDevice_16 CreateDevice_16;

    }



}

