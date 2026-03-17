using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9UpdateTextureHookItem : HookItem<D3D9UpdateTextureHookItem, Ptr_Func_UpdateTexture_31, Ptr_Func_UpdateTexture_31>, IHookItemFactory<D3D9UpdateTextureHookItem>
    {
        public const string MethodName = Ptr_Func_UpdateTexture_31.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, nint, uint, uint, uint, int>? SyncCallback { get; set; }

        public static D3D9UpdateTextureHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9UpdateTextureHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9UpdateTextureHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, nint, uint, uint, uint, int>
                _proc = &Hook_UpdateTexture;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_UpdateTexture(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, nint pSourceTexture, nint pDestinationTexture, uint SourceLevel, uint SourceBox, uint DestPoint)
        {
            if (D3D9UpdateTextureHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pSourceTexture, pDestinationTexture, SourceLevel, SourceBox, DestPoint);
                }
                return hookItem.OriginalMethod.Invoke(@this, pSourceTexture, pDestinationTexture, SourceLevel, SourceBox, DestPoint);
            }
            return 0;
        }
    }
}
