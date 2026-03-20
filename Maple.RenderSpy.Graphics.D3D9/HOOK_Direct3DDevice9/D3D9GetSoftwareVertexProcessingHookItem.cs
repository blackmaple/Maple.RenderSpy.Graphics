using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetSoftwareVertexProcessingHookItem : HookItem<D3D9GetSoftwareVertexProcessingHookItem, Ptr_Func_GetSoftwareVertexProcessing_78, Ptr_Func_GetSoftwareVertexProcessing_78>, IHookItemFactory<D3D9GetSoftwareVertexProcessingHookItem>
    {
        public const string MethodName = Ptr_Func_GetSoftwareVertexProcessing_78.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, int>? SyncCallback { get; set; }

        public static D3D9GetSoftwareVertexProcessingHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetSoftwareVertexProcessingHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetSoftwareVertexProcessingHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, int>
                _proc = &Hook_GetSoftwareVertexProcessing;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_GetSoftwareVertexProcessing(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this)
        {
            if (D3D9GetSoftwareVertexProcessingHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this);
                }
                return hookItem.OriginalMethod.Invoke(@this);
            }
            return 0;
        }
    }
}
