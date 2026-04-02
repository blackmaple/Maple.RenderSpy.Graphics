using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetTextureHookItem : HookItem<D3D9GetTextureHookItem, Ptr_Func_GetTexture_64, Ptr_Func_GetTexture_64>, IGraphicsHookItem<D3D9GetTextureHookItem>
    {
        public const string MethodName = Ptr_Func_GetTexture_64.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeOut<nint>, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetTextureHookItem Create(ISupperHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9GetTextureHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetTextureHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, Maple.UnmanagedExtensions.UnsafeOut<nint>, COM_HRESULT>
                _proc = &Hook_GetTexture;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetTexture(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint Stage, Maple.UnmanagedExtensions.UnsafeOut<nint> ppTexture)
        {
            if (D3D9GetTextureHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Stage, ppTexture);
                }
                return hookItem.OriginalMethod.Invoke(@this, Stage, ppTexture);
            }
            return 0;
        }
    }
}
