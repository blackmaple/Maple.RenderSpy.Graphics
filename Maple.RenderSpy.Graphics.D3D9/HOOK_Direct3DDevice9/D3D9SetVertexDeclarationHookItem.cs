using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9SetVertexDeclarationHookItem : HookItem<D3D9SetVertexDeclarationHookItem, Ptr_Func_SetVertexDeclaration_87, Ptr_Func_SetVertexDeclaration_87>, IHookItemFactory<D3D9SetVertexDeclarationHookItem>
    {
        public const string MethodName = Ptr_Func_SetVertexDeclaration_87.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9SetVertexDeclarationHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9SetVertexDeclarationHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9SetVertexDeclarationHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint, COM_HRESULT>
                _proc = &Hook_SetVertexDeclaration;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_SetVertexDeclaration(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, nint pDecl)
        {
            if (D3D9SetVertexDeclarationHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pDecl);
                }
                return hookItem.OriginalMethod.Invoke(@this, pDecl);
            }
            return 0;
        }
    }
}
