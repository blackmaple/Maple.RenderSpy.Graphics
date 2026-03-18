using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9DrawIndexedPrimitiveUPHookItem : HookItem<D3D9DrawIndexedPrimitiveUPHookItem, Ptr_Func_DrawIndexedPrimitiveUP_84, Ptr_Func_DrawIndexedPrimitiveUP_84>, IHookItemFactory<D3D9DrawIndexedPrimitiveUPHookItem>
    {
        public const string MethodName = Ptr_Func_DrawIndexedPrimitiveUP_84.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, D3DPRIMITIVETYPE, uint, uint, uint, nint, D3DFORMAT,  nint, uint, D3D9DrawIndexedPrimitiveUPHookItem, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9DrawIndexedPrimitiveUPHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9DrawIndexedPrimitiveUPHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9DrawIndexedPrimitiveUPHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, D3DPRIMITIVETYPE, uint, uint, uint, nint, D3DFORMAT, nint, uint, COM_HRESULT>
                _proc = &Hook_DrawIndexedPrimitiveUP;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_DrawIndexedPrimitiveUP(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, D3DPRIMITIVETYPE PrimitiveType, uint MinVertexIndex, uint NumVertices, uint PrimitiveCount, nint pIndexData, D3DFORMAT IndexDataFormat, nint pVertexStreamZeroData, uint VertexStreamZeroStride)
        {
            if (D3D9DrawIndexedPrimitiveUPHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, PrimitiveType, MinVertexIndex, NumVertices, PrimitiveCount, pIndexData, IndexDataFormat, pVertexStreamZeroData, VertexStreamZeroStride, hookItem);
                }
                return hookItem.OriginalMethod.Invoke(@this, PrimitiveType, MinVertexIndex, NumVertices, PrimitiveCount, pIndexData, IndexDataFormat, pVertexStreamZeroData, VertexStreamZeroStride);
            }
            return 0;
        }
    }
}
