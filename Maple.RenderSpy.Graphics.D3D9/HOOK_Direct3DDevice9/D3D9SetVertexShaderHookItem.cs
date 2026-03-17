using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetVertexShaderHookItem : HookItem<Ptr_Func_SetVertexShader_92, Ptr_Func_SetVertexShader_92>, IHookItemFactory<D3D9SetVertexShaderHookItem>
    {
        public const string MethodName = Ptr_Func_SetVertexShader_92.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, D3D9SetVertexShaderHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetVertexShaderHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetVertexShaderHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetVertexShaderHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, COM_HRESULT>
                _proc = &Hook_SetVertexShader;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetVertexShader(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, nint pShader)
        {
            if (D3D9SetVertexShaderHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pShader, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, pShader);
            }
            return 0;
        }
    }
}
