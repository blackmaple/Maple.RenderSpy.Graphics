using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetBackBufferHookItem : HookItem<D3D9GetBackBufferHookItem, Ptr_Func_GetBackBuffer_18, Ptr_Func_GetBackBuffer_18>, IHookItemFactory<D3D9GetBackBufferHookItem>
    {
        public const string MethodName = Ptr_Func_GetBackBuffer_18.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, uint, D3DBACKBUFFER_TYPE, nint, D3D9GetBackBufferHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetBackBufferHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetBackBufferHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetBackBufferHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, uint, D3DBACKBUFFER_TYPE, nint, COM_HRESULT>
                _proc = &Hook_GetBackBuffer;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetBackBuffer(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint iSwapChain, uint iBackBuffer, D3DBACKBUFFER_TYPE Type, nint ppBackBuffer)
        {
            if (D3D9GetBackBufferHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, iSwapChain, iBackBuffer, Type, ppBackBuffer, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, iSwapChain, iBackBuffer, Type, ppBackBuffer);
            }
            return 0;
        }
    }
}
