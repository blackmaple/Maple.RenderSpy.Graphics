using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Maple.RenderSpy.Graphics.DXGI.COM_DXGISwapChain;

namespace Maple.RenderSpy.Graphics.DXGI.HOOK_DXGISwapChain
{
    internal class DXGISetPrivateDataInterfaceHookItem : HookItem<DXGISetPrivateDataInterfaceHookItem, Ptr_Func_SetPrivateDataInterface_4, Ptr_Func_SetPrivateDataInterface_4>, IGraphicsHookItem<DXGISetPrivateDataInterfaceHookItem>
    {
        public const string MethodName = Ptr_Func_SetPrivateDataInterface_4.Name;

        public Func<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeIn<global::System.Guid>, UnsafePtr, DXGISetPrivateDataInterfaceHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static DXGISetPrivateDataInterfaceHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<DXGISetPrivateDataInterfaceHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<DXGISetPrivateDataInterfaceHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeIn<global::System.Guid>, UnsafePtr, COM_HRESULT>
                _proc = &Hook_SetPrivateDataInterface;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetPrivateDataInterface(COM_PTR_IUNKNOWN<IDXGISwapChainImp> @this, UnsafeIn<global::System.Guid> Name, UnsafePtr pUnknown)
        {
            if (DXGISetPrivateDataInterfaceHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Name, pUnknown, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this,  Name, pUnknown);
            }
            return 0;
        }
    }
}
