using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D10.COM_DXGISwapChain;
using Maple.UnmanagedExtensions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D10.HOOK_DXGISwapChain
{
    internal class D3D10GetPrivateDataHookItem : HookItem<D3D10GetPrivateDataHookItem, Ptr_Func_GetPrivateData_5, Ptr_Func_GetPrivateData_5>, IHookItemFactory<D3D10GetPrivateDataHookItem>
    {
        public const string MethodName = Ptr_Func_GetPrivateData_5.Name;

        public Func<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeIn<global::System.Guid>, UnsafeOut<uint>, UnsafePtr, D3D10GetPrivateDataHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D10GetPrivateDataHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D10GetPrivateDataHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D10GetPrivateDataHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDXGISwapChainImp>, UnsafeIn<global::System.Guid>, UnsafeOut<uint>, UnsafeOut<nint>, COM_HRESULT>
                _proc = &Hook_GetPrivateData;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetPrivateData(COM_PTR_IUNKNOWN<IDXGISwapChainImp> @this, UnsafeIn<global::System.Guid> Name, UnsafeOut<uint> pDataSize, UnsafeOut<nint> pData)
        {
            if (D3D10GetPrivateDataHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Name, pDataSize, pData, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Name, pDataSize, pData);
            }
            return 0;
        }
    }
}
