using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetTextureHookItem : HookItem<Ptr_Func_GetTexture_64, Ptr_Func_GetTexture_64>, IHookItemFactory<D3D9GetTextureHookItem>
    {
        public const string MethodName = Ptr_Func_GetTexture_64.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, nint, D3D9GetTextureHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetTextureHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetTextureHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetTextureHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, uint, nint, COM_HRESULT>
                _proc = &Hook_GetTexture;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetTexture(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, uint Stage, nint ppTexture)
        {
            if (D3D9GetTextureHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Stage, ppTexture, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, Stage, ppTexture);
            }
            return 0;
        }
    }
}
