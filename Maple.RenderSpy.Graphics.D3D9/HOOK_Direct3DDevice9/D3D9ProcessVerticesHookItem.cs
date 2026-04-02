using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.Windows.COM;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9ProcessVerticesHookItem : HookItem<D3D9ProcessVerticesHookItem, Ptr_Func_ProcessVertices_85, Ptr_Func_ProcessVertices_85>, IGraphicsHookItem<D3D9ProcessVerticesHookItem>
    {
        public const string MethodName = Ptr_Func_ProcessVertices_85.Name;

        public Func<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, uint, nint, nint, uint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9ProcessVerticesHookItem Create(ISupperHookFactory hookFactory, GraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return GraphicsException.Throw<D3D9ProcessVerticesHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9ProcessVerticesHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<IDirect3DDevice9Imp>, uint, uint, uint, nint, nint, uint, COM_HRESULT>
                _proc = &Hook_ProcessVertices;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_ProcessVertices(COM_PTR_IUNKNOWN<IDirect3DDevice9Imp> @this, uint SrcStartIndex, uint DestIndex, uint VertexCount, nint pDestBuffer, nint pVertexDeclaration, uint Flags)
        {
            if (D3D9ProcessVerticesHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, SrcStartIndex, DestIndex, VertexCount, pDestBuffer, pVertexDeclaration, Flags);
                }
                return hookItem.OriginalMethod.Invoke(@this, SrcStartIndex, DestIndex, VertexCount, pDestBuffer, pVertexDeclaration, Flags);
            }
            return 0;
        }
    }
}
