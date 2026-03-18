using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9DrawTriPatchHookItem : HookItem<D3D9DrawTriPatchHookItem, Ptr_Func_DrawTriPatch_116, Ptr_Func_DrawTriPatch_116>, IHookItemFactory<D3D9DrawTriPatchHookItem>
    {
        public const string MethodName = Ptr_Func_DrawTriPatch_116.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, Maple.UnmanagedExtensions.UnsafeRef<float>, Maple.UnmanagedExtensions.UnsafeOut<global::Windows.Win32.Graphics.Direct3D9.D3DTRIPATCH_INFO>, D3D9DrawTriPatchHookItem, COM_HRESULT>? SyncCallback { get; set; }

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
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, Maple.UnmanagedExtensions.UnsafeRef<float>, Maple.UnmanagedExtensions.UnsafeOut<global::Windows.Win32.Graphics.Direct3D9.D3DTRIPATCH_INFO>, COM_HRESULT>
                _proc = &Hook_DrawTriPatch;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_DrawTriPatch(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint Handle, Maple.UnmanagedExtensions.UnsafeRef<float> pNumSegs, Maple.UnmanagedExtensions.UnsafeOut<global::Windows.Win32.Graphics.Direct3D9.D3DTRIPATCH_INFO> pTriPatchInfo)
        {
            if (D3D9DrawTriPatchHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Handle, pNumSegs, pTriPatchInfo, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Handle, pNumSegs, pTriPatchInfo);
            }
            return 0;
        }
    }
}
