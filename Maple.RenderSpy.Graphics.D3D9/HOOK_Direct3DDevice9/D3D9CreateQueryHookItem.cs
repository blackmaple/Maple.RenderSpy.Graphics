using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9CreateQueryHookItem : HookItem<D3D9CreateQueryHookItem, Ptr_Func_CreateQuery_118, Ptr_Func_CreateQuery_118>, IHookItemFactory<D3D9CreateQueryHookItem>
    {
        public const string MethodName = Ptr_Func_CreateQuery_118.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, D3DQUERYTYPE,Maple.UnmanagedExtensions.UnsafeOut<nint>, D3D9CreateQueryHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9CreateQueryHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9CreateQueryHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9CreateQueryHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, D3DQUERYTYPE,Maple.UnmanagedExtensions.UnsafeOut<nint>, COM_HRESULT>
                _proc = &Hook_CreateQuery;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_CreateQuery(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, D3DQUERYTYPE Type,Maple.UnmanagedExtensions.UnsafeOut<nint> ppQuery)
        {
            if (D3D9CreateQueryHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Type, ppQuery, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Type, ppQuery);
            }
            return 0;
        }
    }
}
