using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetMaterialHookItem : HookItem<D3D9SetMaterialHookItem, Ptr_Func_SetMaterial_49, Ptr_Func_SetMaterial_49>, IHookItemFactory<D3D9SetMaterialHookItem>
    {
        public const string MethodName = Ptr_Func_SetMaterial_49.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, D3DMATERIAL9*, D3D9SetMaterialHookItem, int>? SyncCallback { get; set; }

        public static D3D9SetMaterialHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetMaterialHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetMaterialHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, D3DMATERIAL9*, int>
                _proc = &Hook_SetMaterial;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_SetMaterial(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, D3DMATERIAL9* pMaterial)
        {
            if (D3D9SetMaterialHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pMaterial, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, pMaterial);
            }
            return 0;
        }
    }
}
