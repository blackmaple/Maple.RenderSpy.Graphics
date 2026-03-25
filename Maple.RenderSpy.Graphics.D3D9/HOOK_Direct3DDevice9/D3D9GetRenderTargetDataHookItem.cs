using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetRenderTargetDataHookItem : HookItem<D3D9GetRenderTargetDataHookItem, Ptr_Func_GetRenderTargetData_32, Ptr_Func_GetRenderTargetData_32>, IGraphicsHookItem<D3D9GetRenderTargetDataHookItem>
    {
        public const string MethodName = Ptr_Func_GetRenderTargetData_32.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, nint, nint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetRenderTargetDataHookItem Create(IHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9GetRenderTargetDataHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetRenderTargetDataHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, nint, nint, COM_HRESULT>
                _proc = &Hook_GetRenderTargetData;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetRenderTargetData(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, nint pRenderTarget, nint pDestSurface)
        {
            if (D3D9GetRenderTargetDataHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pRenderTarget, pDestSurface);
                }
                return hookItem.OriginalMethod.Invoke(@this, pRenderTarget, pDestSurface);
            }
            return 0;
        }
    }
}
