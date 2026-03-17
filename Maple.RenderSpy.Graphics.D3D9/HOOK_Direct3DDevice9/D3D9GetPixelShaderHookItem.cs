using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9GetPixelShaderHookItem : HookItem<D3D9GetPixelShaderHookItem, Ptr_Func_GetPixelShader_108, Ptr_Func_GetPixelShader_108>, IHookItemFactory<D3D9GetPixelShaderHookItem>
    {
        public const string MethodName = Ptr_Func_GetPixelShader_108.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, D3D9GetPixelShaderHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9GetPixelShaderHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9GetPixelShaderHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9GetPixelShaderHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, COM_HRESULT>
                _proc = &Hook_GetPixelShader;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_GetPixelShader(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, nint ppShader)
        {
            if (D3D9GetPixelShaderHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, ppShader, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, ppShader);
            }
            return 0;
        }
    }
}
