using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetIndicesHookItem : HookItem<D3D9SetIndicesHookItem, Ptr_Func_SetIndices_104, Ptr_Func_SetIndices_104>, IGraphicsHookItem<D3D9SetIndicesHookItem>
    {
        public const string MethodName = Ptr_Func_SetIndices_104.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, nint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetIndicesHookItem Create(ISupperHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9SetIndicesHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetIndicesHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, nint, COM_HRESULT>
                _proc = &Hook_SetIndices;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetIndices(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, nint pIndexData)
        {
            if (D3D9SetIndicesHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pIndexData);
                }
                return hookItem.OriginalMethod.Invoke(@this, pIndexData);
            }
            return 0;
        }
    }
}
