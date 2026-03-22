using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D10.COM_DXGISwapChain;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D10.HOOK_DXGISwapChain
{
    internal class D3D10GetLastPresentCountHookItem : HookItem<D3D10GetLastPresentCountHookItem, Ptr_Func_GetLastPresentCount_17, Ptr_Func_GetLastPresentCount_17>, IHookItemFactory<D3D10GetLastPresentCountHookItem>
    {
        public const string MethodName = Ptr_Func_GetLastPresentCount_17.Name;

        public Func<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeOut<uint>, D3D10GetLastPresentCountHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D10GetLastPresentCountHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D10GetLastPresentCountHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D10GetLastPresentCountHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeOut<uint>, COM_HRESULT>
                _proc = &Hook_GetLastPresentCount;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetLastPresentCount(COM_PTR_IUNKNOWN<IDXGISwapChainImp> @this, UnsafeOut<uint> pLastPresentCount)
        {
            if (D3D10GetLastPresentCountHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pLastPresentCount, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, pLastPresentCount);
            }
            return 0;
        }
    }
}
