using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetMaterialHookItem : HookItem<D3D9GetMaterialHookItem, Ptr_Func_GetMaterial_50, Ptr_Func_GetMaterial_50>, IHookItemFactory<D3D9GetMaterialHookItem>
    {
        public const string MethodName = Ptr_Func_GetMaterial_50.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DMATERIAL9>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetMaterialHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetMaterialHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetMaterialHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DMATERIAL9>, COM_HRESULT>
                _proc = &Hook_GetMaterial;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetMaterial(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, Maple.UnmanagedExtensions.UnsafeRef<global::Windows.Win32.Graphics.Direct3D9.D3DMATERIAL9> pMaterial)
        {
            if (D3D9GetMaterialHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pMaterial);
                }
                return hookItem.OriginalMethod.Invoke(@this, pMaterial);
            }
            return 0;
        }
    }
}
