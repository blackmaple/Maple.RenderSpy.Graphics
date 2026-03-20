using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Graphics.Direct3D10;
using Windows.Win32.Graphics.Dxgi;

var res = PInvoke.D3D10CreateDevice(
    default,
    Windows.Win32.Graphics.Direct3D10.D3D10_DRIVER_TYPE.D3D10_DRIVER_TYPE_HARDWARE,
    default
    , default, PInvoke.D3D10_SDK_VERSION, out var ppDevice);
var s= nameof(Windows.Win32.Graphics.Dxgi.IDXGIDevice.GetAdapter);
s = nameof(Windows.Win32.Graphics.Dxgi.IDXGIAdapter.GetParent);
s = nameof(Windows.Win32.Graphics.Dxgi.IDXGIFactory.CreateSwapChain);

//ppDevice.CreateQuery
//ppDevice.CreateQuery