using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9DrawRectPatchHookItem : HookItem<D3D9DrawRectPatchHookItem, Ptr_Func_DrawRectPatch_115, Ptr_Func_DrawRectPatch_115>, IHookItemFactory<D3D9DrawRectPatchHookItem>
    {
        public const string MethodName = Ptr_Func_DrawRectPatch_115.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, nint, nint, uint, nint, D3D9DrawRectPatchHookItem, int>? SyncCallback { get; set; }

        public static D3D9DrawRectPatchHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9DrawRectPatchHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9DrawRectPatchHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, nint, nint, uint, nint, int>
                _proc = &Hook_DrawRectPatch;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_DrawRectPatch(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint Handle, nint pNumSegs, nint pRectPatchInfo, uint Flags, nint pTriangleFanIndices)
        {
            if (D3D9DrawRectPatchHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Handle, pNumSegs, pRectPatchInfo, Flags, pTriangleFanIndices, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Handle, pNumSegs, pRectPatchInfo, Flags, pTriangleFanIndices);
            }
            return 0;
        }
    }
}
