using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9DrawTriPatchHookItem : HookItem<Ptr_Func_DrawTriPatch_116, Ptr_Func_DrawTriPatch_116>, IHookItemFactory<D3D9DrawTriPatchHookItem>
    {
        public const string MethodName = Ptr_Func_DrawTriPatch_116.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, nint, nint, uint, nint, D3D9DrawTriPatchHookItem, int>? SyncCallback { get; set; }

        public static D3D9DrawTriPatchHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9DrawTriPatchHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9DrawTriPatchHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, nint, nint, uint, nint, int>
                _proc = &Hook_DrawTriPatch;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_DrawTriPatch(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint Handle, nint pNumSegs, nint pTriPatchInfo, uint Flags, nint pTriangleFanIndices)
        {
            if (D3D9DrawTriPatchHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Handle, pNumSegs, pTriPatchInfo, Flags, pTriangleFanIndices, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Handle, pNumSegs, pTriPatchInfo, Flags, pTriangleFanIndices);
            }
            return 0;
        }
    }
}
