using Maple.Hook.Abstractions;
using Maple.RenderSpy.Graphics.D3D;
using Maple.RenderSpy.Graphics.D3D9.COM_Direct3DDevice9;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Direct3D9;

namespace Maple.RenderSpy.Graphics.D3D9.HOOK_Direct3DDevice9
{
    internal class D3D9DrawIndexedPrimitiveHookItem : HookItem<D3D9DrawIndexedPrimitiveHookItem, Ptr_Func_DrawIndexedPrimitive_82, Ptr_Func_DrawIndexedPrimitive_82>, IHookItemFactory<D3D9DrawIndexedPrimitiveHookItem>
    {
        public const string MethodName = Ptr_Func_DrawIndexedPrimitive_82.Name;

        public Func<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, D3DPRIMITIVETYPE, int, uint, uint, uint, uint, COM_HRESULT>? SyncCallback { get; set; }

        public static D3D9DrawIndexedPrimitiveHookItem Create(IHookFactory hookFactory, IRenderSpyGraphicsFunctionsProvider functionsProvider)
        {
            if (!functionsProvider.TryGetGraphicsFunctions(MethodName, out var functionPtr))
            {
                return RenderSpyGraphicsException.Throw<D3D9DrawIndexedPrimitiveHookItem>($"NOT FOUND {MethodName}");
            }
            var hookItemImp = hookFactory.Create<D3D9DrawIndexedPrimitiveHookItem>(
                functionPtr,
                GetHookMethodPointer());
            return hookItemImp;
        }

        private static unsafe nint GetHookMethodPointer()
        {
            delegate* unmanaged[Stdcall]<COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9>, D3DPRIMITIVETYPE, int, uint, uint, uint, uint, COM_HRESULT>
                _proc = &Hook_DrawIndexedPrimitive;
            return new(_proc);
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
        private static COM_HRESULT Hook_DrawIndexedPrimitive(COM_PTR_IUNKNOWN<COM_INTERFACE_Direct3DDevice9> @this, D3DPRIMITIVETYPE Type, int BaseVertexIndex, uint MinVertexIndex, uint NumVertices, uint startIndex, uint primCount)
        {
            if (D3D9DrawIndexedPrimitiveHookItem.TryGet(out var hookItem))
            {
                if (hookItem.SyncCallback is not null)
                {
                    return hookItem.SyncCallback.Invoke(@this, Type, BaseVertexIndex, MinVertexIndex, NumVertices, startIndex, primCount);
                }
                return hookItem.OriginalMethod.Invoke(@this, Type, BaseVertexIndex, MinVertexIndex, NumVertices, startIndex, primCount);
            }
            return 0;
        }
    }
}
