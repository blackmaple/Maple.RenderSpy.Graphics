using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9CreateStateBlockHookItem : HookItem<D3D9CreateStateBlockHookItem, Ptr_Func_CreateStateBlock_59, Ptr_Func_CreateStateBlock_59>, IHookItemFactory<D3D9CreateStateBlockHookItem>
    {
        public const string MethodName = Ptr_Func_CreateStateBlock_59.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, D3DSTATEBLOCKTYPE,Maple.UnmanagedExtensions.UnsafeOut<nint>, D3D9CreateStateBlockHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9CreateStateBlockHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9CreateStateBlockHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9CreateStateBlockHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, D3DSTATEBLOCKTYPE,Maple.UnmanagedExtensions.UnsafeOut<nint>, COM_HRESULT>
                _proc = &Hook_CreateStateBlock;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_CreateStateBlock(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, D3DSTATEBLOCKTYPE Type,Maple.UnmanagedExtensions.UnsafeOut<nint> ppSB)
        {
            if (D3D9CreateStateBlockHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Type, ppSB, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Type, ppSB);
            }
            return 0;
        }
    }
}
