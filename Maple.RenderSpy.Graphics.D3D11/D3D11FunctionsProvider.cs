using Maple.RenderSpy.Graphics;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D11.COM_D3D11Device;
using Maple.RenderSpy.Graphics.D3D11.COM_D3D11DeviceContext;
using Maple.RenderSpy.Graphics.D3D11.COM_DXGIAdapter;
using Maple.RenderSpy.Graphics.D3D11.COM_DXGIDevice;
using Maple.RenderSpy.Graphics.D3D11.COM_DXGIFactory;
using Maple.RenderSpy.Graphics.D3D11.COM_DXGISwapChain;
using Maple.RenderSpy.Graphics.TempWindow;
using Maple.UnmanagedExtensions;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Direct3D;
using Windows.Win32.Graphics.Direct3D11;
using Windows.Win32.Graphics.Dxgi;
using Windows.Win32.Graphics.Dxgi.Common;
namespace Maple.RenderSpy.Graphics.D3D11
{
    internal partial class D3D11FunctionsProvider : GraphicsFunctionsProvider, IGraphicsFunctions<D3D11FunctionsProvider>
    {
        //     public Dictionary<string, nint> Functions { get; }= [];


        public static D3D11FunctionsProvider Create(IServiceProvider provider)
        {
            D3DTempWindowFactory windowFactory = provider.GetRequiredService<D3DTempWindowFactory>();

            using var pDevice = CreateID3D11DeviceImp();
            using var pDXGIDevice = CreateIDXGIDeviceImp(pDevice);
            using var pAdapter = CreateIDXGIAdapterImp(pDXGIDevice);
            using var pFactory = CreateIDXGIFactoryImp(pAdapter);
            using var pSwapChain = CreateIDXGISwapChainImp(pFactory, pDevice, windowFactory);

            var functions = new D3D11FunctionsProvider();
            functions.TryAddGraphicsFunctions(COM_DXGISwapChain.Ptr_Func_SetPrivateData_3.Name, pSwapChain.Interface_VTable.SetPrivateData_3.PtrMethod);
            functions.TryAddGraphicsFunctions(COM_DXGISwapChain.Ptr_Func_SetPrivateDataInterface_4.Name, pSwapChain.Interface_VTable.SetPrivateDataInterface_4.PtrMethod);
            functions.TryAddGraphicsFunctions(COM_DXGISwapChain.Ptr_Func_GetPrivateData_5.Name, pSwapChain.Interface_VTable.GetPrivateData_5.PtrMethod);
            functions.TryAddGraphicsFunctions(COM_DXGISwapChain.Ptr_Func_GetParent_6.Name, pSwapChain.Interface_VTable.GetParent_6.PtrMethod);
            functions.TryAddGraphicsFunctions(COM_DXGISwapChain.Ptr_Func_GetDevice_7.Name, pSwapChain.Interface_VTable.GetDevice_7.PtrMethod);
            functions.TryAddGraphicsFunctions(COM_DXGISwapChain.Ptr_Func_Present_8.Name, pSwapChain.Interface_VTable.Present_8.PtrMethod);
            functions.TryAddGraphicsFunctions(COM_DXGISwapChain.Ptr_Func_GetBuffer_9.Name, pSwapChain.Interface_VTable.GetBuffer_9.PtrMethod);
            functions.TryAddGraphicsFunctions(COM_DXGISwapChain.Ptr_Func_SetFullscreenState_10.Name, pSwapChain.Interface_VTable.SetFullscreenState_10.PtrMethod);
            functions.TryAddGraphicsFunctions(COM_DXGISwapChain.Ptr_Func_GetFullscreenState_11.Name, pSwapChain.Interface_VTable.GetFullscreenState_11.PtrMethod);
            functions.TryAddGraphicsFunctions(COM_DXGISwapChain.Ptr_Func_GetDesc_12.Name, pSwapChain.Interface_VTable.GetDesc_12.PtrMethod);
            functions.TryAddGraphicsFunctions(COM_DXGISwapChain.Ptr_Func_ResizeBuffers_13.Name, pSwapChain.Interface_VTable.ResizeBuffers_13.PtrMethod);
            functions.TryAddGraphicsFunctions(COM_DXGISwapChain.Ptr_Func_ResizeTarget_14.Name, pSwapChain.Interface_VTable.ResizeTarget_14.PtrMethod);
            functions.TryAddGraphicsFunctions(COM_DXGISwapChain.Ptr_Func_GetContainingOutput_15.Name, pSwapChain.Interface_VTable.GetContainingOutput_15.PtrMethod);
            functions.TryAddGraphicsFunctions(COM_DXGISwapChain.Ptr_Func_GetFrameStatistics_16.Name, pSwapChain.Interface_VTable.GetFrameStatistics_16.PtrMethod);
            functions.TryAddGraphicsFunctions(COM_DXGISwapChain.Ptr_Func_GetLastPresentCount_17.Name, pSwapChain.Interface_VTable.GetLastPresentCount_17.PtrMethod);

            return functions;




        }

        private static COM_PTR_IUNKNOWN<ID3D11DeviceImp> CreateID3D11DeviceImp()
        {

            var hResult = D3D11CreateDevice(
                default,
                D3D_DRIVER_TYPE.D3D_DRIVER_TYPE_HARDWARE,
                Windows.Win32.Foundation.HMODULE.Null,
                default,
                default, 0U,
                PInvoke.D3D11_SDK_VERSION,

                UnsafeOut<COM_PTR_IUNKNOWN<ID3D11DeviceImp>>.FromOut(out var ppDevice),
                new UnsafePtr<D3D_FEATURE_LEVEL>(nint.Zero),
                new UnsafePtr<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>>(nint.Zero)

                );

            if (hResult.Failed)
            {
                return RenderSpyGraphicsException.Throw<COM_PTR_IUNKNOWN<ID3D11DeviceImp>>($"{nameof(CreateID3D11DeviceImp)}:{hResult.Value:X8}");
            }
            return ppDevice;
        }
        private static COM_PTR_IUNKNOWN<IDXGIDeviceImp> CreateIDXGIDeviceImp(COM_PTR_IUNKNOWN<ID3D11DeviceImp> pDevice)
        {
            var hResult = pDevice.QueryInterface<IDXGIDeviceImp>(IDXGIDeviceImp.GUID, out var pDXGIDevice);
            if (!hResult)
            {
                return RenderSpyGraphicsException.Throw<COM_PTR_IUNKNOWN<IDXGIDeviceImp>>($"{nameof(CreateIDXGIDeviceImp)}:{hResult.Value:X8}");
            }
            return pDXGIDevice;
        }
        private static COM_PTR_IUNKNOWN<IDXGIAdapterImp> CreateIDXGIAdapterImp(COM_PTR_IUNKNOWN<IDXGIDeviceImp> pDXGIDevice)
        {

            var hResult = pDXGIDevice.Interface_VTable.GetAdapter_7.Invoke(pDXGIDevice, out var pAdapter);
            if (hResult.Failed)
            {
                return RenderSpyGraphicsException.Throw<COM_PTR_IUNKNOWN<IDXGIAdapterImp>>($"{nameof(CreateIDXGIAdapterImp)}:{hResult.Value:X8}");
            }
            return pAdapter;
        }
        private static COM_PTR_IUNKNOWN<IDXGIFactoryImp> CreateIDXGIFactoryImp(COM_PTR_IUNKNOWN<IDXGIAdapterImp> pAdapter)
        {

            var hResult = pAdapter.Interface_VTable.GetParent_6.Invoke(pAdapter, in IDXGIFactoryImp.GUID, out var ppParent);
            if (hResult.Failed)
            {
                return RenderSpyGraphicsException.Throw<COM_PTR_IUNKNOWN<IDXGIFactoryImp>>($"{nameof(CreateIDXGIFactoryImp)}:{hResult.Value:X8}");
            }
            return ppParent;
        }
        private static COM_PTR_IUNKNOWN<IDXGISwapChainImp> CreateIDXGISwapChainImp(
            COM_PTR_IUNKNOWN<IDXGIFactoryImp> pFactory,
            COM_PTR_IUNKNOWN<ID3D11DeviceImp> pDevice,
            D3DTempWindowFactory windowFactory)
        {
            using var from = windowFactory.Create();
            var swapChainDesc = new DXGI_SWAP_CHAIN_DESC
            {
                BufferDesc = new DXGI_MODE_DESC
                {
                    Width = 100,
                    Height = 100,
                    Format = DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM,
                    RefreshRate = new DXGI_RATIONAL { Numerator = 60, Denominator = 1 }
                },
                SampleDesc = new DXGI_SAMPLE_DESC { Count = 1, Quality = 0 },
                BufferUsage = DXGI_USAGE.DXGI_USAGE_RENDER_TARGET_OUTPUT,
                BufferCount = 1,
                OutputWindow = new HWND(from.Handle),
                Windowed = true,
                SwapEffect = DXGI_SWAP_EFFECT.DXGI_SWAP_EFFECT_DISCARD
            };
            var hResult = pFactory.Interface_VTable.CreateSwapChain_10.Invoke(pFactory, pDevice, in swapChainDesc, out var ppSwapChain);
            if (hResult.Failed)
            {
                return RenderSpyGraphicsException.Throw<COM_PTR_IUNKNOWN<IDXGISwapChainImp>>($"{nameof(CreateIDXGISwapChainImp)}:{hResult.Value:X8}");
            }
            return ppSwapChain;
        }


        //internal static unsafe winmdroot.Foundation.HRESULT D3D11CreateDevice(
        //    [Optional] winmdroot.Graphics.Dxgi.IDXGIAdapter pAdapter, 
        //    winmdroot.Graphics.Direct3D.D3D_DRIVER_TYPE DriverType, 
        //    [Optional] winmdroot.Foundation.HMODULE Software, 
        //    winmdroot.Graphics.Direct3D11.D3D11_CREATE_DEVICE_FLAG Flags, 
        //    [Optional] ReadOnlySpan<winmdroot.Graphics.Direct3D.D3D_FEATURE_LEVEL> pFeatureLevels, 
        //    uint SDKVersion, 
        //    out winmdroot.Graphics.Direct3D11.ID3D11Device ppDevice, 
        //    out winmdroot.Graphics.Direct3D.D3D_FEATURE_LEVEL pFeatureLevel, 
        //    out winmdroot.Graphics.Direct3D11.ID3D11DeviceContext ppImmediateContext)

        const string LibraryName = "d3d11.dll";
        const string EntryPoint = "D3D11CreateDevice";

        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
        [LibraryImport(LibraryName, EntryPoint = EntryPoint)]
        private static unsafe partial HRESULT D3D11CreateDevice(
            nint pAdapter,
            D3D_DRIVER_TYPE DriverType,
            HMODULE Software,
            D3D11_CREATE_DEVICE_FLAG Flags,
            UnsafeIn<D3D_FEATURE_LEVEL> pFeatureLevels,
            uint FeatureLevels,
            uint SDKVersion,
            UnsafeOut<COM_PTR_IUNKNOWN<ID3D11DeviceImp>> ppDevice,
            UnsafeOut<D3D_FEATURE_LEVEL> pFeatureLevel,
            UnsafeOut<COM_PTR_IUNKNOWN<ID3D11DeviceContextImp>> ppImmediateContext);

    }

}
