using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetAvailableTextureMemHookItem : HookItem<D3D9GetAvailableTextureMemHookItem, Ptr_Func_GetAvailableTextureMem_4, Ptr_Func_GetAvailableTextureMem_4>, IGraphicsHookItem<D3D9GetAvailableTextureMemHookItem>
    {
        public const string MethodName = Ptr_Func_GetAvailableTextureMem_4.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint>? SyncCallback { get; set; }

        public static D3D9GetAvailableTextureMemHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetAvailableTextureMemHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetAvailableTextureMemHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint>
                _proc = &Hook_GetAvailableTextureMem;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static uint Hook_GetAvailableTextureMem(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this)
        {
            if (D3D9GetAvailableTextureMemHookItem.TryGet(out var hookItem))
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
