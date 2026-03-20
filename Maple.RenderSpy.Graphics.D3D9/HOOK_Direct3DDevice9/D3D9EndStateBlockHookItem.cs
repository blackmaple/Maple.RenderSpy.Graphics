using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9EndStateBlockHookItem : HookItem<D3D9EndStateBlockHookItem, Ptr_Func_EndStateBlock_61, Ptr_Func_EndStateBlock_61>, IHookItemFactory<D3D9EndStateBlockHookItem>
    {
        public const string MethodName = Ptr_Func_EndStateBlock_61.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>,Maple.UnmanagedExtensions.UnsafeOut<nint>, D3D9EndStateBlockHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9EndStateBlockHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9EndStateBlockHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9EndStateBlockHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>,Maple.UnmanagedExtensions.UnsafeOut<nint>, COM_HRESULT>
                _proc = &Hook_EndStateBlock;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_EndStateBlock(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this,Maple.UnmanagedExtensions.UnsafeOut<nint> ppSB)
        {
            if (D3D9EndStateBlockHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, ppSB, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, ppSB);
            }
            return 0;
        }
    }
}
