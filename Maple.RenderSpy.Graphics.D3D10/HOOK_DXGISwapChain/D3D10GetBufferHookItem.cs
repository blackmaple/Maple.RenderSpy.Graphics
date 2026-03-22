using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D10.COM_DXGISwapChain;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Dxgi;

namespace Maple.RenderSpy.Graphics.D3D10.HOOK_DXGISwapChain
{
    internal class D3D10GetBufferHookItem : HookItem<D3D10GetBufferHookItem, Ptr_Func_GetBuffer_9, Ptr_Func_GetBuffer_9>, IGraphicsHookItem<D3D10GetBufferHookItem>
    {
        public const string MethodName = Ptr_Func_GetBuffer_9.Name;

        public Func<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, uint, UnsafeIn<global::System.Guid>, UnsafePtr, D3D10GetBufferHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D10GetBufferHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D10GetBufferHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D10GetBufferHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, uint, UnsafeIn<global::System.Guid>, UnsafeOut<nint>, COM_HRESULT>
                _proc = &Hook_GetBuffer;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetBuffer(COM_PTR_IUNKNOWN<IDXGISwapChainImp> @this, uint Buffer, UnsafeIn<System.Guid> riid, UnsafeOut<nint> ppSurface)
        {

            if (D3D10GetBufferHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Buffer, riid, ppSurface, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Buffer, riid, ppSurface);
            }
            return COM_HRESULT.S_FALSE;
        }
    }
}
