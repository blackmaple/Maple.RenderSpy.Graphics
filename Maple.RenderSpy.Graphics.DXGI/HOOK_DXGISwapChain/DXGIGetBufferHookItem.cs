using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Dxgi;
using Maple.RenderSpy.Graphics.DXGI.COM_DXGISwapChain;

namespace Maple.RenderSpy.Graphics.DXGI.HOOK_DXGISwapChain
{
    internal class DXGIGetBufferHookItem : HookItem<DXGIGetBufferHookItem, Ptr_Func_GetBuffer_9, Ptr_Func_GetBuffer_9>, IGraphicsHookItem<DXGIGetBufferHookItem>
    {
        public const string MethodName = Ptr_Func_GetBuffer_9.Name;

        public Func<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, uint, UnsafeIn<global::System.Guid>, UnsafeOut<COM_PTR_IUNKNOWN>, DXGIGetBufferHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static DXGIGetBufferHookItem Create(ISupperHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<DXGIGetBufferHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<DXGIGetBufferHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, uint, UnsafeIn<global::System.Guid>, UnsafeOut<COM_PTR_IUNKNOWN>, COM_HRESULT>
                _proc = &Hook_GetBuffer;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetBuffer(COM_PTR_IUNKNOWN<IDXGISwapChainImp> @this, uint Buffer, UnsafeIn<System.Guid> riid, UnsafeOut<COM_PTR_IUNKNOWN> ppSurface)
        {

            if (DXGIGetBufferHookItem.TryGet(out var hookItem))
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
