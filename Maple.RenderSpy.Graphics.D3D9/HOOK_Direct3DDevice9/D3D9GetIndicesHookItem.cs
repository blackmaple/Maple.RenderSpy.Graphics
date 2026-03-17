using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetIndicesHookItem : HookItem<D3D9GetIndicesHookItem, Ptr_Func_GetIndices_105, Ptr_Func_GetIndices_105>, IHookItemFactory<D3D9GetIndicesHookItem>
    {
        public const string MethodName = Ptr_Func_GetIndices_105.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetIndicesHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetIndicesHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetIndicesHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, COM_HRESULT>
                _proc = &Hook_GetIndices;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetIndices(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, nint ppIndexData)
        {
            if (D3D9GetIndicesHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, ppIndexData);
                }
                return hookItem.OriginalMethod.Invoke(@this, ppIndexData);
            }
            return 0;
        }
    }
}
