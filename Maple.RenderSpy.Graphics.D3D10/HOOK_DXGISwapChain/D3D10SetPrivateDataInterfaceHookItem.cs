using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D10.COM_DXGISwapChain;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D10.HOOK_DXGISwapChain
{
    internal class D3D10SetPrivateDataInterfaceHookItem : HookItem<D3D10SetPrivateDataInterfaceHookItem, Ptr_Func_SetPrivateDataInterface_4, Ptr_Func_SetPrivateDataInterface_4>, IGraphicsHookItem<D3D10SetPrivateDataInterfaceHookItem>
    {
        public const string MethodName = Ptr_Func_SetPrivateDataInterface_4.Name;

        public Func<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeIn<global::System.Guid>, UnsafePtr, D3D10SetPrivateDataInterfaceHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D10SetPrivateDataInterfaceHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D10SetPrivateDataInterfaceHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D10SetPrivateDataInterfaceHookItem>(
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
            if (D3D10SetPrivateDataInterfaceHookItem.TryGet(out var hookItem))
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
