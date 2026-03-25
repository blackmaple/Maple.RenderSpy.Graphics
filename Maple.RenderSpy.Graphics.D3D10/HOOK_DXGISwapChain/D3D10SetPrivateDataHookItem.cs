using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D10.COM_DXGISwapChain;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D10.HOOK_DXGISwapChain
{
    internal class D3D10SetPrivateDataHookItem : HookItem<D3D10SetPrivateDataHookItem, Ptr_Func_SetPrivateData_3, Ptr_Func_SetPrivateData_3>, IGraphicsHookItem<D3D10SetPrivateDataHookItem>
    {
        public const string MethodName = Ptr_Func_SetPrivateData_3.Name;

        public Func<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeIn<global::System.Guid>, uint, UnsafePtr, D3D10SetPrivateDataHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D10SetPrivateDataHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D10SetPrivateDataHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D10SetPrivateDataHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeIn<global::System.Guid>, uint, UnsafePtr, COM_HRESULT>
                _proc = &Hook_SetPrivateData;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetPrivateData(COM_PTR_IUNKNOWN<IDXGISwapChainImp> @this, UnsafeIn<global::System.Guid> Name, uint DataSize, UnsafePtr pData)
        {
            if (D3D10SetPrivateDataHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Name, DataSize, pData, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Name, DataSize, pData);
            }
            return 0;
        }
    }
}
