using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace Maple.RenderSpy.Graphics.D3D9
{
    using Maple.RenderSpy.Graphics.D3D;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    // 1. RegisterSoftwareDevice
    public readonly unsafe struct Ptr_Func_RegisterSoftwareDevice(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<nint, COM_HRESULT> _ptr = (delegate* unmanaged[Stdcall]<nint, COM_HRESULT>)ptr;

        public COM_HRESULT Invoke(nint pInitializeFunction) => _ptr(pInitializeFunction);

        public static implicit operator Ptr_Func_RegisterSoftwareDevice(nint ptr)
            => new(ptr);
    }

    // 2. GetAdapterCount
    public readonly unsafe struct Ptr_Func_GetAdapterCount(nint ptr)
    {
        private readonly delegate* unmanaged[Stdcall]<COM_HRESULT> _ptr = (delegate* unmanaged[Stdcall]<COM_HRESULT>)ptr;

        public COM_HRESULT Invoke() => _ptr();

        public static implicit operator Ptr_Func_GetAdapterCount(nint ptr)
            => new Ptr_Func_GetAdapterCount(ptr);
    }

    // 3. GetAdapterIdentifier
    public readonly unsafe struct Ptr_Func_GetAdapterIdentifier
    {
        private readonly delegate* unmanaged[Stdcall]<uint, uint, D3DADAPTER_IDENTIFIER9*, uint> _ptr;

        public Ptr_Func_GetAdapterIdentifier(nint ptr)
        {
            _ptr = (delegate* unmanaged[Stdcall]<uint, uint, D3DADAPTER_IDENTIFIER9*, uint>)ptr;
        }

        public uint Invoke(uint Adapter, uint Flags, out D3DADAPTER_IDENTIFIER9 pIdentifier)
        {
            fixed (D3DADAPTER_IDENTIFIER9* pId = &pIdentifier)
            {
                return _ptr(Adapter, Flags, pId);
            }
        }

        public static implicit operator Ptr_Func_GetAdapterIdentifier(nint ptr)
            => new Ptr_Func_GetAdapterIdentifier(ptr);
    }

    // 4. GetAdapterModeCount
    public readonly unsafe struct Ptr_Func_GetAdapterModeCount
    {
        private readonly delegate* unmanaged[Stdcall]<uint, D3DFORMAT, uint> _ptr;

        public Ptr_Func_GetAdapterModeCount(nint ptr)
        {
            _ptr = (delegate* unmanaged[Stdcall]<uint, D3DFORMAT, uint>)ptr;
        }

        public uint Invoke(uint Adapter, D3DFORMAT Format) => _ptr(Adapter, Format);

        public static implicit operator Ptr_Func_GetAdapterModeCount(nint ptr)
            => new Ptr_Func_GetAdapterModeCount(ptr);
    }

    // 5. EnumAdapterModes
    public readonly unsafe struct Ptr_Func_EnumAdapterModes
    {
        private readonly delegate* unmanaged[Stdcall]<uint, D3DFORMAT, uint, D3DDISPLAYMODE*, uint> _ptr;

        public Ptr_Func_EnumAdapterModes(nint ptr)
        {
            _ptr = (delegate* unmanaged[Stdcall]<uint, D3DFORMAT, uint, D3DDISPLAYMODE*, uint>)ptr;
        }

        public uint Invoke(uint Adapter, D3DFORMAT Format, uint Mode, out D3DDISPLAYMODE pMode)
        {
            fixed (D3DDISPLAYMODE* pDisplayMode = &pMode)
            {
                return _ptr(Adapter, Format, Mode, pDisplayMode);
            }
        }

        public static implicit operator Ptr_Func_EnumAdapterModes(nint ptr)
            => new Ptr_Func_EnumAdapterModes(ptr);
    }

    // 6. GetAdapterDisplayMode
    public readonly unsafe struct Ptr_Func_GetAdapterDisplayMode
    {
        private readonly delegate* unmanaged[Stdcall]<uint, D3DDISPLAYMODE*, uint> _ptr;

        public Ptr_Func_GetAdapterDisplayMode(nint ptr)
        {
            _ptr = (delegate* unmanaged[Stdcall]<uint, D3DDISPLAYMODE*, uint>)ptr;
        }

        public uint Invoke(uint Adapter, out D3DDISPLAYMODE pMode)
        {
            fixed (D3DDISPLAYMODE* pDisplayMode = &pMode)
            {
                return _ptr(Adapter, pDisplayMode);
            }
        }

        public static implicit operator Ptr_Func_GetAdapterDisplayMode(nint ptr)
            => new Ptr_Func_GetAdapterDisplayMode(ptr);
    }

    // 7. CheckDeviceType
    public readonly unsafe struct Ptr_Func_CheckDeviceType
    {
        private readonly delegate* unmanaged[Stdcall]<uint, D3DDEVTYPE, D3DFORMAT, D3DFORMAT, uint, uint> _ptr;

        public Ptr_Func_CheckDeviceType(nint ptr)
        {
            _ptr = (delegate* unmanaged[Stdcall]<uint, D3DDEVTYPE, D3DFORMAT, D3DFORMAT, uint, uint>)ptr;
        }

        public uint Invoke(uint Adapter, D3DDEVTYPE DevType, D3DFORMAT AdapterFormat, D3DFORMAT BackBufferFormat, uint bWindowed)
            => _ptr(Adapter, DevType, AdapterFormat, BackBufferFormat, bWindowed);

        public static implicit operator Ptr_Func_CheckDeviceType(nint ptr)
            => new Ptr_Func_CheckDeviceType(ptr);
    }

    // 8. CheckDeviceFormat
    public readonly unsafe struct Ptr_Func_CheckDeviceFormat
    {
        private readonly delegate* unmanaged[Stdcall]<uint, D3DDEVTYPE, D3DFORMAT, uint, D3DRESOURCETYPE, D3DFORMAT, uint> _ptr;

        public Ptr_Func_CheckDeviceFormat(nint ptr)
        {
            _ptr = (delegate* unmanaged[Stdcall]<uint, D3DDEVTYPE, D3DFORMAT, uint, D3DRESOURCETYPE, D3DFORMAT, uint>)ptr;
        }

        public uint Invoke(uint Adapter, D3DDEVTYPE DeviceType, D3DFORMAT AdapterFormat, uint Usage, D3DRESOURCETYPE RType, D3DFORMAT CheckFormat)
            => _ptr(Adapter, DeviceType, AdapterFormat, Usage, RType, CheckFormat);

        public static implicit operator Ptr_Func_CheckDeviceFormat(nint ptr)
            => new Ptr_Func_CheckDeviceFormat(ptr);
    }

    // 9. CheckDeviceMultiSampleType
    public readonly unsafe struct Ptr_Func_CheckDeviceMultiSampleType
    {
        private readonly delegate* unmanaged[Stdcall]<uint, D3DDEVTYPE, D3DFORMAT, uint, D3DMULTISAMPLE_TYPE, uint*, uint> _ptr;

        public Ptr_Func_CheckDeviceMultiSampleType(nint ptr)
        {
            _ptr = (delegate* unmanaged[Stdcall]<uint, D3DDEVTYPE, D3DFORMAT, uint, D3DMULTISAMPLE_TYPE, uint*, uint>)ptr;
        }

        public uint Invoke(uint Adapter, D3DDEVTYPE DeviceType, D3DFORMAT SurfaceFormat, uint Windowed, D3DMULTISAMPLE_TYPE MultiSampleType, out uint pQualityLevels)
        {
            fixed (uint* pQuality = &pQualityLevels)
            {
                return _ptr(Adapter, DeviceType, SurfaceFormat, Windowed, MultiSampleType, pQuality);
            }
        }

        public static implicit operator Ptr_Func_CheckDeviceMultiSampleType(nint ptr)
            => new Ptr_Func_CheckDeviceMultiSampleType(ptr);
    }

    // 10. CheckDepthStencilMatch
    public readonly unsafe struct Ptr_Func_CheckDepthStencilMatch
    {
        private readonly delegate* unmanaged[Stdcall]<uint, D3DDEVTYPE, D3DFORMAT, D3DFORMAT, D3DFORMAT, uint> _ptr;

        public Ptr_Func_CheckDepthStencilMatch(nint ptr)
        {
            _ptr = (delegate* unmanaged[Stdcall]<uint, D3DDEVTYPE, D3DFORMAT, D3DFORMAT, D3DFORMAT, uint>)ptr;
        }

        public uint Invoke(uint Adapter, D3DDEVTYPE DeviceType, D3DFORMAT AdapterFormat, D3DFORMAT RenderTargetFormat, D3DFORMAT DepthStencilFormat)
            => _ptr(Adapter, DeviceType, AdapterFormat, RenderTargetFormat, DepthStencilFormat);

        public static implicit operator Ptr_Func_CheckDepthStencilMatch(nint ptr)
            => new Ptr_Func_CheckDepthStencilMatch(ptr);
    }

    // 11. CheckDeviceFormatConversion
    public readonly unsafe struct Ptr_Func_CheckDeviceFormatConversion
    {
        private readonly delegate* unmanaged[Stdcall]<uint, D3DDEVTYPE, D3DFORMAT, D3DFORMAT, uint> _ptr;

        public Ptr_Func_CheckDeviceFormatConversion(nint ptr)
        {
            _ptr = (delegate* unmanaged[Stdcall]<uint, D3DDEVTYPE, D3DFORMAT, D3DFORMAT, uint>)ptr;
        }

        public uint Invoke(uint Adapter, D3DDEVTYPE DeviceType, D3DFORMAT SourceFormat, D3DFORMAT TargetFormat)
            => _ptr(Adapter, DeviceType, SourceFormat, TargetFormat);

        public static implicit operator Ptr_Func_CheckDeviceFormatConversion(nint ptr)
            => new Ptr_Func_CheckDeviceFormatConversion(ptr);
    }

    // 12. GetDeviceCaps
    public readonly unsafe struct Ptr_Func_GetDeviceCaps
    {
        private readonly delegate* unmanaged[Stdcall]<uint, D3DDEVTYPE, D3DCAPS9*, uint> _ptr;

        public Ptr_Func_GetDeviceCaps(nint ptr)
        {
            _ptr = (delegate* unmanaged[Stdcall]<uint, D3DDEVTYPE, D3DCAPS9*, uint>)ptr;
        }

        public uint Invoke(uint Adapter, D3DDEVTYPE DevType, out D3DCAPS9 pCaps)
        {
            fixed (D3DCAPS9* pCapsPtr = &pCaps)
            {
                return _ptr(Adapter, DevType, pCapsPtr);
            }
        }

        public static implicit operator Ptr_Func_GetDeviceCaps(nint ptr)
            => new Ptr_Func_GetDeviceCaps(ptr);
    }

    // 13. GetAdapterMonitor
    public readonly unsafe struct Ptr_Func_GetAdapterMonitor
    {
        private readonly delegate* unmanaged[Stdcall]<uint, nint> _ptr;

        public Ptr_Func_GetAdapterMonitor(nint ptr)
        {
            _ptr = (delegate* unmanaged[Stdcall]<uint, nint>)ptr;
        }

        public nint Invoke(uint Adapter) => _ptr(Adapter);

        public static implicit operator Ptr_Func_GetAdapterMonitor(nint ptr)
            => new Ptr_Func_GetAdapterMonitor(ptr);
    }

    // 14. CreateDevice
    public readonly unsafe struct Ptr_Func_CreateDevice
    {
        private readonly delegate* unmanaged[Stdcall]<uint, D3DDEVTYPE, nint, uint, D3DPRESENT_PARAMETERS*, IDirect3DDevice9**, uint> _ptr;

        public Ptr_Func_CreateDevice(nint ptr)
        {
            _ptr = (delegate* unmanaged[Stdcall]<uint, D3DDEVTYPE, nint, uint, D3DPRESENT_PARAMETERS*, IDirect3DDevice9**, uint>)ptr;
        }

        public uint Invoke(uint Adapter, D3DDEVTYPE DeviceType, nint hFocusWindow, uint BehaviorFlags,
            ref D3DPRESENT_PARAMETERS pPresentationParameters, out IDirect3DDevice9 ppReturnedDeviceInterface)
        {
            fixed (D3DPRESENT_PARAMETERS* pParams = &pPresentationParameters)
            {
                IDirect3DDevice9* pDevice = null;
                uint hr = _ptr(Adapter, DeviceType, hFocusWindow, BehaviorFlags, pParams, &pDevice);
                ppReturnedDeviceInterface = pDevice != null ? new IDirect3DDevice9((nint)pDevice) : null;
                return hr;
            }
        }

        public static implicit operator Ptr_Func_CreateDevice(nint ptr)
            => new Ptr_Func_CreateDevice(ptr);
    }
}
