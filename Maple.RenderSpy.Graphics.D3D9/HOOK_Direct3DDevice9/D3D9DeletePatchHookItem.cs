using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9DeletePatchHookItem : HookItem<D3D9DeletePatchHookItem, Ptr_Func_DeletePatch_117, Ptr_Func_DeletePatch_117>, IGraphicsHookItem<D3D9DeletePatchHookItem>
    {
        public const string MethodName = Ptr_Func_DeletePatch_117.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, D3D9DeletePatchHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9DeletePatchHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9DeletePatchHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9DeletePatchHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, COM_HRESULT>
                _proc = &Hook_DeletePatch;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_DeletePatch(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint Handle)
        {
            if (D3D9DeletePatchHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Handle, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Handle);
            }
            return 0;
        }
    }
}
