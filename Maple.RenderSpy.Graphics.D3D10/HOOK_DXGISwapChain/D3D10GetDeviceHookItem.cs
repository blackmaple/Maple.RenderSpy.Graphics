using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D10.COM_DXGISwapChain;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D10.HOOK_DXGISwapChain
{
    internal class D3D10GetDeviceHookItem : HookItem<D3D10GetDeviceHookItem, Ptr_Func_GetDevice_7, Ptr_Func_GetDevice_7>, IGraphicsHookItem<D3D10GetDeviceHookItem>
    {
        public const string MethodName = Ptr_Func_GetDevice_7.Name;

        public Func<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeIn<global::System.Guid>, UnsafeOut<nint>, D3D10GetDeviceHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D10GetDeviceHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D10GetDeviceHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D10GetDeviceHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeIn<global::System.Guid>, UnsafeOut<nint>, COM_HRESULT>
                _proc = &Hook_GetDevice;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetDevice(COM_PTR_IUNKNOWN<IDXGISwapChainImp> @this, UnsafeIn<global::System.Guid> riid, UnsafeOut<nint> ppDevice)
        {
            if (D3D10GetDeviceHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, riid, ppDevice, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, riid, ppDevice);
            }
            return 0;
        }
    }
}
