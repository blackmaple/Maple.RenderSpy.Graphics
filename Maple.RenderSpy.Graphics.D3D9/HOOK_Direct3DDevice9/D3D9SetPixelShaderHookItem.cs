using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetPixelShaderHookItem : HookItem<D3D9SetPixelShaderHookItem, Ptr_Func_SetPixelShader_107, Ptr_Func_SetPixelShader_107>, IHookItemFactory<D3D9SetPixelShaderHookItem>
    {
        public const string MethodName = Ptr_Func_SetPixelShader_107.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetPixelShaderHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetPixelShaderHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetPixelShaderHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, COM_HRESULT>
                _proc = &Hook_SetPixelShader;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetPixelShader(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, nint pShader)
        {
            if (D3D9SetPixelShaderHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pShader);
                }
                return hookItem.OriginalMethod.Invoke(@this, pShader);
            }
            return 0;
        }
    }
}
