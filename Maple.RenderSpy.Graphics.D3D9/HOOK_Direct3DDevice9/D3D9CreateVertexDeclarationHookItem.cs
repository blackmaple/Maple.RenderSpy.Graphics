using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9CreateVertexDeclarationHookItem : HookItem<D3D9CreateVertexDeclarationHookItem, Ptr_Func_CreateVertexDeclaration_86, Ptr_Func_CreateVertexDeclaration_86>, IHookItemFactory<D3D9CreateVertexDeclarationHookItem>
    {
        public const string MethodName = Ptr_Func_CreateVertexDeclaration_86.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint,Maple.UnmanagedExtensions.UnsafeRef<nint>, D3D9CreateVertexDeclarationHookItem, int>? SyncCallback { get; set; }

        public static D3D9CreateVertexDeclarationHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9CreateVertexDeclarationHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9CreateVertexDeclarationHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, nint,Maple.UnmanagedExtensions.UnsafeRef<nint>, int>
                _proc = &Hook_CreateVertexDeclaration;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static int Hook_CreateVertexDeclaration(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, nint pVertexElements,Maple.UnmanagedExtensions.UnsafeRef<nint> ppDecl)
        {
            if (D3D9CreateVertexDeclarationHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, pVertexElements, ppDecl, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, pVertexElements, ppDecl);
            }
            return 0;
        }
    }
}
